namespace ItemLookUp.Forms.UserControls
{
    partial class KitViewer
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
            this.kitViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.kitViewTabControl = new System.Windows.Forms.TabControl();
            this.tabComponents = new System.Windows.Forms.TabPage();
            this.dataGridViewComponents = new System.Windows.Forms.DataGridView();
            this.productNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyStdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyContainedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDiff = new System.Windows.Forms.TabPage();
            this.dataGridViewDiff = new System.Windows.Forms.DataGridView();
            this.missingQtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.missingProductNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.missingDescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kitviewDetailsPanel = new System.Windows.Forms.Panel();
            this.kitViewDetailsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.kitViewerDetailsFlowLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.detailsProductNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.detailsLotSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.detailsType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.detailsInventoryType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.detailsContainer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.detailsComponentStd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.detailsComponentsContained = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.detailsDiffFromStandard = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.detailsDescription = new System.Windows.Forms.TextBox();
            this.kitViewLayout.SuspendLayout();
            this.kitViewTabControl.SuspendLayout();
            this.tabComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).BeginInit();
            this.tabDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiff)).BeginInit();
            this.kitviewDetailsPanel.SuspendLayout();
            this.kitViewDetailsLayout.SuspendLayout();
            this.kitViewerDetailsFlowLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // kitViewLayout
            // 
            this.kitViewLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.kitViewLayout.ColumnCount = 1;
            this.kitViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.kitViewLayout.Controls.Add(this.kitViewTabControl, 0, 1);
            this.kitViewLayout.Controls.Add(this.kitviewDetailsPanel, 0, 0);
            this.kitViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitViewLayout.Location = new System.Drawing.Point(0, 0);
            this.kitViewLayout.Name = "kitViewLayout";
            this.kitViewLayout.RowCount = 2;
            this.kitViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
            this.kitViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.83334F));
            this.kitViewLayout.Size = new System.Drawing.Size(651, 599);
            this.kitViewLayout.TabIndex = 0;
            // 
            // kitViewTabControl
            // 
            this.kitViewTabControl.Controls.Add(this.tabComponents);
            this.kitViewTabControl.Controls.Add(this.tabDiff);
            this.kitViewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitViewTabControl.Location = new System.Drawing.Point(4, 178);
            this.kitViewTabControl.Name = "kitViewTabControl";
            this.kitViewTabControl.SelectedIndex = 0;
            this.kitViewTabControl.Size = new System.Drawing.Size(643, 417);
            this.kitViewTabControl.TabIndex = 0;
            // 
            // tabComponents
            // 
            this.tabComponents.Controls.Add(this.dataGridViewComponents);
            this.tabComponents.Location = new System.Drawing.Point(4, 22);
            this.tabComponents.Name = "tabComponents";
            this.tabComponents.Padding = new System.Windows.Forms.Padding(4);
            this.tabComponents.Size = new System.Drawing.Size(635, 391);
            this.tabComponents.TabIndex = 0;
            this.tabComponents.Text = "Components";
            this.tabComponents.UseVisualStyleBackColor = true;
            // 
            // dataGridViewComponents
            // 
            this.dataGridViewComponents.AllowUserToAddRows = false;
            this.dataGridViewComponents.AllowUserToDeleteRows = false;
            this.dataGridViewComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNumberColumn,
            this.descriptionColumn,
            this.parentColumn,
            this.qtyStdColumn,
            this.qtyContainedColumn});
            this.dataGridViewComponents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewComponents.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewComponents.Name = "dataGridViewComponents";
            this.dataGridViewComponents.Size = new System.Drawing.Size(627, 383);
            this.dataGridViewComponents.TabIndex = 0;
            // 
            // productNumberColumn
            // 
            this.productNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNumberColumn.HeaderText = "Product Number";
            this.productNumberColumn.Name = "productNumberColumn";
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "descriptionColumn";
            // 
            // parentColumn
            // 
            this.parentColumn.HeaderText = "Container";
            this.parentColumn.Name = "parentColumn";
            // 
            // qtyStdColumn
            // 
            this.qtyStdColumn.HeaderText = "Qty Standard";
            this.qtyStdColumn.Name = "qtyStdColumn";
            // 
            // qtyContainedColumn
            // 
            this.qtyContainedColumn.HeaderText = "Qty";
            this.qtyContainedColumn.Name = "qtyContainedColumn";
            // 
            // tabDiff
            // 
            this.tabDiff.Controls.Add(this.dataGridViewDiff);
            this.tabDiff.Location = new System.Drawing.Point(4, 22);
            this.tabDiff.Name = "tabDiff";
            this.tabDiff.Padding = new System.Windows.Forms.Padding(4);
            this.tabDiff.Size = new System.Drawing.Size(635, 391);
            this.tabDiff.TabIndex = 1;
            this.tabDiff.Text = "Missing Components";
            this.tabDiff.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDiff
            // 
            this.dataGridViewDiff.AllowUserToAddRows = false;
            this.dataGridViewDiff.AllowUserToDeleteRows = false;
            this.dataGridViewDiff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.missingQtyColumn,
            this.missingProductNumberColumn,
            this.missingDescriptionColumn});
            this.dataGridViewDiff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewDiff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDiff.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewDiff.Name = "dataGridViewDiff";
            this.dataGridViewDiff.Size = new System.Drawing.Size(627, 383);
            this.dataGridViewDiff.TabIndex = 1;
            // 
            // missingQtyColumn
            // 
            this.missingQtyColumn.HeaderText = "Missing";
            this.missingQtyColumn.Name = "missingQtyColumn";
            // 
            // missingProductNumberColumn
            // 
            this.missingProductNumberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.missingProductNumberColumn.HeaderText = "Product Number";
            this.missingProductNumberColumn.Name = "missingProductNumberColumn";
            // 
            // missingDescriptionColumn
            // 
            this.missingDescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.missingDescriptionColumn.HeaderText = "Description";
            this.missingDescriptionColumn.Name = "missingDescriptionColumn";
            // 
            // kitviewDetailsPanel
            // 
            this.kitviewDetailsPanel.Controls.Add(this.kitViewDetailsLayout);
            this.kitviewDetailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitviewDetailsPanel.Location = new System.Drawing.Point(4, 4);
            this.kitviewDetailsPanel.Name = "kitviewDetailsPanel";
            this.kitviewDetailsPanel.Size = new System.Drawing.Size(643, 167);
            this.kitviewDetailsPanel.TabIndex = 1;
            // 
            // kitViewDetailsLayout
            // 
            this.kitViewDetailsLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.kitViewDetailsLayout.ColumnCount = 2;
            this.kitViewDetailsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.86781F));
            this.kitViewDetailsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.132193F));
            this.kitViewDetailsLayout.Controls.Add(this.kitViewerDetailsFlowLeft, 0, 0);
            this.kitViewDetailsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitViewDetailsLayout.Location = new System.Drawing.Point(0, 0);
            this.kitViewDetailsLayout.Name = "kitViewDetailsLayout";
            this.kitViewDetailsLayout.RowCount = 1;
            this.kitViewDetailsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.352518F));
            this.kitViewDetailsLayout.Size = new System.Drawing.Size(643, 167);
            this.kitViewDetailsLayout.TabIndex = 0;
            // 
            // kitViewerDetailsFlowLeft
            // 
            this.kitViewerDetailsFlowLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label1);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsProductNumber);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label2);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsLotSerial);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label9);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsDescription);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label3);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsType);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label4);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsInventoryType);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label5);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsContainer);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label6);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsComponentStd);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label7);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsComponentsContained);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.label8);
            this.kitViewerDetailsFlowLeft.Controls.Add(this.detailsDiffFromStandard);
            this.kitViewerDetailsFlowLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kitViewerDetailsFlowLeft.Location = new System.Drawing.Point(5, 5);
            this.kitViewerDetailsFlowLeft.Name = "kitViewerDetailsFlowLeft";
            this.kitViewerDetailsFlowLeft.Size = new System.Drawing.Size(598, 157);
            this.kitViewerDetailsFlowLeft.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // detailsProductNumber
            // 
            this.detailsProductNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsProductNumber.Location = new System.Drawing.Point(53, 3);
            this.detailsProductNumber.Name = "detailsProductNumber";
            this.detailsProductNumber.ReadOnly = true;
            this.detailsProductNumber.Size = new System.Drawing.Size(230, 20);
            this.detailsProductNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lot / Serial";
            // 
            // detailsLotSerial
            // 
            this.detailsLotSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsLotSerial.Location = new System.Drawing.Point(354, 3);
            this.detailsLotSerial.Name = "detailsLotSerial";
            this.detailsLotSerial.ReadOnly = true;
            this.detailsLotSerial.Size = new System.Drawing.Size(215, 20);
            this.detailsLotSerial.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 26);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // detailsType
            // 
            this.detailsType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsType.Location = new System.Drawing.Point(325, 29);
            this.detailsType.Name = "detailsType";
            this.detailsType.ReadOnly = true;
            this.detailsType.Size = new System.Drawing.Size(244, 20);
            this.detailsType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Inventory Type";
            // 
            // detailsInventoryType
            // 
            this.detailsInventoryType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsInventoryType.Location = new System.Drawing.Point(87, 55);
            this.detailsInventoryType.Name = "detailsInventoryType";
            this.detailsInventoryType.ReadOnly = true;
            this.detailsInventoryType.Size = new System.Drawing.Size(195, 20);
            this.detailsInventoryType.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 52);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Container";
            // 
            // detailsContainer
            // 
            this.detailsContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsContainer.Location = new System.Drawing.Point(346, 55);
            this.detailsContainer.Name = "detailsContainer";
            this.detailsContainer.ReadOnly = true;
            this.detailsContainer.Size = new System.Drawing.Size(223, 20);
            this.detailsContainer.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Component Standard";
            // 
            // detailsComponentStd
            // 
            this.detailsComponentStd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsComponentStd.Location = new System.Drawing.Point(116, 81);
            this.detailsComponentStd.Name = "detailsComponentStd";
            this.detailsComponentStd.ReadOnly = true;
            this.detailsComponentStd.Size = new System.Drawing.Size(166, 20);
            this.detailsComponentStd.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 78);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Components Contained";
            // 
            // detailsComponentsContained
            // 
            this.detailsComponentsContained.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsComponentsContained.Location = new System.Drawing.Point(411, 81);
            this.detailsComponentsContained.Name = "detailsComponentsContained";
            this.detailsComponentsContained.ReadOnly = true;
            this.detailsComponentsContained.Size = new System.Drawing.Size(158, 20);
            this.detailsComponentsContained.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 104);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Diff From Standard";
            // 
            // detailsDiffFromStandard
            // 
            this.detailsDiffFromStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsDiffFromStandard.Location = new System.Drawing.Point(104, 107);
            this.detailsDiffFromStandard.Name = "detailsDiffFromStandard";
            this.detailsDiffFromStandard.ReadOnly = true;
            this.detailsDiffFromStandard.Size = new System.Drawing.Size(178, 20);
            this.detailsDiffFromStandard.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 26);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Description";
            // 
            // detailsDescription
            // 
            this.detailsDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsDescription.Location = new System.Drawing.Point(69, 29);
            this.detailsDescription.Name = "detailsDescription";
            this.detailsDescription.ReadOnly = true;
            this.detailsDescription.Size = new System.Drawing.Size(213, 20);
            this.detailsDescription.TabIndex = 17;
            // 
            // KitViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.kitViewLayout);
            this.MaximumSize = new System.Drawing.Size(653, 601);
            this.MinimumSize = new System.Drawing.Size(653, 601);
            this.Name = "KitViewer";
            this.Size = new System.Drawing.Size(651, 599);
            this.kitViewLayout.ResumeLayout(false);
            this.kitViewTabControl.ResumeLayout(false);
            this.tabComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComponents)).EndInit();
            this.tabDiff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiff)).EndInit();
            this.kitviewDetailsPanel.ResumeLayout(false);
            this.kitViewDetailsLayout.ResumeLayout(false);
            this.kitViewerDetailsFlowLeft.ResumeLayout(false);
            this.kitViewerDetailsFlowLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel kitViewLayout;
        private System.Windows.Forms.TabControl kitViewTabControl;
        private System.Windows.Forms.TabPage tabComponents;
        private System.Windows.Forms.TabPage tabDiff;
        private System.Windows.Forms.Panel kitviewDetailsPanel;
        private System.Windows.Forms.TableLayoutPanel kitViewDetailsLayout;
        private System.Windows.Forms.FlowLayoutPanel kitViewerDetailsFlowLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox detailsProductNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox detailsLotSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox detailsType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox detailsInventoryType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox detailsContainer;
        private System.Windows.Forms.DataGridView dataGridViewComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyStdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyContainedColumn;
        private System.Windows.Forms.DataGridView dataGridViewDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn missingQtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn missingProductNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn missingDescriptionColumn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox detailsComponentStd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox detailsComponentsContained;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox detailsDiffFromStandard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox detailsDescription;
    }
}
