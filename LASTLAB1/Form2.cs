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

namespace LASTLAB1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //insert data
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Emp_Tb (Emp_ID,Emp_FirstName,Emp_MiddleName,Emp_LastName,Age,Gender,Position,Contact) values (@ID,@FirstName,@MiddleName,@LastName,@Age,@Gender,@Position,@Contact)" , con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpId.Text));
            cmd.Parameters.AddWithValue("@FirstName", (TxtFname.Text));
            cmd.Parameters.AddWithValue("@MiddleName", (txtMname.Text));
            cmd.Parameters.AddWithValue("@LastName", (txtLname.Text));

            cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cmd.Parameters.AddWithValue("@Gender", (cbGender.Text));
            cmd.Parameters.AddWithValue("@Position", (cbPosition.Text));
            cmd.Parameters.AddWithValue("@Contact", int.Parse(txtContact.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success");

            //show data on gridvieqw auto load
            SqlCommand cmd2 = new SqlCommand("Select * from Emp_Tb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //clear all textbox when finished inserting data
            txtEmpId.Focus();

            TxtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            cbGender.Text = "";
            cbPosition.Text = "";
            txtContact.Clear();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //update data
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Emp_Tb set Emp_FirstName=@FirstName,Emp_MiddleName=@MiddleName,Emp_LastName=@LastName,Age=@Age,Gender=@Gender,Position=@Position,Contact=@Contact where Emp_ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpId.Text));
            cmd.Parameters.AddWithValue("@FirstName", (TxtFname.Text));
            cmd.Parameters.AddWithValue("@MiddleName", (txtMname.Text));
            cmd.Parameters.AddWithValue("@LastName", (txtLname.Text));

            cmd.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
            cmd.Parameters.AddWithValue("@Gender", (cbGender.Text));
            cmd.Parameters.AddWithValue("@Position", (cbPosition.Text));
            cmd.Parameters.AddWithValue("@Contact", int.Parse(txtContact.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success Updated");

            //show data on gridvieqw auto load
            SqlCommand cmd2 = new SqlCommand("Select * from Emp_Tb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //clear all textbox when finished Updating data
            txtEmpId.Focus();

            TxtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            cbGender.Text = "";
            cbPosition.Text = "";
            txtContact.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //show data on gridvieqw auto load
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Select * from Emp_Tb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete data
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE Emp_Tb WHERE Emp_ID=@ID ",con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpId.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Success Deleted");

            //show data on gridview autoload
            SqlCommand cmd2 = new SqlCommand("Select * from Emp_Tb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //find sepcific row
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Emp_Tb WHERE Emp_ID=@ID ", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtEmpId.Text));
            SqlDataAdapter d = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            d.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //function of logout gop back to login
            Form1 frm1 = new Form1();
            frm1.Show();
            Visible = false;
            //end
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Show all
            //show data on gridvieqw auto load
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q7UOJO5;Initial Catalog=User;Integrated Security=True");
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Select * from Emp_Tb", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
