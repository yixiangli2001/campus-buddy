using campus_buddy.Models;
using campus_buddy.Services;

namespace campus_buddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Test data service
            var dataService = DataService.Instance;

            // Create a test lost item
            var testItem = new LostItem
            {
                Title = "Black Laptop",
                Description = "MacBook Pro 13 inch",
                Category = ItemCategory.Electronics,
                Location = "Library Level 3",
                ReporterName = "Test Student",
                ReporterContact = "test@student.uts.edu.au"
            };

            // Add and save
            dataService.AddLostItem(testItem);

            // Show confirmation
            MessageBox.Show($"Test item saved! Data saved to:\n{dataService.GetDataDirectory()}");

            // Load and display count
            var count = dataService.LostItems.Count();
            MessageBox.Show($"Total lost items in database: {count}");
        }
    }
}
