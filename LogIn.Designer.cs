namespace StudentPerformanceTracker
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogInbtn = new System.Windows.Forms.Button();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.Logintxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Closebtn = new System.Windows.Forms.Button();
            this.pb_showPassword = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pb_showPassword);
            this.panel1.Controls.Add(this.LogInbtn);
            this.panel1.Controls.Add(this.Passwordtxt);
            this.panel1.Controls.Add(this.Logintxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(724, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 290);
            this.panel1.TabIndex = 5;
            // 
            // LogInbtn
            // 
            this.LogInbtn.BackColor = System.Drawing.Color.Navy;
            this.LogInbtn.FlatAppearance.BorderSize = 0;
            this.LogInbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogInbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInbtn.ForeColor = System.Drawing.Color.White;
            this.LogInbtn.Location = new System.Drawing.Point(34, 247);
            this.LogInbtn.Name = "LogInbtn";
            this.LogInbtn.Size = new System.Drawing.Size(170, 29);
            this.LogInbtn.TabIndex = 5;
            this.LogInbtn.Text = "Log In";
            this.LogInbtn.UseVisualStyleBackColor = false;
            this.LogInbtn.Click += new System.EventHandler(this.LogInbtn_Click);
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Passwordtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Passwordtxt.Location = new System.Drawing.Point(35, 197);
            this.Passwordtxt.Multiline = true;
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.PasswordChar = '●';
            this.Passwordtxt.Size = new System.Drawing.Size(170, 26);
            this.Passwordtxt.TabIndex = 4;
            this.Passwordtxt.TextChanged += new System.EventHandler(this.Passwordtxt_TextChanged);
            // 
            // Logintxt
            // 
            this.Logintxt.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Logintxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Logintxt.Location = new System.Drawing.Point(34, 144);
            this.Logintxt.Multiline = true;
            this.Logintxt.Name = "Logintxt";
            this.Logintxt.Size = new System.Drawing.Size(170, 24);
            this.Logintxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(34, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(34, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.White;
            this.Closebtn.BackgroundImage = global::StudentPerformanceTracker.Properties.Resources.Exit;
            this.Closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.Location = new System.Drawing.Point(954, -1);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(31, 28);
            this.Closebtn.TabIndex = 6;
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // pb_showPassword
            // 
            this.pb_showPassword.Image = global::StudentPerformanceTracker.Properties.Resources.show;
            this.pb_showPassword.Location = new System.Drawing.Point(182, 197);
            this.pb_showPassword.Name = "pb_showPassword";
            this.pb_showPassword.Size = new System.Drawing.Size(23, 26);
            this.pb_showPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_showPassword.TabIndex = 6;
            this.pb_showPassword.TabStop = false;
            this.pb_showPassword.Visible = false;
            this.pb_showPassword.Click += new System.EventHandler(this.pb_showPassword_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::StudentPerformanceTracker.Properties.Resources.LOGO;
            this.pictureBox2.Location = new System.Drawing.Point(86, 36);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(0, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(985, 542);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LogIn
            // 
            this.AcceptButton = this.LogInbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 541);
            this.Controls.Add(this.Closebtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_showPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LogInbtn;
        private System.Windows.Forms.TextBox Passwordtxt;
        private System.Windows.Forms.TextBox Logintxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.PictureBox pb_showPassword;
    }
}

