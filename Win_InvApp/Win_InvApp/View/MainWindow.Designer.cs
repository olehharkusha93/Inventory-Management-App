namespace Win_InvApp
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
            this.dgvDatabase = new System.Windows.Forms.DataGridView();
            this._dbchecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dbs_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dbadded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveDatabase = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnRemoveNew = new System.Windows.Forms.Button();
            this.btnAddDatabase = new System.Windows.Forms.Button();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCommands = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSearchButtons = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainerLower = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomming)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpCommands.SuspendLayout();
            this.tlpSearchButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLower)).BeginInit();
            this.splitContainerLower.Panel1.SuspendLayout();
            this.splitContainerLower.Panel2.SuspendLayout();
            this.splitContainerLower.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            // dgvDatabase
            // 
            this.dgvDatabase.AllowUserToAddRows = false;
            this.dgvDatabase.CausesValidation = false;
            this.dgvDatabase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._dbchecked,
            this.dbs_Quantity,
            this._dbid,
            this._dbname,
            this._dbtype,
            this._dbadded});
            this.dgvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatabase.GridColor = System.Drawing.SystemColors.Control;
            this.dgvDatabase.Location = new System.Drawing.Point(3, 3);
            this.dgvDatabase.Name = "dgvDatabase";
            this.dgvDatabase.Size = new System.Drawing.Size(1141, 342);
            this.dgvDatabase.TabIndex = 2;
            // 
            // _dbchecked
            // 
            this._dbchecked.HeaderText = "Ready";
            this._dbchecked.Name = "_dbchecked";
            this._dbchecked.Width = 50;
            // 
            // dbs_Quantity
            // 
            this.dbs_Quantity.DataPropertyName = "_incQuant";
            this.dbs_Quantity.HeaderText = "Quantity";
            this.dbs_Quantity.Name = "dbs_Quantity";
            // 
            // _dbid
            // 
            this._dbid.DataPropertyName = "_incId";
            this._dbid.HeaderText = "ID";
            this._dbid.Name = "_dbid";
            this._dbid.Width = 45;
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
            this._dbtype.Width = 90;
            // 
            // _dbadded
            // 
            this._dbadded.DataPropertyName = "_incAdded";
            this._dbadded.HeaderText = "Date Added";
            this._dbadded.Name = "_dbadded";
            // 
            // btnRemoveDatabase
            // 
            this.btnRemoveDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveDatabase.Location = new System.Drawing.Point(54, 164);
            this.btnRemoveDatabase.Name = "btnRemoveDatabase";
            this.btnRemoveDatabase.Size = new System.Drawing.Size(117, 23);
            this.btnRemoveDatabase.TabIndex = 3;
            this.btnRemoveDatabase.Text = "Remove from Database";
            this.btnRemoveDatabase.UseVisualStyleBackColor = true;
            this.btnRemoveDatabase.Click += new System.EventHandler(this.btnRemoveDatabase_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddNew.Location = new System.Drawing.Point(54, 68);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(117, 23);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add to Queue";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnRemoveNew
            // 
            this.btnRemoveNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveNew.Location = new System.Drawing.Point(54, 100);
            this.btnRemoveNew.Name = "btnRemoveNew";
            this.btnRemoveNew.Size = new System.Drawing.Size(117, 23);
            this.btnRemoveNew.TabIndex = 1;
            this.btnRemoveNew.Text = "Remove from Queue";
            this.btnRemoveNew.UseVisualStyleBackColor = true;
            this.btnRemoveNew.Click += new System.EventHandler(this.btnRemoveNew_Click);
            // 
            // btnAddDatabase
            // 
            this.btnAddDatabase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddDatabase.Location = new System.Drawing.Point(54, 132);
            this.btnAddDatabase.Name = "btnAddDatabase";
            this.btnAddDatabase.Size = new System.Drawing.Size(117, 23);
            this.btnAddDatabase.TabIndex = 0;
            this.btnAddDatabase.Text = "Add to Database";
            this.btnAddDatabase.UseVisualStyleBackColor = true;
            this.btnAddDatabase.Click += new System.EventHandler(this.btnAddDatabase_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearSearch.Location = new System.Drawing.Point(112, 3);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 20);
            this.btnClearSearch.TabIndex = 2;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // cbSearchType
            // 
            this.cbSearchType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbSearchType.FormattingEnabled = true;
            this.cbSearchType.Location = new System.Drawing.Point(18, 3);
            this.cbSearchType.Name = "cbSearchType";
            this.cbSearchType.Size = new System.Drawing.Size(88, 21);
            this.cbSearchType.TabIndex = 1;
            this.cbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbSearchType_SelectedIndexChanged);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.Location = new System.Drawing.Point(18, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(189, 20);
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
            this.dgvIncomming.GridColor = System.Drawing.SystemColors.Control;
            this.dgvIncomming.Location = new System.Drawing.Point(3, 31);
            this.dgvIncomming.Name = "dgvIncomming";
            this.dgvIncomming.ShowCellErrors = false;
            this.dgvIncomming.ShowCellToolTips = false;
            this.dgvIncomming.ShowEditingIcon = false;
            this.dgvIncomming.ShowRowErrors = false;
            this.dgvIncomming.Size = new System.Drawing.Size(906, 308);
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
            this._queueid.Width = 45;
            // 
            // _queueQuantity
            // 
            this._queueQuantity.DataPropertyName = "_incQuant";
            this._queueQuantity.HeaderText = "Quantity";
            this._queueQuantity.Name = "_queueQuantity";
            this._queueQuantity.Width = 60;
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
            this._queuetype.Width = 90;
            // 
            // _queueadded
            // 
            this._queueadded.DataPropertyName = "_incAdded";
            this._queueadded.HeaderText = "Date Added";
            this._queueadded.Name = "_queueadded";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1147, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.dgvDatabase, 0, 0);
            this.tlpMain.Controls.Add(this.splitContainerLower, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 49);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1147, 696);
            this.tlpMain.TabIndex = 3;
            // 
            // tlpCommands
            // 
            this.tlpCommands.ColumnCount = 1;
            this.tlpCommands.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommands.Controls.Add(this.tbSearch, 0, 0);
            this.tlpCommands.Controls.Add(this.btnAddNew, 0, 2);
            this.tlpCommands.Controls.Add(this.btnRemoveNew, 0, 3);
            this.tlpCommands.Controls.Add(this.btnAddDatabase, 0, 4);
            this.tlpCommands.Controls.Add(this.btnRemoveDatabase, 0, 5);
            this.tlpCommands.Controls.Add(this.tlpSearchButtons, 0, 1);
            this.tlpCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommands.Location = new System.Drawing.Point(0, 0);
            this.tlpCommands.Name = "tlpCommands";
            this.tlpCommands.RowCount = 7;
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpCommands.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommands.Size = new System.Drawing.Size(225, 342);
            this.tlpCommands.TabIndex = 2;
            // 
            // tlpSearchButtons
            // 
            this.tlpSearchButtons.ColumnCount = 2;
            this.tlpSearchButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchButtons.Controls.Add(this.btnClearSearch, 1, 0);
            this.tlpSearchButtons.Controls.Add(this.cbSearchType, 0, 0);
            this.tlpSearchButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchButtons.Location = new System.Drawing.Point(3, 35);
            this.tlpSearchButtons.Name = "tlpSearchButtons";
            this.tlpSearchButtons.RowCount = 1;
            this.tlpSearchButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchButtons.Size = new System.Drawing.Size(219, 26);
            this.tlpSearchButtons.TabIndex = 4;
            // 
            // splitContainerLower
            // 
            this.splitContainerLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLower.Location = new System.Drawing.Point(3, 351);
            this.splitContainerLower.Name = "splitContainerLower";
            // 
            // splitContainerLower.Panel1
            // 
            this.splitContainerLower.Panel1.Controls.Add(this.tlpCommands);
            this.splitContainerLower.Panel1MinSize = 225;
            // 
            // splitContainerLower.Panel2
            // 
            this.splitContainerLower.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerLower.Size = new System.Drawing.Size(1141, 342);
            this.splitContainerLower.SplitterDistance = 225;
            this.splitContainerLower.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(422, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Queue";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvIncomming, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.187135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.81287F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(912, 342);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 745);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Inventory Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncomming)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpCommands.ResumeLayout(false);
            this.tlpCommands.PerformLayout();
            this.tlpSearchButtons.ResumeLayout(false);
            this.splitContainerLower.Panel1.ResumeLayout(false);
            this.splitContainerLower.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLower)).EndInit();
            this.splitContainerLower.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dgvIncomming;
        private System.Windows.Forms.DataGridView dgvDatabase;
        private System.Windows.Forms.Button btnRemoveDatabase;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnRemoveNew;
        private System.Windows.Forms.Button btnAddDatabase;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.ComboBox cbSearchType;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _queuechecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queuename;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queuetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn _queueadded;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _dbchecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbs_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbid;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbname;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn _dbadded;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpCommands;
        private System.Windows.Forms.TableLayoutPanel tlpSearchButtons;
        private System.Windows.Forms.SplitContainer splitContainerLower;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}

