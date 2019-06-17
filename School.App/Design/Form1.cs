using School.App.Controls;
using School.App.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School.App.AllExt;

namespace School.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           if( Globals.Session.Instance.IsLogin)
            {
                LoginAndRegistration login = new LoginAndRegistration();
                login.Hide();
                lblEmail.Text = "Welcome" +":        " + Globals.Session.Instance.user.Name;
                pictureBox1.Image = Globals.Session.Instance.user.Image.ComveryByteArrayToImage();
            }
            //else
            //{
            //    Application.Exit();
            //}
        }

        private void BtnSchool_Click(object sender, EventArgs e)
        {
            
            ShowControl(SchoolUserControl.Instance);
        }

        public void ShowControl(Control Layout)
        {
            if (!RightPanel.Controls.Contains(Layout))
            {
                RightPanel.Controls.Add(Layout);
                Layout.Dock = DockStyle.Fill;
                Layout.BringToFront();
                Layout.Focus();
               
            }
            else
            {
                Layout.BringToFront();
            }
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            
            ShowControl(CreateClassControl.Instance);
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            ShowControl(TeacherUserControl.Instance);
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            ShowControl(CountryUserControl.Instance);
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            ShowControl(UserProfile.Instance);
        }

        private void txtSubject_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {
            ShowControl(UserProfile.Instance);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ShowControl(UserProfile.Instance);
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            ShowControl(CreateStudentUserControl.Instance);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ShowControl(UserProfile.Instance);
        }
    }
    
}
