using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_JoshuaCowell
{
    public partial class MonthReportForm : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        private void fillDropdown()
        {
            for (int i = 1; i <= 12; i++)
            {
                cmbReportMonths.Items.Add(i);
            }
        }

        public MonthReportForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MonthReportForm_Load(object sender, EventArgs e)
        {
            fillDropdown();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            if (cmbReportMonths.Text == "")
            {
                MessageBox.Show("Please select a Month before refreshing");
            }
            else
            {
                string currentMonth = cmbReportMonths.Text;
                dgvMonthReport.Rows.Clear();
                try
                {
                    var conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();

                    string onlineCountQuery = $"SELECT COUNT(*) FROM appointment WHERE type='Online' AND MONTH(start)={currentMonth}";
                    var onlineCountCMD = new MySqlCommand(onlineCountQuery, conn);
                    int onlineCountIndex = Convert.ToInt32(onlineCountCMD.ExecuteScalar());
                    dgvMonthReport.Rows.Add("Online", onlineCountIndex);

                    string inPersonCountQuery = $"SELECT COUNT(*) FROM appointment WHERE type='In-Person' AND MONTH(start)={currentMonth}";
                    var inPersonCountCMD = new MySqlCommand(inPersonCountQuery, conn);
                    int inPersonCountIndex = Convert.ToInt32(inPersonCountCMD.ExecuteScalar());
                    dgvMonthReport.Rows.Add("In-Person", inPersonCountIndex);

                    string phoneCountQuery = $"SELECT COUNT(*) FROM appointment WHERE type='Phone' AND MONTH(start)={currentMonth}";
                    var phoneCountCMD = new MySqlCommand(phoneCountQuery, conn);
                    int phoneCountIndex = Convert.ToInt32(phoneCountCMD.ExecuteScalar());
                    dgvMonthReport.Rows.Add("Phone", phoneCountIndex);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }            
        }
    }
}
