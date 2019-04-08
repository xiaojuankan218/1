using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Inventory.DBUnitily;
using Inventory.Model;

namespace Inventory.DAL
{
    /// <summary>
    /// 管理员数据访问操作类
    /// </summary>
    public class ManagerDAL : IDataService<manager>
    {
        #region 新增
        /// <summary>
        /// 插入管理员信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(manager t)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into manager values(@mno,@mname,@sex,@birthday,@stno)");
            SqlParameter[] ps =
            {
               new SqlParameter("@mno", SqlDbType.Char, 3) {Value = t.mno},
               new SqlParameter("@mname", SqlDbType.VarChar, 20) {Value = t.mname},
               new SqlParameter("@sex", SqlDbType.Char, 2) {Value = t.sex},
               new SqlParameter("@birthday", SqlDbType.DateTime) {Value = t.birthday},
               new SqlParameter("@stno", SqlDbType.Char, 3) {Value = t.stno}
           };
            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update manager set mname=@mname,sex=@sex,birthday=@birthday,stno=@stno where mno=@mno");
            //strSql.Append(",birthday=@birthday,stno=@stno where mno=@mno");
            SqlParameter[] ps =
            {
               new SqlParameter("@mno", SqlDbType.Char, 3) {Value = t.mno},
               new SqlParameter("@mname", SqlDbType.VarChar, 20) {Value = t.mname},
               new SqlParameter("@sex", SqlDbType.Char, 2) {Value = t.sex},
               new SqlParameter("@birthday", SqlDbType.DateTime) {Value = t.birthday},
               new SqlParameter("@stno", SqlDbType.Char, 3) {Value = t.stno}
           };
            int number = DBHelper.ExecuteNonQuery(strSql.ToString(), ps);
            return number;
        }
        #endregion

        #region 删除

        /// <summary>
        /// 根据管理员编号，删除该管理员信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public int Delete(string mno)
        {
            string strSql = "delete from manager where mno=@mno";
            SqlParameter ps = new SqlParameter("@mno",SqlDbType.Char,3) {Value = mno};
            int number = DBHelper.ExecuteNonQuery(strSql, ps);
            return number;
        }

        #endregion

        #region 查询

        /// <summary>
        /// 根据管理员编号查询该管理员信息
        /// </summary>
        /// <param name="mno">管理员编号</param>
        /// <returns></returns>
        public manager GetSingleByno(string mno)
        {
            string strSql = "select top 1 * from manager where mno="+mno;
            var reader = DBHelper.ExecuteReader(strSql);
            var man = new manager();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        man.mno = reader.GetString(0);
                        man.mname = reader.GetString(1);
                        man.sex = reader.GetString(2);
                        man.birthday = reader.GetDateTime(3);
                        man.stno = reader.GetString(4);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return man;
        }

        /// <summary>
        /// 根据条件查询管理员信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Query(string strWhere)
        {
            string strSql = "select * from manager ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " where " + strWhere;
            }

            var managerTable = DBHelper.GetDataTable(strSql);
            return managerTable;
        }

        #endregion




    }
}
