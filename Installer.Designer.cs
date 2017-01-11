namespace CM3D2_Updater
{
    partial class Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Installer));
            this.cancelButton = new System.Windows.Forms.Button();
            this.installButton = new System.Windows.Forms.Button();
            this.selectedContent = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 159);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(128, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // installButton
            // 
            this.installButton.Enabled = false;
            this.installButton.Location = new System.Drawing.Point(153, 159);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(128, 23);
            this.installButton.TabIndex = 2;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // selectedContent
            // 
            this.selectedContent.FormattingEnabled = true;
            this.selectedContent.Location = new System.Drawing.Point(13, 13);
            this.selectedContent.Name = "selectedContent";
            this.selectedContent.Size = new System.Drawing.Size(268, 132);
            this.selectedContent.TabIndex = 3;
            this.selectedContent.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.selectedContent_ItemCheck);
            // 
            // Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 194);
            this.Controls.Add(this.selectedContent);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Installer";
            this.ShowInTaskbar = false;
            this.Text = "Installer";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.CheckedListBox selectedContent;
        private bool scanning = false;
    }
}