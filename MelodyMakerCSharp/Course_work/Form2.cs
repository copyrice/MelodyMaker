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

namespace Course_work
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        //public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\b0nd7\source\repos\Course_work\Course_work\Database1.mdf;Integrated Security=True";


        
        public Form2()
        {
            InitializeComponent();
        }
        /*if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))*/
        public bool Empty_fields_checker(params string[] list)
        {
            int count = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (!string.IsNullOrEmpty(list[i]) && !string.IsNullOrWhiteSpace(list[i]))
                { 
                    count++;
                }
            }
            if (count == list.Length) return true;
            else return false;

        }
        
        public void display_db()
        {
            
            sqlConnection = new SqlConnection(Form1.connectionString);

            sqlConnection.Open();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Chords]", sqlConnection);
            //"SELECT * FROM [Chords] WHERE [Name]="+"'C'"
            //try
            //{
                sqlReader = command.ExecuteReader();


                while (sqlReader.Read())
                {
                   listBox2.Items.Add(Convert.ToString(sqlReader["id"]) + "  "
                        + Convert.ToString(sqlReader["Name"]).Trim() + "  "
                        + Convert.ToString(sqlReader["Notes"]));

                }
            //}
            /*catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null) sqlReader.Close();
            } */
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            display_db();
        }
        /*
        private async void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible) label8.Visible = false;

            if (Empty_fields_checker(textBox5.Text,
                textBox4.Text, textBox3.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [Chords] SET [Name]=@Name," +
                    "[Notes]=@Notes WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox5.Text);
                command.Parameters.AddWithValue("Name", textBox4.Text);
                command.Parameters.AddWithValue("Notes", textBox3.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label8.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible) label7.Visible = false;

            if (Empty_fields_checker(textBox1.Text,
                textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Chords] (Name, Notes)" +
                    "VALUES(@Name, @Notes)", sqlConnection);

                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Notes", textBox2.Text);

                await command.ExecuteNonQueryAsync();
                listBox2.Items.Clear();
                display_db();
            }
            else
            {
                label7.Visible = true;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (label9.Visible) label9.Visible = false;
            if (Empty_fields_checker(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Chords] WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", textBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
        }
        */
        private void tabControl1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            display_db();
        }
    }
}