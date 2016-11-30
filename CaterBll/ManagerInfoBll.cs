using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCommon;
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

        /// <summary>
        /// 从UI获得用户输入的用户名和密码，调用DAl进行查询，判断登录状态
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns>返回登录结果</returns>
        public LoginState Login(string name, string pwd)
        {
            ManagerInfo managerInfo = dal.GetByName(name);
            if (managerInfo == null)
            {
                return LoginState.NameError;
            }
            else
            {
                if (managerInfo.MPwd.Equals(Md5Helper.EncryptString(pwd)))
                {
                    return LoginState.Ok;
                }
                else
                {
                    return LoginState.PwdError;
                }
            }
        }
    }
}
