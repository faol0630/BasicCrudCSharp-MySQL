using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicEmployeeCrudMySQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            employees.showAllEmployees(dgvEmployee);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            //crear nuevo employee:
            employees.saveEmployee(txtName, txtLastname);

            // refrescar la lista de employees:
            employees.showAllEmployees(dgvEmployee);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            //crear nuevo employee:
            employees.updateEmployee(txtId, txtName, txtLastname);

            // refrescar la lista de employees:
            employees.showAllEmployees(dgvEmployee);

        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            employees.getEmployees(dgvEmployee, txtId, txtName, txtLastname);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            employees.deleteEmployeeById(txtId);

            employees.showAllEmployees(dgvEmployee);

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {

            EmployeesCrud.Employees employees = new EmployeesCrud.Employees();
            employees.deleteAll();

            employees.showAllEmployees(dgvEmployee);

        }
    }
}
