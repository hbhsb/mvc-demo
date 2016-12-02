using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterModel;

namespace CaterDal
{
    public partial class MemberInfoDal
    {
        public List<MemberInfo> GetList(Dictionary<string,string> dictionary )
        {
            string sql = "select mi.*,mti.MTitle as MTypeTitle " +
                         "from MemberInfo as mi " +
                         "inner join MemberTypeInfo as mti " +
                         "on mi.MTypeId = mti.MId "+
                         "where mi.mIsDelete=0 ";
            if (dictionary.Count > 0)
            {
                foreach (var pair in dictionary)
                {
                    sql+=" and "+pair.Key+" like'%"+ pair.Value+ "%'";
                }
            }
            DataTable table = SqliteHelper.GetDataTable(sql);
            List<MemberInfo> list = new List<MemberInfo>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new MemberInfo()
                {
                    MId = Convert.ToInt32(row["mid"]),
                    MName =row["mname"].ToString(),
                    MPhone = row["mphone"].ToString(),
                    MMoney = Convert.ToDecimal(row["MMoney"]),
                    MTypeId = Convert.ToInt32(row["MTypeId"]),
                    MTypeTitle = row["MTypeTitle"].ToString()
                });
            }
            return list;
        }
    }
}
