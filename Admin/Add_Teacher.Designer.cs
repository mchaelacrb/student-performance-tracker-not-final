namespace StudentPerformanceTracker.Admin
{
    partial class Add_Teacher
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
            this.Cancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Closebtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.t_first = new System.Windows.Forms.TextBox();
            this.t_last = new System.Windows.Forms.TextBox();
            this.t_dep = new System.Windows.Forms.ComboBox();
            this.t_sub = new System.Windows.Forms.ComboBox();
            this.t_save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Cancel.Location = new System.Drawing.Point(125, 268);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(57, 22);
            this.Cancel.TabIndex = 16;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(2, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 274);
            this.panel2.TabIndex = 33;
            // 
            // Closebtn
            // 
            this.Closebtn.BackColor = System.Drawing.Color.DarkBlue;
            this.Closebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Closebtn.FlatAppearance.BorderSize = 0;
            this.Closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebtn.ForeColor = System.Drawing.Color.White;
            this.Closebtn.Location = new System.Drawing.Point(234, 8);
            this.Closebtn.Name = "Closebtn";
            this.Closebtn.Size = new System.Drawing.Size(18, 20);
            this.Closebtn.TabIndex = 32;
            this.Closebtn.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(6, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Register Teacher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(17, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(26, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lastname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(33, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subject";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firstname";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.t_first);
            this.panel3.Controls.Add(this.t_last);
            this.panel3.Controls.Add(this.t_dep);
            this.panel3.Controls.Add(this.t_sub);
            this.panel3.Location = new System.Drawing.Point(13, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 206);
            this.panel3.TabIndex = 14;
            // 
            // t_first
            // 
            this.t_first.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.t_first.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_first.Location = new System.Drawing.Point(86, 27);
            this.t_first.Multiline = true;
            this.t_first.Name = "t_first";
            this.t_first.Size = new System.Drawing.Size(126, 20);
            this.t_first.TabIndex = 0;
            // 
            // t_last
            // 
            this.t_last.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.t_last.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.t_last.Location = new System.Drawing.Point(86, 70);
            this.t_last.Multiline = true;
            this.t_last.Name = "t_last";
            this.t_last.Size = new System.Drawing.Size(126, 22);
            this.t_last.TabIndex = 1;
            // 
            // t_dep
            // 
            this.t_dep.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.t_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.t_dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t_dep.FormattingEnabled = true;
            this.t_dep.Location = new System.Drawing.Point(86, 116);
            this.t_dep.Name = "t_dep";
            this.t_dep.Size = new System.Drawing.Size(126, 21);
            this.t_dep.TabIndex = 2;
            this.t_dep.SelectedIndexChanged += new System.EventHandler(this.t_dep_SelectedIndexChanged);
            // 
            // t_sub
            // 
            this.t_sub.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.t_sub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t_sub.FormattingEnabled = true;
            this.t_sub.Location = new System.Drawing.Point(85, 160);
            this.t_sub.Name = "t_sub";
            this.t_sub.Size = new System.Drawing.Size(127, 21);
            this.t_sub.TabIndex = 3;
            // 
            // t_save
            // 
            this.t_save.BackColor = System.Drawing.Color.MediumBlue;
            this.t_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.t_save.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.t_save.Location = new System.Drawing.Point(189, 268);
            this.t_save.Name = "t_save";
            this.t_save.Size = new System.Drawing.Size(63, 22);
            this.t_save.TabIndex = 13;
            this.t_save.Text = "Save";
            this.t_save.UseVisualStyleBackColor = false;
            this.t_save.Click += new System.EventHandler(this.t_save_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.Closebtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 34);
            this.panel1.TabIndex = 15;
            // 
            // Add_Teacher
            // 
            this.AcceptButton = this.t_save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(265, 308);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.t_save);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Teacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Teacher";
            this.Load += new System.EventHandler(this.Add_Teacher_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Closebtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox t_first;
        private System.Windows.Forms.TextBox t_last;
        private System.Windows.Forms.ComboBox t_dep;
        private System.Windows.Forms.ComboBox t_sub;
        private System.Windows.Forms.Button t_save;
        private System.Windows.Forms.Panel panel1;
    }
}