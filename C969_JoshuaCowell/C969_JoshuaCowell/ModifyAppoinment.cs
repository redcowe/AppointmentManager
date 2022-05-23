using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace C969_JoshuaCowell
{
    public partial class ModifyAppoinment : Form
    {
        public string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

        private MainForm mainForm = null;
        public ModifyAppoinment()
        {
            InitializeComponent();
        }

        public ModifyAppoinment(Form callingForm)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
            
        }

        private void btnModifyAppointmentCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModifyAppoinment_Load(object sender, EventArgs e)
        {
            cmbModifyAppointmentType.Items.Add("Online");
            cmbModifyAppointmentType.Items.Add("In-Person");
            cmbModifyAppointmentType.Items.Add("Phone");
            //setting customer id, user id, title, and type
            txtModifyAppointmentCustomerID.Text = mainForm.dgvAppointments.SelectedRows[0].Cells[1].Value.ToString();
            txtModifyAppointmentUserID.Text = mainForm.dgvAppointments.SelectedRows[0].Cells[2].Value.ToString();
            cmbModifyAppointmentType.Text = mainForm.dgvAppointments.SelectedRows[0].Cells[7].Value.ToString();
            txtModifyAppointmentTitle.Text = mainForm.dgvAppointments.SelectedRows[0].Cells[3].Value.ToString();
            string startTime = mainForm.dgvAppointments.SelectedRows[0].Cells[9].Value.ToString();
            string endTime = mainForm.dgvAppointments.SelectedRows[0].Cells[10].Value.ToString();

            //setting date 
            string[] dateArray = startTime.Split('/');
            txtModifyCustomerDateMonths.Text = dateArray[0];
            txtModifyCustomerDateDays.Text = dateArray[1];
            string[] yearsTimeArray = dateArray[2].Split(' ');
            txtModifyCustomerDateYears.Text = yearsTimeArray[0];

            //setting start time
            string[] startDateTimeArray = startTime.Split(' ');
            string[] startTimeArray = startDateTimeArray[1].Split(':');
            if (startDateTimeArray[2] == "PM" && startTimeArray[0] != "12")
            {
                txtModifyAppointmentStartHours.Text = (int.Parse(startTimeArray[0]) + 12).ToString();
            }
            else if (startDateTimeArray[2] == "AM" && startTimeArray[0] == "12")
            {
                txtModifyAppointmentStartHours.Text = "00";
            }
            else
            {
                txtModifyAppointmentStartHours.Text = startTimeArray[0];
            }
            
            txtModifyAppointmentStartMinutes.Text = startTimeArray[1];
            txtModifyAppointmentStartSeconds.Text = startTimeArray[2];

            //setting end time
            string[] endDateTimeArray = endTime.Split(' ');
            string[] endTimeArray = endDateTimeArray[1].Split(':');
            if (endDateTimeArray[2] == "PM" && endTimeArray[0] != "12")
            {
                txtModifyAppointmentEndHours.Text = (int.Parse(endTimeArray[0]) + 12).ToString();
            }
            else if (endDateTimeArray[2] == "AM" && endTimeArray[0] == "12")
            {
                txtModifyAppointmentEndHours.Text = "00";
            }
            else
            {
                txtModifyAppointmentEndHours.Text = endTimeArray[0];
            }
            txtModifyAppointmentEndMinutes.Text = endTimeArray[1];
            txtModifyAppointmentEndSeconds.Text = endTimeArray[2];
        }

        private void btnModifyAppointmentSave_Click(object sender, EventArgs e)
        {
            //getting values from text boxes
            string appointmentId = mainForm.dgvAppointments.SelectedRows[0].Cells[0].Value.ToString();
            string _type = cmbModifyAppointmentType.Text;
            string _startTime = $"{txtModifyAppointmentStartHours.Text}:{txtModifyAppointmentStartMinutes.Text}:{txtModifyAppointmentStartSeconds.Text}";
            string _endTime = $"{txtModifyAppointmentEndHours.Text}:{txtModifyAppointmentEndMinutes.Text}:{txtModifyAppointmentEndSeconds.Text}";
            string _date = $"{txtModifyCustomerDateYears.Text}-{txtModifyCustomerDateMonths.Text}-{txtModifyCustomerDateDays.Text}";
            string _title = txtModifyAppointmentTitle.Text;
            string _customerID = txtModifyAppointmentCustomerID.Text;
            string _userID = txtModifyAppointmentUserID.Text;

            //variables for checking if time is between business hours
            TimeSpan startBusinessHours = new TimeSpan(06, 0, 0);
            TimeSpan endBusinessHours = new TimeSpan(16, 0, 0);
            TimeSpan startTime = new TimeSpan(int.Parse(txtModifyAppointmentStartHours.Text), int.Parse(txtModifyAppointmentStartMinutes.Text), int.Parse(txtModifyAppointmentStartSeconds.Text));
            TimeSpan endTime = new TimeSpan(int.Parse(txtModifyAppointmentEndHours.Text), int.Parse(txtModifyAppointmentEndMinutes.Text), int.Parse(txtModifyAppointmentEndSeconds.Text));

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

                //function for checking if there's scheduling overlap
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

                        if (overlapIndex > 1)
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

                        string updateAppointmentQuery =
                            $"UPDATE appointment SET type='{_type}', title='{_title}',customerId={_customerID}, userId={_userID}, start='{_startDateTimeUTC}', end='{_endDateTimeUTC}' WHERE appointmentId={appointmentId}";
                        var updateAppointmentCMD = new MySqlCommand(updateAppointmentQuery, conn);
                        updateAppointmentCMD.Prepare();
                        updateAppointmentCMD.ExecuteNonQuery();
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
