using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form_Load(object sender,EventArgs e)
        { 
            List<ManagerInfo> list = new List<ManagerInfo>();
            string connStr = @"data source=E:\ItcastCater.db;version=3;";
            using(SQLiteConnection conn=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand("select * from ManagerInfo", conn);
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(new ManagerInfo()
                    {
                        Min = Convert.ToInt32(reader["mid"]),
                        Mname=reader["mname"].ToString(),
                        Mpwd=reader["mpwd"].ToString(),
                        Mtype=Convert.ToInt32(reader["mtype"])
                    });
                }
                Console.WriteLine(list.ToString());
                Console.WriteLine("sd");
                dataGridView1.DataSource = list;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
