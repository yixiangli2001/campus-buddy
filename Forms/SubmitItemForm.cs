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
    public partial class SubmitItemForm : Form
    {

        private DataService dataService;
        private ValidationService validationService;
        private MatchingService matchingService;
        public SubmitItemForm()
        {
            InitializeComponent();
            dataService = DataService.Instance;
            validationService = new ValidationService();
            matchingService = new MatchingService();
        }
        private void SubmitItemForm_Load(object sender, EventArgs e)
        {
            // Set form title
            this.Text = "Report Lost or Found Item";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(600, 700);

            // Populate category combo box
            cmbCategory.Items.Clear();
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory)))
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0;

            // Set default date to today
            dtpDate.Value = DateTime.Now;
            dtpDate.MaxDate = DateTime.Now; // Can't select future dates

            // Show/hide controls based on item type
            UpdateControlVisibility();
        }

        // Radio button changed - Lost/Found
        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlVisibility();
        }

        private void rbFound_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlVisibility();
        }

        // Show/hide controls based on whether it's Lost or Found
        private void UpdateControlVisibility()
        {
            bool isLost = rbLost.Checked;

            // Show/hide Lost Item specific controls
            lblReward.Visible = isLost;
            txtReward.Visible = isLost;
            chkUrgent.Visible = isLost;

            // Show/hide Found Item specific controls
            lblCurrentLocation.Visible = !isLost;
            txtCurrentLocation.Visible = !isLost;
            chkSecurity.Visible = !isLost;

            // Update form title
            lblTitle.Text = isLost ? "Report Lost Item" : "Report Found Item";
        }

        // Submit button clicked
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Sanitize inputs
                string title = validationService.SanitizeInput(txtTitle.Text);
                string description = validationService.SanitizeInput(txtDescription.Text);
                string location = validationService.SanitizeInput(txtLocation.Text);
                string reporterName = validationService.SanitizeInput(txtReporterName.Text);
                string contact = validationService.SanitizeInput(txtContact.Text);

                // Create the appropriate item
                Item item;

                if (rbLost.Checked)
                {
                    // Create Lost Item
                    var lostItem = new LostItem
                    {
                        Title = title,
                        Description = description,
                        Category = (ItemCategory)cmbCategory.SelectedItem,
                        Location = location,
                        DateLost = dtpDate.Value,
                        DateReported = DateTime.Now,
                        ReporterName = reporterName,
                        ReporterContact = contact,
                        IsUrgent = chkUrgent.Checked,
                        RewardOffered = txtReward.Text.Trim(),
                        Status = ItemStatus.Active
                    };

                    item = lostItem;
                }
                else
                {
                    // Create Found Item
                    var foundItem = new FoundItem
                    {
                        Title = title,
                        Description = description,
                        Category = (ItemCategory)cmbCategory.SelectedItem,
                        Location = location,
                        DateFound = dtpDate.Value,
                        DateReported = DateTime.Now,
                        ReporterName = reporterName,
                        ReporterContact = contact,
                        CurrentLocation = validationService.SanitizeInput(txtCurrentLocation.Text),
                        HandedToSecurity = chkSecurity.Checked,
                        Status = ItemStatus.Active
                    };

                    item = foundItem;
                }

                // Validate the item
                var validationResult = validationService.ValidateItem(item);

                if (!validationResult.IsValid)
                {
                    MessageBox.Show(validationResult.GetErrorMessage(), "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save the item
                if (item is LostItem lostItemToSave)
                {
                    dataService.AddLostItem(lostItemToSave);
                }
                else if (item is FoundItem foundItemToSave)
                {
                    dataService.AddFoundItem(foundItemToSave);
                }

                // Check for matches and create notifications
                matchingService.CheckAndNotifyMatches(item);

                // Show success message
                MessageBox.Show($"{item.GetItemType()} item '{item.Title}' has been reported successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cancel button clicked
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }




    }
}
