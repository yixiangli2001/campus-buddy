namespace campus_buddy.Forms
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupSearch = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbSearchFound = new System.Windows.Forms.RadioButton();
            this.rbSearchLost = new System.Windows.Forms.RadioButton();
            this.lblResults = new System.Windows.Forms.Label();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnFindMatches = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Smart Search && Match";
            // 
            // groupSearch
            // 
            this.groupSearch.Controls.Add(this.btnClear);
            this.groupSearch.Controls.Add(this.btnSearch);
            this.groupSearch.Controls.Add(this.cmbCategory);
            this.groupSearch.Controls.Add(this.label2);
            this.groupSearch.Controls.Add(this.txtSearch);
            this.groupSearch.Controls.Add(this.label1);
            this.groupSearch.Controls.Add(this.rbSearchFound);
            this.groupSearch.Controls.Add(this.rbSearchLost);
            this.groupSearch.Location = new System.Drawing.Point(17, 50);
            this.groupSearch.Name = "groupSearch";
            this.groupSearch.Size = new System.Drawing.Size(850, 140);
            this.groupSearch.TabIndex = 1;
            this.groupSearch.TabStop = false;
            this.groupSearch.Text = "Search Options";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(740, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(630, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(400, 95);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 23);
            this.cmbCategory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Category:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(20, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by keyword:";
            // 
            // rbSearchFound
            // 
            this.rbSearchFound.AutoSize = true;
            this.rbSearchFound.Location = new System.Drawing.Point(180, 35);
            this.rbSearchFound.Name = "rbSearchFound";
            this.rbSearchFound.Size = new System.Drawing.Size(134, 19);
            this.rbSearchFound.TabIndex = 1;
            this.rbSearchFound.Text = "Search Found Items";
            this.rbSearchFound.UseVisualStyleBackColor = true;
            this.rbSearchFound.CheckedChanged += new System.EventHandler(this.rbSearchFound_CheckedChanged);
            // 
            // rbSearchLost
            // 
            this.rbSearchLost.AutoSize = true;
            this.rbSearchLost.Checked = true;
            this.rbSearchLost.Location = new System.Drawing.Point(20, 35);
            this.rbSearchLost.Name = "rbSearchLost";
            this.rbSearchLost.Size = new System.Drawing.Size(121, 19);
            this.rbSearchLost.TabIndex = 0;
            this.rbSearchLost.TabStop = true;
            this.rbSearchLost.Text = "Search Lost Items";
            this.rbSearchLost.UseVisualStyleBackColor = true;
            this.rbSearchLost.CheckedChanged += new System.EventHandler(this.rbSearchLost_CheckedChanged);
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblResults.Location = new System.Drawing.Point(17, 205);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(107, 19);
            this.lblResults.TabIndex = 2;
            this.lblResults.Text = "Search Results:";
            // 
            // dgvResults
            // 
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(17, 235);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 25;
            this.dgvResults.Size = new System.Drawing.Size(850, 350);
            this.dgvResults.TabIndex = 3;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(17, 600);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(120, 35);
            this.btnViewDetails.TabIndex = 4;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnFindMatches
            // 
            this.btnFindMatches.BackColor = System.Drawing.Color.Green;
            this.btnFindMatches.ForeColor = System.Drawing.Color.White;
            this.btnFindMatches.Location = new System.Drawing.Point(150, 600);
            this.btnFindMatches.Name = "btnFindMatches";
            this.btnFindMatches.Size = new System.Drawing.Size(120, 35);
            this.btnFindMatches.TabIndex = 5;
            this.btnFindMatches.Text = "Find Matches";
            this.btnFindMatches.UseVisualStyleBackColor = false;
            this.btnFindMatches.Click += new System.EventHandler(this.btnFindMatches_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(767, 600);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFindMatches);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.groupSearch);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Smart Search & Match";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupSearch.ResumeLayout(false);
            this.groupSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupSearch;
        private System.Windows.Forms.RadioButton rbSearchLost;
        private System.Windows.Forms.RadioButton rbSearchFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnFindMatches;
        private System.Windows.Forms.Button btnClose;
    }
}