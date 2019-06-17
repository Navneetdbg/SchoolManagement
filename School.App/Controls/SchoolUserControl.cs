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
using School.Database;
using School.Globals;



namespace School.App
{
    public partial class SchoolUserControl : UserControl
    {
        #region Singleton Service
        public static SchoolUserControl Instance
        {
            get
            {
                if (instance == null) instance = new SchoolUserControl();
                return instance;
            }
        }

        private static SchoolUserControl instance { get; set; }
        private SchoolUserControl()
        {
            InitializeComponent();
        }

        #endregion
       


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if(!txtPricipalName.Text.IsFormValid() ||!RTxtAddress.Text.IsFormValid()||!txtSchoolName.Text.IsFormValid())
            {
                lblError.Text = "Fill All Valid Column";
                lblError.ForeColor = Color.Red;
                return;
            }

            SchoolClass model = new SchoolClass();
            model.Name = txtSchoolName.Text;
            model.Principal = txtPricipalName.Text;
            model.Address = new Address();
           
            string CityAddress = CityCombo.SelectedItem.ToString();
            model.Address.Details = RTxtAddress.Text;
           
            var result = await SchoolClassServices.Instance.SaveData(model,CityAddress);
            if (result == true)
            {
                lblError.Text="Data Inserted";
                lblError.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblError.Text = "Data Not Inserted";
                lblError.ForeColor = Color.Red;
               
            }
        }

        private async void SchoolCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

            int CountryId = ((Country)SchoolCombo.SelectedItem).Id;
            pictureBoxLoad.Show();
            List<City> cities = await CitiesServices.Instance.GetCities(CountryId);

            foreach(City item in cities)
            {
                CityCombo.Items.Add(item.Name);
            }
            pictureBoxLoad.Hide();
        }

        private async void SchoolUserControl_Load(object sender, EventArgs e)
        {
            pictureBoxLoad.Show();
            List<Country> countries = await CountriesServices.Instance.GetAllCountries();

            foreach (Country item in countries)
            {
                SchoolCombo.Items.Add(item);
            }
            pictureBoxLoad.Hide();
            SchoolCombo.DisplayMember = "Name";
            SchoolCombo.ValueMember = "Id";
        }
    }
}
