using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace campus_buddy.Forms
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            this.Text = "Smart Search";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(800, 600);

            // Placeholder message
            Label lblPlaceholder = new Label
            {
                Text = "Search functionality coming soon!",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20),
                Font = new System.Drawing.Font("Segoe UI", 12F)
            };
            this.Controls.Add(lblPlaceholder);
        }
    }
}