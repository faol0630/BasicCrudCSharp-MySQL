using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

                if (lastname.Text != "" && name.Text != "")
                {

                    string query = "insert into employee (name, lastname) values( '" + name.Text + "', '" + lastname.Text + "')";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    MessageBox.Show("Employee saved successful ");

                    name.Text = "";
                    lastname.Text = "";

                    while (mySqlDataReader.Read())
                    {
    
                    }

                }
                else
                {
                    MessageBox.Show("Error saving Employee. There should be no empty name or lastname fields");
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

                if (id.Text != "" && name.Text != "" && lastname.Text != "")
                {


                    string query = "update employee set name= '" + name.Text + "', lastname='" + lastname.Text + "' where id='" + id.Text + "';";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    MessageBox.Show("Employee updated");

                    name.Text = "";
                    lastname.Text = "";
                    id.Text = "";

                    while (mySqlDataReader.Read())
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Error updating Employee. There should be no empty fields");
                }

                connection.closeConnection();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error updating employee: " + e.Message);
            }
        }

        public void deleteEmployeeById(TextBox id)
        {

            try
            {

                CConnection connection = new CConnection();

                if (id.Text != "")
                {

                    string query = "delete from employee where id= '" + id.Text + "';";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    MessageBox.Show("Employee deleted");

                    id.Text = "";

                }
                else
                {
                    MessageBox.Show("Id null or empty.Nothing to delete");
                }

                connection.closeConnection();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message);
            }

        }

        public void deleteAll()
        {

            try
            {

                CConnection connection = new CConnection();

                DialogResult answer = MessageBox.Show("Are you sure ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (answer == DialogResult.Yes)
                {
                    string query = "delete from employee";

                    MySqlCommand mySqlCommand = new MySqlCommand(query, connection.openConnection());
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    MessageBox.Show("All Employees deleted");
                }
                else
                {
                    MessageBox.Show("Deletion canceled");
                }

                

                connection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employees list: " + ex.Message);

            }
        }

    }
}
