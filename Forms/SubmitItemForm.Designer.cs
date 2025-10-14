namespace campus_buddy.Forms
{
    partial class SubmitItemForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.rbLost = new System.Windows.Forms.RadioButton();
            this.rbFound = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReporterName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblCurrentLocation = new System.Windows.Forms.Label();
            this.txtCurrentLocation = new System.Windows.Forms.TextBox();
            this.chkSecurity = new System.Windows.Forms.CheckBox();
            this.chkUrgent = new System.Windows.Forms.CheckBox();
            this.lblReward = new System.Windows.Forms.Label();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Report Lost or Found Item";
            // 
            // rbLost
            // 
            this.rbLost.AutoSize = true;
            this.rbLost.Checked = true;
            this.rbLost.Location = new System.Drawing.Point(17, 50);
            this.rbLost.Name = "rbLost";
            this.rbLost.Size = new System.Drawing.Size(76, 19);
            this.rbLost.TabIndex = 1;
            this.rbLost.TabStop = true;
            this.rbLost.Text = "Lost Item";
            this.rbLost.UseVisualStyleBackColor = true;
            this.rbLost.CheckedChanged += new System.EventHandler(this.rbLost_CheckedChanged);
            // 
            // rbFound
            // 
            this.rbFound.AutoSize = true;
            this.rbFound.Location = new System.Drawing.Point(120, 50);
            this.rbFound.Name = "rbFound";
            this.rbFound.Size = new System.Drawing.Size(89, 19);
            this.rbFound.TabIndex = 2;
            this.rbFound.Text = "Found Item";
            this.rbFound.UseVisualStyleBackColor = true;
            this.rbFound.CheckedChanged += new System.EventHandler(this.rbFound_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(17, 103);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(540, 23);
            this.txtTitle.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Category:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(17, 158);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(250, 23);
            this.cmbCategory.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(17, 213);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(540, 80);
            this.txtDescription.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(17, 323);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(540, 23);
            this.txtLocation.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date Lost/Found:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(17, 378);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(250, 23);
            this.dtpDate.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Your Name:";
            // 
            // txtReporterName
            // 
            this.txtReporterName.Location = new System.Drawing.Point(17, 433);
            this.txtReporterName.Name = "txtReporterName";
            this.txtReporterName.Size = new System.Drawing.Size(540, 23);
            this.txtReporterName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 470);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Contact (Email or Phone):";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(17, 488);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(540, 23);
            this.txtContact.TabIndex = 16;
            // 
            // lblCurrentLocation
            // 
            this.lblCurrentLocation.AutoSize = true;
            this.lblCurrentLocation.Location = new System.Drawing.Point(17, 525);
            this.lblCurrentLocation.Name = "lblCurrentLocation";
            this.lblCurrentLocation.Size = new System.Drawing.Size(224, 15);
            this.lblCurrentLocation.TabIndex = 17;
            this.lblCurrentLocation.Text = "Current Location (where you're keeping it):";
            // 
            // txtCurrentLocation
            // 
            this.txtCurrentLocation.Location = new System.Drawing.Point(17, 543);
            this.txtCurrentLocation.Name = "txtCurrentLocation";
            this.txtCurrentLocation.Size = new System.Drawing.Size(540, 23);
            this.txtCurrentLocation.TabIndex = 18;
            // 
            // chkSecurity
            // 
            this.chkSecurity.AutoSize = true;
            this.chkSecurity.Location = new System.Drawing.Point(17, 575);
            this.chkSecurity.Name = "chkSecurity";
            this.chkSecurity.Size = new System.Drawing.Size(173, 19);
            this.chkSecurity.TabIndex = 19;
            this.chkSecurity.Text = "Handed to Security Office";
            this.chkSecurity.UseVisualStyleBackColor = true;
            // 
            // chkUrgent
            // 
            this.chkUrgent.AutoSize = true;
            this.chkUrgent.Location = new System.Drawing.Point(17, 525);
            this.chkUrgent.Name = "chkUrgent";
            this.chkUrgent.Size = new System.Drawing.Size(109, 19);
            this.chkUrgent.TabIndex = 20;
            this.chkUrgent.Text = "Mark as Urgent";
            this.chkUrgent.UseVisualStyleBackColor = true;
            // 
            // lblReward
            // 
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(17, 555);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(134, 15);
            this.lblReward.TabIndex = 21;
            this.lblReward.Text = "Reward Offered (optional):";
            // 
            // txtReward
            // 
            this.txtReward.Location = new System.Drawing.Point(17, 573);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(540, 23);
            this.txtReward.TabIndex = 22;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(370, 615);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 35);
            this.btnSubmit.TabIndex = 23;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(467, 615);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SubmitItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtReward);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.chkUrgent);
            this.Controls.Add(this.chkSecurity);
            this.Controls.Add(this.txtCurrentLocation);
            this.Controls.Add(this.lblCurrentLocation);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReporterName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbFound);
            this.Controls.Add(this.rbLost);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubmitItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Lost or Found Item";
            this.Load += new System.EventHandler(this.SubmitItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rbLost;
        private System.Windows.Forms.RadioButton rbFound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReporterName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblCurrentLocation;
        private System.Windows.Forms.TextBox txtCurrentLocation;
        private System.Windows.Forms.CheckBox chkSecurity;
        private System.Windows.Forms.CheckBox chkUrgent;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.TextBox txtReward;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}