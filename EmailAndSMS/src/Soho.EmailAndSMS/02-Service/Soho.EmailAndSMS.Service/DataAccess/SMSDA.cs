using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Service.DataAccess
{
    /// <summary>
    /// 短信数据处理
    /// </summary>
    public class SMSDA
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadConfig()
        {
            DataTable dt = null;
            string sql = @"SELECT SysNo, Category, ConfigKey, ConfigValue
                                FROM [SohoEmailAndSMS].[dbo].[Configs](NOLOCK)
	                            WHERE [Category] = N'SMS'";
            DBHelper db = new DBHelper();
            try
            {
                dt = db.ExeSqlDataAdapter(CommandType.Text, sql);
            }
            catch (Exception ex)
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
        /// 写入短信数据
        /// </summary>
        /// <param name="entity">短信对象</param>
        public static bool InsertSMS(SMSEntity entity)
        {
            int retVal = 0;
            string sql = @"INSERT INTO [SohoEmailAndSMS].[dbo].[SMS]
                            ([UserSysNo]
                            ,[ReceiveName]
                            ,[ReceivePhoneNumber]
                            ,[SMSBody]
                            ,[Status]
                            ,[SendTime]
                            ,[InDate]
                            ,[LastUpdateTime]
                            ,[Note])
                        VALUES
                            (@UserSysNo
                            ,@ReceiveName
                            ,@ReceivePhoneNumber
                            ,@SMSBody
                            ,@Status
                            ,@SendTime
                            ,GETDATE()
                            ,NULL
                            ,@Note)";

            DBHelper db = new DBHelper();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                { 
                    new SqlParameter("@UserSysNo", entity.UserSysNo.HasValue ? entity.UserSysNo.Value : 0),
                    new SqlParameter("@ReceiveName", entity.ReceiveName),
                    new SqlParameter("@ReceivePhoneNumber", entity.ReceivePhoneNumber),
                    new SqlParameter("@SMSBody", entity.SMSBody),
                    new SqlParameter("@Status", entity.Status),
                    new SqlParameter("@SendTime", entity.SendTime.HasValue ? entity.SendTime.Value.ToString() : ""),
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
        /// 查询短信数据
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="totalCounts">总记录数</param>
        /// <returns></returns>
        public static List<SMSEntity> QuerySMS(SMSQueryFilter filter, out int totalCounts)
        {
            totalCounts = 0;
            List<SMSEntity> result = new List<SMSEntity>();

            string sql = @"SELECT COUNT(1)
                          FROM [SohoEmailAndSMS].[dbo].[SMS](NOLOCK)
                              WHERE #StrWhere#

                            SELECT TOP " + filter.PageSize.ToString() + @" T.* FROM
                               (SELECT 
                               row_number() over(order by InDate DESC) AS RowNumber
                              ,[SysNo]
                              ,[UserSysNo]
                              ,[ReceiveName]
                              ,[ReceivePhoneNumber]
                              ,[SMSBody]
                              ,[Status]
                              ,[SendTime]
                              ,[InDate]
                              ,[LastUpdateTime]
                              ,[Note]
                          FROM [SohoEmailAndSMS].[dbo].[SMS](NOLOCK)
                              WHERE #StrWhere#) T
                          WHERE T.[RowNumber] > @StartNumber AND T.[RowNumber] < @EndNumber";
            DBHelper db = new DBHelper();
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
                if (!string.IsNullOrWhiteSpace(filter.ReceivePhoneNumber))
                {
                    strWhere += " AND [ReceivePhoneNumber] LIKE '%' + @ReceivePhoneNumber + '%'";
                    param.Add(new SqlParameter("@ReceivePhoneNumber", filter.ReceivePhoneNumber));
                }
                if (!string.IsNullOrWhiteSpace(filter.Keywords))
                {
                    strWhere += " AND [SMSBody] LIKE '%' + @Keywords + '%'";
                    param.Add(new SqlParameter("@Keywords", filter.Keywords));
                }
                if (filter.Status.HasValue)
                {
                    strWhere += " AND [Status] = @Status";
                    param.Add(new SqlParameter("@Status", filter.Status));
                }
                if (filter.BeginInDate.HasValue)
                {
                    strWhere += " AND [InDate] >= @BeginInDate";
                    param.Add(new SqlParameter("@BeginInDate", filter.BeginInDate));
                }
                if (filter.EndInDate.HasValue)
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
                            result.Add(new SMSEntity()
                            {
                                SysNo = int.Parse(row["SysNo"].ToString()),
                                UserSysNo = string.IsNullOrWhiteSpace(row["UserSysNo"].ToString()) ? 0 : int.Parse(row["UserSysNo"].ToString()),
                                ReceiveName = row["ReceiveName"].ToString(),
                                ReceivePhoneNumber = row["ReceivePhoneNumber"].ToString(),
                                SMSBody = row["SMSBody"].ToString(),
                                Status = (SMSStatus)int.Parse(row["Status"].ToString()),
                                SendTime = string.IsNullOrWhiteSpace(row["SendTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["SendTime"].ToString()),
                                InDate = DateTime.Parse(row["InDate"].ToString()),
                                LastUpdateTime = string.IsNullOrWhiteSpace(row["LastUpdateTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["LastUpdateTime"].ToString()),
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
        /// 获取待发送的短信列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        public static List<SMSEntity> GetWaitSendSMSList(int topCnts)
        {
            List<SMSEntity> result = new List<SMSEntity>();

            string sql = @"DECLARE @TblSysNoList TABLE (GetSysNo INT);
INSERT INTO @TblSysNoList
SELECT TOP " + topCnts.ToString() + @" [SysNo]
	FROM [SohoEmailAndSMS].[dbo].[SMS](NOLOCK)
    WHERE [Status] = 200 OR ([Status] = 300 AND [SendTime] < GETDATE())

UPDATE [SohoEmailAndSMS].[dbo].[SMS] SET Status = 301
	WHERE [SysNo] IN (SELECT GetSysNo FROM @TblSysNoList)

SELECT [SysNo]
      ,[UserSysNo]
      ,[ReceiveName]
      ,[ReceivePhoneNumber]
      ,[SMSBody]
      ,[Status]
      ,[SendTime]
      ,[InDate]
      ,[LastUpdateTime]
      ,[Note]
          FROM [SohoEmailAndSMS].[dbo].[SMS](NOLOCK)
          WHERE [SysNo] IN (SELECT GetSysNo FROM @TblSysNoList)";
            DBHelper db = new DBHelper();
            try
            {
                DataTable dt = db.ExeSqlDataAdapter(CommandType.Text, sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        result.Add(new SMSEntity()
                        {
                            SysNo = int.Parse(row["SysNo"].ToString()),
                            UserSysNo = string.IsNullOrWhiteSpace(row["UserSysNo"].ToString()) ? 0 : int.Parse(row["UserSysNo"].ToString()),
                            ReceiveName = row["ReceiveName"].ToString(),
                            ReceivePhoneNumber = row["ReceivePhoneNumber"].ToString(),
                            SMSBody = row["SMSBody"].ToString(),
                            Status = (SMSStatus)int.Parse(row["Status"].ToString()),
                            SendTime = string.IsNullOrWhiteSpace(row["SendTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["SendTime"].ToString()),
                            InDate = DateTime.Parse(row["InDate"].ToString()),
                            LastUpdateTime = string.IsNullOrWhiteSpace(row["LastUpdateTime"].ToString()) ? DateTime.MinValue : DateTime.Parse(row["LastUpdateTime"].ToString()),
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
        /// 更新短信状态
        /// </summary>
        /// <param name="sysNo">短信编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        public static void UpdateSMSStatus(long sysNo, SMSStatus status, string note)
        {
            string sql = @"UPDATE [SohoEmailAndSMS].[dbo].[SMS]
	                          SET [Status] = @Status,
		                          [LastUpdateTime] = GETDATE(),
		                          [Note] = ISNULL([Note], N'') + @Note
	                          WHERE [SysNo] = @SysNo";
            DBHelper db = new DBHelper();
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

        public static void InsertTests(long sysNo)
        {
            string sql = @"INSERT INTO [SohoEmailAndSMS].[dbo].[Tests] ([SysNo] ,[InDate])
VALUES (" + sysNo + ", GETDATE())";

            DBHelper db = new DBHelper();
            try
            {
                db.ExecuteNonQuery(CommandType.Text, sql);
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
