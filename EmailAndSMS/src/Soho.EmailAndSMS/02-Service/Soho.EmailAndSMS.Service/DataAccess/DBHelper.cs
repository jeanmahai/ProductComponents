using System.Data;
using System.Data.SqlClient;

namespace Soho.EmailAndSMS.Service.DataAccess
{
    /// <summary>
    /// 底层程序与数据库交互类
    /// </summary>
    public class DBHelper
    {
        /*
        CollectResultEntity result = new CollectResultEntity();

            string sql = @"SELECT TOP 1 [PeriodNum],[RetTime] FROM [Helpmate].[dbo].[SourceData_28_Beijing] ORDER BY [PeriodNum] DESC";
            DBHelper db = new DBHelper();
            try
            {
                DataTable dt = db.ExeSqlDataAdapter(CommandType.Text, sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    result.PeriodNum = long.Parse(dt.Rows[0]["PeriodNum"].ToString()) + 1;
                    result.RetTime = DateTime.Parse(dt.Rows[0]["RetTime"].ToString());
                    //到23:55当天开奖就结束了，下一期在第二天9:05
                    if (result.RetTime.Hour == 23 && result.RetTime.Minute == 55)
                        result.RetTime = DateTime.Parse(string.Format("{0} 9:05", result.RetTime.ToShortDateString())).AddDays(1);
                    else
                        result.RetTime = result.RetTime.AddMinutes(5);
                }
                else
                {
                    result.PeriodNum = 0;
                }
            }
            catch (Exception ex)
            {
                WriteLog.Write(string.Format("GetBeijingNextPeriodNum读取SQL Server数据库期号失败，sql：{0}，错误信息：{1}", sql, ex.ToString()));
            }
            finally
            {
                db.Dispose();
            }

            return result;
        */

        private SqlConnection conn;
        private SqlCommand cmd;
        private static readonly string ConnectionString = "";//GetConfig.GetXMLValue(ConfigSource.NA, "SqlServices");

        public DBHelper()
        {
            conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = ConnectionString;

            try
            {
                conn.Open();
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public void Dispose()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }

            conn.Dispose();
        }

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        private void PrepareCommand(SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParams)
        {
            cmd.CommandText = cmdText;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            cmd.CommandType = cmdType;

            if (cmdParams != null)
            {
                foreach (SqlParameter param in cmdParams)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }

        /// <summary>
        /// Return Int
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            cmd = conn.CreateCommand();
            cmd.CommandTimeout = 300;
            try
            {
                PrepareCommand(null, cmdType, cmdText, commandParameters);

                int retVal = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cmd.Dispose();

                return retVal;
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        /// <summary>
        /// Return SqlDataReader
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            cmd = conn.CreateCommand();
            cmd.CommandTimeout = 300;

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work

            try
            {
                PrepareCommand(null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                cmd.Dispose();
                return rdr;
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        /// <summary>
        /// Return DataTable
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public DataTable ExeSqlDataAdapter(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            cmd = conn.CreateCommand();
            cmd.CommandTimeout = 300;
            try
            {
                PrepareCommand(null, cmdType, cmdText, commandParameters);
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                objDataAdapter.Fill(dt);
                cmd.Parameters.Clear();
                cmd.Dispose();
                return dt;
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        /// <summary>
        /// Return DataSet
        /// </summary>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public DataSet ExeSqlDataSet(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            cmd = conn.CreateCommand();
            cmd.CommandTimeout = 300;
            try
            {
                PrepareCommand(null, cmdType, cmdText, commandParameters);
                SqlDataAdapter objDataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                objDataAdapter.Fill(ds);
                cmd.Parameters.Clear();
                cmd.Dispose();
                return ds;
            }
            catch
            {
                Dispose();
                throw;
            }
        }
    }
}
