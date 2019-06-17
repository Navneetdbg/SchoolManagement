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
    public partial class CountryUserControl : UserControl
    {
        #region Singleton Service
        public static CountryUserControl Instance
        {
            get
            {
                if (instance == null) instance = new CountryUserControl();
                return instance;
            }
        }

        private static CountryUserControl instance { get; set; }
        private CountryUserControl()
        {
            InitializeComponent();
        }

        #endregion
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if(!txtCountryName.Text.IsFormValid())
            {
                lblError.Text = "Enter Country Name";
                lblError.ForeColor = Color.Red;
                return;
            }

            Country model = new Country();
            model.Name = txtCountryName.Text;
            pictureBoxLoad.Show();
            var result = await CountriesServices.Instance.SaveCountryData(model);
            if (result == true)
            {
                lblError.Text = "Data Inserted Successfully";
                lblError.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblError.Text = "Error";
                lblError.ForeColor = Color.Red;
            }
            pictureBoxLoad.Hide();
        }

        private async void CountryUserControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Show();
            List<Country> countries = await CountriesServices.Instance.GetAllCountries();
            pictureBox1.Hide();
            foreach (Country item in countries)
            {
                SchoolCombo.Items.Add(item.Name);
            }
            

        }

        private async void btnSave2_Click(object sender, EventArgs e)
        {
            if (!txtCityName.Text.IsFormValid())
            {
                lblError.Text = "Enter Valid City";
                lblError.ForeColor = Color.Red;
                return;
            }
            City model = new City();
            model.Name = txtCityName.Text;

            string CountryName = SchoolCombo.SelectedItem.ToString();
            pictureBoxLoad.Show();
            var result = await CitiesServices.Instance.SaveCityData(model, CountryName);
            if (result == true)
            {
                lblError.Text = "Data Inserted";
                lblError.ForeColor = Color.YellowGreen;
            }
            else
            {
                lblError.Text = "Data Not Inserted";
                lblError.ForeColor = Color.Red;
            }
            pictureBoxLoad.Hide();
        }
    }
}