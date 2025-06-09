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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = comboBox1.SelectedItem.ToString();
                string sp = selected.Split('-')[0];
                string query = $"DELETE FROM library WHERE id='{sp}'";
               
                string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Library\Library\Database1.mdf;Integrated Security=True";
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("delete data successfuly");
                   
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
