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

namespace sql_DataSet
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=DESKTOP-4VJ698M\GJF;Initial Catalog=DBUsers;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter adapter;
        DataSet dsUsers;
        DataTable dtUsers;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dsUsers = new DataSet();
            con = new SqlConnection(strCon);
            adapter = new SqlDataAdapter(
                " SELECT * " +
                " FROM TBUser ", con);
            dsUsers.Clear();
            adapter.Fill(dsUsers, "Users1");
            dtUsers = dsUsers.Tables["Users1"];
            dataGridUsers.DataSource = dtUsers;

        }
      

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

   
        private void btnIN_Click(object sender, EventArgs e)
        {
            DataRow dr = dtUsers.NewRow();
            dr["user_name"] = txtname.Text;
            dr["password"] = txtpass.Text;
            dr["email"] = txtemail.Text;
            dtUsers.Rows.Add(dr);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["email"].ToString() == textBox4.Text)
                {
                    row.Delete();
                }
            }
            MessageBox.Show("succese");
        }

        private void txtnameUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtemailUP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassUP_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUPtoDB_Click(object sender, EventArgs e)
        {
            new SqlCommandBuilder(adapter);
            adapter.Update(dtUsers);
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
   
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["email"].ToString() == txtEmailToUP.Text)
                {
                    row["user_name"] = txtnameUp.Text;
                    row["password"] = txtpassUP.Text;
                    row["email"] = txtemailUP.Text;
                }
            }
            MessageBox.Show("succese");
        }

    
    }
}
