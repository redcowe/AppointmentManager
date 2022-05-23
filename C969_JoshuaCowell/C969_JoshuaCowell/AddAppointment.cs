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
    public partial class AddAppointment : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        private MainForm mainForm = null;
        public AddAppointment()
        {
            InitializeComponent();
        }

        public AddAppointment(Form callingform)
        {
            mainForm = callingform as MainForm;
            InitializeComponent();
        }

        private void btnAddAppointmentCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            cmbAddAppointmentType.Items.Add("Online");
            cmbAddAppointmentType.Items.Add("In-Person");
            cmbAddAppointmentType.Items.Add("Phone");
        }

        private void btnAddAppointmentSave_Click(object sender, EventArgs e)
        {

            //getting values from text boxes
            string _type = cmbAddAppointmentType.Text;
            string _startTime = $"{txtAddAppointmentStartHours.Text}:{txtAddAppointmentStartMinutes.Text}:{txtAddAppointmentStartSeconds.Text}";
            string _endTime = $"{txtAddAppointmentEndHours.Text}:{txtAddAppointmentEndMinutes.Text}:{txtAddAppointmentEndSeconds.Text}";
            string _date = $"{txtAddCustomerDateYears.Text}-{txtAddCustomerDateMonths.Text}-{txtAddCustomerDateDays.Text}";
            string _title = txtAddAppointmentTitle.Text;
            string _customerID = txtAddAppointmentCustomerID.Text;
            string _userID = txtAddAppointmentUserID.Text;


            //variables for checking if time is between business hours
            TimeSpan startBusinessHours = new TimeSpan(06, 0, 0);
            TimeSpan endBusinessHours = new TimeSpan(16, 0, 0);
            TimeSpan startTime = new TimeSpan(int.Parse(txtAddAppointmentStartHours.Text), int.Parse(txtAddAppointmentStartMinutes.Text), int.Parse(txtAddAppointmentStartSeconds.Text));
            TimeSpan endTime = new TimeSpan(int.Parse(txtAddAppointmentEndHours.Text), int.Parse(txtAddAppointmentEndMinutes.Text), int.Parse(txtAddAppointmentEndSeconds.Text));

            if ((startBusinessHours > startTime) || (startBusinessHours > endTime))
            {
                MessageBox.Show("Please make sure times are between 06:00 and 16:00");
            }
            else if ((endBusinessHours < startTime) || (endBusinessHours < endTime))
            {
                MessageBox.Show("Please make sure times are between 06:00 and 16:00");
            }
            else
            {
                for (int i = 0; i < mainForm.dgvAppointments.Rows.Count; i++)
                {
                    
                    
                }
                
                //converting time and formatting string for query
                string tempStartDate = $"{_date} {_startTime}";
                string _startDateTime = DateTime.Parse(tempStartDate).ToUniversalTime().ToString();
                string[] vs = _startDateTime.Split(' ');
                string[] vs1 = vs[0].Split('/');
                string[] vs2 = vs[1].Split(':');
                string _startDateTimeUTC = "";
                if (vs[2] == "PM" && vs2[1] != "12")
                {
                    _startDateTimeUTC = $"{vs1[2]}-{vs1[0]}-{vs1[1]} {int.Parse(vs2[0]) + 12}:{vs2[1]}:{vs2[2]}";
                }
                else
                {
                    _startDateTimeUTC = $"{vs1[2]}-{vs1[0]}-{vs1[1]} {vs[1]}";
                }


                string tempEndDate = $"{_date} {_endTime}";
                string _endDateTime = DateTime.Parse(tempEndDate).ToUniversalTime().ToString();
                string[] ps = _endDateTime.Split(' ');
                string[] ps1 = ps[0].Split('/');
                string[] ps2 = ps[1].Split(':');
                string _endDateTimeUTC = "";

                if (ps[2] == "PM" && ps2[0] != "12")
                {
                    _endDateTimeUTC = $"{ps1[2]}-{ps1[0]}-{ps1[1]} {int.Parse(ps2[0]) + 12}:{ps2[1]}:{ps2[2]}";
                }
                else
                {
                    _endDateTimeUTC = $"{ps1[2]}-{ps1[0]}-{ps1[1]} {ps[1]}";
                }

                //function for checking if there's appointment overlap
                bool isNoOverlap()
                {
                    bool result = false;
                    try
                    {
                        var conn = new MySqlConnection();
                        conn.ConnectionString = connString;
                        conn.Open();
                        string appointmentOverlapQuery =
                            $"SELECT COUNT(*) FROM appointment WHERE start BETWEEN '{_startDateTimeUTC}' AND '{_endDateTimeUTC}' AND userId={_userID} OR end BETWEEN '{_startDateTimeUTC}' AND '{_endDateTimeUTC}' AND userId={_userID}";
                        var appointmentOverlapCMD = new MySqlCommand(appointmentOverlapQuery, conn);
                        int overlapIndex = Convert.ToInt32(appointmentOverlapCMD.ExecuteScalar());

                        if (overlapIndex != 0)
                        {
                            result = false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error!" + ex);
                    }
                   return result;
                }


                if (isNoOverlap() == true)
                {
                    try
                    {

                        var conn = new MySqlConnection();
                        conn.ConnectionString = connString;
                        conn.Open();

                        //Getting Index and inserting Appointment
                        string appointmentIndexQuery = "SELECT appointmentId FROM appointment ORDER BY appointmentId DESC LIMIT 1";
                        var appointmentIndexCMD = new MySqlCommand(appointmentIndexQuery, conn);
                        int appointmentIndex = Convert.ToInt32(appointmentIndexCMD.ExecuteScalar()) + 1;

                        string appointmentInsertQuery =
                            $"INSERT INTO appointment VALUES({appointmentIndex}, {_customerID}, {_userID}, '{_title}', '', '', '', '{_type}', '', '{_startDateTimeUTC}', '{_endDateTimeUTC}', NOW(), '', NOW(), '')";
                        var appointmentInsertCMD = new MySqlCommand(appointmentInsertQuery, conn);
                        appointmentInsertCMD.Prepare();
                        appointmentInsertCMD.ExecuteNonQuery();
                        this.Close();
                        mainForm.refreshAppointment();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("error!" + ex);
                    }
                }
                else
                {
                    MessageBox.Show($"Please make sure dates and times don't overlap with other appointments for User with UserID: {_userID}.");
                }
            }
        }
    }
}
