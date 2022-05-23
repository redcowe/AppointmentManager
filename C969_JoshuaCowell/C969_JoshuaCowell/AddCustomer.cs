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

    
   
    public partial class AddCustomer : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        //This lambda allows for defining custom functions that will return true or false based on whatever conditions are provided.
        //This prevents the creation of functions that would do similar, but slightly different verification tasks.
        private delegate bool IsComplete();

        public AddCustomer()
        {
            InitializeComponent();
        }

        private MainForm mainForm = null;

        public AddCustomer(Form callingform)
        {
            mainForm = callingform as MainForm;
            InitializeComponent();
        }

        private void btnAddCustomerCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomerSave_Click(object sender, EventArgs e)
        {
            string _name = txtAddCustomerName.Text;
            string _address = txtAddCustomerAddress.Text;
            string _phoneNumber = txtAddCustomerPhoneNumber.Text;
            string _city = txtAddCustomerCity.Text;
            string _country = txtAddCustomerCountry.Text;

            IsComplete isComplete = () =>
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
            };

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

                    //Customer Queries
                    string customerIndexQuery = "SELECT customerId FROM customer ORDER BY customerId DESC LIMIT 1";
                    var customerIndexCMD = new MySqlCommand(customerIndexQuery, conn);
                    int customerIndex = Convert.ToInt32(customerIndexCMD.ExecuteScalar()) + 1;

                    string customerInsertQuery = $"INSERT INTO customer VALUES({customerIndex}, '{_name}', {addressIndex}, 1, NOW(), 'test', NOW(), 'test')"
    ;
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

        private void lblAddCustomerCountry_Click(object sender, EventArgs e)
        {

        }

        private void txtAddCustomerCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddCustomerCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddCustomerCity_Click(object sender, EventArgs e)
        {

        }

        private void lblAddCustomerPhoneNumber_Click(object sender, EventArgs e)
        {

        }

        private void txtAddCustomerPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddCustomerAddress_Click(object sender, EventArgs e)
        {

        }

        private void txtAddCustomerAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddCustomerName_Click(object sender, EventArgs e)
        {

        }
    }
}
