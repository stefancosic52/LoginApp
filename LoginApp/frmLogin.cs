using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=COSICPC;Initial Catalog=Login;Integrated Security=True");

            string upit = "Select * from tbl_Login Where username = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(upit, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if(dtbl.Rows.Count == 1)
            {
                frmMain objFrmMain = new frmMain();
                this.Hide();
                objFrmMain.Show();
            }
            else
            {
                MessageBox.Show("Greska! Proverite username i password");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
