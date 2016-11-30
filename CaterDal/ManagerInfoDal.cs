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
            List<SQLiteParameter>parameters=new List<SQLiteParameter>();

            parameters.Add(new SQLiteParameter("@name", miInfo.MName));
            string sql = "update ManagerInfo set mname=@name";
            if (!miInfo.MPwd.Equals("这是原来的密码吗"))
            {
                sql += ",mpwd=@pwd";
                parameters.Add(new SQLiteParameter("@pwd", Md5Helper.EncryptString(miInfo.MPwd)));
            }
            sql+= ",mtype=@type where mid=@id";
            parameters.Add(new SQLiteParameter("@type", miInfo.MType));
            parameters.Add(new SQLiteParameter("@id", miInfo.MId));
            return SqliteHelper.ExecuteNonQuery(sql, parameters.ToArray());
        }
        /// <summary>
        /// 根据编号删除管理员
        /// </summary>
        /// <param name="id">要删除行的id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int id)
        {
            string sql = "delete from ManagerInfo where mid=@id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
        /// <summary>
        /// 根据用户名查找对象，判断用户输入是否正确
        /// </summary>
        /// <param name="name">要查找的用户名</param>
        /// <returns>返回查找到的第一个对象</returns>
        public ManagerInfo GetByName(string name)
        {
            ManagerInfo managerInfo = null;
            string sql = "select * from managerInfo where mname=@name";
            SQLiteParameter parameter=new SQLiteParameter("@name",name);
            DataTable table = SqliteHelper.GetDataTable(sql, parameter);
            if (table.Rows.Count > 0)
            {
                managerInfo = new ManagerInfo()
                {
                    MId = Convert.ToInt32(table.Rows[0][0]),
                    MName = name,
                    MPwd = table.Rows[0][2].ToString(),
                    MType = Convert.ToInt32(table.Rows[0][3])
                };
            }
            return managerInfo;
        }
    }

}
