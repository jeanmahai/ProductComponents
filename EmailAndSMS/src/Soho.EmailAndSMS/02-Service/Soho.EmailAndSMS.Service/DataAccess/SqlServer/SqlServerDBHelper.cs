using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace Soho.EmailAndSMS.Service.DataAccess.SqlServer
{
    /// <summary>
    /// 底层程序与SqlServer数据库交互类
    /// </summary>
    public class SqlServerDBHelper
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        public static string ConnectionString
        {
            get
            {
                //  如果找不到应用程序配置中的数据库连接串配置，则加载配置文件配置
                string conn = string.Empty;
                if (ConfigurationManager.AppSettings["EmailAndSMSDbSettingConn"] == null)
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration\\EmailAndSMSConfig.xml");
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    conn = xmlDoc.SelectSingleNode("Root/EmailAndSMSDbSettingConn").InnerText;
                }
                else
                {
                    conn = ConfigurationManager.AppSettings["EmailAndSMSDbSettingConn"].ToString();
                }

                return Decrypt(conn);
            }
        }

        #region 连接串解密
        private static string Decrypt(string encryptionText)
        {
            string result = "";

            if (encryptionText.Length > 0)
            {
                byte[] bytes = Convert.FromBase64String(encryptionText);
                byte[] inArray = Decrypt(bytes);
                if (inArray.Length > 0)
                {
                    result = System.Text.Encoding.Unicode.GetString(inArray);
                }
            }
            return result;

        }
        private static byte[] Decrypt(byte[] bytesData)
        {
            byte[] result = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                ICryptoTransform cryptoServiceProvider = CreateAlgorithm().CreateDecryptor();
                using (CryptoStream stream2 = new CryptoStream(stream, cryptoServiceProvider, CryptoStreamMode.Write))
                {
                    stream2.Write(bytesData, 0, bytesData.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                    result = stream.ToArray();
                }
                stream.Close();
            }
            return result;
        }
        private static Rijndael CreateAlgorithm()
        {
            Rijndael rijndael = new RijndaelManaged();
            rijndael.Mode = CipherMode.CBC;
            byte[] key = System.Text.Encoding.Unicode.GetBytes("Nesc.Oversea");
            byte[] iv = System.Text.Encoding.Unicode.GetBytes("Oversea3");
            rijndael.Key = key;
            rijndael.IV = iv;
            return rijndael;
        }
        #endregion

        public SqlServerDBHelper()
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
