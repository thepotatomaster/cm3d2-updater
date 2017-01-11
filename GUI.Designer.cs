using System.Collections.Generic;
namespace CM3D2_Updater {
    public partial class GUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.contentSelector = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.scanButt = new System.Windows.Forms.Button();
            this.verifyButt = new System.Windows.Forms.Button();
            this.consolePlaceholder = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // contentSelector
            // 
            this.contentSelector.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contentSelector.FormattingEnabled = true;
            this.contentSelector.Location = new System.Drawing.Point(432, 25);
            this.contentSelector.Name = "contentSelector";
            this.contentSelector.Size = new System.Drawing.Size(145, 277);
            this.contentSelector.TabIndex = 4;
            this.contentSelector.SelectedIndexChanged += new System.EventHandler(this.contentSelector_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(429, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Installable Content";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Console logs";
            // 
            // installButton
            // 
            this.installButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installButton.Location = new System.Drawing.Point(12, 309);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(141, 23);
            this.installButton.TabIndex = 7;
            this.installButton.Text = "Install Selected";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // scanButt
            // 
            this.scanButt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.scanButt.Location = new System.Drawing.Point(432, 309);
            this.scanButt.Name = "scanButt";
            this.scanButt.Size = new System.Drawing.Size(145, 23);
            this.scanButt.TabIndex = 8;
            this.scanButt.Text = "Scan Directory";
            this.scanButt.UseVisualStyleBackColor = true;
            this.scanButt.Click += new System.EventHandler(this.scanButt_Click);
            // 
            // verifyButt
            // 
            this.verifyButt.Location = new System.Drawing.Point(159, 309);
            this.verifyButt.Name = "verifyButt";
            this.verifyButt.Size = new System.Drawing.Size(141, 23);
            this.verifyButt.TabIndex = 9;
            this.verifyButt.Text = "Verify Contents";
            this.verifyButt.UseVisualStyleBackColor = true;
            this.verifyButt.Click += new System.EventHandler(this.verifyButt_Click);
            // 
            // consolePlaceholder
            // 
            this.consolePlaceholder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.consolePlaceholder.Enabled = false;
            this.consolePlaceholder.Location = new System.Drawing.Point(16, 25);
            this.consolePlaceholder.Name = "consolePlaceholder";
            this.consolePlaceholder.Size = new System.Drawing.Size(410, 277);
            this.consolePlaceholder.TabIndex = 10;
            this.consolePlaceholder.Text = "";
            this.consolePlaceholder.Visible = false;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(589, 344);
            this.Controls.Add(this.consolePlaceholder);
            this.Controls.Add(this.verifyButt);
            this.Controls.Add(this.scanButt);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contentSelector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GUI";
            this.Text = "Custom Maid 3D 2 Content Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox contentSelector;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button installButton;
        public System.Windows.Forms.Button scanButt;
        private System.Windows.Forms.Button verifyButt;
        private System.Windows.Forms.RichTextBox consolePlaceholder;
    }
}

