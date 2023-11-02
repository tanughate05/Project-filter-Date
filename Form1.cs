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
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Project_Report_Filter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Invoice> invoices = new List<Invoice>();
        public object DataSources { get; private set; }

        private void filterList()
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            if (!s.IsNullOrEmpty())
            {
                DateTime enteredDate = DateTime.Parse(s);
                List<Invoice> fiteredInvoices = new List<Invoice>();
                foreach (var invoice in invoices)
                {
                    DateTime invoiceDate = DateTime.Parse(invoice.DATE_);
                    int result = DateTime.Compare(enteredDate, invoiceDate);
                    if (result == 0)
                    {
                        fiteredInvoices.Add(invoice);
                    }

                }
                dataGridView1.DataSource = fiteredInvoices;
            } else
            {
                dataGridView1.DataSource = invoices;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // address of Sql server and database
            string ConnectionString = "Data Source=ADI\\SQLEXPRESS;Initial Catalog=KARAKUS;Integrated Security=True";

            // Establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            // open connection
            con.Open();
  
               

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("SELECT INVOICE.LOGICALREF,DATE_,FICHENO, (CASE  WHEN INVOICE.TRCODE=2   THEN 'Perakende Satış İade Faturası'  WHEN INVOICE.TRCODE=3   THEN 'Toptan Satış İade Faturası'  WHEN INVOICE.TRCODE=7   THEN 'Perakende Satış Faturası'  WHEN INVOICE.TRCODE=8   THEN 'Toptan Satış Faturası' END) as FICHETYPE, CLCARD.CODE,CLCARD.DEFINITION_,NETTOTAL FROM  LG_121_01_INVOICE INVOICE LEFT JOIN LG_121_CLCARD CLCARD ON CLCARD.LOGICALREF=INVOICE.CLIENTREF  WHERE  INVOICE.TRCODE IN (2,3,7,8)", conn);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {

                    int Logicalref = (int)reader["LOGICALREF"];
                    string date = (string)reader["DATE_"].ToString();
                    string ficheno = (string)reader["FICHENO"].ToString();
                    string fichetpe = (string)reader["FICHETYPE"].ToString();
                    string code = (string)reader["CODE"].ToString();
                    string definition = (string)reader["DEFINITION_"].ToString();
                    double netTotal = (double)reader["NETTOTAL"];
                    Invoice i = new Invoice() { LOGICALREF= Logicalref, DATE_=date, FICHENO=ficheno, FICHETYPE= fichetpe, CODE=code, DEFINITION_=definition, NETTOTAL=netTotal };
                    //filterListBox.Items.Add(Logicalref);
                    invoices.Add(i);
                    
                }
              
                dataGridView1.DataSource = invoices;
                
                conn.Close();
                }
            con.Close();
            MessageBox.Show("Reporting. . . ");
            
        }
    }
}
