using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Data;

namespace CrcMrc
{
    class DBConnect
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;        


        //Constructor
        public DBConnect()
        {
            Initialize();

        }

        //Initialize values
        private void Initialize()
        {
            /*
            server = "localhost";
            database = "test";
            uid = "root";
            password = "kreso1004";
            */

            server = CrcMrc.Properties.Settings.Default.dbServer;
            database = CrcMrc.Properties.Settings.Default.dbName;
            uid = CrcMrc.Properties.Settings.Default.dbUser;
            password = CrcMrc.Properties.Settings.Default.dbPsw;
            
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open) return true;
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;
                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                    case 1042:                        
                        Console.WriteLine("[-] NO CONNECTION");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            if (connection.State != ConnectionState.Open) return false;
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public void InsertProcess(string ProcName, Int32 ProcID, DateTime ProcTime, string CompName, string CompUser, string IP,string Title, bool bViewOnly = false)
        {
            string formatForMySql = ProcTime.ToString("yyyyMMddHHmmss");
            string sViewOnly = string.Empty;
            if (bViewOnly == false)
            {
                sViewOnly = "null";
            }
            else
            {
                sViewOnly = "1";
            }

            string query = @"INSERT INTO process (  `ProcName`,
                                                    `ProcID`,
                                                    `ProcTime`,
                                                    `CompName`,
                                                    `CompUser`,
                                                    `IP`,
                                                    `Title`,
                                                    `ViewOnly`)
                                                    VALUES
                                                    ('" + RetStringForMySql( ProcName ) + "',"
                                                    + ProcID + ","
                                                    + formatForMySql + ","
                                                    + "'" + CompName + "',"
                                                    + "'" + CompUser + "',"
                                                    + "'"+ IP + "',"
                                                    + "'" + RetStringForMySql( Title ) + "'," 
                                                    + sViewOnly + ");";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public string RetStringForMySql(string s)
        {
            s = s.Replace("'", "''");
            return s;
        }

        public Boolean CheckProcess(string ProcName, Int32 ProcID, DateTime ProcTime, string CompName, string CompUser, string IP)
        {
            Boolean retVal = false;

            /*
            if (this.OpenConnection() != true)
                return retVal;
            */

            if (this.OpenConnection() == true)
                return retVal;

            
            string formatForMySql = ProcTime.ToString("yyyyMMddHHmmss");
            string query = " process WHERE ProcName ='" + ProcName + "' and ProcID = " + ProcID + " and ProcTime = " + formatForMySql + "";
            DataTable dt = this.Select(query);

            if (dt.Rows.Count > 0)
                retVal = true;

            return retVal;
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public DataTable Select(string sTableName)
        {

            string query = "SELECT * FROM " + sTableName;


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                //MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command

                MySqlDataAdapter adr = new MySqlDataAdapter(query, connection);
                adr.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                adr.Fill(dt);


                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return dt;
            }
            else
            {
                return null;
            }
        }

        //Count statement
        public int Count(string sTableName)
        {
            string query = "SELECT Count(ID) FROM " + sTableName;
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar()+"");
                
                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);

                
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup! " + ex.Message);
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                
                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore! " + ex.Message);
            }
        }
    }
}
