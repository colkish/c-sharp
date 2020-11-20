using CustomDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lifecycle
{
    public partial class Lifecycle : Form
    {
        public Lifecycle()
        {
            InitializeComponent();
        }

        private void Lifecycle_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Oranges");
            listBox1.Items.Add("Grapes");
            listBox1.Items.Add("Bananas");
            listBox1.Items.Add("Peaches");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                var msg = "Please slelect an item from the list box";
                MessageBox.Show(msg,this.Text);
            }
            label1.Text = listBox1.Text;
        }

        private void Lifecycle_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var msg = "Are you sure you want to close?";
            var dialog = new ConfirmDialogs();
            //if (MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
            if (dialog.ShowDialog() == DialogResult.No)
            { 
                e.Cancel = true;
            }
        }
    }
}
