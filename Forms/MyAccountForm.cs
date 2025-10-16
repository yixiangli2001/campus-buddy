using campus_buddy.Services;
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

namespace campus_buddy.Forms
{
    public partial class MyAccountForm : Form
    {
        public MyAccountForm()
        {
            InitializeComponent();

            emailText.Text = DataService.Instance.CurrentUser.Email;
            txtName.Text = DataService.Instance.CurrentUser.Name;
            txtPhone.Text = DataService.Instance.CurrentUser.PhoneNumber;
            txtPassword.Text = DataService.Instance.CurrentUser.Password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User(txtName.Text, emailText.Text, txtPassword.Text, txtPhone.Text);
            ValidationService validationService = new ValidationService();
            var validationResult = validationService.ValidateUser(user);
            if (!validationResult.IsValid)
            {
                string errors = string.Join("\n", validationResult.Errors);
                MessageBox.Show(errors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataService.Instance.UpdateUserDetails(user);
            DataService.Instance.SetCurrentUser(user);
            this.Tag = DataService.Instance.CurrentUser;
            this.Close();
        }
    }
}
