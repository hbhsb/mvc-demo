using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class MemberTypeInfoDal
    {
        /// <summary>
        /// 查询未删除的数据
        /// </summary>
        /// <returns></returns>
        public List<MemberTypeInfo> GetList()
        {
            string sql = "select * from memberTypeInfo where mIsDelete=0";
            DataTable table = SqliteHelper.GetDataTable(sql);
            List<MemberTypeInfo> list = new List<MemberTypeInfo>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new MemberTypeInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MTitle = row["mtitle"].ToString(),
                    MDiscount = Convert.ToDecimal(row["mdiscount"])
                });
            }
            return list;
        }

        public int Insert(MemberTypeInfo memberTypeInfo)
        {
            string sql = "insert into MemberTypeInfo(mtitle,mdiscount,misdelete) values(@title,@discount,0)";
            SQLiteParameter[] parameter =
            {
                new SQLiteParameter("@title", memberTypeInfo.MTitle),
                new SQLiteParameter("@discount", memberTypeInfo.MDiscount),
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }

        public int Update(MemberTypeInfo memberTypeInfo)
        {
            string sql = "update membertypeinfo set mtitle=@title,mdiscount=@discount where mid=@id";
            SQLiteParameter[] parameters =
            {
                new SQLiteParameter("@title", memberTypeInfo.MTitle),
                new SQLiteParameter("@discount", memberTypeInfo.MDiscount),
                new SQLiteParameter("@id", memberTypeInfo.MId),
            };
            return SqliteHelper.ExecuteNonQuery(sql, parameters);
        }

        public int Delete(int id)
        {
            string sql = "update membertypeinfo set misdelete=1 where mid=@id";
            SQLiteParameter parameter = new SQLiteParameter("@id", id);
            return SqliteHelper.ExecuteNonQuery(sql, parameter);
        }
    }
}
