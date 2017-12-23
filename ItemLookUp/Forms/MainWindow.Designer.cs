namespace ItemLookUp.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabCannibalize = new System.Windows.Forms.TabPage();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lookUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1256, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainTabControl.Controls.Add(this.tabCannibalize);
            this.mainTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1256, 696);
            this.mainTabControl.TabIndex = 1;
            // 
            // tabCannibalize
            // 
            this.tabCannibalize.Location = new System.Drawing.Point(23, 4);
            this.tabCannibalize.Name = "tabCannibalize";
            this.tabCannibalize.Padding = new System.Windows.Forms.Padding(3);
            this.tabCannibalize.Size = new System.Drawing.Size(1229, 688);
            this.tabCannibalize.TabIndex = 1;
            this.tabCannibalize.Text = "Cannibalizer";
            this.tabCannibalize.UseVisualStyleBackColor = true;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lookUpToolStripMenuItem,
            this.mappingToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // lookUpToolStripMenuItem
            // 
            this.lookUpToolStripMenuItem.Name = "lookUpToolStripMenuItem";
            this.lookUpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lookUpToolStripMenuItem.Text = "Look Up";
            this.lookUpToolStripMenuItem.Click += new System.EventHandler(this.lookUpToolStripMenuItem_Click);
            // 
            // mappingToolStripMenuItem
            // 
            this.mappingToolStripMenuItem.Name = "mappingToolStripMenuItem";
            this.mappingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mappingToolStripMenuItem.Text = "Mapping";
            this.mappingToolStripMenuItem.Click += new System.EventHandler(this.mappingToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 720);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.Text = "ItemLookUp";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabCannibalize;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lookUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mappingToolStripMenuItem;
    }
}