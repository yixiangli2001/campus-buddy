
using campus_buddy.Models;
using campus_buddy.Services;

namespace campus_buddy.Forms
{
    partial class SignupForm
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
            signUpLabel = new Label();
            emailLabel = new Label();
            nameLabel = new Label();
            phoneNumberLabel = new Label();
            passwordLabel = new Label();
            txtEmail = new TextBox();
            txtName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtPassword = new TextBox();
            btnSignup = new Button();
            SuspendLayout();
            // 
            // signUpLabel
            // 
            signUpLabel.AutoSize = true;
            signUpLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            signUpLabel.Location = new Point(189, 54);
            signUpLabel.Name = "signUpLabel";
            signUpLabel.Size = new Size(393, 45);
            signUpLabel.TabIndex = 0;
            signUpLabel.Text = "Sign Up to Campus Buddy";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(252, 135);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(252, 175);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(39, 15);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(252, 214);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(88, 15);
            phoneNumberLabel.TabIndex = 3;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(252, 255);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(369, 135);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(369, 175);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 6;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(369, 214);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(100, 23);
            txtPhoneNumber.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(369, 255);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 8;
            // 
            // btnSignup
            // 
            btnSignup.Location = new Point(335, 323);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(75, 23);
            btnSignup.TabIndex = 9;
            btnSignup.Text = "Sign Up";
            btnSignup.UseVisualStyleBackColor = true;
            btnSignup.Click += btnSignup_Click;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 419);
            Controls.Add(btnSignup);
            Controls.Add(txtPassword);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtName);
            Controls.Add(txtEmail);
            Controls.Add(passwordLabel);
            Controls.Add(phoneNumberLabel);
            Controls.Add(nameLabel);
            Controls.Add(emailLabel);
            Controls.Add(signUpLabel);
            Name = "SignupForm";
            Text = "SignupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            User user = new User(txtName.Text, txtEmail.Text, txtPassword.Text, txtPhoneNumber.Text);
            ValidationService validationService = new ValidationService();
            var validationResult = validationService.ValidateUser(user);
            if (!validationResult.IsValid)
            {
                string errors = string.Join("\n", validationResult.Errors);
                MessageBox.Show(errors, "Validation Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataService.Instance.AddUser(user);
            MessageBox.Show("Successfully signed up!","Success", MessageBoxButtons.OK);
            this.Close();
        }

        #endregion

        private Label signUpLabel;
        private Label emailLabel;
        private Label nameLabel;
        private Label phoneNumberLabel;
        private Label passwordLabel;
        private TextBox txtEmail;
        private TextBox txtName;
        private TextBox txtPhoneNumber;
        private TextBox txtPassword;
        private Button btnSignup;
    }
}