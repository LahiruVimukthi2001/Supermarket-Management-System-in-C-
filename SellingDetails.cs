using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_Systems_Project
{
    public partial class SellingDetails : Form
    {
        public SellingDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {   }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            populate();           
        }        

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lahiru Vimukthi\Documents\smarketdb.mdf"";Integrated Security=True;Connect Timeout=30");

        private void populate()
        {
            Con.Open();
            string query = "select * from SellingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void populatebills()
        { }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //add bill
            //bill table
            try
            {
                Con.Open();
                string query = "insert into SellingTbl values('" + BId.Text + "','" + IteName.Text + "','"+Pri.Text+"','"+Quant.Text+"','" + DateLbl.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill Details Added Successfully");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {  }

        private void Quan_TextChanged(object sender, EventArgs e)
        {  }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DateLbl.Text = DateTime.Today.Day.ToString()+"/" + DateTime.Today.Month.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {  }

        private void button5_Click(object sender, EventArgs e)
        {
            //print 
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            try
            {
                if (BId.Text == "" || IteName.Text == "" || Pri.Text == "" || Quant.Text  == "" || DateLbl.Text == "" )
                {
                    MessageBox.Show("Select the Bill Item to delete");
                }
                else
                {
                    Con.Open();
                    string query = "delete from SellingTbl where BillID= '" + BId.Text+"' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Item Deleted Successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //sells list           
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            //print preview document
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //print document
            e.Graphics.DrawString("WELCOME SUPERMARKET", new Font("Arial", 25 , FontStyle.Bold), Brushes.Blue, new Point(250));
            e.Graphics.DrawString("BILL ID : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(70, 70));
            e.Graphics.DrawString("ITEM NAME : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(70, 70) );
            e.Graphics.DrawString("PRICE : " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(70, 70));
            e.Graphics.DrawString("QUANTITY : " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(70, 70));
            e.Graphics.DrawString("DATE : " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString(), new Font("Arial", 15, FontStyle.Regular), Brushes.Black, new Point(70, 70));
            e.Graphics.DrawString("THANK YOU!", new Font("Arial", 25, FontStyle.Bold), Brushes.Blue, new Point(250));
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {  }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {  }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //datagridview1
            BId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            IteName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Pri.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Quant.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            DateLbl.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //refesh
            this.Hide();
            SellingDetails login = new SellingDetails();
            login.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //edit
            try
            {
                if (BId.Text == "" || IteName.Text == "" || Pri.Text == "" || Quant.Text == "" || DateLbl.Text == "")
                {
                    MessageBox.Show("selling details is missing");
                }
                else
                {
                    Con.Open();
                    string query = "update SellingTbl set ItemName = '" + IteName.Text+"',ItemPrice = '"+Pri.Text+"',Quantity ='"+Quant.Text+"', BillDate= '"+DateLbl.Text+"'  where BillID= '"+BId.Text+"'; ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selling Details Successfully Updated");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pri_TextChanged(object sender, EventArgs e)
        {  }

        private void button1_Click(object sender, EventArgs e)
        {
            //seller details
            this.Hide();
            Seller_Form login = new Seller_Form();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //seller details
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

        private void button9_Click(object sender, EventArgs e)
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
    } 
}
