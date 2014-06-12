using System;
using System.Data;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Collections.Generic;

using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Service.DataAccess.SqlServer
{
    /// <summary>
    /// Email数据处理
    /// </summary>
    public class EmailDA : IEmailDA
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public DataTable LoadConfig()
        {
            DataTable dt = null;
            string sql = @"SELECT SysNo, Category, ConfigKey, ConfigValue
                                FROM [SohoEmailAndSMS].[dbo].[Configs](NOLOCK)
	                            WHERE [Category] = N'Email'";
            SqlServerDBHelper db = new SqlServerDBHelper();
            try
            {
                dt = db.ExeSqlDataAdapter(CommandType.Text, sql);
            }
            catch(Exception ex) 
            {
                Logger.WriteException(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 写入Email数据
        /// </summary>
        /// <param name="entity">Email对象</param>
        public bool InsertEmail(EmailEntity entity)
        {
            int retVal = 0;
            string sql = @"INSERT INTO [SohoEmailAndSMS].[dbo].[Emails]
                            ([UserSysNo]
                            ,[ReceiveName]
                            ,[ReceiveAddress]
                            ,[CCAddress]
                            ,[EmailTitle]
                            ,[EmailBody]
                            ,[IsBodyHtml]
                            ,[EmailPriority]
                            ,[Status]
                            ,[SendTime]
                            ,[InDate]
                            ,[LastUpdateTime]
                            ,[Note])
                        VALUES
                            (@UserSysNo
                            ,@ReceiveName
                            ,@ReceiveAddress
                            ,@CCAddress
                            ,@EmailTitle
                            ,@EmailBody
                            ,@IsBodyHtml
                            ,@EmailPriority
                            ,@Status
                            ,@SendTime
                            ,GETDATE()
                            ,NULL
                            ,@Note)";

            SqlServerDBHelper db = new SqlServerDBHelper();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                { 
                    new SqlParameter("@UserSysNo", entity.UserSysNo.HasValue ? entity.UserSysNo.Value : 0),
                    new SqlParameter("@ReceiveName", string.IsNullOrWhiteSpace(entity.ReceiveName) ? "" : entity.ReceiveName),
                    new SqlParameter("@ReceiveAddress", entity.ReceiveAddress),
                    new SqlParameter("@CCAddress", string.IsNullOrWhiteSpace(entity.CCAddress) ? "" : entity.CCAddress),
                    new SqlParameter("@EmailTitle", entity.EmailTitle),
                    new SqlParameter("@EmailBody", entity.EmailBody),
                    new SqlParameter("@IsBodyHtml", entity.IsBodyHtml),
                    new SqlParameter("@EmailPriority", entity.EmailPriority),
                    new SqlParameter("@Status", entity.Status),
                    new SqlParameter("@SendTime", string.IsNullOrWhiteSpace(entity.SendTime) ? "" : entity.SendTime),
                    new SqlParameter("@Note", string.IsNullOrWhiteSpace(entity.Note) ? "" : entity.Note)
                };
                retVal = db.ExecuteNonQuery(CommandType.Text, sql, para);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }

            return retVal > 0 ? true : false;
        }

        /// <summary>
        /// 查询Email数据
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="totalCounts">总记录数</param>
        /// <returns></returns>
        public List<EmailEntity> QueryMail(EmailQueryFilter filter, out int totalCounts)
        {
            totalCounts = 0;
            List<EmailEntity> result = new List<EmailEntity>();

            string sql = @"SELECT COUNT(1)
                          FROM [SohoEmailAndSMS].[dbo].[Emails](NOLOCK)
                              WHERE #StrWhere#

                            SELECT TOP " + filter.PageSize.ToString() + @" T.* FROM
                               (SELECT 
                               row_number() over(order by InDate DESC) AS RowNumber
                              ,[SysNo]
                              ,[UserSysNo]
                              ,[ReceiveName]
                              ,[ReceiveAddress]
                              ,[CCAddress]
                              ,[EmailTitle]
                              ,[EmailBody]
                              ,[IsBodyHtml]
                              ,[EmailPriority]
                              ,[Status]
                              ,[SendTime]
                              ,[InDate]
                              ,[LastUpdateTime]
                              ,[Note]
                          FROM [SohoEmailAndSMS].[dbo].[Emails](NOLOCK)
                              WHERE #StrWhere#) T
                          WHERE T.[RowNumber] > @StartNumber AND T.[RowNumber] < @EndNumber";
            SqlServerDBHelper db = new SqlServerDBHelper();
            try
            {
                List<SqlParameter> param = new List<SqlParameter>();
                string strWhere = "1=1";
                if (filter.UserSysNo.HasValue)
                {
                    strWhere += " AND [UserSysNo] = @UserSysNo";
                    param.Add(new SqlParameter("@UserSysNo", filter.UserSysNo));
                }
                if (!string.IsNullOrWhiteSpace(filter.ReceiveName))
                {
                    strWhere += " AND [ReceiveName] LIKE '%' + @ReceiveName + '%'";
                    param.Add(new SqlParameter("@ReceiveName", filter.ReceiveName));
                }
                if (!string.IsNullOrWhiteSpace(filter.EmailAddress))
                {
                    strWhere += " AND ([ReceiveAddress] LIKE '%' + @EmailAddress + '%'";
                    strWhere += " OR [CCAddress] LIKE '%' + @EmailAddress + '%')";
                    param.Add(new SqlParameter("@EmailAddress", filter.EmailAddress));
                }
                if (!string.IsNullOrWhiteSpace(filter.Keywords))
                {
                    strWhere += " AND ([EmailTitle] LIKE '%' + @Keywords + '%'";
                    strWhere += " OR [EmailBody] LIKE '%' + @Keywords + '%')";
                    param.Add(new SqlParameter("@Keywords", filter.Keywords));
                }
                if (filter.Status.HasValue)
                {
                    strWhere += " AND [Status] = @Status";
                    param.Add(new SqlParameter("@Status", filter.Status));
                }
                if (!string.IsNullOrWhiteSpace(filter.BeginInDate))
                {
                    strWhere += " AND [InDate] >= @BeginInDate";
                    param.Add(new SqlParameter("@BeginInDate", filter.BeginInDate));
                }
                if (!string.IsNullOrWhiteSpace(filter.EndInDate))
                {
                    strWhere += " AND [InDate] <= @EndInDate";
                    param.Add(new SqlParameter("@EndInDate", filter.EndInDate));
                }
                long startNumber = (filter.PageIndex - 1) * filter.PageSize;
                long endNumber = filter.PageIndex * filter.PageSize + 1;
                param.Add(new SqlParameter("@StartNumber", startNumber));
                param.Add(new SqlParameter("@EndNumber", endNumber));

                sql = sql.Replace("#StrWhere#", strWhere);
                SqlParameter[] paramArray = param.ToArray();
                DataSet ds = db.ExeSqlDataSet(CommandType.Text, sql, paramArray);
                if (ds != null && ds.Tables.Count > 0)
                {
                    totalCounts = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                if (ds != null && ds.Tables.Count > 1)
                {
                    DataTable dt = ds.Tables[1];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            result.Add(new EmailEntity()
                            {
                                SysNo = int.Parse(row["SysNo"].ToString()),
                                UserSysNo = string.IsNullOrWhiteSpace(row["UserSysNo"].ToString()) ? 0 : int.Parse(row["UserSysNo"].ToString()),
                                ReceiveName = row["ReceiveName"].ToString(),
                                ReceiveAddress = row["ReceiveAddress"].ToString(),
                                CCAddress = row["CCAddress"].ToString(),
                                EmailTitle = row["EmailTitle"].ToString(),
                                EmailBody = row["EmailBody"].ToString(),
                                IsBodyHtml = row["IsBodyHtml"].ToString() == "1" ? true : false,
                                EmailPriority = (MailPriority)int.Parse(row["EmailPriority"].ToString()),
                                Status = (EmailStatus)int.Parse(row["Status"].ToString()),
                                SendTime = row["SendTime"].ToString(),
                                InDate = row["InDate"].ToString(),
                                LastUpdateTime = row["LastUpdateTime"].ToString(),
                                Note = row["Note"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }

            return result;
        }

        /// <summary>
        /// 获取待发送的电子邮件列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        public List<EmailEntity> GetWaitSendMailList(int topCnts)
        {
            List<EmailEntity> result = new List<EmailEntity>();

            string sql = @"DECLARE @TblSysNoList TABLE (GetSysNo INT);
INSERT INTO @TblSysNoList
SELECT TOP " + topCnts.ToString() + @" [SysNo]
	FROM [SohoEmailAndSMS].[dbo].[Emails](NOLOCK)
    WHERE [Status] = 200 OR ([Status] = 300 AND [SendTime] < GETDATE())

UPDATE [SohoEmailAndSMS].[dbo].[Emails] SET Status = 301
	WHERE [SysNo] IN (SELECT GetSysNo FROM @TblSysNoList)

SELECT [SysNo]
              ,[UserSysNo]
              ,[ReceiveName]
              ,[ReceiveAddress]
              ,[CCAddress]
              ,[EmailTitle]
              ,[EmailBody]
              ,[IsBodyHtml]
              ,[EmailPriority]
              ,[Status]
              ,[SendTime]
              ,[InDate]
              ,[LastUpdateTime]
              ,[Note]
          FROM [SohoEmailAndSMS].[dbo].[Emails](NOLOCK)
          WHERE [SysNo] IN (SELECT GetSysNo FROM @TblSysNoList)";
            SqlServerDBHelper db = new SqlServerDBHelper();
            try
            {
                DataTable dt = db.ExeSqlDataAdapter(CommandType.Text, sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        result.Add(new EmailEntity()
                        {
                            SysNo = int.Parse(row["SysNo"].ToString()),
                            UserSysNo = string.IsNullOrWhiteSpace(row["UserSysNo"].ToString()) ? 0 : int.Parse(row["UserSysNo"].ToString()),
                            ReceiveName = row["ReceiveName"].ToString(),
                            ReceiveAddress = row["ReceiveAddress"].ToString(),
                            CCAddress = row["CCAddress"].ToString(),
                            EmailTitle = row["EmailTitle"].ToString(),
                            EmailBody = row["EmailBody"].ToString(),
                            IsBodyHtml = row["IsBodyHtml"].ToString() == "1" ? true : false,
                            EmailPriority = (MailPriority)int.Parse(row["EmailPriority"].ToString()),
                            Status = (EmailStatus)int.Parse(row["Status"].ToString()),
                            SendTime = row["SendTime"].ToString(),
                            InDate = row["InDate"].ToString(),
                            LastUpdateTime = row["LastUpdateTime"].ToString(),
                            Note = row["Note"].ToString(),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }

            return result;
        }

        /// <summary>
        /// 更新电子邮件状态
        /// </summary>
        /// <param name="sysNo">电子邮件编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        public void UpdateEmailStatus(long sysNo, EmailStatus status, string note)
        {
            string sql = @"UPDATE [SohoEmailAndSMS].[dbo].[Emails]
	                          SET [Status] = @Status,
		                          [LastUpdateTime] = GETDATE(),
		                          [Note] = ISNULL([Note], N'') + @Note
	                          WHERE [SysNo] = @SysNo";
            SqlServerDBHelper db = new SqlServerDBHelper();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                { 
                    new SqlParameter("@SysNo", sysNo),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@Note", note)
                };
                db.ExecuteNonQuery(CommandType.Text, sql, para);
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.ToString());
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
