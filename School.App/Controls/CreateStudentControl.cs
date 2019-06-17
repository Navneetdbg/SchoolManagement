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

namespace School.App.Controls
{
    public partial class CreateStudentUserControl : UserControl
    {
        #region Singleton Service
        public static CreateStudentUserControl Instance
        {
            get
            {
                if (instance == null) instance = new CreateStudentUserControl();
                return instance;
            }
        }

        private static CreateStudentUserControl instance { get; set; }
        private CreateStudentUserControl()
        {
            InitializeComponent();
        }

        #endregion

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!txtSchoolName.Text.IsFormValid() || !txtGender.Text.IsFormValid() ||!RTxtAddress.Text.IsFormValid()||!txtParent.Text.IsFormValid()||!txtparentGender.Text.IsFormValid())
            {
                lblerror.Text = "Valid Feild";
                lblerror.ForeColor = Color.Red;
            }

            Student student = new Student();
            student.Name = txtSchoolName.Text;
            student.Gender = txtGender.Text;
            student.DateofBirth = dateTimePicker1.Value;
            string Class = ClassCombo.SelectedItem.ToString();
            
            string City = CityCombo.SelectedItem.ToString();
            var x = await StudentServices.Instance.GetCity(City);

            Address address = new Address();
            address.Details = RTxtAddress.Text;
            address.CityId = x.Id;
            Parent parent = new Parent();
            parent.Name = txtParent.Text;
            parent.Gender = txtparentGender.Text;
            parent.Addresses = new List<Address>();

            parent.Addresses.Add(address);
            parent.Name = txtParent.Text;
            student.Parents = new List<Parent>();

            student.Parents.Add(parent);

            student.Addresses = new List<Address>();
            student.Addresses.Add(address);
            var result = await StudentServices.Instance.SaveDataStudent(student,Class);
            if(result == true)
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

        private async void CreateStudentUserControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Show();
            List<Country> countries = await CountriesServices.Instance.GetAllCountries();
            pictureBox1.Hide();
            foreach (Country item in countries)
            {
                CountryCombo.Items.Add(item.Name);
            }
        }

        private async void CountryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Country = CountryCombo.SelectedItem.ToString();

            pictureBox1.Show();
            List<City> cities = await CitiesServices.Instance.GetCitiesByName(Country);

            foreach (City item in cities)
            {
                CityCombo.Items.Add(item.Name);
            }
            pictureBox1.Hide();
        }

        private async void CityCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Country = CityCombo.SelectedItem.ToString();

            pictureBox1.Show();
            List<SchoolClass> cities = await SchoolClassServices.Instance.GetSchoolsByName(Country);

            foreach (SchoolClass item in cities)
            {
                SchoolCombo.Items.Add(item.Name);
            }
            pictureBox1.Hide();
        }

        private async void SchoolCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Class = SchoolCombo.SelectedItem.ToString();
            pictureBox1.Show();
            List<Class> classes = await ClassServices.Instance.GetClasses(Class);

            foreach (Class item in classes)
            {
                ClassCombo.Items.Add(item.Name);
            }
            pictureBox1.Hide();

        }
    }
}
