using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Model;
using System.Data.SqlClient;
using Inventory.DBUnitily;
using System.Data;

namespace Inventory.DAL
{
    public class OutStoreDAL
    {
        public int Insert(OutStore t)
        {
            string sql = "proc_OutStoreRecord";
            SqlParameter[] ps =
            {
                new SqlParameter("@gno", SqlDbType.Char,6) {Value = t.gno},
                new SqlParameter("@stno", SqlDbType.Char,3) {Value = t.stno},
                new SqlParameter("@mno", SqlDbType.Char,3) {Value = t.mno},
                new SqlParameter("@number", SqlDbType.Int,4) {Value = t.number}
            };
            int num = DBHelper.ExecuteProc(sql, ps);
            return num;
        }
    }
}
