using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhoWantsToBeAMillionaire
{
    public class OneError : IHelper
    {
        GameForm gameForm;
        public OneError(GameForm form) 
        {
            gameForm = form;
        }
        Button myButton;
        public void ActivateHelp()
        {
        }

        public void Dispose()
        {
            myButton.Enabled = true;
        }

        public Button GetControl()
        {
            Button button = new Button()
            {
                Text = "Право на ошибку",
            };
            button.Click += OneError_Click;
            myButton = button;
            return button;
        }

        private void OneError_Click(object sender, EventArgs e)
        {
            myButton.Enabled = false;
            gameForm.clickFail = new OneClickFail(gameForm);
        }

        private class OneClickFail : GameForm.ClickFail
        {
            bool use;
            public OneClickFail(GameForm form) : base(form)
            {
            }
            public override void Fail(object sender)
            {
                Button but = (Button)sender;
                but.Visible = false;
                if(use)
                    base.Fail(sender);
                use = true;
            }
        }
    }
}
