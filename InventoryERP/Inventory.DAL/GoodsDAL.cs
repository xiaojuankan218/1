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
    public class GoodsDAL:IDataService<goods>
    {

        #region 新增
        public int Insert(goods t)
        {
            string sql = "insert into goods values(@gno,@gname,@price,@producer)";
            SqlParameter[] ps =
            {
                new SqlParameter("@gno", SqlDbType.Char,6) {Value = t.gno},
                new SqlParameter("@gname", SqlDbType.VarChar,20) {Value = t.gname},
                new SqlParameter("@price", SqlDbType.Float) {Value = t.price},
                new SqlParameter("@producer", SqlDbType.VarChar,30) {Value = t.producer}
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion

        #region 修改
        public int Update(goods t)
        {
            string sql = "update goods set gname=@gname,price=@price,producer=@producer where gno=@gno ";
            SqlParameter[] ps =
            {
                new SqlParameter("@gno", SqlDbType.Char,6) {Value = t.gno},
                new SqlParameter("@gname", SqlDbType.VarChar,20) {Value = t.gname},
                new SqlParameter("@price", SqlDbType.Float) {Value = t.price},
                new SqlParameter("@producer", SqlDbType.VarChar,30) {Value = t.producer}
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion

        #region 删除

        public int Delete(string gno)
        {
            string strSql = "delete from goods where gno=@gno";
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from invent where gno='"+gno+"'");
            SqlParameter ps = null;
            DBHelper.ExecuteNonQuery(sb.ToString());
            
           ps = new SqlParameter("@gno", SqlDbType.Char, 6) { Value = gno };
                
            
            return DBHelper.ExecuteNonQuery(strSql, ps);

        }

        #endregion

        #region 查询

        public DataTable Query(string strWhere)
        {
            string strSql = "select * from goods ";
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " where " + strWhere;
            }

            var goodsTable = DBHelper.GetDataTable(strSql);
            return goodsTable;
        }

        public goods GetSingleByno(string gno)
        {
            string strSql = "select top 1 * from goods where gno=@gno";
            SqlParameter ps= new SqlParameter("@gno",SqlDbType.Char,6) {Value = gno};
            var reader = DBHelper.ExecuteReader(strSql, ps);
            var good = new goods();
            if (reader!= null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        good.gno = reader.GetString(0);
                        good.gname = reader.GetString(1);
                        good.price = Convert.ToDecimal(reader.GetValue(2));
                        good.producer = reader.GetString(3);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return good;
        }

        #endregion
    }
}
