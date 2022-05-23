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
using System.Globalization;
using System.IO;

namespace C969_JoshuaCowell
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private bool isUpcoming()
        {
            string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";
            string username = txtLoginUsername.Text;
            bool result = false;
            try
            {
                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();

                string upcomingAppointmentQuery = 
                    $"SELECT * FROM appointment WHERE start BETWEEN NOW() AND NOW() + INTERVAL 15 MINUTE AND userId=(SELECT userId FROM user WHERE userName='{username}')";
                var upcomingAppointmentCMD = new MySqlCommand(upcomingAppointmentQuery, conn);
                int upcomingAppointmentIndex = Convert.ToInt32(upcomingAppointmentCMD.ExecuteScalar());

                if (upcomingAppointmentIndex == 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
                
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error!");
            }
            return result;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoginLogin_Click(object sender, EventArgs e)
        {
            string connString = "server=127.0.0.1;uid=sqlUser;pwd=Passw0rd!;database=client_schedule";

            try
            {
                string path = @"log.txt";

                var conn = new MySqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string username = txtLoginUsername.Text;
                string password = txtLoginPassword.Text;
                string query = $"SELECT * FROM user WHERE userName='{username}' AND password='{password}'";
                var cmd = new MySqlCommand(query,conn);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MainForm mainForm = new MainForm();
                    if (isUpcoming() != true)
                    {
                        MessageBox.Show("Successful Login!");
                        mainForm.Show();
                        this.Hide();

                        //logging successful attempt to file
                        try
                        {
                            if (File.Exists(path) == false)
                            {
                                File.Create(path).Dispose();

                                using (TextWriter tw = new StreamWriter(path))
                                {
                                    tw.WriteLine($"SUCCESSFUL LOGIN ATTEMPT FOR USER {username} AT {DateTime.Now} {Environment.NewLine}" );
                                }
                            }
                            else if (File.Exists(path) == true)
                            {
                                File.AppendAllText(path, $"SUCCESSFUL LOGIN ATTEMPT FOR USER {username} AT {DateTime.Now} {Environment.NewLine}");
                            }

                        }
                        catch (IOException error)
                        {
                            MessageBox.Show(error.ToString());
                        }

                    }
                    else
                    {
                        MessageBox.Show("You have an appointment within the next 15 minutes.");
                        mainForm.Show();
                        this.Hide();
                    }
                    
                }
                else
                {
                    //Checking for english
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
                    {
                        MessageBox.Show("Username or Password is incorrect");
                    }
                    //Checking for spanish
                    else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
                    {
                        MessageBox.Show("El nombre de usuario o la contraseña son incorrectos");
                    }

                    try
                    {
                        if (File.Exists(path) == false)
                        {
                            File.Create(path).Dispose();

                            using (TextWriter tw = new StreamWriter(path))
                            {
                                tw.WriteLine($"UNSUCCESSFUL LOGIN ATTEMPT FOR USER {username} AT {DateTime.Now} {Environment.NewLine}");
                            }
                        }
                        else if (File.Exists(path) == true)
                        {
                            File.AppendAllText(path, $"UNSUCCESSFUL LOGIN ATTEMPT FOR USER {username} AT {DateTime.Now} {Environment.NewLine}");
                        }

                    }
                    catch (IOException error)
                    {
                        MessageBox.Show(error.ToString());
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Unable to connect to server");
            }

            
            
        }
    }
}
