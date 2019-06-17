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

namespace School.App.Controls
{
    public partial class TeacherUserControl : UserControl
    {
        #region Singleton Service
        public static TeacherUserControl Instance
        {
            get
            {
                if (instance == null) instance = new TeacherUserControl();
                return instance;
            }
        }

        private static TeacherUserControl instance { get; set; }
        private TeacherUserControl()
        {
            InitializeComponent();
        }

        #endregion

        private async void TeacherUserControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Show();
            List<Country> countries = await CountriesServices.Instance.GetAllCountries();
            pictureBox1.Hide();
            foreach (Country item in countries)
            {
                comboBox1.Items.Add(item.Name);
            }
           
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!txtGender.Text.IsFormValid() || !RTxtAddress.Text.IsFormValid() || !txtSchoolName.Text.IsFormValid())
            {
                lblerror.Text = "Fill All Valid Column";
                lblerror.ForeColor = Color.Red;
                return;
            }

            Teacher model = new Teacher();
            model.Name = txtSchoolName.Text;
            model.Gender = txtGender.Text;
            

            Address address = new Address();
            
            string cityAdd = comboBox2.SelectedItem.ToString();
            address.Details = RTxtAddress.Text;
            model.Addresses = new List<Address>();
            model.Addresses.Add(address);
            string School = SchoolCombo.SelectedItem.ToString();
            


            var result = await TeacherServices.Instance.SaveDataofTeacher(model, School, cityAdd);
            
            if (result == true)
            {
               

                lblerror.Text = "Data Inserted";
                lblerror.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblerror.Text = "Data Not Inserted";
                lblerror.ForeColor = Color.Red;

            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string Country = comboBox1.SelectedItem.ToString();
            
            pictureBox1.Show();
            List<City> cities = await CitiesServices.Instance.GetCitiesByName(Country);

            foreach(City item in cities)
            {
                comboBox2.Items.Add(item.Name);
            }
            pictureBox1.Hide();
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Country = comboBox2.SelectedItem.ToString();
            
            pictureBox1.Show();
            List<SchoolClass> cities = await SchoolClassServices.Instance.GetSchoolsByName(Country);

            foreach (SchoolClass item in cities)
            {
                SchoolCombo.Items.Add(item.Name);
            }
            pictureBox1.Hide();
        }
    }
}
