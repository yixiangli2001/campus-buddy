namespace campus_buddy.Forms
{
    partial class MainForm
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
            panelTop = new Panel();
            btnMyAccount = new Button();
            btnRefresh = new Button();
            btnNotifications = new Button();
            btnMyPosts = new Button();
            btnSearch = new Button();
            btnAddItem = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvLostItems = new DataGridView();
            tabPage2 = new TabPage();
            dgvFoundItems = new DataGridView();
            btnLogout = new Button();
            panelTop.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLostItems).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoundItems).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.LightGray;
            panelTop.Controls.Add(btnLogout);
            panelTop.Controls.Add(btnMyAccount);
            panelTop.Controls.Add(btnRefresh);
            panelTop.Controls.Add(btnNotifications);
            panelTop.Controls.Add(btnMyPosts);
            panelTop.Controls.Add(btnSearch);
            panelTop.Controls.Add(btnAddItem);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 60);
            panelTop.TabIndex = 0;
            // 
            // btnMyAccount
            // 
            btnMyAccount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMyAccount.Location = new Point(560, 12);
            btnMyAccount.Name = "btnMyAccount";
            btnMyAccount.Size = new Size(120, 35);
            btnMyAccount.TabIndex = 5;
            btnMyAccount.Text = "My Account";
            btnMyAccount.UseVisualStyleBackColor = true;
            btnMyAccount.Click += btnMyAccount_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.Location = new Point(876, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnNotifications
            // 
            btnNotifications.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnNotifications.Location = new Point(698, 12);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(160, 35);
            btnNotifications.TabIndex = 3;
            btnNotifications.Text = "Notifications (0)";
            btnNotifications.UseVisualStyleBackColor = true;
            btnNotifications.Click += btnNotifications_Click;
            // 
            // btnMyPosts
            // 
            btnMyPosts.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMyPosts.Location = new Point(420, 12);
            btnMyPosts.Name = "btnMyPosts";
            btnMyPosts.Size = new Size(120, 35);
            btnMyPosts.TabIndex = 2;
            btnMyPosts.Text = "My Posts";
            btnMyPosts.UseVisualStyleBackColor = true;
            btnMyPosts.Click += btnMyPosts_Click;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSearch.Location = new Point(260, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(140, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Smart Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.DodgerBlue;
            btnAddItem.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddItem.ForeColor = Color.White;
            btnAddItem.Location = new Point(20, 12);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(220, 35);
            btnAddItem.TabIndex = 0;
            btnAddItem.Text = "Report Lost/Found Item";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(0, 60);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1200, 418);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvLostItems);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1192, 388);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lost Items";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLostItems
            // 
            dgvLostItems.AllowUserToAddRows = false;
            dgvLostItems.AllowUserToDeleteRows = false;
            dgvLostItems.BackgroundColor = Color.White;
            dgvLostItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLostItems.Dock = DockStyle.Fill;
            dgvLostItems.Location = new Point(3, 3);
            dgvLostItems.Name = "dgvLostItems";
            dgvLostItems.ReadOnly = true;
            dgvLostItems.Size = new Size(1186, 382);
            dgvLostItems.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvFoundItems);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1192, 388);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Found Items";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvFoundItems
            // 
            dgvFoundItems.AllowUserToAddRows = false;
            dgvFoundItems.AllowUserToDeleteRows = false;
            dgvFoundItems.BackgroundColor = Color.White;
            dgvFoundItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoundItems.Dock = DockStyle.Fill;
            dgvFoundItems.Location = new Point(3, 3);
            dgvFoundItems.Name = "dgvFoundItems";
            dgvFoundItems.ReadOnly = true;
            dgvFoundItems.Size = new Size(1186, 382);
            dgvFoundItems.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogout.Location = new Point(1068, 12);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(120, 35);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Log Out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 478);
            Controls.Add(tabControl1);
            Controls.Add(panelTop);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Campus Buddy - Lost & Found";
            Load += MainForm_Load;
            panelTop.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLostItems).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFoundItems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnMyPosts;
        private System.Windows.Forms.Button btnNotifications;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvLostItems;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvFoundItems;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Button btnLogout;
    }
}