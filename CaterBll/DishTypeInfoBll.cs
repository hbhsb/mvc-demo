using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class DishTypeInfoBll
    {
        private DishTypeInfoDal dal=new DishTypeInfoDal();

        public List<DishTypeInfo> GetList()
        {
            return dal.GetList();
        }

        public bool Add(DishTypeInfo dishTypeInfo)
        {
            return dal.Insert(dishTypeInfo) > 0;
        }

        public bool Update(DishTypeInfo dishTypeInfo)
        {
            return dal.Update(dishTypeInfo) > 0;
        }

        public bool Delete(int id)
        {
            return dal.Delete(id) > 0;
        }
    }
}
