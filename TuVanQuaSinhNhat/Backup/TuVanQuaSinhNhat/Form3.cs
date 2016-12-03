using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TuVanQuaSinhNhat
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            btnConnect_Click();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Form RefToForm1 { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.RefToForm1.Show();
        }

        private void btnConnect_Click()
        {
            SqlConnection myConnection = new SqlConnection("Database=birthdayGift;Server=HOANKI\\SQLEXPRESS;Integrated Security=True;connect timeout = 30");
            try
            {
                myConnection.Open();
                MessageBox.Show("Well done!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connect to database failed!" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
