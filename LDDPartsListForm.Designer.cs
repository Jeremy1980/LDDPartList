﻿namespace LDDPartsList
{
    partial class LDDPartsListForm
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lxfName = new System.Windows.Forms.TextBox();
            this.openbutton = new System.Windows.Forms.Button();
            this.opendialog = new System.Windows.Forms.OpenFileDialog();
            this.savedialog = new System.Windows.Forms.SaveFileDialog();
            this.outputtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.savename = new System.Windows.Forms.TextBox();
            this.savebutton = new System.Windows.Forms.Button();
            this.gobutton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.progressText = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Model filename";
            // 
            // lxfName
            // 
            this.lxfName.Location = new System.Drawing.Point(110, 27);
            this.lxfName.Name = "lxfName";
            this.lxfName.Size = new System.Drawing.Size(291, 20);
            this.lxfName.TabIndex = 1;
            this.lxfName.TextChanged += new System.EventHandler(this.outputtype_TextChanged);
            // 
            // openbutton
            // 
            this.openbutton.Location = new System.Drawing.Point(407, 25);
            this.openbutton.Name = "openbutton";
            this.openbutton.Size = new System.Drawing.Size(75, 23);
            this.openbutton.TabIndex = 2;
            this.openbutton.Text = "&Open...";
            this.openbutton.UseVisualStyleBackColor = true;
            this.openbutton.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // opendialog
            // 
            this.opendialog.Filter = "LEGO Digital Designer model|*.LXF";
            this.opendialog.Title = "Select a model file...";
            // 
            // savedialog
            // 
            this.savedialog.Title = "Select the output file...";
            // 
            // outputtype
            // 
            this.outputtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputtype.Enabled = false;
            this.outputtype.Items.AddRange(new object[] {
            "Text",
            "XML",
            "Excel",
            "HTML"});
            this.outputtype.Location = new System.Drawing.Point(110, 79);
            this.outputtype.Name = "outputtype";
            this.outputtype.Size = new System.Drawing.Size(160, 21);
            this.outputtype.TabIndex = 3;
            this.outputtype.SelectionChangeCommitted += new System.EventHandler(this.outputtype_SelectedIndexChanged);
            this.outputtype.TextChanged += new System.EventHandler(this.outputtype_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Type of the output";
            // 
            // LType
            // 
            this.LType.AutoSize = true;
            this.LType.Location = new System.Drawing.Point(276, 82);
            this.LType.Name = "LType";
            this.LType.Size = new System.Drawing.Size(80, 13);
            this.LType.TabIndex = 13;
            this.LType.Text = "(none selected)";
            this.LType.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output filename";
            // 
            // savename
            // 
            this.savename.Enabled = false;
            this.savename.Location = new System.Drawing.Point(110, 53);
            this.savename.Name = "savename";
            this.savename.Size = new System.Drawing.Size(291, 20);
            this.savename.TabIndex = 4;
            this.savename.TextChanged += new System.EventHandler(this.outputtype_TextChanged);
            // 
            // savebutton
            // 
            this.savebutton.Enabled = false;
            this.savebutton.Location = new System.Drawing.Point(407, 51);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 5;
            this.savebutton.Text = "&Save...";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // gobutton
            // 
            this.gobutton.Enabled = false;
            this.gobutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gobutton.Location = new System.Drawing.Point(407, 79);
            this.gobutton.Name = "gobutton";
            this.gobutton.Size = new System.Drawing.Size(75, 46);
            this.gobutton.TabIndex = 6;
            this.gobutton.Text = "Go!";
            this.gobutton.UseVisualStyleBackColor = true;
            this.gobutton.Click += new System.EventHandler(this.gobutton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openbutton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.ToolTipText = "Exit from this application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.ToolTipText = "Shows licensing information";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.progressText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 131);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // progressText
            // 
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(433, 17);
            this.progressText.Spring = true;
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = global::LDDPartsList.Properties.Resources.preview;
            this.pictureBox.Image = global::LDDPartsList.Properties.Resources.preview;
            this.pictureBox.InitialImage = global::LDDPartsList.Properties.Resources.preview;
            this.pictureBox.Location = new System.Drawing.Point(488, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 16;
            this.pictureBox.TabStop = false;
            // 
            // LDDPartsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 153);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gobutton);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.savename);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputtype);
            this.Controls.Add(this.openbutton);
            this.Controls.Add(this.lxfName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LDDPartsListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LDD Parts List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LDDPartsListForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lxfName;
        private System.Windows.Forms.Button openbutton;
        private System.Windows.Forms.OpenFileDialog opendialog;
        private System.Windows.Forms.SaveFileDialog savedialog;
        private System.Windows.Forms.ComboBox outputtype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox savename;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.Button gobutton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel progressText;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}

