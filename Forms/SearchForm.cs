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
    public partial class SearchForm : Form
    {
        private DataService dataService;
        private MatchingService matchingService;
        private ValidationService validationService;

        public SearchForm()
        {
            InitializeComponent();
            dataService = DataService.Instance;
            matchingService = new MatchingService();
            validationService = new ValidationService();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            // Set form properties
            this.Text = "Smart Search & Match";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(900, 700);

            // Populate category combo box
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            foreach (ItemCategory category in Enum.GetValues(typeof(ItemCategory)))
            {
                cmbCategory.Items.Add(category);
            }
            cmbCategory.SelectedIndex = 0;

            // Configure DataGridView
            ConfigureDataGridView();

            // Load all items by default
            PerformSearch();
        }

        private void ConfigureDataGridView()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.ReadOnly = true;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;
            dgvResults.RowHeadersVisible = false;

            // Clear existing columns
            dgvResults.Columns.Clear();

            // Add columns
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category",
                HeaderText = "Category",
                Width = 100
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Location",
                HeaderText = "Location",
                Width = 150
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Description",
                Width = 200
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReporterName",
                HeaderText = "Reporter",
                Width = 120
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status",
                Width = 80
            });

            // Add double-click event
            dgvResults.CellDoubleClick += DgvResults_CellDoubleClick;
        }

        // Search button clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // Perform the search using LINQ and extension methods
        private void PerformSearch()
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                bool searchLost = rbSearchLost.Checked;

                // Validate search if keyword is provided
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var validation = validationService.ValidateSearchQuery(keyword);
                    if (!validation.IsValid)
                    {
                        MessageBox.Show(validation.GetErrorMessage(), "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Get items based on search type
                IEnumerable<Item> items;

                if (searchLost)
                {
                    items = dataService.LostItems.GetAll().Cast<Item>();
                }
                else
                {
                    items = dataService.FoundItems.GetAll().Cast<Item>();
                }

                // Apply filters using extension methods
                var filteredItems = items.GetActiveItems(); // Extension method

                // Filter by keyword if provided
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    filteredItems = filteredItems.SearchByKeyword(keyword); // Extension method
                }

                // Filter by category if not "All Categories"
                if (cmbCategory.SelectedIndex > 0)
                {
                    var selectedCategory = (ItemCategory)cmbCategory.SelectedItem;
                    filteredItems = filteredItems.FilterByCategory(selectedCategory); // Extension method
                }

                // Sort by newest first and convert to list
                var results = filteredItems.SortByNewest().ToList(); // Extension method

                // Bind to DataGridView
                dgvResults.DataSource = results;

                // Update results label
                lblResults.Text = $"Search Results: {results.Count} item(s) found";

                // Enable/disable buttons
                btnViewDetails.Enabled = results.Count > 0;
                btnFindMatches.Enabled = results.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error performing search: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear search
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbCategory.SelectedIndex = 0;
            PerformSearch();
        }

        // View details of selected item
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to view details.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = dgvResults.SelectedRows[0].DataBoundItem as Item;
            if (selectedItem != null)
            {
                ShowItemDetails(selectedItem);
            }
        }

        // Double-click on item
        private void DgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = dgvResults.Rows[e.RowIndex].DataBoundItem as Item;
            if (item != null)
            {
                ShowItemDetails(item);
            }
        }

        // Show item details
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
                         $"Reported: {item.GetTimeSinceReported()}\n"; // Extension method

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

            MessageBox.Show(details, $"{itemType} Item Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Find matches for selected item
        private void btnFindMatches_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to find matches.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = dgvResults.SelectedRows[0].DataBoundItem as Item;
            if (selectedItem == null)
                return;

            try
            {
                // Find matches based on item type
                var matches = selectedItem is LostItem lostItem
                    ? matchingService.FindMatchesForLostItem(lostItem, 10)
                    : matchingService.FindMatchesForFoundItem((FoundItem)selectedItem, 10);

                if (matches.Count == 0)
                {
                    MessageBox.Show("No matches found for this item.", "No Matches",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Display matches
                ShowMatchResults(selectedItem, matches);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding matches: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show match results in a dialog
        private void ShowMatchResults(Item originalItem, System.Collections.Generic.List<MatchResult> matches)
        {
            var matchForm = new Form
            {
                Text = "Match Results",
                Size = new Size(700, 500),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblTitle = new Label
            {
                Text = $"Found {matches.Count} potential match(es) for: {originalItem.Title}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            matchForm.Controls.Add(lblTitle);

            var lstMatches = new ListBox
            {
                Location = new Point(20, 60),
                Size = new Size(640, 320),
                Font = new Font("Segoe UI", 10F)
            };

            foreach (var match in matches)
            {
                var oppositeItem = originalItem is LostItem ? (Item)match.FoundItem : match.LostItem;
                var displayText = $"[{match.MatchScore:F1}%] {match.GetMatchQuality()} - " +
                                 $"{oppositeItem.Title} at {oppositeItem.Location}";
                lstMatches.Items.Add(displayText);
            }

            lstMatches.DoubleClick += (s, e) =>
            {
                if (lstMatches.SelectedIndex >= 0)
                {
                    var selectedMatch = matches[lstMatches.SelectedIndex];
                    var oppositeItem = originalItem is LostItem ? (Item)selectedMatch.FoundItem : selectedMatch.LostItem;
                    ShowItemDetails(oppositeItem);
                }
            };

            matchForm.Controls.Add(lstMatches);

            var btnClose = new Button
            {
                Text = "Close",
                Location = new Point(580, 400),
                Size = new Size(80, 30)
            };
            btnClose.Click += (s, e) => matchForm.Close();
            matchForm.Controls.Add(btnClose);

            var lblHint = new Label
            {
                Text = "Double-click on a match to view details",
                Location = new Point(20, 405),
                AutoSize = true,
                ForeColor = Color.Gray
            };
            matchForm.Controls.Add(lblHint);

            matchForm.ShowDialog();
        }

        // Radio button changed
        private void rbSearchLost_CheckedChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void rbSearchFound_CheckedChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }

        // Close button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}