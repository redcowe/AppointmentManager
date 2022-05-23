using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace C969_JoshuaCowell
{
    public partial class ModifyCustomerForm : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
        public string country;
        public string nameId;
        public string phoneNumber;
        public string addressId;
        public string cityId;
        public string customerId;
        private MainForm mainForm = null;

        public ModifyCustomerForm()
        {
            InitializeComponent();
        }

        public ModifyCustomerForm(Form callingform)
        {
            InitializeComponent();
            mainForm = callingform as MainForm;
            try
            {
                customerId = mainForm.dgvCustomers.SelectedRows[0].Cells[0].Value.ToString();
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                
                //Resolving Customer Name
                string searchCustomerIDQuery = $"SELECT * FROM customer WHERE customerId={customerId}";
                var searchCMD = new MySqlCommand(searchCustomerIDQuery, conn);
                DataTable tempDTCustomer = new DataTable();

                using (MySqlDataAdapter a = new MySqlDataAdapter(searchCMD))
                {
                    a.Fill(tempDTCustomer);
                }

                txtModifyCustomerName.Text = tempDTCustomer.Rows[0][1].ToString();
                nameId = tempDTCustomer.Rows[0][1].ToString();

                //Resolving Address and Phone Number
                string searchAddressQuery = $"SELECT * FROM address WHERE addressId={tempDTCustomer.Rows[0][2]}";
                var searchAddressCMD = new MySqlCommand(searchAddressQuery, conn);
                DataTable tempDTAddress = new DataTable();

                using (MySqlDataAdapter a = new MySqlDataAdapter(searchAddressCMD))
                {
                    a.Fill(tempDTAddress);
                }

                txtModifyCustomerAddress.Text = tempDTAddress.Rows[0][1].ToString();
                addressId = tempDTAddress.Rows[0][0].ToString();
                txtModifyCustomerPhoneNumber.Text = tempDTAddress.Rows[0][5].ToString();
                phoneNumber = tempDTAddress.Rows[0][5].ToString();


                //Resolving City
                string searchCityQuery = $"SELECT * FROM city WHERE cityId={tempDTAddress.Rows[0][3]}";
                var searchCityCMD = new MySqlCommand(searchCityQuery, conn);
                DataTable tempDTCity = new DataTable();

                using (MySqlDataAdapter a = new MySqlDataAdapter(searchCityCMD))
                {
                    a.Fill(tempDTCity);
                }

                txtModifyCustomerCity.Text = tempDTCity.Rows[0][1].ToString();
                cityId = tempDTCity.Rows[0][0].ToString();

                //Resolving Country

                string searchCountryQuery = $"SELECT country.country FROM country WHERE countryID={tempDTCity.Rows[0][2]}";
                var serachCityCMD = new MySqlCommand(searchCountryQuery, conn);
                DataTable tempDTCountry = new DataTable();
                using (MySqlDataAdapter a = new MySqlDataAdapter(serachCityCMD))
                {
                    a.Fill(tempDTCountry);
                }

                txtModifyCustomerCountry.Text = tempDTCountry.Rows[0][0].ToString();
                country = tempDTCountry.Rows[0][0].ToString();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("error" + ex);
            }
            
        }

        private void btnModifyCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifyCustomerSave_Click(object sender, EventArgs e)
        {
            string _name = txtModifyCustomerName.Text;
            string _address = txtModifyCustomerAddress.Text;
            string _phoneNumber = txtModifyCustomerPhoneNumber.Text;
            string _city = txtModifyCustomerCity.Text;
            string _country = txtModifyCustomerCountry.Text;
            bool isComplete()
            {
                bool result = false;

                if (_name == "")
                {
                    result = false;
                }
                else if (_address == "")
                {
                    result = false;
                }
                else if (_phoneNumber == "")
                {
                    result = false;
                }
                else if (_city == "")
                {
                    result = false;
                }
                else if (_country == "")
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                return result;
            }

            if (isComplete() != true)
            {
                MessageBox.Show("Please make sure all fields are filled out before submitting");
            }
            else
            {
                try
                {
                    var conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();
                    int customerId = (int)mainForm.dgvCustomers.SelectedRows[0].Cells[0].Value;

                    //Country Queries
                    string countryIndexQuery = "SELECT countryId FROM country ORDER BY countryId DESC LIMIT 1";
                    var countryIndexCMD = new MySqlCommand(countryIndexQuery, conn);
                    int countryIndex = Convert.ToInt32(countryIndexCMD.ExecuteScalar()) + 1;

                    string countryInsertQuery = $"INSERT INTO country VALUES({countryIndex}, '{_country}', NOW(), 'test', NOW(), NOW())";
                    var countryInsertCMD = new MySqlCommand(countryInsertQuery, conn);
                    countryInsertCMD.Prepare();
                    countryInsertCMD.ExecuteNonQuery();

                    //City Queries
                    string cityIndexQuery = "SELECT cityId FROM city ORDER BY cityId DESC LIMIT 1";
                    var cityIndexCMD = new MySqlCommand(cityIndexQuery, conn);
                    int cityIndex = Convert.ToInt32(cityIndexCMD.ExecuteScalar()) + 1;

                    string cityInsertQuery = $"INSERT INTO city VALUES({cityIndex},'{_city}', {countryIndex}, NOW(), 'test', NOW(), 'test')";
                    var cityInsertCMD = new MySqlCommand(cityInsertQuery, conn);
                    cityInsertCMD.Prepare();
                    cityInsertCMD.ExecuteNonQuery();

                    //Address Queries
                    string addressIndexQuery = "SELECT addressId FROM address ORDER BY addressId DESC LIMIT 1";
                    var addressIndexCMD = new MySqlCommand(addressIndexQuery, conn);
                    int addressIndex = Convert.ToInt32(addressIndexCMD.ExecuteScalar()) + 1;

                    string addressInsertQuery = $"INSERT INTO address VALUES({addressIndex}, '{_address}', '', {cityIndex}, 11111, '{_phoneNumber}', NOW(), 'test', NOW(), 'test')";
                    var addressInsertCommand = new MySqlCommand(addressInsertQuery, conn);
                    addressInsertCommand.Prepare();
                    addressInsertCommand.ExecuteNonQuery();

                    //Customer Query
                    string customerInsertQuery = $"UPDATE customer SET customerName='{_name}', addressId={addressIndex} WHERE customerId={customerId}";
                    var customerInsertCommand = new MySqlCommand(customerInsertQuery, conn);
                    customerInsertCommand.Prepare();
                    customerInsertCommand.ExecuteNonQuery();

                    mainForm.refreshCustomers();
                    this.Close();
                    
                    
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("error!" + ex);
                }
            } 
        }
    }
}
