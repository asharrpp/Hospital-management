using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (username == "hms" && password == "pass")
            {
                this.Hide();
                Dashboard da = new Dashboard();
                da.Show();
              
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }
}
