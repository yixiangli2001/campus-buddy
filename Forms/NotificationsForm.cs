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

namespace campus_buddy.Forms
{
    public partial class NotificationsForm : Form
    {
        private DataService dataService;
        private User currentUser;

        public NotificationsForm()
        {
            InitializeComponent();
            dataService = DataService.Instance;
            currentUser = dataService.GetCurrentUser();
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            // Set form properties
            this.Text = "Notifications";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(700, 600);

            // Populate filter combo
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("All Notifications");
            cmbFilter.Items.Add("Unread Only");
            cmbFilter.Items.Add("High Priority");
            cmbFilter.Items.Add("Medium Priority");
            cmbFilter.Items.Add("Low Priority");
            cmbFilter.SelectedIndex = 0;

            // Configure ListView
            ConfigureListView();

            // Load notifications
            LoadNotifications();
        }

        private void ConfigureListView()
        {
            lstNotifications.View = View.Details;
            lstNotifications.FullRowSelect = true;
            lstNotifications.GridLines = true;
            lstNotifications.MultiSelect = false;

            // Add columns
            lstNotifications.Columns.Clear();
            lstNotifications.Columns.Add("Priority", 80);
            lstNotifications.Columns.Add("Title", 200);
            lstNotifications.Columns.Add("Message", 300);
            lstNotifications.Columns.Add("Time", 120);

            // Handle selection
            lstNotifications.SelectedIndexChanged += LstNotifications_SelectedIndexChanged;
            lstNotifications.DoubleClick += LstNotifications_DoubleClick;
        }

        private void LoadNotifications()
        {
            try
            {
                // Get all notifications for current user
                var notifications = currentUser.GetNotifications();

                // Apply filter
                var filteredNotifications = ApplyFilter(notifications);

                // Sort by date (newest first)
                var sortedNotifications = filteredNotifications
                    .OrderByDescending(n => n.CreatedDate)
                    .ToList();

                // Clear ListView
                lstNotifications.Items.Clear();

                // Add to ListView
                foreach (var notification in sortedNotifications)
                {
                    var item = new ListViewItem(notification.Priority.ToString());
                    item.SubItems.Add(notification.Title);
                    item.SubItems.Add(notification.Message);
                    item.SubItems.Add(notification.GetTimeAgo());
                    item.Tag = notification; // Store notification object

                    // Color code by read status
                    if (!notification.IsRead)
                    {
                        item.Font = new Font(lstNotifications.Font, FontStyle.Bold);
                        item.BackColor = Color.LightYellow;
                    }

                    // Color code by priority
                    if (notification.Priority == NotificationPriority.High)
                    {
                        item.ForeColor = Color.Red;
                    }
                    else if (notification.Priority == NotificationPriority.Low)
                    {
                        item.ForeColor = Color.Gray;
                    }

                    lstNotifications.Items.Add(item);
                }

                // Update info label
                var unreadCount = notifications.Count(n => !n.IsRead);
                lblInfo.Text = $"Total: {sortedNotifications.Count} notifications ({unreadCount} unread)";

                // Enable/disable buttons
                btnMarkRead.Enabled = sortedNotifications.Any(n => !n.IsRead);
                btnMarkAllRead.Enabled = unreadCount > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading notifications: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private System.Collections.Generic.List<Notification> ApplyFilter(System.Collections.Generic.List<Notification> notifications)
        {
            switch (cmbFilter.SelectedIndex)
            {
                case 1: // Unread Only
                    return notifications.Where(n => !n.IsRead).ToList();
                case 2: // High Priority
                    return notifications.Where(n => n.Priority == NotificationPriority.High).ToList();
                case 3: // Medium Priority
                    return notifications.Where(n => n.Priority == NotificationPriority.Medium).ToList();
                case 4: // Low Priority
                    return notifications.Where(n => n.Priority == NotificationPriority.Low).ToList();
                default: // All
                    return notifications;
            }
        }

        private void LstNotifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool hasSelection = lstNotifications.SelectedItems.Count > 0;
            btnMarkRead.Enabled = hasSelection;
            btnViewDetails.Enabled = hasSelection;
        }

        private void LstNotifications_DoubleClick(object sender, EventArgs e)
        {
            ShowNotificationDetails();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ShowNotificationDetails();
        }

        private void ShowNotificationDetails()
        {
            if (lstNotifications.SelectedItems.Count == 0)
                return;

            var selectedItem = lstNotifications.SelectedItems[0];
            var notification = selectedItem.Tag as Notification;

            if (notification == null)
                return;

            // Mark as read
            if (!notification.IsRead)
            {
                notification.IsRead = true;
                dataService.SaveAllData();
            }

            // Show details
            var details = $"=== NOTIFICATION DETAILS ===\n\n" +
                         $"Priority: {notification.Priority}\n" +
                         $"Title: {notification.Title}\n\n" +
                         $"Message:\n{notification.Message}\n\n" +
                         $"Created: {notification.CreatedDate.ToString("g")}\n" +
                         $"({notification.GetTimeAgo()})\n";

            if (notification.MatchScore > 0)
            {
                details += $"\nMatch Score: {notification.MatchScore:F1}%";
            }

            MessageBox.Show(details, "Notification Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh list to update read status
            LoadNotifications();
        }

        private void btnMarkRead_Click(object sender, EventArgs e)
        {
            if (lstNotifications.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a notification to mark as read.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = lstNotifications.SelectedItems[0];
            var notification = selectedItem.Tag as Notification;

            if (notification != null && !notification.IsRead)
            {
                currentUser.MarkNotificationAsRead(notification.Id);
                dataService.SaveAllData();

                MessageBox.Show("Notification marked as read.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNotifications();
            }
        }

        private void btnMarkAllRead_Click(object sender, EventArgs e)
        {
            var unreadCount = currentUser.GetUnreadCount();

            if (unreadCount == 0)
            {
                MessageBox.Show("No unread notifications.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Mark all {unreadCount} notification(s) as read?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentUser.MarkAllAsRead();
                dataService.SaveAllData();

                MessageBox.Show("All notifications marked as read.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNotifications();
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadNotifications();
            MessageBox.Show("Notifications refreshed!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}