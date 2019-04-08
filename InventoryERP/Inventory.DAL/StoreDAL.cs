using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DBUnitily;
using Inventory.Model;

namespace Inventory.DAL
{
    /// <summary>
    /// 库位信息数据库操作类
    /// </summary>
    public class StoreDAL : IDataService<Store>
    {

        #region 添加
        public int Insert(Store t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into store values(@stno,@address,@telephone,@capacity)");
            SqlParameter[] ps =
            {
                                 new SqlParameter("@stno",SqlDbType.Char,3) {Value = t.stno},
                                 new SqlParameter("@telephone",SqlDbType.VarChar,11) {Value = t.telephone},
                                 new SqlParameter("@address",SqlDbType.VarChar,30) {Value = t.address},
                                 new SqlParameter("@capacity",SqlDbType.SmallInt,4) {Value = t.capacity}
            };
            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
        }
        #endregion

        #region 修改
        public int Update(Store t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update store set address=@address,telephone=@telephone,capacity=@capacity where stno=@stno ");
            SqlParameter[] ps =
            {
                new SqlParameter("@stno",SqlDbType.Char,3) {Value = t.stno},
                new SqlParameter("@telephone",SqlDbType.VarChar,11) {Value = t.telephone},
                new SqlParameter("@address",SqlDbType.VarChar,30) {Value = t.address},
                new SqlParameter("@capacity",SqlDbType.SmallInt,4) {Value = t.capacity}
            };
            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
        }
        #endregion

        #region 删除
        public int Delete(string stno)
        {
            string strSql = "delete from store where stno ='" + stno + "'";
            int number = DBHelper.ExecuteNonQuery(strSql);
            return number;
        }
        #endregion

        #region 查询

        public Store GetSingleByno(string stno)
        {
            string strSql = "select top 1 * from store where stno ='" + stno + "'";
            var store = new Store();
            var reader = DBHelper.ExecuteReader(strSql);
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        store.stno = reader.GetString(0);
                        store.address = reader.GetString(1);
                        store.telephone = reader.GetString(2);
                        store.capacity = reader.GetInt16(3);
                    }
                }
                reader.Close();
                reader.Dispose();
            }

            return store;
        }
        public DataTable Query(string strWhere)
        {
            string strSql = "select * from store ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " where " + strWhere;
            }

            var storeTable = DBHelper.GetDataTable(strSql);
            return storeTable;
        }
        #endregion
    }
}
