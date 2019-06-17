namespace School.App
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
            this.MenuLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnSchool = new System.Windows.Forms.Button();
            this.btnClass = new System.Windows.Forms.Button();
            this.btnTeacher = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnCountry = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.MenuLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuLayoutPanel
            // 
            this.MenuLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MenuLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.MenuLayoutPanel.Controls.Add(this.panel1);
            this.MenuLayoutPanel.Controls.Add(this.BtnSchool);
            this.MenuLayoutPanel.Controls.Add(this.btnClass);
            this.MenuLayoutPanel.Controls.Add(this.btnTeacher);
            this.MenuLayoutPanel.Controls.Add(this.btnStudent);
            this.MenuLayoutPanel.Controls.Add(this.btnCountry);
            this.MenuLayoutPanel.Location = new System.Drawing.Point(1, 1);
            this.MenuLayoutPanel.Name = "MenuLayoutPanel";
            this.MenuLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MenuLayoutPanel.Size = new System.Drawing.Size(220, 622);
            this.MenuLayoutPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblEmail);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 150);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Image = global::School.App.Properties.Resources.settings_work_tool;
            this.label1.Location = new System.Drawing.Point(178, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.lblEmail.Location = new System.Drawing.Point(2, 122);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(170, 19);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Click += new System.EventHandler(this.lblEmail_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::School.App.Properties.Resources.default_profile_01;
            this.pictureBox1.Location = new System.Drawing.Point(32, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // BtnSchool
            // 
            this.BtnSchool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.BtnSchool.FlatAppearance.BorderSize = 0;
            this.BtnSchool.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSchool.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.BtnSchool.Image = global::School.App.Properties.Resources.Class_icon_32;
            this.BtnSchool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSchool.Location = new System.Drawing.Point(8, 164);
            this.BtnSchool.Name = "BtnSchool";
            this.BtnSchool.Padding = new System.Windows.Forms.Padding(2);
            this.BtnSchool.Size = new System.Drawing.Size(204, 52);
            this.BtnSchool.TabIndex = 3;
            this.BtnSchool.Text = "School";
            this.BtnSchool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSchool.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSchool.UseVisualStyleBackColor = false;
            this.BtnSchool.Click += new System.EventHandler(this.BtnSchool_Click);
            // 
            // btnClass
            // 
            this.btnClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnClass.FlatAppearance.BorderSize = 0;
            this.btnClass.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.btnClass.Image = global::School.App.Properties.Resources.Class_icon_32;
            this.btnClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClass.Location = new System.Drawing.Point(8, 222);
            this.btnClass.Name = "btnClass";
            this.btnClass.Padding = new System.Windows.Forms.Padding(2);
            this.btnClass.Size = new System.Drawing.Size(204, 50);
            this.btnClass.TabIndex = 2;
            this.btnClass.Text = "Class";
            this.btnClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClass.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClass.UseVisualStyleBackColor = false;
            this.btnClass.Click += new System.EventHandler(this.btnClass_Click);
            // 
            // btnTeacher
            // 
            this.btnTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnTeacher.FlatAppearance.BorderSize = 0;
            this.btnTeacher.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.btnTeacher.Image = global::School.App.Properties.Resources.teacher_icon_32;
            this.btnTeacher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeacher.Location = new System.Drawing.Point(8, 278);
            this.btnTeacher.Name = "btnTeacher";
            this.btnTeacher.Padding = new System.Windows.Forms.Padding(2);
            this.btnTeacher.Size = new System.Drawing.Size(204, 50);
            this.btnTeacher.TabIndex = 1;
            this.btnTeacher.Text = "Teacher";
            this.btnTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeacher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTeacher.UseVisualStyleBackColor = false;
            this.btnTeacher.Click += new System.EventHandler(this.btnTeacher_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.btnStudent.Image = global::School.App.Properties.Resources.student_Icon_32;
            this.btnStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.Location = new System.Drawing.Point(8, 334);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(2);
            this.btnStudent.Size = new System.Drawing.Size(204, 50);
            this.btnStudent.TabIndex = 0;
            this.btnStudent.Text = "Student";
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnCountry
            // 
            this.btnCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(216)))), ((int)(((byte)(220)))));
            this.btnCountry.FlatAppearance.BorderSize = 0;
            this.btnCountry.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.btnCountry.Image = global::School.App.Properties.Resources.Class_icon_32;
            this.btnCountry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCountry.Location = new System.Drawing.Point(8, 390);
            this.btnCountry.Name = "btnCountry";
            this.btnCountry.Padding = new System.Windows.Forms.Padding(2);
            this.btnCountry.Size = new System.Drawing.Size(204, 50);
            this.btnCountry.TabIndex = 6;
            this.btnCountry.Text = "Country-City";
            this.btnCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCountry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCountry.UseVisualStyleBackColor = false;
            this.btnCountry.Click += new System.EventHandler(this.btnCountry_Click);
            // 
            // RightPanel
            // 
            this.RightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(36)))), ((int)(((byte)(170)))));
            this.RightPanel.Location = new System.Drawing.Point(219, 1);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(796, 622);
            this.RightPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(741, 622);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.MenuLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MenuLayoutPanel;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnTeacher;
        private System.Windows.Forms.Button btnClass;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button BtnSchool;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCountry;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

