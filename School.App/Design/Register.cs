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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
       

        private void label6_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
            
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {

            if (!txtName.Text.IsFormValid() || !txtEmail.Text.IsFormValid() || !txtPass.Text.IsFormValid() || !txtConfirm.Text.IsFormValid())
            {
                lblError.Text = "Error ! Enter All Valid Feilds"; lblError.ForeColor = Color.Red;
                return;
            }
            if (!txtEmail.Text.IsEmail())
            {
                lblError.Text = "Error ! Email Not Valid"; lblError.ForeColor = Color.Red;
                return;
            }


            if (txtPass.Text == txtConfirm.Text)
            {

                User user = new User();
                user.Email = txtEmail.Text;
                user.Password = txtPass.Text;
                user.Name = txtName.Text;
                pictureBoxLoad.Show();
                var result = await UsersServices.Instance.RegisterUser(user);
                var registerUserStatus = (Ennumation.Register)Enum.Parse(typeof(Ennumation.Register), result.ToString());
                if (Ennumation.Register.Success.ToString().Equals(result.ToString()))
                {
                    lblError.Text = "User Register Successfully";
                    lblError.ForeColor = Color.ForestGreen;

                }
                else
                {

                    lblError.ForeColor = Color.Red;
                    switch (registerUserStatus)
                    {
                        case Ennumation.Register.EmailExist:
                            {
                                lblError.Text = "User Already Register";
                                break;
                            }

                        case Ennumation.Register.RegisterFailed:
                            {
                                lblError.Text = "Internal Error ! User Registration Failed";
                                break;
                            }
                        default:
                            {
                                lblError.Text = "Internal Error ! Try Again Later";
                                break;
                            }
                    }
                }
                pictureBoxLoad.Hide();
            }
            else { lblError.Text = "Password Not Match"; lblError.ForeColor = Color.Red; };
        }
    }
}
