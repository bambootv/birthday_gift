using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Data;

namespace TuVanQuaSinhNhat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public class ProductComparer : IComparer
        {
            public int Compare(object a, object b)
            {
                ProductList pa = (ProductList)a;
                ProductList pb = (ProductList)b;
                return pb.rating.CompareTo(pa.rating);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.age.Text != "" && this.job.Text != "" && this.maritalStatus.Text != "" && this.relationship.Text != "" && this.color.Text != "" && this.money.Text != "" && !this.radioButtonMan.Checked && !this.radioButtonWomen.Checked)
            {
                MessageBox.Show("Bạn vui lòng nhập một số thông tin.");
            }

            if (this.age.Text == "")
            {
                this.label10.Text = "Hãy nhập trường tuổi !";
                return;
            }
            else
            {
                this.label10.Text = "";
            }

            try
            {
                int age = int.Parse(this.age.Text);
            }
            catch
            {
                MessageBox.Show("Mời bạn nhập đúng định dạng !");
                return;
            }

            ArrayList ar = compareObject();
            Form3 obj2 = new Form3(ar);
            obj2.RefToForm1 = this;
            this.Visible = false;
            obj2.Show();
            this.Hide();

        }

        private ArrayList btnConnect_Click()
        {
            SqlConnection myConnection = new SqlConnection
                ("Database=birthdayGift;Server=HOANKI\\SQLEXPRESS;Integrated Security=True;connect timeout = 30");
            try
            {
                myConnection.Open();
                ArrayList ar = new ArrayList();
                Product pro;
                using (var objCmd = new SqlCommand("Select * from Product", myConnection))
                {
                    using (var rsData = objCmd.ExecuteReader())
                    {
                        int minimumAge = 0;
                        int maximumAge = 0;
                        string relationshipFit = "";
                        string genderFit = "";
                        string jobFit = "";
                        string maritalStatusFit = "";
                        string message = "";
                        string color = "";

                        while (rsData.Read())
                        {

                            if (rsData["minimumAge"] != System.DBNull.Value)
                            {
                                minimumAge = (int)rsData["minimumAge"];
                            }

                            if (rsData["maximumAge"] != System.DBNull.Value)
                            {
                                maximumAge = (int)rsData["maximumAge"];
                            }

                            if (rsData["relationshipFit"] != System.DBNull.Value)
                            {
                                relationshipFit = (string)rsData["relationshipFit"];
                            }

                            if (rsData["genderFit"] != System.DBNull.Value)
                            {
                                genderFit = (string)rsData["genderFit"];
                            }

                            if (rsData["jobFit"] != System.DBNull.Value)
                            {
                                jobFit = (string)rsData["jobFit"];
                            }

                            if (rsData["maritalStatusFit"] != System.DBNull.Value)
                            {
                                maritalStatusFit = (string)rsData["maritalStatusFit"];
                            }

                            if (rsData["message"] != System.DBNull.Value)
                            {
                                message = (string)rsData["message"];
                            }

                            if (rsData["image"] != System.DBNull.Value)
                            {
                                //pictureBox1.Image = byteArrayToImage((byte[])rsData["image"]);
                            }

                            if (rsData["color"] != System.DBNull.Value)
                            {
                                color = (string)rsData["color"];
                            }

                            float f = (float)Convert.ToDouble(rsData["money"]);


                            pro = new Product((int)rsData["id"], (string)rsData["name"], minimumAge,
                                      maximumAge, f, relationshipFit,
                                      genderFit, jobFit, maritalStatusFit,
                                      message, (byte[])rsData["image"], color);
                            ar.Add(new ProductList(-1, pro));

                            minimumAge = 0;
                            maximumAge = 0;
                            relationshipFit = "";
                            genderFit = "";
                            jobFit = "";
                            maritalStatusFit = "";
                            message = "";
                            color = "";
                        }
                    }
                }

                myConnection.Close();
                return ar;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Connect to database failed! " + ex.Message);
            }
            return null;
        }

        private ArrayList compareObject()
        {
            var age = -1;
            if (this.age.Text != "")
            {
                age = int.Parse(this.age.Text);
            }

            var job = this.job.Text;
            var relationship = this.relationship.Text;
            var maritalStatus = this.maritalStatus.Text;
            var color = this.color.Text;
            var money = this.money.Text;
            var gender = "";

            //MessageBox.Show(""+age + "" + job + relationship + maritalStatus + color + money + gender);

            if (radioButtonMan.Checked)
            {
                gender = "Nam";
            }
            else if (radioButtonWomen.Checked)
            {
                gender = "Nữ";
            }

            ArrayList ar = btnConnect_Click();

            var count = 0;
            var accept = 1;

            for (int iIndex = 0; iIndex < ar.Count; iIndex++)
            {
                ProductList pro = (ProductList)ar[iIndex];

                if ((age >= pro.p.MinimumAge && age <= pro.p.MaximumAge) || (age == -1))
                {
                    count++;
                }
                else if (age <= pro.p.MinimumAge || age >= pro.p.MaximumAge)
                {
                    accept = 0;
                }

                if (job == pro.p.JobFit || job == "")
                {
                    count++;
                }
                else if (job != pro.p.JobFit)
                {
                    accept = 0;
                }

                if (relationship == pro.p.RelationshipFit || relationship == "")
                {
                    count++;
                }
                else if (relationship != pro.p.RelationshipFit)
                {
                    accept = 0;
                }

                if (maritalStatus == pro.p.MaritalStatusFit || maritalStatus == "")
                {
                    count++;
                }
                else if (maritalStatus != pro.p.MaritalStatusFit)
                {
                    accept = 0;
                }

                if (gender == pro.p.GenderFit || gender == "")
                {
                    count++;
                }
                else if (gender != pro.p.GenderFit)
                {
                    accept = 0;
                }

                if (color == pro.p.Color || color == "")
                {
                    count++;
                }
                else if (color != pro.p.Color)
                {
                    accept = 0;
                }

                float minimumMoney = 0;
                float maximumMoney = 0;

                if (money == "< 50 nghìn đồng")
                {
                    minimumMoney = 0;
                    maximumMoney = 50000;
                }
                else if (money == "50 - 100 nghìn đồng")
                {
                    minimumMoney = 50000;
                    maximumMoney = 100000;
                }
                else if (money == "100 - 200 nghìn đồng")
                {
                    minimumMoney = 100000;
                    maximumMoney = 200000;
                }
                else if (money == "> 200 nghìn đồng")
                {
                    minimumMoney = 200000;
                    maximumMoney = float.MaxValue;
                }
                else
                {
                    minimumMoney = float.MinValue;
                    maximumMoney = float.MaxValue;
                }

                if (minimumMoney <= pro.p.Money && maximumMoney >= pro.p.Money)
                {
                    count++;
                }
                else if (minimumMoney >= pro.p.Money || maximumMoney <= pro.p.Money)
                {
                    accept = 0;
                }

                if (accept == 0)
                {
                    pro.rating = 0;
                    ar[iIndex] = pro;
                }
                else
                {
                    pro.rating = count;
                    ar[iIndex] = pro;
                }
                accept = 1;
                count = 0;
            }

            ar.Sort(new ProductComparer());
            return ar;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            /*
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose Image File";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] image = null;

                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    image = new Byte[fs.Length];
                    fs.Read(image, 0, (int)fs.Length);

                    string sql = @"Data Source=HOANKI\SQLEXPRESS;Initial Catalog=birthdayGift;Integrated Security=True";
                    //sql = @"Database=birthdayGift;Server=HOANKI\\SQLEXPRESS;Integrated Security=True;connect timeout = 30";
                    using (SqlConnection conn = new SqlConnection(sql))
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Product SET image = @HinhAnh WHERE Id =  @id", conn);
                        conn.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@id", "20");
                        cmd.Parameters["@id"].Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("@HinhAnh", SqlDbType.Image);
                        cmd.Parameters["@HinhAnh"].Direction = ParameterDirection.Input;
                        cmd.Parameters["@HinhAnh"].Value = image;
                        cmd.ExecuteNonQuery();
                    }
                    
                }
            }
            */
            
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
    
}