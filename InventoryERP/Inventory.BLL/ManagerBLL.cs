using System;
using System.Data;
using System.Net.Mail;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
    public class ManagerBLL : IDataService<manager>
    {
        private  readonly  ManagerDAL managerDAL = new ManagerDAL();

        #region 添加
        /// <summary>
        /// 添加仓库管理员信息
        /// </summary>
        /// <param name="t">管理员信息</param>
        /// <returns></returns>
        public int Insert(manager t)
        {
            return managerDAL.Insert(t);
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(manager t)
        {
            return managerDAL.Update(t);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 根据管理员编号删除该管理员
        /// </summary>
        /// <param name="mno">管理员编号</param>
        /// <returns></returns>
        public int Delete(string mno)
        {
            return managerDAL.Delete(mno);
        }

        #endregion

        #region 查询

        public bool Login(string mno,string mname)
        {
            var manager = GetSingleByno(mno);
            if (manager == null)
            {
                return false;
            }
            return true;
            //else
            //{
            //    if()
            //}
        }

        /// <summary>
        /// 根据管理员编号查询该管理员信息
        /// </summary>
        /// <param name="mno">管理员编号</param>
        /// <returns></returns>
        public manager GetSingleByno(string mno)
        {
            return managerDAL.GetSingleByno(mno);
        }

        /// <summary>
        /// 查询全部管理员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllManager()
        {
            return Query("");
        }

        /// <summary>
        /// 根据条件查询管理列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            return managerDAL.Query(strWhere);
        }

        #endregion



    }
}