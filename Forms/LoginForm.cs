using campus_buddy.Services;
using campus_buddy.Forms;
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
    public partial class LoginForm : Form

    {
        private readonly AuthenticationService _auth;
        public LoginForm()
        {
            InitializeComponent();
            _auth = new AuthenticationService();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var res = _auth.Login(txtEmail.Text, txtPassword.Text);

            if (!res.IsSuccess)
            {
                MessageBox.Show(res.ErrorText(), "Login failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Welcome {res.User!.Name}!", "Login successful");
            var mainForm = new MainForm(res.User); 
            mainForm.Show();
        }
    }
}
