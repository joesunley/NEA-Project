namespace Login_Visual
{
    partial class FrmLoginLogin
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
            this.pbUserName = new System.Windows.Forms.PictureBox();
            this.pnTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnUserNameLine = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnPasswordLine = new System.Windows.Forms.Panel();
            this.pbPassword = new System.Windows.Forms.PictureBox();
            this.btnForgotPassword = new System.Windows.Forms.Button();
            this.btnLogin = new ePOSOne.btnProduct.Button_WOC();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserName)).BeginInit();
            this.pnTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pbUserName
            // 
            this.pbUserName.Image = global::Login_Visual.Properties.Resources.icons8_user_male_30;
            this.pbUserName.Location = new System.Drawing.Point(22, 185);
            this.pbUserName.Name = "pbUserName";
            this.pbUserName.Size = new System.Drawing.Size(30, 30);
            this.pbUserName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUserName.TabIndex = 0;
            this.pbUserName.TabStop = false;
            // 
            // pnTitle
            // 
            this.pnTitle.Controls.Add(this.btnClose);
            this.pnTitle.Controls.Add(this.lblTitle);
            this.pnTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitle.Location = new System.Drawing.Point(0, 0);
            this.pnTitle.Name = "pnTitle";
            this.pnTitle.Size = new System.Drawing.Size(300, 109);
            this.pnTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitle.Location = new System.Drawing.Point(55, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 73);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Login";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnUserNameLine
            // 
            this.pnUserNameLine.BackColor = System.Drawing.Color.Gainsboro;
            this.pnUserNameLine.Location = new System.Drawing.Point(68, 213);
            this.pnUserNameLine.Name = "pnUserNameLine";
            this.pnUserNameLine.Size = new System.Drawing.Size(200, 1);
            this.pnUserNameLine.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.txtUsername.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.Location = new System.Drawing.Point(68, 192);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 19);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtPassword.Location = new System.Drawing.Point(68, 258);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 19);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "Password";
            // 
            // pnPasswordLine
            // 
            this.pnPasswordLine.BackColor = System.Drawing.Color.Gainsboro;
            this.pnPasswordLine.Location = new System.Drawing.Point(68, 279);
            this.pnPasswordLine.Name = "pnPasswordLine";
            this.pnPasswordLine.Size = new System.Drawing.Size(200, 1);
            this.pnPasswordLine.TabIndex = 5;
            // 
            // pbPassword
            // 
            this.pbPassword.Image = global::Login_Visual.Properties.Resources.icons8_password_30;
            this.pbPassword.Location = new System.Drawing.Point(22, 251);
            this.pbPassword.Name = "pbPassword";
            this.pbPassword.Size = new System.Drawing.Size(30, 30);
            this.pbPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPassword.TabIndex = 4;
            this.pbPassword.TabStop = false;
            // 
            // btnForgotPassword
            // 
            this.btnForgotPassword.FlatAppearance.BorderSize = 0;
            this.btnForgotPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnForgotPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgotPassword.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnForgotPassword.Location = new System.Drawing.Point(94, 461);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(109, 27);
            this.btnForgotPassword.TabIndex = 8;
            this.btnForgotPassword.Text = "Forgotten Password";
            this.btnForgotPassword.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnLogin.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(53, 381);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(74)))), ((int)(((byte)(89)))));
            this.btnLogin.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnLogin.OnHoverTextColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.Size = new System.Drawing.Size(192, 74);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.Gainsboro;
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::Login_Visual.Properties.Resources.icons8_close_window_32;
            this.btnClose.Location = new System.Drawing.Point(266, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FrmLoginLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.ClientSize = new System.Drawing.Size(300, 500);
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.pnPasswordLine);
            this.Controls.Add(this.pbPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pnUserNameLine);
            this.Controls.Add(this.pnTitle);
            this.Controls.Add(this.pbUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoginLogin";
            this.Text = "FrmLoginLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pbUserName)).EndInit();
            this.pnTitle.ResumeLayout(false);
            this.pnTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbUserName;
        private System.Windows.Forms.Panel pnTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnUserNameLine;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnPasswordLine;
        private System.Windows.Forms.PictureBox pbPassword;
        private ePOSOne.btnProduct.Button_WOC btnLogin;
        private System.Windows.Forms.Button btnForgotPassword;
        private System.Windows.Forms.Button btnClose;
    }
}