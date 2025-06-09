using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string fami = textBox2.Text;
                string mobi = textBox3.Text;
                string nati = textBox4.Text;
                string query = "INSERT INTO library (name,family,mobile,nationalcode) VALUES" +
                    "('" + name + "','" + fami + "','" + mobi + "', '" + nati + "')";
                  
                string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Library\Library\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                 if (command.ExecuteNonQuery()>0)
                 { 
                   MessageBox.Show("insert data successfuly");
                   textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                 }
                connection.Close();

            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }
    }
}
