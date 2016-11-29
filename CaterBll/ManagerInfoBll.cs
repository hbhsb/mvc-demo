using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    /// <summary>
    /// control layer
    /// </summary>
    public partial class ManagerInfoBll
    {
        ManagerInfoDal dal = new ManagerInfoDal();
        public List<ManagerInfo> GetList()
        {
            return dal.GetIist();
        }

        public bool Add(ManagerInfo miInfo)
        {
            return dal.Insert(miInfo) > 0;
        }

        public bool Edit(ManagerInfo miInfo)
        {
            return dal.Update(miInfo) > 0;
        }

        public bool Remove(int id)
        {
            return dal.Delete(id) > 0;
        }
    }
}
