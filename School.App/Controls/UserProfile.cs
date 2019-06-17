using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School.Globals;
using School.Entities;
using School.Services;
using School.Database.Enum;
using School.App.AllExt;

namespace School.App.Controls
{
    public partial class UserProfile : UserControl
    {
        #region Singleton Service
        public static UserProfile Instance
        {
            get
            {
                if (instance == null) instance = new UserProfile();
                return instance;
            }
        }

        private static UserProfile instance { get; set; }
        private UserProfile()
        {
            InitializeComponent();
        }

        #endregion

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if ( !txtPassword.Text.IsFormValid()&& !txtName.Text.IsFormValid() && !txtConfirm.Text.IsFormValid())
            {
                lblError.Text = "Error ! Enter All Valid Feilds"; lblError.ForeColor = Color.Red;
                return;
            }

            if (txtPassword.Text == txtConfirm.Text)
            {
                User user = Globals.Session.Instance.user;
                user.Name = txtName.Text;
                user.Password = txtPassword.Text;
                user.Email = Globals.Session.Instance.user.Email;
                user.Image = pictureBox1.Image.ConvertImageToArray();

                pictureBoxLoad.Show();
                var v = await UsersServices.Instance.UpdateUser(user);
                var newEnum = (Ennumation.Register)Enum.Parse(typeof(Ennumation.Register), v.ToString());
                if (Ennumation.Login.Success.ToString().Equals(newEnum.ToString()))
                {
                    lblError.Text = "Successfully Updated";
                    lblError.ForeColor = Color.GreenYellow;
                }
                else
                {

                    lblError.ForeColor = Color.Red;

                    switch (newEnum)
                    {
                        case Ennumation.Register.RegisterFailed:
                            {
                                lblError.Text = "Some Error";
                                break;
                            }


                        default:
                            {
                                lblError.Text = "Try Again Later";
                                break;
                            }
                    }

                }
            }
            pictureBoxLoad.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(opnfd.FileName);
                
            }
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            txtName.Text = Globals.Session.Instance.user.Name.ToString();
            txtPassword.Text = Globals.Session.Instance.user.Password;
            txtConfirm.Text = Globals.Session.Instance.user.Password;
            pictureBox1.Image = Globals.Session.Instance.user.Image.ComveryByteArrayToImage();
        }
    }
}
