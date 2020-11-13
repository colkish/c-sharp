using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple 
{
    class MyForm : Form
    {
        //Define fields
        private readonly TextBox MessageTextBox ;
        private readonly Label MessageLabel ;
        private readonly Button ShowMessageButton ;

        //Form constructor
        public MyForm()
        {
            this.Text = "My Form";

            //Instanciate controls and set properties
            MessageTextBox = new TextBox
            {
                Left = 25,
                Top = 25,
                Width = 200
            };
            this.Controls.Add(MessageTextBox);

            ShowMessageButton = new Button
            {
                Left = 25,
                Top = 75,
                Width = 200,
                Text = "Show Message"
            };
            this.Controls.Add(ShowMessageButton);
            //Define event handler for message button click
            ShowMessageButton.Click += ShowMessageButton_Click;

            MessageLabel = new Label
            { 
                Left = 25,
                Top = 125,
                Width = 200,
                Text = "[Label]"
            };
            this.Controls.Add(MessageLabel);
        
        }

        private void ShowMessageButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = MessageTextBox.Text;
            MessageBox.Show("Button clicked");
        }
    }
}
 