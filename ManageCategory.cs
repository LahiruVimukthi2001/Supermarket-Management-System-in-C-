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
    public partial class ManageCategory : Form
    {
        public ManageCategory()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lahiru Vimukthi\Documents\smarketdb.mdf"";Integrated Security=True;Connect Timeout=30");
        private void button4_Click(object sender, EventArgs e)
        {
            //add
            //category table
            try
            {
                Con.Open();
                string query = "insert into MCategoryTbl values('"+CatIdTb.Text +"','"+CatNameTb.Text+"','"+CatDescTb.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Added Successfully");
                Con.Close();
                populate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from MCategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();            
        }

        private void CatForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataguide view
            CatIdTb.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("Select the Category to delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from MCategoryTbl where CategoryID= '" + CatIdTb.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //edit
            try 
            {
                if (CatIdTb.Text== "" || CatNameTb.Text== "" || CatDescTb.Text== "")
                {
                    MessageBox.Show("Your data is missing");
                }
                else
                {
                    Con.Open();
                    string query = "update MCategoryTbl set CategoryName = '" + CatNameTb.Text + "', CategoryDesc = '" + CatDescTb.Text + "' where CategoryID= '" + CatIdTb.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dashboard seller
            ManageCategory cat = new ManageCategory();
            cat.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //dashboard product
            ManageItems a = new ManageItems();
            a.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        { }

        private void button11_Click(object sender, EventArgs e)
        { }

        private void button12_Click(object sender, EventArgs e)
        { }

        private void button7_Click(object sender, EventArgs e)
        { }

        private void button12_Click_1(object sender, EventArgs e)
        {
            //seller details
            this.Hide();
            Seller_Form login = new Seller_Form();
            login.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //selling details
            this.Hide();
            SellingDetails login = new SellingDetails();
            login.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //manage Items
            this.Hide();
            ManageItems login = new ManageItems();
            login.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //login form
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            //Registration
            this.Hide();
            RegistrationForm login = new RegistrationForm();
            login.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //logout
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
