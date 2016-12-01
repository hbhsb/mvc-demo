using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
   public partial class MemberTypeInfoBll
   {
       private MemberTypeInfoDal dal;

       public MemberTypeInfoBll()
       {
           dal=new MemberTypeInfoDal();
       }

       public List<MemberTypeInfo> GetList()
       {
           return dal.GetList();
       }

       public bool Add(MemberTypeInfo memberTypeInfo)
       {
           return dal.Insert(memberTypeInfo) > 0;
       }

       public bool Edit(MemberTypeInfo memberTypeInfo)
       {
           return dal.Update(memberTypeInfo) > 0;
       }

       public bool Delete(int id)
       {
           return dal.Delete(id) > 0;
       }
   }
}
