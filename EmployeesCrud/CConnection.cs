using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicEmployeeCrudMySQL.EmployeesCrud
{
    internal class CConnection
    {
        MySqlConnection mySqlConnection = new MySqlConnection();

        static string server = "localhost";
        static string db = "employee_c_sharp";
        static string user = "root";
        static string password = "";
        static string port = "3306";

        string stringConnection = $"Server={server}; Database={db}; User ID={user}; Password={password}; Port={port}";

        public MySqlConnection openConnection()
        {
            try
            {
                mySqlConnection.ConnectionString = stringConnection;
                mySqlConnection.Open();
                //MessageBox.Show("Connection opened");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failure.Error: " + ex.Message);
            }
            return mySqlConnection;
        }

        public void closeConnection()
        {
            mySqlConnection.Close();
        }

    }
}
