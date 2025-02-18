using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhoWantsToBeAMillionaire.Helpers;

namespace WhoWantsToBeAMillionaire
{
    public partial class GameForm : Form
    {
        const int TOP_MARGIN = 35;
        const int SPACING = 5;

        public int level = 0;

        public IQuest currentQuest;

        public IReadQestions qestions;

        public Button[] buttons;

        private IHelper[] helpers;

        public ClickFail clickFail;

        public GameForm()
        {
            InitializeComponent();

            buttons  = new Button[] { button1, button2,
            button3, button4 };

            clickFail = new ClickFail(this);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += ClickButton;
            }

            helpers = new IHelper[]
            {
                new FiftyFiftyHelp(this),
                new OneError(this),
                new AudienceHelper(this),
                new FriendsHelp(),
                new ReplaceHelp(this)
            };

            var controls = helpers.Select(h => h.GetControl()).ToArray();

            LayoutButtonInBox(controls);

            helpersBox.Controls.AddRange(controls);

            qestions = new ReadQuestFromSQL();

            qestions.Initialize();

            startGame();
        }

        private void LayoutButtonInBox(Button[] controls)
        {
            int startY = TOP_MARGIN;

            int x = 5;

            int currentY = startY;

            foreach (var control in controls)
            {
                control.Location = new Point(x, currentY);
                control.Size = new Size(helpersBox.Width - 10, 50);
                currentY += control.Height + SPACING;
            }
        }

        private void startGame()
        {
            level = 0;
            NextStep();
            foreach(var t in helpers)
            {
                t.Dispose();
            }
        }

        private void NextStep()
        {
            foreach (Button btn in buttons)
                btn.Visible = true;

            level++;
            currentQuest = qestions.GetQuestion(level);
            ShowQuestion(currentQuest);
            lstLevel.SelectedIndex = lstLevel.Items.Count - level;
        }

        public void ShowQuestion(IQuest q)
        {
            lblQuestion.Text = q.Text;

            for(int i = 0; i < buttons.Length; i++)
            { 
                buttons[i].Text = q.Answers[i]; 
            }
        }

        public void ClickButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuest.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                clickFail.Fail(sender);
            }
            Player.UpdateRecord(Player.name, int.Parse(lstLevel.Items[14 - level].ToString().Replace(" ", "")));
        }

        public class ClickFail
        {
            public GameForm GameForm { get; private set; }

            public ClickFail(GameForm form)
            {
                GameForm = form;
            }

            public virtual void Fail(object sender)
            {
                MessageBox.Show("Неверный ответ! Начнем по новой");
                GameForm.startGame();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form recordForm = new Form
            {
                Text = "Таблица рекордов",
                Size = new Size(500, 500),
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 11, 
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));

            Label nameHeader = new Label
            {
                Text = "Имя игрока",
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            Label scoreHeader = new Label
            {
                Text = "Рекорд",
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            tableLayout.Controls.Add(nameHeader, 0, 0);
            tableLayout.Controls.Add(scoreHeader, 1, 0);

            var leaderboard = Player.GetLeaderboard();
            int row = 1;
            foreach (var (Name, Record) in leaderboard)
            {
                Label nameLabel = new Label
                {
                    Text = Name,
                    Font = new Font("Arial", 10),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10, 0, 0, 0)
                };

                Label recordLabel = new Label
                {
                    Text = Record.ToString("N0"), // Форматируем число с разделителями
                    Font = new Font("Arial", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                if (Name == Player.name)
                {
                    nameLabel.BackColor = Color.LightYellow;
                    recordLabel.BackColor = Color.LightYellow;
                    nameLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                    recordLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                }

                tableLayout.Controls.Add(nameLabel, 0, row);
                tableLayout.Controls.Add(recordLabel, 1, row);
                row++;
            }
            Button closeButton = new Button
            {
                Text = "Закрыть",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom,
                Height = 40,
                Font = new Font("Arial", 10)
            };

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            mainPanel.Controls.Add(tableLayout);
            mainPanel.Controls.Add(closeButton);
            recordForm.Controls.Add(mainPanel);

            recordForm.ShowDialog();
        }
    }
    
}
