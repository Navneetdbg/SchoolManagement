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
    public partial class CreateClassControl : UserControl
    {

        #region Singleton Service
        public static CreateClassControl Instance
        {
            get
            {
                if (instance == null) instance = new CreateClassControl();
                return instance;
            }
        }

        private static CreateClassControl instance { get; set; }
        private CreateClassControl()
        {

            InitializeComponent();
        }





        #endregion

        private async void CreateClassControl_Load(object sender, EventArgs e)
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
            string schoolName = SchoolCombo.SelectedItem.ToString();
            pictureBox1.Show();
            List<Teacher> teachers = await TeacherServices.Instance.GetTeacher(schoolName);
            foreach (Teacher item in teachers)
            {
                TeacherCombo.Items.Add(item.Name);
            }
            pictureBox1.Hide();
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!txtGrade.Text.IsFormValid() || !txtName.Text.IsFormValid()||!txtSection.Text.IsFormValid()||!txtSubject.Text.IsFormValid() )
            {
                lblerror.Text = "Enter All Valid Feilds";
                lblerror.ForeColor = Color.Red;
            }

            Class clas = new Class();
            clas.Grade = int.Parse(txtGrade.Text);
            clas.Section = txtSection.Text;
            clas.Name = txtName.Text;
            Subject subject = new Subject();
            subject.Name = txtSubject.Text;
            
            
            string SchoolName = SchoolCombo.SelectedItem.ToString();
            string teacherName = TeacherCombo.SelectedItem.ToString();

            var result = await ClassServices.Instance.SaveClassData(clas, SchoolName, teacherName);
            pictureBox1.Show();
            if (result == true)
            {
                lblerror.Text = "Data Inserted Successfully";
                lblerror.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblerror.Text = "Error";
                lblerror.ForeColor = Color.Red;
            }
            pictureBox1.Hide();

        }
    }
}
