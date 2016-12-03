
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace fr_login
{
    class Connect
    {

        static public SqlConnection con = new SqlConnection(@"Data Source=DUONG-PC\SQLEXPRESS;Initial Catalog=DongHo;Integrated Security=True");
        static public SqlDataAdapter da;
        static public SqlCommandBuilder sqlComd;
        static public void Laydl(DataGridView _dataview, String a)
        {
            try
            {

                con.Open();

                string id = "select Id from Watch ";
                if (id == a)
                {
                    SqlCommand cmd = new SqlCommand(id, con);

                    cmd.CommandType = CommandType.Text;
                    da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Vi du");
                    _dataview.DataSource = ds.Tables[0];
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                con.Close();
            }
        }

        internal static void Laydl()
        {
            throw new NotImplementedException();
        }
    }
}