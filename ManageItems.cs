using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_Systems_Project
{
    public partial class ManageItems : Form
    {
        public ManageItems()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lahiru Vimukthi\Documents\smarketdb.mdf"";Integrated Security=True;Connect Timeout=30");
               
        private void fillcombo()
        {
            //method
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            //populate method call
            populate();
        }
       
        private void button4_Click(object sender, EventArgs e) 
        {
            //add
            //product table
            try
            {
                Con.Open();
                string query = "insert into MItemsTbl values('" + IteId.Text+ "','" +IteName.Text+ "','" +IteQuan.Text+ "','" +ItePri.Text+"','"+IteCate.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Added Successfully");
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
            string query = "select * from MItemsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagride view
            IteId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            IteName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            IteQuan.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            ItePri.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            IteCate.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //edit
            try
            {
                if (IteId.Text == "" || IteName.Text == "" || IteQuan.Text == "" || ItePri.Text == "" || IteCate.Text == "")
                {
                    MessageBox.Show("Your data is missing");
                }
                else
                {
                    Con.Open();
                    string query = "update MItemsTbl set ItemName = '" + IteName.Text + "', ItemQuantity = '" + IteQuan.Text + "', ItemPrice = '" + ItePri.Text + "', ItemCategory = '" + IteCate.Text + "' where ItemID= '" + IteId.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                if (IteId.Text == "" || IteName.Text == "" || IteQuan.Text == "" || ItePri.Text == "" || IteCate.Text == "")
                {
                    MessageBox.Show("Select the Item to Delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from MItemsTbl where ItemID= '" + IteId.Text+ "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManageCategory cat = new ManageCategory();
            cat.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ManageItems a = new ManageItems();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {  }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  }

        private void label7_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {  }

        private void button10_Click(object sender, EventArgs e)
        {
            // new refesh
            this.Hide();
            ManageItems login = new ManageItems();
            login.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //logout
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //registration
            this.Hide();
            RegistrationForm login = new RegistrationForm();
            login.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //loginpage
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //seller details
            this.Hide();
            Seller_Form login = new Seller_Form();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //manage category
            this.Hide();
            ManageCategory login = new ManageCategory();
            login.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //selling Details
            this.Hide();
            SellingDetails login = new SellingDetails();
            login.Show();
        }
    }
}
