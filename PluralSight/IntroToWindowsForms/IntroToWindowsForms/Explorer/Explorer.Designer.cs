
namespace Explorer
{
    partial class Explorer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.listView1 = new System.Windows.Forms.ListView();
            this.LargeImageList = new System.Windows.Forms.ImageList(this.components);
            this.SmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.ToolStripLabel = new System.Windows.Forms.Label();
            this.ViewToolsStripComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1099, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(1099, 575);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(365, 575);
            this.treeView1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.LargeImageList;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(730, 575);
            this.listView1.SmallImageList = this.SmallImageList;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // LargeImageList
            // 
            this.LargeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.LargeImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.LargeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SmallImageList
            // 
            this.SmallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.SmallImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.SmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ToolStripLabel
            // 
            this.ToolStripLabel.AutoSize = true;
            this.ToolStripLabel.Location = new System.Drawing.Point(13, 4);
            this.ToolStripLabel.Name = "ToolStripLabel";
            this.ToolStripLabel.Size = new System.Drawing.Size(32, 15);
            this.ToolStripLabel.TabIndex = 2;
            this.ToolStripLabel.Text = "View";
            // 
            // ViewToolsStripComboBox
            // 
            this.ViewToolsStripComboBox.FormattingEnabled = true;
            this.ViewToolsStripComboBox.Items.AddRange(new object[] {
            "Large Icons",
            "Small Icons",
            "Details"});
            this.ViewToolsStripComboBox.Location = new System.Drawing.Point(52, 4);
            this.ViewToolsStripComboBox.Name = "ViewToolsStripComboBox";
            this.ViewToolsStripComboBox.Size = new System.Drawing.Size(121, 23);
            this.ViewToolsStripComboBox.TabIndex = 3;
            this.ViewToolsStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ViewToolStripComboBox_SelectedIndexChanged);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 600);
            this.Controls.Add(this.ViewToolsStripComboBox);
            this.Controls.Add(this.ToolStripLabel);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Explorer";
            this.Text = "Explorer Style Application";
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList LargeImageList;
        private System.Windows.Forms.ImageList SmallImageList;
        private System.Windows.Forms.Label ToolStripLabel;
        private System.Windows.Forms.ComboBox ViewToolsStripComboBox;
    }
}

