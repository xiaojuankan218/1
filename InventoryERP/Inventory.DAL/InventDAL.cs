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
    /// 库存数据库访问操作类
    /// </summary>
    public class InventDAL : IDataService<invent>
    {
        #region 添加
        /// <summary>
        /// 向库存表中插入记录 返回值为整形，如果大于0表示插入成功，等于0表示插入失败，-1表示出异常
        /// </summary>
        /// <param name="t">库存信息</param>
        /// <returns></returns>
        public int Insert(invent t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into invent values(@stno,@gno,@number)");
            SqlParameter[] ps ={
                                    new SqlParameter("@stno",SqlDbType.Char,6) {Value = t.stno},
                                    new SqlParameter("@gno",SqlDbType.Char,6) {Value = t.gno},
                                    new SqlParameter("@number",SqlDbType.Int,4) {Value = t.number},
                                };

            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改库存记录，返回整形，如果大于0则修改成功，等于0修改失败，-1修改出异常
        /// </summary>
        /// <param name="t">需要修改的信息</param>
        /// <returns></returns>
        public int Update(invent t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update invent set number=@number where stno=@stno and gno=@gno ");
            SqlParameter[] ps =
                                {
                                    new SqlParameter("@stno",SqlDbType.Char,5) {Value = t.stno},
                                    new SqlParameter("@gno",SqlDbType.Char,5) {Value = t.gno},
                                    new SqlParameter("@number",SqlDbType.Int,4) {Value = t.number} 
                                };
            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
        }


        #endregion

        #region 删除

        /// <summary>
        /// 删除该商品所有库存信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public int Delete(string no)
        {
            string strSql = "delete invent where gno='"+no+"'";
            int number = DBHelper.ExecuteNonQuery(strSql);
            return number;
        }
        /// <summary>
        /// 根据商品编号和库位号，删除该库存信息
        /// </summary>
        /// <param name="sno">库位号</param>
        /// <param name="gno">商品编号</param>
        /// <returns></returns>
        public int Delete(string sno, string gno)
        {
            string strSql = "delete invent where stno=@stno and gno=@gno";
            SqlParameter[] ps =
            {
                new SqlParameter("@stno", SqlDbType.Char, 5) {Value = sno},
                new SqlParameter("@gno", SqlDbType.Char, 5) {Value = gno}
            };
            int number = DBHelper.ExecuteNonQuery(strSql, ps);
            return number;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据商品编号，查询该商品库存
        /// </summary>
        /// <param name="gno">商品编号</param>
        /// <returns></returns>
        public invent GetSingleByno(string gno)
        {
            string strSql = "select top 1 * from invent where gno=@gno";
            SqlParameter ps = new SqlParameter("@gno",SqlDbType.Char,5) {Value = gno};
            var reader = DBHelper.ExecuteReader(strSql, ps);
            var inv = new invent();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        inv.stno = reader.GetString(0);
                        inv.gno = reader.GetString(1);
                        inv.number = reader.GetInt32(2);
                    }
                }
            }
            return inv;
        }
        /// <summary>
        /// 根据商品编号与库位编号，查询该商品所在的库存信息，返回库存实体类
        /// </summary>
        /// <param name="stno">库位编号</param>
        /// <param name="gno">商品编号</param>
        /// <returns></returns>
        public invent GetSingleByno(string stno, string gno)
        {
            string strSql = "select top 1 * from invent where gno=@gno and stno=@stno";
            SqlParameter[] ps =
            {
                new SqlParameter("@gno", SqlDbType.Char, 5) { Value = gno },
                new SqlParameter("@stno",SqlDbType.Char,5) {Value = stno} 
            };
            var reader = DBHelper.ExecuteReader(strSql, ps);
            var inv = new invent();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        inv.stno = reader.GetString(0);
                        inv.gno = reader.GetString(1);
                        inv.number = reader.GetInt32(2);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return inv;
        }
        /// <summary>
        /// 根据条件，查询出库存信息，返回DataTable数据表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            string strSql = "select * from invent ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " where " + strWhere;
            }

            DataTable inventTable = DBHelper.GetDataTable(strSql);
            return inventTable;
        }
        #endregion
        
    }
}
