
using System.Drawing;

namespace Poker_Online
{
    partial class Form1
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
            this.pageHandler = new System.Windows.Forms.TabControl();
            this.loginScreen = new System.Windows.Forms.TabPage();
            this.loginPageGoBackButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextbox = new System.Windows.Forms.TextBox();
            this.signupScreen = new System.Windows.Forms.TabPage();
            this.signupStatusLabel = new System.Windows.Forms.Label();
            this.signupRegisterButton = new System.Windows.Forms.Button();
            this.signupGoBackButton = new System.Windows.Forms.Button();
            this.signupPasswordTextbox = new System.Windows.Forms.TextBox();
            this.signupUserTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainScreen = new System.Windows.Forms.TabPage();
            this.existUserButton = new System.Windows.Forms.Button();
            this.newUserButton = new System.Windows.Forms.Button();
            this.loggedInMainScreen = new System.Windows.Forms.TabPage();
            this.gameScreen = new System.Windows.Forms.TabPage();
            this.menuBox = new System.Windows.Forms.GroupBox();
            this.raiseButton = new System.Windows.Forms.Button();
            this.callButton = new System.Windows.Forms.Button();
            this.foldButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.raiseChipsLbl = new System.Windows.Forms.Label();
            this.pageHandler.SuspendLayout();
            this.loginScreen.SuspendLayout();
            this.signupScreen.SuspendLayout();
            this.mainScreen.SuspendLayout();
            this.gameScreen.SuspendLayout();
            this.menuBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pageHandler
            // 
            this.pageHandler.Controls.Add(this.loginScreen);
            this.pageHandler.Controls.Add(this.signupScreen);
            this.pageHandler.Controls.Add(this.mainScreen);
            this.pageHandler.Controls.Add(this.loggedInMainScreen);
            this.pageHandler.Controls.Add(this.gameScreen);
            this.pageHandler.Location = new System.Drawing.Point(-17, -39);
            this.pageHandler.Name = "pageHandler";
            this.pageHandler.SelectedIndex = 0;
            this.pageHandler.Size = new System.Drawing.Size(942, 730);
            this.pageHandler.TabIndex = 0;
            // 
            // loginScreen
            // 
            this.loginScreen.BackgroundImage = global::Poker_Online.Properties.Resources.image2;
            this.loginScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginScreen.Controls.Add(this.loginPageGoBackButton);
            this.loginScreen.Controls.Add(this.loginButton);
            this.loginScreen.Controls.Add(this.label2);
            this.loginScreen.Controls.Add(this.label1);
            this.loginScreen.Controls.Add(this.passwordTextBox);
            this.loginScreen.Controls.Add(this.userNameTextbox);
            this.loginScreen.Location = new System.Drawing.Point(4, 22);
            this.loginScreen.Name = "loginScreen";
            this.loginScreen.Padding = new System.Windows.Forms.Padding(3);
            this.loginScreen.Size = new System.Drawing.Size(934, 704);
            this.loginScreen.TabIndex = 0;
            this.loginScreen.Text = "loginScreen";
            this.loginScreen.UseVisualStyleBackColor = true;
            // 
            // loginPageGoBackButton
            // 
            this.loginPageGoBackButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.loginPageGoBackButton.Location = new System.Drawing.Point(63, 73);
            this.loginPageGoBackButton.Name = "loginPageGoBackButton";
            this.loginPageGoBackButton.Size = new System.Drawing.Size(75, 23);
            this.loginPageGoBackButton.TabIndex = 5;
            this.loginPageGoBackButton.Text = "Go back!";
            this.loginPageGoBackButton.UseVisualStyleBackColor = true;
            this.loginPageGoBackButton.Click += new System.EventHandler(this.loginPageGoBackButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.loginButton.Location = new System.Drawing.Point(428, 138);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(133, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(133, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(226, 185);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(172, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // userNameTextbox
            // 
            this.userNameTextbox.Location = new System.Drawing.Point(226, 138);
            this.userNameTextbox.Name = "userNameTextbox";
            this.userNameTextbox.Size = new System.Drawing.Size(172, 20);
            this.userNameTextbox.TabIndex = 0;
            // 
            // signupScreen
            // 
            this.signupScreen.BackgroundImage = global::Poker_Online.Properties.Resources.image;
            this.signupScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.signupScreen.Controls.Add(this.signupStatusLabel);
            this.signupScreen.Controls.Add(this.signupRegisterButton);
            this.signupScreen.Controls.Add(this.signupGoBackButton);
            this.signupScreen.Controls.Add(this.signupPasswordTextbox);
            this.signupScreen.Controls.Add(this.signupUserTextbox);
            this.signupScreen.Controls.Add(this.label4);
            this.signupScreen.Controls.Add(this.label3);
            this.signupScreen.Location = new System.Drawing.Point(4, 22);
            this.signupScreen.Name = "signupScreen";
            this.signupScreen.Padding = new System.Windows.Forms.Padding(3);
            this.signupScreen.Size = new System.Drawing.Size(934, 704);
            this.signupScreen.TabIndex = 1;
            this.signupScreen.Text = "signupScreen";
            this.signupScreen.UseVisualStyleBackColor = true;
            // 
            // signupStatusLabel
            // 
            this.signupStatusLabel.AutoSize = true;
            this.signupStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.signupStatusLabel.Location = new System.Drawing.Point(243, 211);
            this.signupStatusLabel.Name = "signupStatusLabel";
            this.signupStatusLabel.Size = new System.Drawing.Size(0, 20);
            this.signupStatusLabel.TabIndex = 6;
            // 
            // signupRegisterButton
            // 
            this.signupRegisterButton.Location = new System.Drawing.Point(416, 135);
            this.signupRegisterButton.Name = "signupRegisterButton";
            this.signupRegisterButton.Size = new System.Drawing.Size(75, 23);
            this.signupRegisterButton.TabIndex = 5;
            this.signupRegisterButton.Text = "Register";
            this.signupRegisterButton.UseVisualStyleBackColor = true;
            this.signupRegisterButton.Click += new System.EventHandler(this.signupRegisterButton_Click);
            // 
            // signupGoBackButton
            // 
            this.signupGoBackButton.Location = new System.Drawing.Point(60, 87);
            this.signupGoBackButton.Name = "signupGoBackButton";
            this.signupGoBackButton.Size = new System.Drawing.Size(75, 23);
            this.signupGoBackButton.TabIndex = 4;
            this.signupGoBackButton.Text = "Go back!";
            this.signupGoBackButton.UseVisualStyleBackColor = true;
            this.signupGoBackButton.Click += new System.EventHandler(this.signupGoBackButton_Click);
            // 
            // signupPasswordTextbox
            // 
            this.signupPasswordTextbox.Location = new System.Drawing.Point(244, 178);
            this.signupPasswordTextbox.Name = "signupPasswordTextbox";
            this.signupPasswordTextbox.Size = new System.Drawing.Size(141, 20);
            this.signupPasswordTextbox.TabIndex = 3;
            // 
            // signupUserTextbox
            // 
            this.signupUserTextbox.Location = new System.Drawing.Point(244, 138);
            this.signupUserTextbox.Name = "signupUserTextbox";
            this.signupUserTextbox.Size = new System.Drawing.Size(141, 20);
            this.signupUserTextbox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(156, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(156, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username:";
            // 
            // mainScreen
            // 
            this.mainScreen.Controls.Add(this.existUserButton);
            this.mainScreen.Controls.Add(this.newUserButton);
            this.mainScreen.Location = new System.Drawing.Point(4, 22);
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.Padding = new System.Windows.Forms.Padding(3);
            this.mainScreen.Size = new System.Drawing.Size(934, 704);
            this.mainScreen.TabIndex = 2;
            this.mainScreen.Text = "mainScreen";
            this.mainScreen.UseVisualStyleBackColor = true;
            // 
            // existUserButton
            // 
            this.existUserButton.Location = new System.Drawing.Point(548, 292);
            this.existUserButton.Name = "existUserButton";
            this.existUserButton.Size = new System.Drawing.Size(107, 23);
            this.existUserButton.TabIndex = 1;
            this.existUserButton.Text = "Existing User";
            this.existUserButton.UseVisualStyleBackColor = true;
            this.existUserButton.Click += new System.EventHandler(this.existUserButton_Click);
            // 
            // newUserButton
            // 
            this.newUserButton.Location = new System.Drawing.Point(233, 292);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(75, 23);
            this.newUserButton.TabIndex = 0;
            this.newUserButton.Text = "New User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // loggedInMainScreen
            // 
            this.loggedInMainScreen.Location = new System.Drawing.Point(4, 22);
            this.loggedInMainScreen.Name = "loggedInMainScreen";
            this.loggedInMainScreen.Size = new System.Drawing.Size(934, 704);
            this.loggedInMainScreen.TabIndex = 3;
            this.loggedInMainScreen.Text = "tabPage1";
            this.loggedInMainScreen.UseVisualStyleBackColor = true;
            // 
            // gameScreen
            // 
            this.gameScreen.Controls.Add(this.menuBox);
            this.gameScreen.Location = new System.Drawing.Point(4, 22);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(934, 704);
            this.gameScreen.TabIndex = 4;
            this.gameScreen.Text = "tabPage1";
            this.gameScreen.UseVisualStyleBackColor = true;
            // 
            // menuBox
            // 
            this.menuBox.BackColor = System.Drawing.Color.Silver;
            this.menuBox.Controls.Add(this.raiseChipsLbl);
            this.menuBox.Controls.Add(this.trackBar1);
            this.menuBox.Controls.Add(this.raiseButton);
            this.menuBox.Controls.Add(this.callButton);
            this.menuBox.Controls.Add(this.foldButton);
            this.menuBox.Location = new System.Drawing.Point(225, 229);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(455, 217);
            this.menuBox.TabIndex = 0;
            this.menuBox.TabStop = false;
            this.menuBox.Text = "Menu";
            this.menuBox.Enter += new System.EventHandler(this.menuBox_Enter);
            // 
            // raiseButton
            // 
            this.raiseButton.Location = new System.Drawing.Point(331, 81);
            this.raiseButton.Name = "raiseButton";
            this.raiseButton.Size = new System.Drawing.Size(102, 35);
            this.raiseButton.TabIndex = 2;
            this.raiseButton.Text = "Raise";
            this.raiseButton.UseVisualStyleBackColor = true;
            // 
            // callButton
            // 
            this.callButton.Location = new System.Drawing.Point(181, 81);
            this.callButton.Name = "callButton";
            this.callButton.Size = new System.Drawing.Size(102, 35);
            this.callButton.TabIndex = 1;
            this.callButton.Text = "Call";
            this.callButton.UseVisualStyleBackColor = true;
            // 
            // foldButton
            // 
            this.foldButton.Location = new System.Drawing.Point(29, 81);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(102, 35);
            this.foldButton.TabIndex = 0;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = true;
            this.foldButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(329, 122);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // raiseChipsLbl
            // 
            this.raiseChipsLbl.AutoSize = true;
            this.raiseChipsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.raiseChipsLbl.Location = new System.Drawing.Point(374, 150);
            this.raiseChipsLbl.Name = "raiseChipsLbl";
            this.raiseChipsLbl.Size = new System.Drawing.Size(16, 17);
            this.raiseChipsLbl.TabIndex = 4;
            this.raiseChipsLbl.Text = "0";
            this.raiseChipsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 663);
            this.Controls.Add(this.pageHandler);
            this.Name = "Form1";
            this.Text = "Poker Online";
            this.pageHandler.ResumeLayout(false);
            this.loginScreen.ResumeLayout(false);
            this.loginScreen.PerformLayout();
            this.signupScreen.ResumeLayout(false);
            this.signupScreen.PerformLayout();
            this.mainScreen.ResumeLayout(false);
            this.gameScreen.ResumeLayout(false);
            this.menuBox.ResumeLayout(false);
            this.menuBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl pageHandler;
        private System.Windows.Forms.TabPage loginScreen;
        private System.Windows.Forms.TabPage signupScreen;
        private System.Windows.Forms.TabPage mainScreen;
        private System.Windows.Forms.Button existUserButton;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button loginPageGoBackButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox userNameTextbox;
        private System.Windows.Forms.Button signupRegisterButton;
        private System.Windows.Forms.Button signupGoBackButton;
        private System.Windows.Forms.TextBox signupPasswordTextbox;
        private System.Windows.Forms.TextBox signupUserTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label signupStatusLabel;
        private System.Windows.Forms.TabPage loggedInMainScreen;
        private System.Windows.Forms.TabPage gameScreen;
        private System.Windows.Forms.GroupBox menuBox;
        private System.Windows.Forms.Button foldButton;
        private System.Windows.Forms.Button raiseButton;
        private System.Windows.Forms.Button callButton;
        private System.Windows.Forms.Label raiseChipsLbl;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

