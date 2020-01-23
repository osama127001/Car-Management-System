using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Management_System.Forms
{
    public partial class EmployeeHomePage : Form
    {
        int employee_id;
        public EmployeeHomePage(int e_id)
        {
            this.employee_id = e_id;
            InitializeComponent();
        }

        private void EmployeeHomePage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeAddCar eac = new EmployeeAddCar(this.employee_id);
            this.Hide();
            eac.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeDeleteCar edc = new EmployeeDeleteCar(this.employee_id);
            this.Hide();
            edc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeSearchCar esc = new EmployeeSearchCar(this.employee_id);
            this.Hide();
            esc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 hp = new Form1();
            this.Hide();
            hp.Show();
        }
    }
}
