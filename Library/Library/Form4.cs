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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {



                string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Library\Library\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                string query = "SELECT * FROM library";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string opt = reader["id"].ToString() + "-" + reader["name"].ToString();
                    comboBox1.Items.Add(opt);
                }

                connection.Close();

            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = comboBox1.SelectedItem.ToString();
                string sp = selected.Split('-')[0];
                string query = $"SELECT * FROM library WHERE id='{sp}'";

                string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Library\Library\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                textBox1.Text = reader["name"].ToString();
                textBox2.Text = reader["family"].ToString();
                textBox3.Text = reader["mobile"].ToString();
                textBox4.Text = reader["nationalcode"].ToString();




                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                string name = textBox1.Text;
                string fami = textBox2.Text;
                string mobi = textBox3.Text;
                string nati = textBox4.Text;
                string selected = comboBox1.SelectedItem.ToString();
                string sp = selected.Split('-')[0];
                string query = $"UPDATE library set name='{name}',family='{fami}',mobile='{mobi}',nationalcode='{nati}' WHERE id={sp}";

                string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Library\Library\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("update data successfuly");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    Refresh();

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
