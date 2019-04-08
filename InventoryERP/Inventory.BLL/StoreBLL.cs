using System;
using System.Data;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
    public class StoreBLL : IDataService<Store>
    {
        private readonly StoreDAL storeDAL = new StoreDAL();

        #region 添加
        /// <summary>
        /// 添加仓库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(Store t)
        {
            return storeDAL.Insert(t);
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改仓库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(Store t)
        {
            return storeDAL.Update(t);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 根据库位编号删除该仓库
        /// </summary>
        /// <param name="stno">库位编号</param>
        /// <returns></returns>
        public int Delete(string stno)
        {
            return storeDAL.Delete(stno);
        }

        #endregion

        #region 查询
        /// <summary>
        /// 根据库位编号，查询该仓库信息
        /// </summary>
        /// <param name="stno"></param>
        /// <returns></returns>
        public Store GetSingleByno(string stno)
        {
            return storeDAL.GetSingleByno(stno);
        }

        /// <summary>
        /// 查询所有仓库信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStore()
        {
            return Query("");
        }

        /// <summary>
        /// 根据条件查询库位信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            return storeDAL.Query(strWhere);
        }

        #endregion
    }
}