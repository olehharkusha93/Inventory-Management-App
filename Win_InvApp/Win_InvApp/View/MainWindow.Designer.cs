﻿namespace Win_InvApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDatabase = new System.Windows.Forms.DataGridView();
            this._dbchecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._dbid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbadded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.testBox_scan = new System.Windows.Forms.TextBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveDatabase = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnRemoveNew = new System.Windows.Forms.Button();
            this.btnAddDatabase = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.cbSearchType = new System.Windows.Forms.ComboBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dgvIncomming = new System.Windows.Forms.DataGridView();
            this._queuechecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._queueid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._queueQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._queuename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._queuetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._queueadded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomming)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDatabase, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvIncomming, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1147, 721);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvDatabase
            // 
            this.dgvDatabase.AllowUserToAddRows = false;
            this.dgvDatabase.CausesValidation = false;
            this.dgvDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dbchecked,
            this._dbid,
            this._dbname,
            this._dbtype,
            this._dbadded});
            this.dgvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatabase.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDatabase.Location = new System.Drawing.Point(693, 3);
            this.dgvDatabase.Name = "dgvDatabase";
            this.dgvDatabase.Size = new System.Drawing.Size(451, 889);
            this.dgvDatabase.TabIndex = 2;
            // 
            // _dbchecked
            // 
            this._dbchecked.HeaderText = "Ready";
            this._dbchecked.Name = "_dbchecked";
            this._dbchecked.Width = 50;
            // 
            // _dbid
            // 
            this._dbid.DataPropertyName = "_incId";
            this._dbid.HeaderText = "ID";
            this._dbid.Name = "_dbid";
            this._dbid.Width = 50;
            // 
            // _dbname
            // 
            this._dbname.DataPropertyName = "_incName";
            this._dbname.HeaderText = "Name";
            this._dbname.Name = "_dbname";
            // 
            // _dbtype
            // 
            this._dbtype.DataPropertyName = "_incType";
            this._dbtype.HeaderText = "Type";
            this._dbtype.Name = "_dbtype";
            // 
            // _dbadded
            // 
            this._dbadded.DataPropertyName = "_incAdded";
            this._dbadded.HeaderText = "Date Added";
            this._dbadded.Name = "_dbadded";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(460, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.349206F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.650519F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.09804F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(227, 889);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.testBox_scan);
            this.panel1.Controls.Add(this.scanButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRemoveDatabase);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Controls.Add(this.btnRemoveNew);
            this.panel1.Controls.Add(this.btnAddDatabase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 385);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "testing";
            // 
            // testBox_scan
            // 
            this.testBox_scan.Location = new System.Drawing.Point(53, 352);
            this.testBox_scan.Name = "testBox_scan";
            this.testBox_scan.Size = new System.Drawing.Size(165, 20);
            this.testBox_scan.TabIndex = 7;
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(69, 212);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(81, 24);
            this.scanButton.TabIndex = 6;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scan";
            // 
            // btnRemoveDatabase
            // 
            this.btnRemoveDatabase.Location = new System.Drawing.Point(69, 45);
            this.btnRemoveDatabase.Name = "btnRemoveDatabase";
            this.btnRemoveDatabase.Size = new System.Drawing.Size(81, 23);
            this.btnRemoveDatabase.TabIndex = 3;
            this.btnRemoveDatabase.Text = "Remove ->";
            this.btnRemoveDatabase.UseVisualStyleBackColor = true;
            this.btnRemoveDatabase.Click += new System.EventHandler(this.btnRemoveDatabase_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(69, 74);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(81, 23);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "<- Add";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnRemoveNew
            // 
            this.btnRemoveNew.Location = new System.Drawing.Point(69, 103);
            this.btnRemoveNew.Name = "btnRemoveNew";
            this.btnRemoveNew.Size = new System.Drawing.Size(81, 23);
            this.btnRemoveNew.TabIndex = 1;
            this.btnRemoveNew.Text = "<- Remove";
            this.btnRemoveNew.UseVisualStyleBackColor = true;
            this.btnRemoveNew.Click += new System.EventHandler(this.btnRemoveNew_Click);
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Location = new System.Drawing.Point(69, 16);
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(81, 23);
            this.btnAddDatabase.TabIndex = 0;
            this.btnAddDatabase.Text = "Add ->";
            this.btnAddDatabase.UseVisualStyleBackColor = true;
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(73, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(80, 25);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearSearch);
            this.panel2.Controls.Add(this.cbSearchType);
            this.panel2.Controls.Add(this.tbSearch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 69);
            this.panel2.TabIndex = 3;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(121, 28);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 23);
            this.btnClearSearch.TabIndex = 2;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // cbSearchType
            // 
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(23, 29);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(92, 21);
            this.cbSearchType.TabIndex = 1;
            this.cbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbSearchType_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(0, 3);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(221, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dgvIncomming
            // 
            this.dgvIncomming.AllowUserToAddRows = false;
            this.dgvIncomming.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncomming.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._queuechecked,
            this._queueid,
            this._queueQuantity,
            this._queuename,
            this._queuetype,
            this._queueadded});
            this.dgvIncomming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncomming.GridColor = System.Drawing.SystemColors.Control;
            this.dgvIncomming.Location = new System.Drawing.Point(3, 3);
            this.dgvIncomming.Name = "dgvIncomming";
            this.dgvIncomming.ShowCellErrors = false;
            this.dgvIncomming.ShowCellToolTips = false;
            this.dgvIncomming.ShowEditingIcon = false;
            this.dgvIncomming.ShowRowErrors = false;
            this.dgvIncomming.Size = new System.Drawing.Size(451, 889);
            this.dgvIncomming.TabIndex = 1;
            // 
            // _queuechecked
            // 
            this._queuechecked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._queuechecked.HeaderText = "Ready";
            this._queuechecked.Name = "_queuechecked";
            this._queuechecked.Width = 44;
            // 
            // _queueid
            // 
            this._queueid.DataPropertyName = "_incId";
            this._queueid.HeaderText = "ID";
            this._queueid.Name = "_queueid";
            this._queueid.Width = 50;
            // 
            // _queueQuantity
            // 
            this._queueQuantity.DataPropertyName = "_incQuant";
            this._queueQuantity.HeaderText = "Quantity";
            this._queueQuantity.Name = "_queueQuantity";
            // 
            // _queuename
            // 
            this._queuename.DataPropertyName = "_incName";
            this._queuename.HeaderText = "Name";
            this._queuename.Name = "_queuename";
            // 
            // _queuetype
            // 
            this._queuetype.DataPropertyName = "_incType";
            this._queuetype.HeaderText = "Type";
            this._queuetype.Name = "_queuetype";
            // 
            // _queueadded
            // 
            this._queueadded.DataPropertyName = "_incAdded";
            this._queueadded.HeaderText = "Date Added";
            this._queueadded.Name = "_queueadded";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 745);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomming)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.DataGridView dgvIncomming;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveDatabase;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnRemoveNew;
        private System.Windows.Forms.Button btnAddDatabase;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox testBox_scan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _dbchecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbadded;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _queuechecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queuename;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queuetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueadded;
    }
}
