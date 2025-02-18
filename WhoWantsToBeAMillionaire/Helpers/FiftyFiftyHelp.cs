using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire.Helpers
{
    public class FiftyFiftyHelp : IHelper
    {
        GameForm gameForm;
        Random rnd = new Random();


        Button myButton;
        public FiftyFiftyHelp(GameForm form)
        {
            gameForm = form;
        }
        public void ActivateHelp()
        {
            int count = 0;
            while (count < 2)
            {
                int n = rnd.Next(4);
                int answer = int.Parse(gameForm.buttons[n].Tag.ToString());

                if (answer != gameForm.currentQuest.RightAnswer && gameForm.buttons[n].Visible)
                {
                    gameForm.buttons[n].Visible = false;
                    count++;
                }
            }
        }

        public void Dispose()
        {
            myButton.Enabled = true;
        }

        public Button GetControl()
        {
            Button button = new Button()
            {
                Text = "50 / 50",
            };
            button.Click += FiftyFifty_Click;
            myButton = button;
            return button;
        }

        private void FiftyFifty_Click(object sender, EventArgs e)
        {
            myButton.Enabled = false;
            ActivateHelp();
        }
    }
}
