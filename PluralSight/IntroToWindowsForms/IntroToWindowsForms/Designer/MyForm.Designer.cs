
namespace Designer
{
    partial class MyForm
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
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ShowMessageButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.HideSelection = false;
            this.MessageTextBox.Location = new System.Drawing.Point(25, 25);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(200, 23);
            this.MessageTextBox.TabIndex = 0;
            // 
            // ShowMessageButton
            // 
            this.ShowMessageButton.Location = new System.Drawing.Point(25, 75);
            this.ShowMessageButton.Name = "ShowMessageButton";
            this.ShowMessageButton.Size = new System.Drawing.Size(200, 23);
            this.ShowMessageButton.TabIndex = 1;
            this.ShowMessageButton.Text = "Show Message";
            this.ShowMessageButton.UseVisualStyleBackColor = true;
            this.ShowMessageButton.Click += new System.EventHandler(this.ShowMessageButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(25, 125);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(200, 15);
            this.MessageLabel.TabIndex = 2;
            this.MessageLabel.Text = "[label]";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 391);
            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.ShowMessageButton);
            this.Controls.Add(this.MessageTextBox);
            this.Name = "MyForm";
            this.Text = "MyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button ShowMessageButton;
        private System.Windows.Forms.Label MessageLabel;
    }
}

