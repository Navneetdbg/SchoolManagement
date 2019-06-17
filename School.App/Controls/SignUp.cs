using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School.Entities;
using School.Services;
using School.Globals;
using School.Database.Enum;

namespace School.App.Controls
{
    public partial class SignUp : UserControl
    {
        #region Singleton Service
        public static SignUp Instance
        {
            get
            {
                if (instance == null) instance = new SignUp();
                return instance;
            }
        }

        private static SignUp instance { get; set; }
        private SignUp()
        {
            InitializeComponent();
        }

        #endregion

        private async void btnSignup_Click(object sender, EventArgs e)
        {
            if (!txtName.Text.IsFormValid() || !txtEmail.Text.IsFormValid() || !txtpass.Text.IsFormValid() || !txtConfirm.Text.IsFormValid())
            {
                lblError.Text = "Error ! Enter All Valid Feilds"; lblError.ForeColor = Color.Red;
                return;
            }
            if (!txtEmail.Text.IsEmail())
            {
                lblError.Text = "Error ! Email Not Valid"; lblError.ForeColor = Color.Red;
                return;
            }
            
            
            if (txtpass.Text == txtConfirm.Text)
            {

                User user = new User();
                user.Email = txtEmail.Text;
                user.Password = txtpass.Text;
                user.Name = txtName.Text;
                pictureBoxLoad.Show();
                var result = await UsersServices.Instance.RegisterUser(user);
                var registerUserStatus = (Ennumation.Register)Enum.Parse(typeof(Ennumation.Register), result.ToString());
                if (Ennumation.Register.Success.ToString().Equals(result.ToString()))
                {
                    lblError.Text = "User Register Successfully";
                    lblError.ForeColor = Color.ForestGreen;

                }
                else {
                    
                    lblError.ForeColor = Color.Red;
                    switch(registerUserStatus)
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
