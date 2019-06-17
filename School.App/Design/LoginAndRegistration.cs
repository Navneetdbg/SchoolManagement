using School.App.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.App.Design
{
    public partial class LoginAndRegistration : Form
    {
        public LoginAndRegistration()
        {
            InitializeComponent();
        }
        public void ShowControl(Control Layout)
        {
            if (!RightSidePanel.Controls.Contains(Layout))
            {
                RightSidePanel.Controls.Add(Layout);
                Layout.Dock = DockStyle.Fill;
                Layout.BringToFront();
                Layout.Focus();

            }
            else
            {
                Layout.BringToFront();
            }
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            /*ShowControl(Login.Instance)*/;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            ShowControl(SignUp.Instance);
        }

        private void LoginAndRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void forgetPassword_Click(object sender, EventArgs e)
        {
            ShowControl(ForgetPassword.Instance);
        }
    }
}
