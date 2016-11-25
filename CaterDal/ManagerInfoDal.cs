using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
using CaterModel;

namespace CaterDal
{
    public partial class ManagerInfoDal
    {
        public List<ManagerInfo> GetIist()
        {
            string sql = "select * from ManagerInfo";
            DataTable dataTable=SqliteHelper.GetDataTable(sql);
            List<ManagerInfo> list = new List<ManagerInfo>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(new ManagerInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName = row["mname"].ToString(),
                    MPwd = row["mpwd"].ToString(),
                    MType = Convert.ToInt32(row["mtype"])
                });
            }
            return list;
        }

        public int Insert(ManagerInfo miInfo)
        {
            string sql = "insert into ManagerInfo(mname,mpwd,mtype) values(@name,@pwd,@type)";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@name", miInfo.MName),
                new SQLiteParameter("@pwd",Md5Helper.EncryptString(miInfo.MPwd)),
                new SQLiteParameter("@type",miInfo.MType),
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Update(ManagerInfo miInfo)
        {
            string sql = "update ManagerInfo set mname=@name,mpwd=@pwd,mtpye=@pwd where mid=@id";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@name", miInfo.MName),
                new SQLiteParameter("@pwd", miInfo.MPwd),
                new SQLiteParameter("@type", miInfo.MType),
                new SQLiteParameter("@id", miInfo.MId)
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }
    }

}
