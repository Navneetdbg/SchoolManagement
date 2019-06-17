using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School.Services;
using School.Globals;

namespace School.App.Controls
{
    public partial class ForgetPassword : UserControl
    {
        #region Singleton Service
        public static ForgetPassword Instance
        {
            get
            {
                if (instance == null) instance = new ForgetPassword();
                return instance;
            }
        }

        private static ForgetPassword instance { get; set; }
        private ForgetPassword()
        {
            InitializeComponent();
        }

        #endregion

        private async void Forget_Click(object sender, EventArgs e)
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
           var user= await  UsersServices.Instance.ForgetPassword(new Entities.User() { Email = txtEmail.Text });
            if(user == true)
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
    }
}
