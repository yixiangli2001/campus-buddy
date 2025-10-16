using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using campus_buddy.Models;
using campus_buddy.Services;
using campus_buddy.Helpers;

namespace campus_buddy.Forms
{
    public partial class MainForm : Form
    {
        private DataService dataService;
        private MatchingService matchingService;
        private User usercurrentUser;
        public MainForm(User user)
        {
            InitializeComponent();
            dataService = DataService.Instance;
            matchingService = new MatchingService();
            currentUser = user;
        }

        //Form Load Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set up the form
            this.Text = "Campus Buddy - Lost & Found";
            this.WindowState = FormWindowState.Maximized;

            // Configure DataGridViews
            ConfigureDataGridViews();

            // Load data
            LoadAllItems();

            // Update notification badge
            UpdateNotificationBadge();
        }

        // Configure DataGridView appearance and columns
        private void ConfigureDataGridViews()
        {
            // Configure Lost Items DataGridView
            dgvLostItems.AutoGenerateColumns = false;
            dgvLostItems.AllowUserToAddRows = false;
            dgvLostItems.AllowUserToDeleteRows = false;
            dgvLostItems.ReadOnly = true;
            dgvLostItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLostItems.MultiSelect = false;
            dgvLostItems.RowHeadersVisible = false;

            // Add columns for Lost Items
            dgvLostItems.Columns.Clear();
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Width = 150
            });
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 100
            });
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Last Seen",
                Width = 150
            });
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 250
            });
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReporterName",
                HeaderText = "Reporter",
                Width = 120
            });
            dgvLostItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 80
            });

            // Configure Found Items DataGridView
            dgvFoundItems.AutoGenerateColumns = false;
            dgvFoundItems.AllowUserToAddRows = false;
            dgvFoundItems.AllowUserToDeleteRows = false;
            dgvFoundItems.ReadOnly = true;
            dgvFoundItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoundItems.MultiSelect = false;
            dgvFoundItems.RowHeadersVisible = false;

            // Add columns for Found Items
            dgvFoundItems.Columns.Clear();
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Width = 150
            });
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 100
            });
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Found At",
                Width = 150
            });
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 250
            });
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReporterName",
                HeaderText = "Reporter",
                Width = 120
            });
            dgvFoundItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 80
            });

            // Add double-click event handlers
            dgvLostItems.CellDoubleClick += DgvItems_CellDoubleClick;
            dgvFoundItems.CellDoubleClick += DgvItems_CellDoubleClick;
        }

        // Load all items into DataGridViews
        private void LoadAllItems()
        {
            try
            {
                // Get items using extension methods
                var lostItems = dataService.LostItems
                    .GetAll()
                    .GetActiveItems()
                    .SortByNewest()
                    .ToList();

                var foundItems = dataService.FoundItems
                    .GetAll()
                    .GetActiveItems()
                    .SortByNewest()
                    .ToList();

                // Bind to DataGridViews
                dgvLostItems.DataSource = lostItems;
                dgvFoundItems.DataSource = foundItems;

                // Update status bar
                this.Text = $"Campus Buddy - {lostItems.Count} Lost Items, {foundItems.Count} Found Items";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Handle double-click on item to view details
        private void DgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = sender as DataGridView;
            var item = dgv.Rows[e.RowIndex].DataBoundItem as Item;

            if (item != null)
            {
                ShowItemDetails(item);
            }
        }

        // Show item details
        private void ShowItemDetails(Item item)
        {
            var details = $"Title: {item.Title}\n" +
                         $"Category: {item.Category}\n" +
                         $"Location: {item.Location}\n" +
                         $"Description: {item.Description}\n" +
                         $"Reporter: {item.ReporterName}\n" +
                         $"Contact: {item.ReporterContact}\n" +
                         $"Status: {item.Status}\n" +
                         $"Reported: {item.GetTimeSinceReported()}";

            MessageBox.Show(details, $"{item.GetItemType()} Item Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Update notification badge count
        private void UpdateNotificationBadge()
        {
            var user = dataService.CurrentUser;
            var unreadCount = user.GetUnreadCount();
            btnNotifications.Text = $"Notifications ({unreadCount})";
        }

        // Button click events
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var submitForm = new SubmitItemForm();
            submitForm.ShowDialog();
            LoadAllItems(); // Refresh after closing
            UpdateNotificationBadge();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchForm();
            searchForm.ShowDialog();
        }

        private void btnMyPosts_Click(object sender, EventArgs e)
        {
            var myPostsForm = new MyPostsForm();
            myPostsForm.ShowDialog();
            LoadAllItems(); // Refresh after closing
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            var notificationsForm = new NotificationsForm();
            notificationsForm.ShowDialog();
            UpdateNotificationBadge();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataService.LoadAllData();
            LoadAllItems();
            UpdateNotificationBadge();
            MessageBox.Show("Data refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {

            var myAccountForm = new MyAccountForm();
            myAccountForm.ShowDialog();
            if (myAccountForm.Tag is User updatedUser)
            {
                DataService.Instance.SetCurrentUser(updatedUser);
                MessageBox.Show("Account updated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            // Hide main form
            this.Hide();

            //Show login form
            using (var login = new LoginForm())
            {
                var result = login.ShowDialog(this);

                if (result == DialogResult.OK && login.Tag is User user)
                {
                    DataService.Instance.SetCurrentUser(user);
                    UpdateNotificationBadge();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
