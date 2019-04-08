using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Inventory.DBUnitily;
using Inventory.Model;

namespace Inventory.DAL
{
    public class IntoStoreDAL
    {
        #region 新增
        /// <summary>
        /// 入库记录操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(IntoStore t)
        {
            //intoID, gno, stno, number, intoTime
            //string sql = "proc_Into_Out";
            //SqlParameter[] ps =
            //{
            //    new SqlParameter("@gno", SqlDbType.Char,6) {Value = t.gno},
            //    new SqlParameter("@stno", SqlDbType.Char,3) {Value = t.stno},
            //    new SqlParameter("@number", SqlDbType.Int) {Value = t.number},
            //    new SqlParameter("@intotime",SqlDbType.DateTime) {Value=t.intoTime }
            //};
            //int num = DBHelper.ExecuteProc(sql, ps);
            //return num;

            string sql = "proc_Into_Out";
            SqlParameter[] ps =
            {
                new SqlParameter("@gno", SqlDbType.Char,6) {Value = t.gno},
                new SqlParameter("@stno", SqlDbType.Char,3) {Value = t.stno},
                new SqlParameter("@mno", SqlDbType.Char,3) {Value = t.mno},
                new SqlParameter("@number", SqlDbType.Int,4) {Value = t.number},
                new SqlParameter("intoTime",t.intoTime)
            };
            int num = DBHelper.ExecuteProc(sql, ps);
            return num;
        }
        #endregion

        #region 修改
        public int Update(IntoStore t)
        {
            throw new NotImplementedException();
        }
        #endregion



        public int Delete(string no)
        {
            throw new NotImplementedException();
        }

        public IntoStore GetSingleByno(string no)
        {
            throw new NotImplementedException();
        }

        

        public DataTable Query(string strWhere)
        {
            string strSql = "select * from IntoStore ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " where " + strWhere;
            }

            var intoStoreTable = DBHelper.GetDataTable(strSql);
            return intoStoreTable;
        }
        
    }
    
}
