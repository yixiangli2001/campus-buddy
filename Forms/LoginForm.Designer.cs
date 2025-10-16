namespace campus_buddy.Forms
{
    partial class LoginForm
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
            emailLabel = new Label();
            txtEmail = new TextBox();
            passwordLabel = new Label();
            txtPassword = new TextBox();
            title = new Label();
            btnLogin = new Button();
            btnSignUp = new Button();
            SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(143, 87);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 0;
            emailLabel.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(213, 87);
            txtEmail.Margin = new Padding(2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(104, 23);
            txtEmail.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(143, 115);
            passwordLabel.Margin = new Padding(2, 0, 2, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(213, 115);
            txtPassword.Margin = new Padding(2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(104, 23);
            txtPassword.TabIndex = 3;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            title.Location = new Point(143, 31);
            title.Margin = new Padding(2, 0, 2, 0);
            title.Name = "title";
            title.Size = new Size(175, 32);
            title.TabIndex = 4;
            title.Text = "Campus Buddy";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(166, 155);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(125, 35);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(166, 195);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(124, 31);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "Sign Up Instead";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignup_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 257);
            Controls.Add(btnSignUp);
            Controls.Add(btnLogin);
            Controls.Add(title);
            Controls.Add(txtPassword);
            Controls.Add(passwordLabel);
            Controls.Add(txtEmail);
            Controls.Add(emailLabel);
            Margin = new Padding(2);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label emailLabel;
        private TextBox txtEmail;
        private Label passwordLabel;
        private TextBox txtPassword;
        private Label title;
        private Button btnLogin;
        private Button btnSignUp;
    }
}
