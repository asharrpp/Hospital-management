using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hospital_management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Add_Patient_Click(object sender, EventArgs e)
        {
            panel1.Visible =true ;
            panel2.Visible = false;
            panel3.Visible = false;

        }

        private void diagnosis_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;

        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                string Name = txtName.Text;
                string Full_address = txtAddress.Text;
                int Contact = int.Parse(txtContact.Text);
                string Gender = cmdGender.Text;
                int Age = int.Parse(txtAge.Text);
                string Blood_group = txtBloodgroup.Text;
                string Major_Disease = txtEarlier.Text;
                int P_id = int.Parse(txtID.Text);


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = ASHARRPP\\SQLEXPRESS; database =hospital; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into AddPatient values('" + Name + "', '" + Full_address + "', " + Contact + ",'" + Gender + "'," + Age + ",'" + Blood_group + "','" + Major_Disease + "'," + P_id + ")";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


            }
            catch (Exception)
            {

                MessageBox.Show("invalid ");
            }


            MessageBox.Show("Patient added successfully");

            ClearText();


        }

        public void ClearText()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtBloodgroup.Clear();
            txtContact.Clear();
            txtID.Clear();
            txtEarlier.Clear();
            cmdGender.ResetText();
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            if (textbox.Text != "")
            {



                int P_id = int.Parse(this.textbox.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = ASHARRPP\\SQLEXPRESS; database =hospital; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select * from Addpatient where P_id = " + P_id + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }



        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {


                int P_id = int.Parse(textbox.Text);
                string symptoms = txtSymptoms.Text;
                string diagnosis = txtDiagnosis.Text;
                string medicine = txtmedicines.Text;
                string ward = cmdWard.Text;
                string wardType = cmdTypeWard.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = ASHARRPP\\SQLEXPRESS; database =hospital; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into Diagnosis values(" + P_id + ", '" + symptoms + "', '" + diagnosis + "','" + medicine + "','" + ward + "','" + wardType + "')";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

            }
            catch
            {
                MessageBox.Show("Invalid values supplier");
            }

            MessageBox.Show("Data saved successfully");

        }

        private void medical_History_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = ASHARRPP\\SQLEXPRESS; database =hospital; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;


            cmd.CommandText = "select * from Addpatient inner join diagnosis on AddPatient.P_id = diagnosis.P_id ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView2.DataSource = DS.Tables[0];
        }
    }
}