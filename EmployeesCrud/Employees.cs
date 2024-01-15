using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicEmployeeCrudMySQL.EmployeesCrud
{
    internal class Employees
    {

        public void showAllEmployees(DataGridView employeesTable)
        {
            try
            {

                CConnection cConnection = new CConnection();
                string query = "select * from employee";

                employeesTable.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, cConnection.openConnection());

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                employeesTable.DataSource = dataTable;
                cConnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with Sql data: " + ex.Message);
            }
        }

        public void saveEmployee(TextBox name, TextBox lastname)
        {

            try
            {

                CConnection connection = new CConnection();
                string query = "insert into employee (name, lastname) values( '" + name.Text + "', '" + lastname.Text + "')";

                MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                MessageBox.Show("Employee saved successful ");

                name.Text = "";
                lastname.Text = "";

                while (mySqlDataReader.Read())
                {

                }

                connection.closeConnection();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving new employee" + ex.Message);
            }

        }


        public void getEmployees(DataGridView dataGridView, TextBox id, TextBox name, TextBox lastname)
        {
            try
            {

                id.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                name.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                lastname.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting employee: " + ex.Message);
            }
        }

        public void updateEmployee(TextBox id, TextBox name, TextBox lastname)
        {

            try
            {
                CConnection connection = new CConnection();
                string query = "update employee set name= '" + name.Text + "', lastname='" + lastname.Text + "' where id='" + id.Text + "';";

                MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                MessageBox.Show("Employee updated");

                name.Text = "";
                lastname.Text = "";

                while (mySqlDataReader.Read())
                {

                }

                connection.closeConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error updating employee: " + e.Message);
            }
        }

    }
}
