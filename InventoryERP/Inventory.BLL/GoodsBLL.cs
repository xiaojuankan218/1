using System;
using System.Data;
using Inventory.DAL;
using Inventory.Model;

namespace Inventory.BLL
{
    /// <summary>
    /// 商品信息业务逻辑类
    /// </summary>
    public class GoodsBLL : IDataService<goods>
    {
        private  readonly  GoodsDAL goodDAL = new GoodsDAL();

        #region 添加
        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public int Insert(goods good)
        {
            return goodDAL.Insert(good);
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public int Update(goods good)
        {
            return goodDAL.Update(good);
        }

        #endregion

        #region 删除

        public int Delete(string gno)
        {
            return goodDAL.Delete(gno);
        }

        #endregion

        #region 查询
        /// <summary>
        /// 根据商品编号查询单个商品信息
        /// </summary>
        /// <param name="gno">商品编号</param>
        /// <returns></returns>
        public goods GetSingleByno(string gno)
        {
            return goodDAL.GetSingleByno(gno);
        }

        /// <summary>
        /// 查询所有商品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllGood()
        {
            return Query("");
        }

        /// <summary>
        /// 根据查询条件查询商品信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            return goodDAL.Query(strWhere);
        }

        #endregion





    }
}