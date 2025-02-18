using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    internal class ReplaceHelp : IHelper
    {
        GameForm gameForm;
        Button myButton;
        public ReplaceHelp(GameForm form)
        {
            gameForm = form;
        }
        public void ActivateHelp()
        {
            myButton.Enabled = false;
            gameForm.currentQuest = gameForm.qestions.GetQuestion(gameForm.level);
            gameForm.ShowQuestion(gameForm.currentQuest);
        }

        public void Dispose()
        {
            myButton.Enabled = true;
        }

        public Button GetControl()
        {
            Button button = new Button()
            {
                Text = "Замена",
            };
            button.Click += (obj, e) => ActivateHelp();
            myButton = button;
            return button;
        }
    }
}
