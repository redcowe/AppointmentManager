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
    public partial class ConsultantReport : Form
    {
        string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
        private void fillUserID()
        {
            
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string userIndexQuery = "SELECT COUNT(*) FROM user";
                var userIndexCMD = new MySqlCommand(userIndexQuery, conn);
                int userIndex = Convert.ToInt32(userIndexCMD.ExecuteScalar());

                for (int i = 0; i < userIndex; i++)
                {
                    cmbUserID.Items.Add(i + 1);
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("error!");
            }
        }

        private void formatAppointments()
        {
            dgvConsultantSchedule.Columns[4].Visible = false;
            dgvConsultantSchedule.Columns[5].Visible = false;
            dgvConsultantSchedule.Columns[6].Visible = false;
            dgvConsultantSchedule.Columns[8].Visible = false;
            dgvConsultantSchedule.Columns[11].Visible = false;
            dgvConsultantSchedule.Columns[12].Visible = false;
            dgvConsultantSchedule.Columns[13].Visible = false;
            dgvConsultantSchedule.Columns[14].Visible = false;

            dgvConsultantSchedule.Columns[0].HeaderText = "Appt Id";
            dgvConsultantSchedule.Columns[1].HeaderText = "Customer Id";
            dgvConsultantSchedule.Columns[2].HeaderText = "User Id";
            dgvConsultantSchedule.Columns[3].HeaderText = "Title";
            dgvConsultantSchedule.Columns[7].HeaderText = "Type";
            dgvConsultantSchedule.Columns[9].HeaderText = "Start";
            dgvConsultantSchedule.Columns[10].HeaderText = "End";
        }

        private void refreshScheduleView()
        {
            try
            {
                string userId = cmbUserID.Text;
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string consultantScheduleQuery = $"SELECT * FROM appointment WHERE userId={userId}";
                var consultantScheduleCMD = new MySqlCommand(consultantScheduleQuery, conn);
                var consultantScheduleAdapter = new MySqlDataAdapter(consultantScheduleCMD);
                DataTable dt = new DataTable();
                consultantScheduleAdapter.Fill(dt);
                dgvConsultantSchedule.DataSource = dt;
                formatAppointments();
            }
            catch (MySqlException)
            {
                MessageBox.Show("error!");
            }
            
        }
        public ConsultantReport()
        {
            InitializeComponent();
        }

        private void btnConsultantReportExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConsultantReport_Load(object sender, EventArgs e)
        {
            fillUserID();
        }

        private void btnConsultantReportRefresh_Click(object sender, EventArgs e)
        {
            if (cmbUserID.Text == "")
            {
                MessageBox.Show("Please select a UserID before refreshing");
            }
            else
            {
                refreshScheduleView();
            }
        }
    }
}
