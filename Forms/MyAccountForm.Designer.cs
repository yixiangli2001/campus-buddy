namespace campus_buddy.Forms
{
    partial class MyAccountForm
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
            myAccountLabel = new Label();
            emailLabel = new Label();
            emailText = new Label();
            phoneLabel = new Label();
            txtPhone = new TextBox();
            passwordLabel = new Label();
            txtPassword = new TextBox();
            btnSave = new Button();
            label1 = new Label();
            nameLabel = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // myAccountLabel
            // 
            myAccountLabel.AutoSize = true;
            myAccountLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            myAccountLabel.Location = new Point(199, 20);
            myAccountLabel.Name = "myAccountLabel";
            myAccountLabel.Size = new Size(190, 45);
            myAccountLabel.TabIndex = 0;
            myAccountLabel.Text = "My Account";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(190, 76);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(36, 15);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Email";
            // 
            // emailText
            // 
            emailText.AutoSize = true;
            emailText.Location = new Point(285, 76);
            emailText.Name = "emailText";
            emailText.Size = new Size(118, 15);
            emailText.TabIndex = 2;
            emailText.Text = "Email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(190, 153);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(41, 15);
            phoneLabel.TabIndex = 3;
            phoneLabel.Text = "phone number";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(285, 149);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(114, 23);
            txtPhone.TabIndex = 5;
            txtPhone.Text = "0424356788";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(190, 193);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(285, 189);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(114, 23);
            txtPassword.TabIndex = 7;
            txtPassword.Text = "Password";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(253, 258);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 91);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 10;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(190, 113);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(39, 15);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(285, 109);
            txtName.Name = "txtName";
            txtName.Size = new Size(114, 23);
            txtName.TabIndex = 11;
            txtName.Text = "Name";
            // 
            // MyAccount
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 324);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(nameLabel);
            Controls.Add(btnSave);
            Controls.Add(txtPassword);
            Controls.Add(passwordLabel);
            Controls.Add(txtPhone);
            Controls.Add(phoneLabel);
            Controls.Add(emailText);
            Controls.Add(emailLabel);
            Controls.Add(myAccountLabel);
            Name = "MyAccount";
            Text = "MyAccount";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label myAccountLabel;
        private Label emailLabel;
        private Label emailText;
        private Label phoneLabel;
        private TextBox txtPhone;
        private Label passwordLabel;
        private TextBox txtPassword;
        private Button btnSave;
        private Label label1;
        private Label nameLabel;
        private TextBox txtName;
    }
}