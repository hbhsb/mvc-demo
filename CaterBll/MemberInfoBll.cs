using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class MemberInfoBll
    {
        private MemberInfoDal dal=new MemberInfoDal();

        public List<MemberInfo> GetList(Dictionary<string,string> dictionary )
        {
            return dal.GetList(dictionary);
        }

        public bool Add(MemberInfo memberInfo)
        {
            return dal.Insert(memberInfo)>0;
        }

        public bool Edit(MemberInfo memberInfo)
        {
            return dal.Update(memberInfo) > 0;
        }

        public bool Deletd(int id)
        {
            return dal.Delete(id) > 0;
        }
    }
}
