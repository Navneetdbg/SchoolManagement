using School.Globals;
using School.Services;
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
    public partial class Forget : Form
    {
        public Forget()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.IsFormValid())
            {
                lblError.Text = "Error ! Enter All Valid Feilds"; lblError.ForeColor = Color.Red;
                return;
            }
            if (!txtEmail.Text.IsEmail())
            {
                lblError.Text = "Error ! Email Not Valid"; lblError.ForeColor = Color.Red;
                return;
            }
            pictureBoxLoad.Show();
            var user = await UsersServices.Instance.ForgetPassword(new Entities.User() { Email = txtEmail.Text });
            if (user == true)
            {
                lblError.Text = "Check Your Email To Retreive Your Password";
                lblError.ForeColor = Color.GreenYellow;
            }

            else
            {
                lblError.Text = "User Doesn't Exist";
                lblError.ForeColor = Color.Red;
            }
            pictureBoxLoad.Hide();
        }

        private void Forget_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            this.Hide();
            register.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Login register = new Login();
            this.Hide();
            register.ShowDialog();
        }
    }
}
