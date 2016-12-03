using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace TuVanQuaSinhNhat
{
    public partial class Form3 : Form
    {
        ArrayList array = new ArrayList();
        int i = 0;
        public Form3(ArrayList ar)
        {
            InitializeComponent();
            for (int iIndex = 0; iIndex < ar.Count; iIndex++)
            {
                ProductList p = (ProductList) ar[iIndex];

                if (p.rating > 0)
                {
                    array.Add(p);
                }
            }
            showResult();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form RefToForm1 { get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.RefToForm1.Show();
        }

        private void showResult()
        {
            if (array.Count == 0) {
                label8.Text = "Sau khi phân tích, chúng tôi không tìm thấy dữ liệu nào phù hợp để trợ giúp cho bạn."
                    + "\n Bạn có thể quay lại để thay đổi thông tin.";
                label3.Text = "0 / 0";
                return;
            } else if (i == array.Count)
            {
                i = 0;
            }
            else if (i < 0)
            {
                i = array.Count - 1;
            }
            label8.Text = "Sau khi phân tích, chúng tôi đề xuất " + array.Count + " món đồ phù hợp để trợ giúp cho bạn.";
            label3.Text = i + 1 + " / " + array.Count;

            ProductList pro = (ProductList)array[i];
            textBox1.Text = pro.p.Money + "";
            textBox2.Text = pro.p.Message + "";
            label5.Text = pro.p.Name + "";
            
            if (pro.p.Image != null)
            {
                pictureBox1.Image = byteArrayToImage(pro.p.Image);
            }
        }

        public Image byteArrayToImage(byte[] byteBLOBData)
        {
            //MessageBox.Show("SHOW: " + Encoding.Default.GetString(byteBLOBData));
            MemoryStream ms = new MemoryStream(byteBLOBData);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            i++;
            showResult();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i--;
            showResult();
        }
    }
}
