using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WhoWantsToBeAMillionaire
{
    internal class FriendsHelp : IHelper
    {
        private DateTime endTime;
        private Button myButton;
        private Timer myTimer;

        public void ActivateHelp()
        {
            myButton.Enabled = false;

            using (myTimer = new Timer { Interval = 16 }) // 60 FPS обновление
            {
                using (Form form = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterParent,
                    Width = 120,
                    Height = 50,
                    TopMost = true 
                })
                {
                    Label label = new Label
                    {
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                        Font = new Font("Arial", 14, FontStyle.Bold)
                    };

                    form.Controls.Add(label);

                    endTime = DateTime.Now.AddSeconds(30);

                    myTimer.Tick += (obj, e) =>
                    {
                        TimeSpan remaining = endTime - DateTime.Now;
                        if (remaining.TotalSeconds <= 0)
                        {
                            myTimer.Stop();
                            form.DialogResult = DialogResult.OK;
                            form.Close();
                        }
                        else
                        {
                            label.Text = $"Звонок другу {remaining.ToString("mm\\:ss")}";
                        }
                    };

                    myTimer.Start();
                    form.ShowDialog();
                }
            }
        }

        public void Dispose()
        {
            myButton.Enabled = true;
            myTimer?.Dispose();
        }

        public Button GetControl()
        {
            Button button = new Button()
            {
                Text = "Звонок",
            };
            button.Click += (obj, e) => ActivateHelp();
            myButton = button;
            return button;
        }
    }
}
