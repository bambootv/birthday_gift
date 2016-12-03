using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TuVanQuaSinhNhat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form3 obj2 = new Form3();
            obj2.RefToForm1 = this;
            this.Visible = false;
            obj2.Show();

            //Form frm = new Form3();
            //frm.ShowDialog();
        }

    }
}
