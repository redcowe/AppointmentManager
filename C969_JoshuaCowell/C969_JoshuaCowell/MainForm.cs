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
    public partial class MainForm : Form
    {

        public void refreshCustomers()
        {
            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);
            dgvCustomers.ClearSelection();
        }

        public void refreshAppointment()
        {
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string selectAppointmentsQuery = "SELECT * FROM appointment";
                var selectAppointmentCommand = new MySqlCommand(selectAppointmentsQuery, conn);
                var selectAppointmentAdapter = new MySqlDataAdapter(selectAppointmentCommand);
                DataTable dataTable = new DataTable();
                selectAppointmentAdapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var currentStart = dataTable.Rows[i]["start"];
                    var currentEnd = dataTable.Rows[i]["end"];
                    DateTime a = (DateTime)currentStart;
                    DateTime b = (DateTime)currentEnd;
                    dataTable.Rows[i]["start"] = a.ToLocalTime();
                    dataTable.Rows[i]["end"] = b.ToLocalTime();
                }
                dgvAppointments.DataSource = dataTable;
                dgvAppointments.ClearSelection();
            }
            catch (MySqlException)
            {
                MessageBox.Show("error!");
            }
            
        }

        private void formatAppointments()
        {
            dgvAppointments.Columns[4].Visible = false;
            dgvAppointments.Columns[5].Visible = false;
            dgvAppointments.Columns[6].Visible = false;
            dgvAppointments.Columns[8].Visible = false;
            dgvAppointments.Columns[11].Visible = false;
            dgvAppointments.Columns[12].Visible = false;
            dgvAppointments.Columns[13].Visible = false;
            dgvAppointments.Columns[14].Visible = false;

            dgvAppointments.Columns[0].HeaderText = "Appt Id";
            dgvAppointments.Columns[1].HeaderText = "Customer Id";
            dgvAppointments.Columns[2].HeaderText = "User Id";
            dgvAppointments.Columns[3].HeaderText = "Title";
            dgvAppointments.Columns[7].HeaderText = "Type";
            dgvAppointments.Columns[9].HeaderText = "Start";
            dgvAppointments.Columns[10].HeaderText = "End";


        }

        
       
        //This lambda allows fine tuning the formatting of DataGridViews instead of creating multiple functions for each case.
        private delegate void FormatDGV(DataGridView dgv);

        
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dgvCustomers.Columns[0].HeaderText = "Customer ID";
            dgvCustomers.Columns[1].HeaderText = "Name";
            this.customerTableAdapter.Fill(this.client_scheduleDataSet.customer);
            refreshAppointment();
            formatAppointments();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCustomer = new AddCustomer(this);
            addCustomer.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row before attempting to delete");
            }
            else
            {
                try
                {
                    var conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();
                    int customerId = (int)dgvCustomers.SelectedRows[0].Cells[0].Value; //Getting Id
                    string deleteCustomerQuery = $"DELETE FROM customer WHERE customerId={customerId}";
                    var deleteCustomerCMD = new MySqlCommand(deleteCustomerQuery, conn);
                    deleteCustomerCMD.Prepare();
                    deleteCustomerCMD.ExecuteNonQuery();
                    refreshCustomers();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("error! " + ex);
                }
            }
        }

        private void btnModifyCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row before attempting to modify");
            }
            else
            {
                ModifyCustomerForm modifyCustomerForm = new ModifyCustomerForm(this);
                modifyCustomerForm.Show();
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {   
            AddAppointment addAppointment = new AddAppointment(this);
            addAppointment.Show();
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row before attempting to delete");
            }
            else
            {
                try
                {
                    var conn = new MySqlConnection();
                    conn.ConnectionString = connString;
                    conn.Open();
                    int appointmentID = (int)dgvAppointments.SelectedRows[0].Cells[0].Value; //Getting Id
                    string deleteAppointmentQuery = $"DELETE FROM appointment WHERE appointmentId={appointmentID}";
                    var deleteAppointmentCMD = new MySqlCommand(deleteAppointmentQuery, conn);
                    deleteAppointmentCMD.Prepare();
                    deleteAppointmentCMD.ExecuteNonQuery();
                    refreshAppointment();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Please make sure customer has no upcoming appointments before updating or deleting");
                }
            }
        }

        private void btnModifyAppointment_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row before attempting to modify");
            }
            else
            {
                ModifyAppoinment modifyAppoinment = new ModifyAppoinment(this);
                modifyAppoinment.Show(); 
            }
        }

        private void rbtnWeekly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string currentWeekQuery = "SELECT * FROM appointment WHERE WEEK(appointment.start)=WEEK(NOW())";
                var currentWeekCMD = new MySqlCommand(currentWeekQuery, conn);
                DataTable tempTable = new DataTable();
                using (MySqlDataAdapter a = new MySqlDataAdapter(currentWeekCMD))
                {
                    a.Fill(tempTable);
                }


                FormatDGV formatDGV = dgv =>
                {
                    dgv.DataSource = tempTable;
                    dgv.Columns[4].Visible = false;
                    dgv.Columns[5].Visible = false;
                    dgv.Columns[6].Visible = false;
                    dgv.Columns[8].Visible = false;
                    dgv.Columns[11].Visible = false;
                    dgv.Columns[12].Visible = false;
                    dgv.Columns[13].Visible = false;
                    dgv.Columns[14].Visible = false;

                    dgv.Columns[0].HeaderText = "Appt Id";
                    dgv.Columns[1].HeaderText = "Customer Id";
                    dgv.Columns[2].HeaderText = "User Id";
                    dgv.Columns[3].HeaderText = "Title";
                    dgv.Columns[7].HeaderText = "Type";
                    dgv.Columns[9].HeaderText = "Start";
                    dgv.Columns[10].HeaderText = "End";
                };

                formatDGV(dgvCalenders);



            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error!" + ex);

            }
        }

        private void rbtnMonthly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string currentWeekQuery = "SELECT * FROM appointment WHERE MONTH(appointment.start)=MONTH(NOW())";
                var currentWeekCMD = new MySqlCommand(currentWeekQuery, conn);
                DataTable tempTable = new DataTable();
                using (MySqlDataAdapter a = new MySqlDataAdapter(currentWeekCMD))
                {
                    a.Fill(tempTable);
                }

                FormatDGV formatDGV = dgv =>
                {
                    dgv.DataSource = tempTable;
                    dgv.Columns[4].Visible = false;
                    dgv.Columns[5].Visible = false;
                    dgv.Columns[6].Visible = false;
                    dgv.Columns[8].Visible = false;
                    dgv.Columns[11].Visible = false;
                    dgv.Columns[12].Visible = false;
                    dgv.Columns[13].Visible = false;
                    dgv.Columns[14].Visible = false;

                    dgv.Columns[0].HeaderText = "Appt Id";
                    dgv.Columns[1].HeaderText = "Customer Id";
                    dgv.Columns[2].HeaderText = "User Id";
                    dgv.Columns[3].HeaderText = "Title";
                    dgv.Columns[7].HeaderText = "Type";
                    dgv.Columns[9].HeaderText = "Start";
                    dgv.Columns[10].HeaderText = "End";
                };

                formatDGV(dgvCalenders);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error!" + ex);

            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string currentWeekQuery = "SELECT * FROM appointment";
                var currentWeekCMD = new MySqlCommand(currentWeekQuery, conn);
                DataTable tempTable = new DataTable();
                using (MySqlDataAdapter a = new MySqlDataAdapter(currentWeekCMD))
                {
                    a.Fill(tempTable);
                }

                FormatDGV formatDGV = dgv =>
                {
                    dgv.DataSource = tempTable;
                    dgv.Columns[4].Visible = false;
                    dgv.Columns[5].Visible = false;
                    dgv.Columns[6].Visible = false;
                    dgv.Columns[8].Visible = false;
                    dgv.Columns[11].Visible = false;
                    dgv.Columns[12].Visible = false;
                    dgv.Columns[13].Visible = false;
                    dgv.Columns[14].Visible = false;

                    dgv.Columns[0].HeaderText = "Appt Id";
                    dgv.Columns[1].HeaderText = "Customer Id";
                    dgv.Columns[2].HeaderText = "User Id";
                    dgv.Columns[3].HeaderText = "Title";
                    dgv.Columns[7].HeaderText = "Type";
                    dgv.Columns[9].HeaderText = "Start";
                    dgv.Columns[10].HeaderText = "End";
                };

                formatDGV(dgvCalenders);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error!" + ex);

            }
        }

        private void btnByMonthReport_Click(object sender, EventArgs e)
        {
            MonthReportForm monthReportForm = new MonthReportForm();
            monthReportForm.Show();
        }

        private void btnByConsultantReport_Click(object sender, EventArgs e)
        {
            ConsultantReport consultantReport = new ConsultantReport();
            consultantReport.Show();
        }

        private void btnTotalAppointments_Click(object sender, EventArgs e)
        {
            TotalAppointmentReport totalAppointmentReport = new TotalAppointmentReport();
            totalAppointmentReport.Show();
        }

        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            if (txtSearchByDate.Text == "")
            {
                MessageBox.Show("Please enter a date before searching.");
            }
            else
            {
                var unformattedDate = txtSearchByDate.Text;
                try
                {
                    var date = DateTime.Parse(unformattedDate).ToString("yyyy-MM-dd");
                    try
                    {
                        var conn = new MySqlConnection();
                        conn.ConnectionString = connString;
                        conn.Open();
                        string searchByDateQuery = $"SELECT * FROM appointment where DATE(start)='{date}'";
                        var searchByDateCMD = new MySqlCommand(searchByDateQuery, conn);
                        DataTable tempTable = new DataTable();
                        using (MySqlDataAdapter a = new MySqlDataAdapter(searchByDateCMD))
                        {
                            a.Fill(tempTable);
                        }
                        if (tempTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No appointments found");
                            txtSearchByDate.Text = "";
                        }
                        else
                        {
                            dgvAppointments.DataSource = tempTable;
                            txtSearchByDate.Text = "";
                        } 
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("error!" + ex);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid date");
                    txtSearchByDate.Text = "";
                }
            } 
        }
    }
}
