using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterDal
{
    public static class SqliteHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["itcastCater"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] ps)
        {
            using (SQLiteConnection connection=new SQLiteConnection(connStr))
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, connection);
                cmd.Parameters.AddRange(ps);
                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        public static DataTable GetDataTable(string sql,params SQLiteParameter[] ps)
        {
            using (SQLiteConnection connection=new SQLiteConnection(connStr))
            {
                SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql,connection);
                DataTable table = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(ps);
                adapter.Fill(table);
                return table;
            }
        }
    }
}
