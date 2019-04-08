using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Configuration;

namespace Inventory.DBUnitily
{
    /// <summary>
    /// 数据库访问操作 ADO.NET
    /// SqlConnection
    /// SqlCommand:三个操作方法 ExecuteScalar(),ExecuteNonQuery();ExecuteReader(); +SQL ：简单SQL，带参数的SQL/存储过程：带参与不带参
    /// 数据库适配器：Fill+SQL带参、不带参
    /// </summary>
  public  class DBHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        #region 执行简单的SQL语句
        /// <summary>
        /// 执行简单SQL，得到首行首列的值 
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        public static Object ExecuteScalar(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(strSql, conn))
                    {
                        conn.Open();//打开连接
                        object obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value)
                        {
                            return null;
                        }
                        return obj;
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return null;
                }
            }
        }

        public static DataTable GetDataTable(string strSql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(strSql,connStr);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        #endregion

        #region 执行带有参数的SQL语句


        /// <summary>
        /// 执行查询，返回首行首列的值
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">SqlParameter类型的数组</param>
        /// <returns>结果集首行首列的值</returns>
        public static Object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();//打开连接
                        if (ps != null)
                        {
                            cmd.Parameters.AddRange(ps);//设置参数
                        }
                        object obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value)
                        {
                            return null;
                        }
                        return obj;
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return null;
                }
            }
        }


        /// <summary>
        /// 执行增、删、改SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">SqlParameter类型的数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();

                        if (ps != null)
                        {
                            cmd.Parameters.AddRange(ps);//添加参数
                        }
                        return cmd.ExecuteNonQuery();//0 或大于0的数
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return -1;
                }
            }
        }


        /// <summary>
        /// 执行查询并返回阅读器
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">SqlParameter类型的数组</param>
        /// <returns>SqlDataReader阅读器</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] ps)
        {
            //创建连接对象和数据库命令对象
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                //打开连接
                conn.Open();
                //添加参数
                if (ps != null)
                {
                    cmd.Parameters.AddRange(ps);
                }
                //执行查询，并返回阅读器
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                conn.Close();
                conn.Dispose();
                return null;
            }
        }

        
        /// <summary>
        /// 执行查询获取DataTable 
        /// </summary>
        /// <param name="sql">sql查询语句</param>
        /// <param name="ps">SqlParameter类型的数组</param>
        /// <returns></returns>
        public static DataTable GetDataTabe(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);//添加参数
                            }
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return null;
                }
            }
        }
        
        #endregion

        #region 执行带有参数的存储过程
        /// <summary>
        /// 执行存储过程，返回影响行数
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="ps">存储过程参数</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteProc(string procName, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ps != null)
                        {
                            cmd.Parameters.AddRange(ps);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return -1;
                }
            }
        }

        #endregion

    }

}
