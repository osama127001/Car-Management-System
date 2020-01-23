using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UserAdminLoginForm
{
    
    public partial class AdminLogin : Form
    {   SqlConnection con = new SqlConnection(Properties.Settings.Default.LoginDBSEConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        public AdminLogin()
        {
            InitializeComponent();
        }
        string msg;
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM tblAdmin WHERE Name = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
            da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if (i == 1)
            {

            }
            else
            {
                MessageBox.Show("Not a Registered Admin or Invalid UserName or Password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
