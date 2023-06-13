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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace Enterprise_Systems_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Lahiru Vimukthi\Documents\smarketdb.mdf"";Integrated Security=True;Connect Timeout=30");

        private void LoginForm_Load(object sender, EventArgs e)
        {  }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //login
            if (uname.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Enter the UserName and Password");
            }
            else
            {
                if (comboBox1.SelectedIndex > -1)
                {
                    if (comboBox1.SelectedItem.ToString() == "ADMIN")
                    {
                        if (uname.Text == "admin" && pass.Text == "1234")
                        {                          
                            this.Hide();
                            ManageItems login = new ManageItems();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("If you are the admin, Enter the Correct Id and Password ");
                        }
                    }
                    else if(comboBox1.SelectedItem.ToString() == "SELLER")
                    {
                        if (uname.Text == "seller" && pass.Text == "5678")
                        {
                            this.Hide();
                            ManageItems login = new ManageItems();
                            login.Show();
                        }
                        else
                        {
                            MessageBox.Show("If you are the seller, Enter the Correct Id and Password ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your in the Section");                       
                    }
                }
                else
                {
                    
                }
            }

            //database
            //add
            try
            {
                Con.Open();
                string query = "insert into LoginTbl values('" + nic.Text + "','" + uname.Text + "','" + pass.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("");
                Con.Close();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //register
            this.Hide();
            RegistrationForm  login = new RegistrationForm();
            login.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }
    }
}
