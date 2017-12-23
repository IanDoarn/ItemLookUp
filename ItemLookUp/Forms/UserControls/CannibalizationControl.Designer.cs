namespace ItemLookUp.Forms.UserControls
{
    partial class CannibalizationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CannibalizationControl));
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.kitQueueLayout = new System.Windows.Forms.TableLayoutPanel();
            this.kitQueueTable = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TextColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewButtonColumn();
            this.kitQueueHeaderFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.kitQueueDetailsCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kitQueueDetailsKitNumber = new System.Windows.Forms.TextBox();
            this.canniblizerMainPanel = new System.Windows.Forms.Panel();
            this.kitQueuePanel = new System.Windows.Forms.Panel();
            this.cannibalizerToolStrip = new System.Windows.Forms.ToolStrip();
            this.cannibalizeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cannibalizeKitNimber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cannibalizeSearchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cannibalizeResetButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cannibalizeRemoveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cannibalizeSearchByBarcode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.kitQueueLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kitQueueTable)).BeginInit();
            this.kitQueueHeaderFlow.SuspendLayout();
            this.cannibalizerToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer);
            this.mainPanel.Controls.Add(this.cannibalizerToolStrip);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(834, 521);
            this.mainPanel.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.kitQueueLayout);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.canniblizerMainPanel);
            this.splitContainer.Panel2.Controls.Add(this.kitQueuePanel);
            this.splitContainer.Size = new System.Drawing.Size(834, 496);
            this.splitContainer.SplitterDistance = 275;
            this.splitContainer.TabIndex = 2;
            // 
            // kitQueueLayout
            // 
            this.kitQueueLayout.ColumnCount = 1;
            this.kitQueueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kitQueueLayout.Controls.Add(this.kitQueueTable, 0, 1);
            this.kitQueueLayout.Controls.Add(this.kitQueueHeaderFlow, 0, 0);
            this.kitQueueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitQueueLayout.Location = new System.Drawing.Point(0, 0);
            this.kitQueueLayout.Name = "kitQueueLayout";
            this.kitQueueLayout.RowCount = 2;
            this.kitQueueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.kitQueueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kitQueueLayout.Size = new System.Drawing.Size(273, 494);
            this.kitQueueLayout.TabIndex = 0;
            // 
            // kitQueueTable
            // 
            this.kitQueueTable.AllowUserToAddRows = false;
            this.kitQueueTable.AllowUserToDeleteRows = false;
            this.kitQueueTable.AllowUserToResizeColumns = false;
            this.kitQueueTable.AllowUserToResizeRows = false;
            this.kitQueueTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kitQueueTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.TextColumn,
            this.Serial,
            this.Details});
            this.kitQueueTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitQueueTable.Location = new System.Drawing.Point(3, 29);
            this.kitQueueTable.Name = "kitQueueTable";
            this.kitQueueTable.Size = new System.Drawing.Size(267, 462);
            this.kitQueueTable.TabIndex = 1;
            // 
            // CheckBox
            // 
            this.CheckBox.FillWeight = 50F;
            this.CheckBox.HeaderText = "Ignore";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CheckBox.Width = 50;
            // 
            // TextColumn
            // 
            this.TextColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TextColumn.HeaderText = "KitNumber";
            this.TextColumn.Name = "TextColumn";
            this.TextColumn.ReadOnly = true;
            // 
            // Serial
            // 
            this.Serial.FillWeight = 50F;
            this.Serial.HeaderText = "Serial";
            this.Serial.MinimumWidth = 50;
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Width = 50;
            // 
            // Details
            // 
            this.Details.FillWeight = 50F;
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 50;
            this.Details.Name = "Details";
            this.Details.Width = 50;
            // 
            // kitQueueHeaderFlow
            // 
            this.kitQueueHeaderFlow.Controls.Add(this.label1);
            this.kitQueueHeaderFlow.Controls.Add(this.kitQueueDetailsCount);
            this.kitQueueHeaderFlow.Controls.Add(this.label2);
            this.kitQueueHeaderFlow.Controls.Add(this.kitQueueDetailsKitNumber);
            this.kitQueueHeaderFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitQueueHeaderFlow.Location = new System.Drawing.Point(3, 3);
            this.kitQueueHeaderFlow.Name = "kitQueueHeaderFlow";
            this.kitQueueHeaderFlow.Size = new System.Drawing.Size(267, 20);
            this.kitQueueHeaderFlow.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kits Loaded";
            // 
            // kitQueueDetailsCount
            // 
            this.kitQueueDetailsCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kitQueueDetailsCount.Location = new System.Drawing.Point(72, 3);
            this.kitQueueDetailsCount.Name = "kitQueueDetailsCount";
            this.kitQueueDetailsCount.ReadOnly = true;
            this.kitQueueDetailsCount.Size = new System.Drawing.Size(44, 13);
            this.kitQueueDetailsCount.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kit #";
            // 
            // kitQueueDetailsKitNumber
            // 
            this.kitQueueDetailsKitNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kitQueueDetailsKitNumber.Location = new System.Drawing.Point(157, 3);
            this.kitQueueDetailsKitNumber.Name = "kitQueueDetailsKitNumber";
            this.kitQueueDetailsKitNumber.ReadOnly = true;
            this.kitQueueDetailsKitNumber.Size = new System.Drawing.Size(99, 13);
            this.kitQueueDetailsKitNumber.TabIndex = 1;
            // 
            // canniblizerMainPanel
            // 
            this.canniblizerMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canniblizerMainPanel.Location = new System.Drawing.Point(0, 0);
            this.canniblizerMainPanel.Name = "canniblizerMainPanel";
            this.canniblizerMainPanel.Size = new System.Drawing.Size(553, 494);
            this.canniblizerMainPanel.TabIndex = 2;
            // 
            // kitQueuePanel
            // 
            this.kitQueuePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitQueuePanel.Location = new System.Drawing.Point(0, 0);
            this.kitQueuePanel.Name = "kitQueuePanel";
            this.kitQueuePanel.Size = new System.Drawing.Size(553, 494);
            this.kitQueuePanel.TabIndex = 1;
            // 
            // cannibalizerToolStrip
            // 
            this.cannibalizerToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cannibalizeButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cannibalizeKitNimber,
            this.toolStripSeparator2,
            this.cannibalizeSearchButton,
            this.toolStripSeparator3,
            this.cannibalizeResetButton,
            this.toolStripSeparator4,
            this.cannibalizeRemoveButton,
            this.toolStripSeparator5,
            this.cannibalizeSearchByBarcode,
            this.toolStripSeparator6});
            this.cannibalizerToolStrip.Location = new System.Drawing.Point(0, 0);
            this.cannibalizerToolStrip.Name = "cannibalizerToolStrip";
            this.cannibalizerToolStrip.Size = new System.Drawing.Size(834, 25);
            this.cannibalizerToolStrip.TabIndex = 1;
            this.cannibalizerToolStrip.Text = "toolStrip1";
            // 
            // cannibalizeButton
            // 
            this.cannibalizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cannibalizeButton.Image = ((System.Drawing.Image)(resources.GetObject("cannibalizeButton.Image")));
            this.cannibalizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cannibalizeButton.Name = "cannibalizeButton";
            this.cannibalizeButton.Size = new System.Drawing.Size(72, 22);
            this.cannibalizeButton.Text = "Cannibalize";
            this.cannibalizeButton.Click += new System.EventHandler(this.cannibalizeButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel1.Text = "Kit Number";
            // 
            // cannibalizeKitNimber
            // 
            this.cannibalizeKitNimber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cannibalizeKitNimber.Name = "cannibalizeKitNimber";
            this.cannibalizeKitNimber.Size = new System.Drawing.Size(100, 25);
            this.cannibalizeKitNimber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cannibalizeKitNimber_KeyPress);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cannibalizeSearchButton
            // 
            this.cannibalizeSearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cannibalizeSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("cannibalizeSearchButton.Image")));
            this.cannibalizeSearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cannibalizeSearchButton.Name = "cannibalizeSearchButton";
            this.cannibalizeSearchButton.Size = new System.Drawing.Size(46, 22);
            this.cannibalizeSearchButton.Text = "Search";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cannibalizeResetButton
            // 
            this.cannibalizeResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cannibalizeResetButton.Image = ((System.Drawing.Image)(resources.GetObject("cannibalizeResetButton.Image")));
            this.cannibalizeResetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cannibalizeResetButton.Name = "cannibalizeResetButton";
            this.cannibalizeResetButton.Size = new System.Drawing.Size(38, 22);
            this.cannibalizeResetButton.Text = "Clear";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // cannibalizeRemoveButton
            // 
            this.cannibalizeRemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cannibalizeRemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("cannibalizeRemoveButton.Image")));
            this.cannibalizeRemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cannibalizeRemoveButton.Name = "cannibalizeRemoveButton";
            this.cannibalizeRemoveButton.Size = new System.Drawing.Size(103, 22);
            this.cannibalizeRemoveButton.Text = "Remove Checked";
            this.cannibalizeRemoveButton.Click += new System.EventHandler(this.cannibalizeRemoveButton_Click_1);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // cannibalizeSearchByBarcode
            // 
            this.cannibalizeSearchByBarcode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cannibalizeSearchByBarcode.Image = ((System.Drawing.Image)(resources.GetObject("cannibalizeSearchByBarcode.Image")));
            this.cannibalizeSearchByBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cannibalizeSearchByBarcode.Name = "cannibalizeSearchByBarcode";
            this.cannibalizeSearchByBarcode.Size = new System.Drawing.Size(92, 22);
            this.cannibalizeSearchByBarcode.Text = "Search Barcode";
            this.cannibalizeSearchByBarcode.Click += new System.EventHandler(this.cannibalizeSearchByBarcode_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // CannibalizationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "CannibalizationControl";
            this.Size = new System.Drawing.Size(834, 521);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.kitQueueLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kitQueueTable)).EndInit();
            this.kitQueueHeaderFlow.ResumeLayout(false);
            this.kitQueueHeaderFlow.PerformLayout();
            this.cannibalizerToolStrip.ResumeLayout(false);
            this.cannibalizerToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStrip cannibalizerToolStrip;
        private System.Windows.Forms.ToolStripButton cannibalizeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox cannibalizeKitNimber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton cannibalizeSearchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton cannibalizeResetButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton cannibalizeRemoveButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel canniblizerMainPanel;
        private System.Windows.Forms.Panel kitQueuePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton cannibalizeSearchByBarcode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TableLayoutPanel kitQueueLayout;
        private System.Windows.Forms.DataGridView kitQueueTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewButtonColumn Details;
        private System.Windows.Forms.FlowLayoutPanel kitQueueHeaderFlow;
        private System.Windows.Forms.TextBox kitQueueDetailsCount;
        private System.Windows.Forms.TextBox kitQueueDetailsKitNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
