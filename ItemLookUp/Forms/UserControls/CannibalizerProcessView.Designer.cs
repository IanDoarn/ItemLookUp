namespace ItemLookUp.Forms.UserControls
{
    partial class CannibalizerProcessView
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processViewTabControl = new System.Windows.Forms.TabControl();
            this.tabPageProcessLog = new System.Windows.Forms.TabPage();
            this.processViewLogTextBox = new System.Windows.Forms.RichTextBox();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.tabPageProcessView = new System.Windows.Forms.TabPage();
            this.processViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.processViewDetailsFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.primaryKitTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iterationsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTransfersTextBox = new System.Windows.Forms.TextBox();
            this.processViewTablePanel = new System.Windows.Forms.Panel();
            this.processViewKitDetailsPanel = new System.Windows.Forms.Panel();
            this.processViewKitDetailsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.processViewValidKitsPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.processViewInvalidKitsPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.processViewTabControl.SuspendLayout();
            this.tabPageProcessLog.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.tabPageProcessView.SuspendLayout();
            this.processViewLayout.SuspendLayout();
            this.processViewDetailsFlowLayout.SuspendLayout();
            this.processViewKitDetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processViewKitDetailsSplitContainer)).BeginInit();
            this.processViewKitDetailsSplitContainer.Panel1.SuspendLayout();
            this.processViewKitDetailsSplitContainer.Panel2.SuspendLayout();
            this.processViewKitDetailsSplitContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(908, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.runToolStripMenuItem.Text = "Next";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // processViewTabControl
            // 
            this.processViewTabControl.Controls.Add(this.tabPageProcessView);
            this.processViewTabControl.Controls.Add(this.tabPageProcessLog);
            this.processViewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewTabControl.Location = new System.Drawing.Point(4, 40);
            this.processViewTabControl.Name = "processViewTabControl";
            this.processViewTabControl.SelectedIndex = 0;
            this.processViewTabControl.Size = new System.Drawing.Size(647, 486);
            this.processViewTabControl.TabIndex = 1;
            // 
            // tabPageProcessLog
            // 
            this.tabPageProcessLog.Controls.Add(this.processViewLogTextBox);
            this.tabPageProcessLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcessLog.Name = "tabPageProcessLog";
            this.tabPageProcessLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProcessLog.Size = new System.Drawing.Size(639, 460);
            this.tabPageProcessLog.TabIndex = 1;
            this.tabPageProcessLog.Text = "Process Log";
            this.tabPageProcessLog.UseVisualStyleBackColor = true;
            // 
            // processViewLogTextBox
            // 
            this.processViewLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewLogTextBox.Location = new System.Drawing.Point(3, 3);
            this.processViewLogTextBox.Name = "processViewLogTextBox";
            this.processViewLogTextBox.Size = new System.Drawing.Size(633, 454);
            this.processViewLogTextBox.TabIndex = 0;
            this.processViewLogTextBox.Text = "";
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.processViewTablePanel);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(3, 3);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(633, 454);
            this.tablePanel.TabIndex = 2;
            // 
            // tabPageProcessView
            // 
            this.tabPageProcessView.Controls.Add(this.tablePanel);
            this.tabPageProcessView.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcessView.Name = "tabPageProcessView";
            this.tabPageProcessView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProcessView.Size = new System.Drawing.Size(639, 460);
            this.tabPageProcessView.TabIndex = 0;
            this.tabPageProcessView.Text = "Process View";
            this.tabPageProcessView.UseVisualStyleBackColor = true;
            // 
            // processViewLayout
            // 
            this.processViewLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.processViewLayout.ColumnCount = 2;
            this.processViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.2467F));
            this.processViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.7533F));
            this.processViewLayout.Controls.Add(this.processViewTabControl, 0, 1);
            this.processViewLayout.Controls.Add(this.processViewDetailsFlowLayout, 0, 0);
            this.processViewLayout.Controls.Add(this.processViewKitDetailsPanel, 1, 1);
            this.processViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewLayout.Location = new System.Drawing.Point(0, 24);
            this.processViewLayout.Name = "processViewLayout";
            this.processViewLayout.RowCount = 2;
            this.processViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.805293F));
            this.processViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.19471F));
            this.processViewLayout.Size = new System.Drawing.Size(908, 530);
            this.processViewLayout.TabIndex = 2;
            // 
            // processViewDetailsFlowLayout
            // 
            this.processViewDetailsFlowLayout.Controls.Add(this.label1);
            this.processViewDetailsFlowLayout.Controls.Add(this.primaryKitTextBox);
            this.processViewDetailsFlowLayout.Controls.Add(this.label2);
            this.processViewDetailsFlowLayout.Controls.Add(this.iterationsTextBox);
            this.processViewDetailsFlowLayout.Controls.Add(this.label3);
            this.processViewDetailsFlowLayout.Controls.Add(this.totalTransfersTextBox);
            this.processViewDetailsFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewDetailsFlowLayout.Location = new System.Drawing.Point(4, 4);
            this.processViewDetailsFlowLayout.Name = "processViewDetailsFlowLayout";
            this.processViewDetailsFlowLayout.Size = new System.Drawing.Size(647, 29);
            this.processViewDetailsFlowLayout.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Kit";
            // 
            // primaryKitTextBox
            // 
            this.primaryKitTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.primaryKitTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.primaryKitTextBox.Location = new System.Drawing.Point(65, 3);
            this.primaryKitTextBox.Name = "primaryKitTextBox";
            this.primaryKitTextBox.ReadOnly = true;
            this.primaryKitTextBox.Size = new System.Drawing.Size(104, 20);
            this.primaryKitTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Iterations";
            // 
            // iterationsTextBox
            // 
            this.iterationsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iterationsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.iterationsTextBox.Location = new System.Drawing.Point(231, 3);
            this.iterationsTextBox.Name = "iterationsTextBox";
            this.iterationsTextBox.ReadOnly = true;
            this.iterationsTextBox.Size = new System.Drawing.Size(34, 20);
            this.iterationsTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total Possible Transfers";
            // 
            // totalTransfersTextBox
            // 
            this.totalTransfersTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.totalTransfersTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.totalTransfersTextBox.Location = new System.Drawing.Point(397, 3);
            this.totalTransfersTextBox.Name = "totalTransfersTextBox";
            this.totalTransfersTextBox.ReadOnly = true;
            this.totalTransfersTextBox.Size = new System.Drawing.Size(30, 20);
            this.totalTransfersTextBox.TabIndex = 5;
            // 
            // processViewTablePanel
            // 
            this.processViewTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewTablePanel.Location = new System.Drawing.Point(0, 0);
            this.processViewTablePanel.Name = "processViewTablePanel";
            this.processViewTablePanel.Size = new System.Drawing.Size(633, 454);
            this.processViewTablePanel.TabIndex = 1;
            // 
            // processViewKitDetailsPanel
            // 
            this.processViewKitDetailsPanel.Controls.Add(this.processViewKitDetailsSplitContainer);
            this.processViewKitDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewKitDetailsPanel.Location = new System.Drawing.Point(658, 40);
            this.processViewKitDetailsPanel.Name = "processViewKitDetailsPanel";
            this.processViewKitDetailsPanel.Size = new System.Drawing.Size(246, 486);
            this.processViewKitDetailsPanel.TabIndex = 2;
            // 
            // processViewKitDetailsSplitContainer
            // 
            this.processViewKitDetailsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewKitDetailsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.processViewKitDetailsSplitContainer.Name = "processViewKitDetailsSplitContainer";
            this.processViewKitDetailsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // processViewKitDetailsSplitContainer.Panel1
            // 
            this.processViewKitDetailsSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // processViewKitDetailsSplitContainer.Panel2
            // 
            this.processViewKitDetailsSplitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.processViewKitDetailsSplitContainer.Size = new System.Drawing.Size(246, 486);
            this.processViewKitDetailsSplitContainer.SplitterDistance = 207;
            this.processViewKitDetailsSplitContainer.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.processViewValidKitsPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.27451F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.72549F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(246, 207);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // processViewValidKitsPanel
            // 
            this.processViewValidKitsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewValidKitsPanel.Location = new System.Drawing.Point(3, 26);
            this.processViewValidKitsPanel.Name = "processViewValidKitsPanel";
            this.processViewValidKitsPanel.Size = new System.Drawing.Size(240, 178);
            this.processViewValidKitsPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Valid Kits";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.processViewInvalidKitsPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.434944F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.56506F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 275);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // processViewInvalidKitsPanel
            // 
            this.processViewInvalidKitsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processViewInvalidKitsPanel.Location = new System.Drawing.Point(3, 23);
            this.processViewInvalidKitsPanel.Name = "processViewInvalidKitsPanel";
            this.processViewInvalidKitsPanel.Size = new System.Drawing.Size(240, 249);
            this.processViewInvalidKitsPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Invalid Kits";
            // 
            // CannibalizerProcessView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.processViewLayout);
            this.Controls.Add(this.menuStrip);
            this.Name = "CannibalizerProcessView";
            this.Size = new System.Drawing.Size(908, 554);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.processViewTabControl.ResumeLayout(false);
            this.tabPageProcessLog.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            this.tabPageProcessView.ResumeLayout(false);
            this.processViewLayout.ResumeLayout(false);
            this.processViewDetailsFlowLayout.ResumeLayout(false);
            this.processViewDetailsFlowLayout.PerformLayout();
            this.processViewKitDetailsPanel.ResumeLayout(false);
            this.processViewKitDetailsSplitContainer.Panel1.ResumeLayout(false);
            this.processViewKitDetailsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processViewKitDetailsSplitContainer)).EndInit();
            this.processViewKitDetailsSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.TabControl processViewTabControl;
        private System.Windows.Forms.TabPage tabPageProcessLog;
        private System.Windows.Forms.RichTextBox processViewLogTextBox;
        private System.Windows.Forms.TabPage tabPageProcessView;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.Panel processViewTablePanel;
        private System.Windows.Forms.TableLayoutPanel processViewLayout;
        private System.Windows.Forms.FlowLayoutPanel processViewDetailsFlowLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox primaryKitTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iterationsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totalTransfersTextBox;
        private System.Windows.Forms.Panel processViewKitDetailsPanel;
        private System.Windows.Forms.SplitContainer processViewKitDetailsSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel processViewValidKitsPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel processViewInvalidKitsPanel;
        private System.Windows.Forms.Label label5;
    }
}
