using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace DataConn
{
    public partial class Form1 : Form
    {
      //  private OleDbConnection myCon;
        public Form1()
        {
            InitializeComponent();

           
        }
         //string myConn  = "@Provider=Microsoft.Jet.OLEDB.12.0;Data Source=C:\\Users\\Aneela\\Documents\\Aneela.accdb";
        public string  myconnectionstring()
        {
        string x= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\VP.accdb";
        return x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\VP.accdb");
            OleDbCommand cmd = new OleDbCommand("insert into My_table (Name) values ('" + textBox2.Text + "')",conn);
           //cmd.CommandType = CommandType.Text;
           //cmd.CommandText = 
            DataSet myDataSet = new DataSet();
            var myAdapptor = new OleDbDataAdapter();
            myAdapptor.SelectCommand = cmd;
            myAdapptor.Fill(myDataSet);
           conn.Open();
           cmd.ExecuteNonQuery();
           // System.Windows.Forms.MessageBox.Show("User Account Succefully Created", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
           
           

            
            
          MessageBox.Show("User Account Succefully Created", "Caption", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\VP.accdb");
            OleDbCommand cmd = new OleDbCommand("SELECT * from My_table;", conn);

            DataTable table = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
           
            dataGridView1.ReadOnly = true;
          
            conn.Open();
            cmd.ExecuteNonQuery();
           
        }

        

       
    }
}

       

