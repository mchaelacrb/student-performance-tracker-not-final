namespace StudentPerformanceTracker.Admin
{
    partial class Add_Subject
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Closebtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.s_name = new System.Windows.Forms.TextBox();
            this.s_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.s_description = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Savebtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DepComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.Closebtn);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 34);
            this.panel2.TabIndex = 52;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(6, 33);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(11, 327);
            this.panel5.TabIndex = 33;
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.DarkBlue;
            this.Closebtn.BackgroundImage = global::StudentPerformanceTracker.Properties.Resources.icon__Times_Circle_;
            this.Closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.Location = new System.Drawing.Point(316, 7);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(18, 20);
            this.Closebtn.TabIndex = 32;
            this.Closebtn.UseVisualStyleBackColor = false;
            this.Closebtn.Click += new System.EventHandler(this.Closebtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Add Subject";
            // 
            // s_name
            // 
            this.s_name.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.s_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.s_name.Location = new System.Drawing.Point(117, 75);
            this.s_name.Multiline = true;
            this.s_name.Name = "s_name";
            this.s_name.Size = new System.Drawing.Size(179, 20);
            this.s_name.TabIndex = 28;
            // 
            // s_code
            // 
            this.s_code.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.s_code.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.s_code.Location = new System.Drawing.Point(118, 43);
            this.s_code.Multiline = true;
            this.s_code.Name = "s_code";
            this.s_code.Size = new System.Drawing.Size(96, 20);
            this.s_code.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(18, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Subject Description :";
            // 
            // s_description
            // 
            this.s_description.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.s_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.s_description.Location = new System.Drawing.Point(21, 127);
            this.s_description.Multiline = true;
            this.s_description.Name = "s_description";
            this.s_description.Size = new System.Drawing.Size(270, 112);
            this.s_description.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(18, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Subject Name :";
            // 
            // Savebtn
            // 
            this.Savebtn.BackColor = System.Drawing.Color.MediumBlue;
            this.Savebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Savebtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Savebtn.ForeColor = System.Drawing.Color.White;
            this.Savebtn.Location = new System.Drawing.Point(254, 321);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(74, 28);
            this.Savebtn.TabIndex = 51;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = false;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(18, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Subject Code :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.DepComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.s_name);
            this.panel1.Controls.Add(this.s_code);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.s_description);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 253);
            this.panel1.TabIndex = 50;
            // 
            // DepComboBox
            // 
            this.DepComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DepComboBox.FormattingEnabled = true;
            this.DepComboBox.Location = new System.Drawing.Point(117, 12);
            this.DepComboBox.Name = "DepComboBox";
            this.DepComboBox.Size = new System.Drawing.Size(96, 21);
            this.DepComboBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(25, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Department :";
            // 
            // Add_Subject
            // 
            this.AcceptButton = this.Savebtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(349, 363);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Subject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Subject";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox s_name;
        private System.Windows.Forms.TextBox s_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox s_description;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox DepComboBox;
        private System.Windows.Forms.Label label3;
    }
}