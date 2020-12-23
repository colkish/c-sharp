using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class MainForm : Form
    {

        private int _counter = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var childForm = new ChildForm() ;
            childForm.MdiParent = this; //use this in c# and not me
            _counter++;
            childForm.Text = "New Document " + _counter;
            childForm.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childform = (ChildForm)this.ActiveMdiChild;
                childform.documentTextBox.SelectAll();
            }
        }

        private void closeStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                var dialogue = new SaveFileDialog() ;
                dialogue.Filter = "Rich text files | *.rtf";
                dialogue.AddExtension = true;
                var result = dialogue.ShowDialog();
                if (result == DialogResult.OK)
                {
                    childForm.documentTextBox.SaveFile(dialogue.FileName);
                    childForm.Text = dialogue.FileName;
                }   

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialogue = new OpenFileDialog();
            dialogue.Filter = "Rich text files | *.rtf";
            var result = dialogue.ShowDialog();
            if (result == DialogResult.OK)
            {
                var childForm = new ChildForm() ;
                childForm.documentTextBox.LoadFile(dialogue.FileName);
                childForm.Text = dialogue.FileName;
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void cascadeStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontallyStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);

        }

        private void tileVerticallyStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);

        }
    }
}
