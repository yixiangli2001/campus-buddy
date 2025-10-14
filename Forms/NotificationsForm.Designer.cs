namespace campus_buddy.Forms
{
    partial class NotificationsForm
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lstNotifications = new System.Windows.Forms.ListView();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnMarkRead = new System.Windows.Forms.Button();
            this.btnMarkAllRead = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Notifications";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInfo.Location = new System.Drawing.Point(12, 45);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(223, 19);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Total: 0 notifications (0 unread)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filter:";
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(54, 77);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(200, 23);
            this.cmbFilter.TabIndex = 3;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // lstNotifications
            // 
            this.lstNotifications.HideSelection = false;
            this.lstNotifications.Location = new System.Drawing.Point(12, 115);
            this.lstNotifications.Name = "lstNotifications";
            this.lstNotifications.Size = new System.Drawing.Size(660, 370);
            this.lstNotifications.TabIndex = 4;
            this.lstNotifications.UseCompatibleStateImageBehavior = false;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(12, 500);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(110, 35);
            this.btnViewDetails.TabIndex = 5;
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnMarkRead
            // 
            this.btnMarkRead.Location = new System.Drawing.Point(140, 500);
            this.btnMarkRead.Name = "btnMarkRead";
            this.btnMarkRead.Size = new System.Drawing.Size(110, 35);
            this.btnMarkRead.TabIndex = 6;
            this.btnMarkRead.Text = "Mark as Read";
            this.btnMarkRead.UseVisualStyleBackColor = true;
            this.btnMarkRead.Click += new System.EventHandler(this.btnMarkRead_Click);
            // 
            // btnMarkAllRead
            // 
            this.btnMarkAllRead.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMarkAllRead.ForeColor = System.Drawing.Color.White;
            this.btnMarkAllRead.Location = new System.Drawing.Point(268, 500);
            this.btnMarkAllRead.Name = "btnMarkAllRead";
            this.btnMarkAllRead.Size = new System.Drawing.Size(120, 35);
            this.btnMarkAllRead.TabIndex = 7;
            this.btnMarkAllRead.Text = "Mark All Read";
            this.btnMarkAllRead.UseVisualStyleBackColor = false;
            this.btnMarkAllRead.Click += new System.EventHandler(this.btnMarkAllRead_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(472, 500);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(582, 500);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 35);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NotificationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnMarkAllRead);
            this.Controls.Add(this.btnMarkRead);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lstNotifications);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NotificationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.NotificationsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.ListView lstNotifications;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnMarkRead;
        private System.Windows.Forms.Button btnMarkAllRead;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}