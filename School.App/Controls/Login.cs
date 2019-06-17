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
using School.Entities;
using School.Globals;
using School.App.Design;
using School.Database.Enum;

namespace School.App.Controls
{
    public partial class Login : UserControl
    {
        #region Singleton Service
        public static Login Instance
        {
            get
            {
                if (instance == null) instance = new Login();
                return instance;
            }
        }

        private static Login instance { get; set; }
        private Login()
        {
            InitializeComponent();
        }

        #endregion

        private async void button1_Click(object sender, EventArgs e)
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
            User user = new User() {
                Email = txtEmail.Text,
                Password = txtPass.Text,
                Name = Name
            };
            
            pictureBoxLoad.Show();
            var v = await UsersServices.Instance.UserLog(user);
            var newEnum = (Ennumation.Login)Enum.Parse(typeof(Ennumation.Login), v.ToString());
            if (Ennumation.Login.Success.ToString().Equals(newEnum.ToString()))
            {

                Globals.Session.Instance.user = user;
                Form1 form = new Form1();
                form.Show();

            }
            else
            {

                lblError.ForeColor = Color.Red;

                switch(newEnum)
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
    }
}
