using School.Database.Enum;
using School.Entities;
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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

       

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.IsFormValid() || !txtPass.Text.IsFormValid())
            {
                lblError.Text = "Error ! Enter All Valid Feilds"; lblError.ForeColor = Color.Red;
                return;
            }
            if (!txtEmail.Text.IsEmail())
            {
                lblError.Text = "Error ! Email Not Valid"; lblError.ForeColor = Color.Red;
                return;
            }
            User user = new User()
            {
                Email = txtEmail.Text,
                Password = txtPass.Text,
                
            };

            pictureBoxLoad.Show();
            var v = await UsersServices.Instance.UserLog(user);
            var newEnum = (Ennumation.Login)Enum.Parse(typeof(Ennumation.Login), v.ToString());
            if (Ennumation.Login.Success.ToString().Equals(newEnum.ToString()))
            {
                var newV = await UsersServices.Instance.GetDetailofUser(user.Email);
                user.Name = newV.Name;
                user.Password = newV.Password;
                user.Email = newV.Email;
                user.Image = newV.Image;
                Globals.Session.Instance.user = user;
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
            else
            {

                lblError.ForeColor = Color.Red;

                switch (newEnum)
                {
                    case Ennumation.Login.InvalidPassword:
                        {
                            lblError.Text = "Invalid Password";
                            break;
                        }
                    case Ennumation.Login.InvalidUser:
                        {
                            lblError.Text = "Invalid Email";
                            break;
                        }

                    default:
                        {
                            lblError.Text = "Try Again Later";
                            break;
                        }
                }

            }
            pictureBoxLoad.Hide();


        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
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
            Forget forget = new Forget();
            this.Hide();
            forget.ShowDialog();
        }
    }
    
}
