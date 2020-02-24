namespace Assigment2last
{
    partial class loginScreen
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
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textUsername.Location = new System.Drawing.Point(366, 77);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(311, 35);
            this.textUsername.TabIndex = 0;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPassword.Location = new System.Drawing.Point(366, 168);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(311, 35);
            this.textPassword.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Username.Location = new System.Drawing.Point(141, 78);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(124, 29);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(141, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(104, 319);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(155, 47);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New User";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(339, 319);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(155, 47);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(574, 319);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 47);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // loginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "loginScreen";
            this.Text = "Login Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}

