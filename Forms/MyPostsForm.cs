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
    public partial class MyPostsForm : Form
    {
        private DataService dataService;
        private User currentUser;

        public MyPostsForm()
        {
            InitializeComponent();
            dataService = DataService.Instance;
            currentUser = dataService.GetCurrentUser();
        }

        private void MyPostsForm_Load(object sender, EventArgs e)
        {
            // Set form properties
            this.Text = "My Posts";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(900, 600);

            // Configure DataGridView
            ConfigureDataGridView();

            // Load user's posts
            LoadMyPosts();
        }

        private void ConfigureDataGridView()
        {
            dgvMyPosts.AutoGenerateColumns = false;
            dgvMyPosts.AllowUserToAddRows = false;
            dgvMyPosts.AllowUserToDeleteRows = false;
            dgvMyPosts.ReadOnly = true;
            dgvMyPosts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyPosts.MultiSelect = false;
            dgvMyPosts.RowHeadersVisible = false;

            // Clear existing columns
            dgvMyPosts.Columns.Clear();

            // Add columns
            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Width = 150
            });

            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Type",
                Width = 80
            });

            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 100
            });

            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Location",
                Width = 150
            });

            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 80
            });

            dgvMyPosts.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Posted",
                Width = 120
            });

            // Handle cell formatting to show item type and time
            dgvMyPosts.CellFormatting += DgvMyPosts_CellFormatting;

            // Handle double-click
            dgvMyPosts.CellDoubleClick += DgvMyPosts_CellDoubleClick;
        }

        private void DgvMyPosts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMyPosts.Rows[e.RowIndex].DataBoundItem is Item item)
            {
                // Set Type column
                if (dgvMyPosts.Columns[e.ColumnIndex].HeaderText == "Type")
                {
                    e.Value = item.GetItemType().ToString();
                }

                // Set Posted column with time ago
                if (dgvMyPosts.Columns[e.ColumnIndex].HeaderText == "Posted")
                {
                    e.Value = item.GetTimeSinceReported(); // Extension method
                }

                // Color code by status
                if (item.Status == ItemStatus.Resolved)
                {
                    dgvMyPosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (item.Status == ItemStatus.Expired)
                {
                    dgvMyPosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (item is LostItem lostItem && lostItem.IsUrgent)
                {
                    dgvMyPosts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void LoadMyPosts()
        {
            try
            {
                // Get ALL items (for demo purposes - in real app would filter by user)
                var lostItems = dataService.LostItems.GetAll().Cast<Item>();
                var foundItems = dataService.FoundItems.GetAll().Cast<Item>();

                // Combine and sort
                var allMyItems = lostItems.Concat(foundItems)
                    .SortByNewest() // Extension method
                    .ToList();

                // Bind to DataGridView
                dgvMyPosts.DataSource = allMyItems;

                // Update label
                lblInfo.Text = $"Total items posted: {allMyItems.Count}";

                // Enable/disable buttons
                bool hasSelection = allMyItems.Count > 0;
                btnViewDetails.Enabled = hasSelection;
                btnMarkResolved.Enabled = hasSelection;
                btnDelete.Enabled = hasSelection;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading posts: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMyPosts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvMyPosts.Rows[e.RowIndex].DataBoundItem as Item;
            if (item != null)
            {
                ShowItemDetails(item);
            }
        }

        private void ShowItemDetails(Item item)
        {
            var itemType = item.GetItemType();
            var details = $"=== {itemType} ITEM DETAILS ===\n\n" +
                         $"Title: {item.Title}\n" +
                         $"Category: {item.Category}\n" +
                         $"Location: {item.Location}\n" +
                         $"Description: {item.Description}\n\n" +
                         $"Reporter: {item.ReporterName}\n" +
                         $"Contact: {item.ReporterContact}\n\n" +
                         $"Status: {item.Status}\n" +
                         $"Posted: {item.GetTimeSinceReported()}\n";

            if (item is LostItem lostItem)
            {
                details += $"\nDate Lost: {lostItem.DateLost.ToShortDateString()}\n";
                if (lostItem.IsUrgent)
                    details += "⚠️ URGENT\n";
                if (!string.IsNullOrEmpty(lostItem.RewardOffered))
                    details += $"Reward: {lostItem.RewardOffered}\n";
            }
            else if (item is FoundItem foundItem)
            {
                details += $"\nDate Found: {foundItem.DateFound.ToShortDateString()}\n";
                details += $"Current Location: {foundItem.CurrentLocation}\n";
                if (foundItem.HandedToSecurity)
                    details += "✓ At Security Office\n";
            }

            MessageBox.Show(details, $"My {itemType} Item",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvMyPosts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to view details.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = dgvMyPosts.SelectedRows[0].DataBoundItem as Item;
            if (selectedItem != null)
            {
                ShowItemDetails(selectedItem);
            }
        }

        private void btnMarkResolved_Click(object sender, EventArgs e)
        {
            if (dgvMyPosts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to mark as resolved.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = dgvMyPosts.SelectedRows[0].DataBoundItem as Item;
            if (selectedItem == null)
                return;

            // Confirm action
            var result = MessageBox.Show(
                $"Mark '{selectedItem.Title}' as resolved?\n\n" +
                "This will change the status to 'Resolved' and indicate the item has been recovered/returned.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Update status
                    dataService.UpdateItemStatus(selectedItem.Id, ItemStatus.Resolved);

                    // Create notification
                    var notification = Notification.CreateStatusNotification(
                        currentUser.UserId,
                        selectedItem.Title,
                        ItemStatus.Resolved);

                    currentUser.SendNotification(notification);
                    dataService.Notifications.Add(notification);
                    dataService.SaveAllData();

                    MessageBox.Show("Item marked as resolved!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh list
                    LoadMyPosts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating item: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMyPosts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = dgvMyPosts.SelectedRows[0].DataBoundItem as Item;
            if (selectedItem == null)
                return;

            // Confirm action
            var result = MessageBox.Show(
                $"Are you sure you want to delete '{selectedItem.Title}'?\n\n" +
                "This action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete item
                    bool deleted = dataService.DeleteItem(selectedItem.Id);

                    if (deleted)
                    {
                        MessageBox.Show("Item deleted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh list
                        LoadMyPosts();
                    }
                    else
                    {
                        MessageBox.Show("Item not found.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting item: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMyPosts();
            MessageBox.Show("Posts refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}