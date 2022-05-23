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
    public partial class TotalAppointmentReport : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        private void refreshTable()
        {
            try
            {
                dgvTotalAppointmentReport.Rows.Clear();
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string appointmentCountQuery = "SELECT COUNT(*) FROM appointment";
                var appointmentCountCMD = new MySqlCommand(appointmentCountQuery, conn);
                int appointmentCount = Convert.ToInt32(appointmentCountCMD.ExecuteScalar());
                dgvTotalAppointmentReport.Rows.Add("Appointments", appointmentCount);
            }
            catch (MySqlException)
            {
                MessageBox.Show("error!");
            }
        }
        public TotalAppointmentReport()
        {
            InitializeComponent();
        }

        private void btnTotalAppointmentReportExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTotalAppointmentReportRefresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }
    }
}
