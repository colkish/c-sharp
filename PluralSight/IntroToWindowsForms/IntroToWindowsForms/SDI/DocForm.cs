using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDI;

namespace MDI
{
    public partial class docForm : Form
    {

        public docForm()
        {
            InitializeComponent();
        }

        private static int _counter = 0;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateForm();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogue = new OpenFileDialog();
            dialogue.Filter = "Rich text files | *.rtf";
            var result = dialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.documentTextBox.LoadFile(dialogue.FileName);
                this.Text = dialogue.FileName;
            }
        }

        private void closeStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogue = new SaveFileDialog();
            dialogue.Filter = "Rich text files | *.rtf";
            dialogue.AddExtension = true;
            var result = dialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.documentTextBox.SaveFile(dialogue.FileName);
                this.Text = dialogue.FileName;
            }

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
                this.documentTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.documentTextBox.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.documentTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.documentTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.documentTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.documentTextBox.SelectAll();
        }

        public static docForm CreateForm()
        {
            var form = new docForm();
            form.Text = "New Document "+ ++ _counter;
            SdiApplication.Instance.ApplicationContext.MainForm = form;
            form.Show();

            return form;
        }
    }
}
