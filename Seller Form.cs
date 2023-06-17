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

namespace Enterprise_Systems_Project
{
    public partial class Seller_Form : Form
    {
        public Seller_Form()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lahiru Vimukthi\Documents\smarketdb.mdf"";Integrated Security=True;Connect Timeout=30");
        
        private void label7_Click(object sender, EventArgs e)
        {
            //exit 
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //add
            //category table
            try
            {
                Con.Open();
                string query = "insert into SellerTbl values('"+SID.Text+"','"+SName.Text+"','"+SAge.Text + "','"+SPhone.Text+"','"+SEmail.Text+"','"+SUname.Text+"','"+SPass.Text+"','"+SCName.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Seller Details Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                if (SID.Text == "" || SName.Text == "" || SAge.Text == "" || SPhone.Text == "" || SEmail.Text == "" || SUname.Text == "" || SPass.Text == "" || SCName.Text == "") 
                {
                    MessageBox.Show("Select the Seller Details to delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellerTbl where SellerID= '"+SID.Text+"' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Details Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //edit
            try
            {
                if (SID.Text == "" || SName.Text == "" || SAge.Text == "" || SPhone.Text == "" || SEmail.Text == "" || SUname.Text == "" || SPass.Text == "" || SCName.Text == "")
                {
                    MessageBox.Show("Your Seller details is missing");
                }
                else
                {
                    Con.Open();
                    string query = "update SellerTbl set SellerName = '"+SName.Text+"',SellerAge ='"+SAge.Text+"',SellerPhone ='"+SPhone.Text+"', SellerEmail = '"+SEmail.Text+"', SellerUsername = '"+SUname.Text+"',SellerPassword = '"+SPass.Text+"', SellerCompany = '"+SCName.Text+"' where SellerID = '"+SID.Text+"'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Seller Details Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {  //log out
        }

        private void Seller_Form_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagrideview
            //dataguide view
            SID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            SName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SAge.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SPhone.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            SEmail.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            SUname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SPass.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            SCName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //selling details
            this.Hide();
            SellingDetails login = new SellingDetails();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //manage category
            this.Hide();
            ManageCategory login = new ManageCategory();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //manage Items
            this.Hide();
            ManageItems login = new ManageItems();
            login.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //login form
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Registration
            this.Hide();
            RegistrationForm login = new RegistrationForm();
            login.Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //logout
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
