using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class DishTypeInfoDal
    {
        public List<DishTypeInfo> GetList()
        {
            string sql = "select * from DishTypeInfo where dIsDelete=0";
            DataTable table = SqliteHelper.GetDataTable(sql);
            List<DishTypeInfo> list=new List<DishTypeInfo>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new DishTypeInfo()
                {
                    DId = Convert.ToInt32(row["did"]),
                    DTitle = row["dtitle"].ToString()
                });
            }
            return list;
        }

        public int Insert(DishTypeInfo dishTypeInfo)
        {
            string sql = "insert into dishTypeInfo(dtitle,dIsDelete) values(@title,0)";
            SQLiteParameter parameter = new SQLiteParameter("title", dishTypeInfo.DTitle);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Update(DishTypeInfo dishTypeInfo)
        {
            string sql = "update dishTypeInfo set dTitle=@title where did=@id";
            SQLiteParameter[] parameters= {
                new SQLiteParameter("@title",dishTypeInfo.DTitle),
                new SQLiteParameter("@id",dishTypeInfo.DId),  
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update dishTypeInfo set dIsDelete=1 where did=@id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
