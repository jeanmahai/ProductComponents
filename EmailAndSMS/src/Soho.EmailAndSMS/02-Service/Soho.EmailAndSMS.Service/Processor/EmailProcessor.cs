using System.Data;
using System.Collections.Generic;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Service.DataAccess;

namespace Soho.EmailAndSMS.Service.Processor
{
    /// <summary>
    /// 电子邮件服务
    /// </summary>
    public class EmailProcessor
    {
        #region 电子邮件服务实例
        private static EmailProcessor _Instance = null;
        public static EmailProcessor Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new EmailProcessor();
                return _Instance;
            }
        }
        #endregion

        #region 加载配置
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> LoadConfig()
        {
            Dictionary<string, string> configs = new Dictionary<string,string>();
            DataTable dt = EmailDA.LoadConfig();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    configs[row["ConfigKey"].ToString()] = row["ConfigValue"].ToString();
                }
            }
            return configs;
        }
        #endregion

        #region 系统读写电子邮件
        /// <summary>
        /// 插入电子邮件
        /// </summary>
        /// <param name="email">电子邮件对象</param>
        /// <returns></returns>
        public bool InsertMail(EmailEntity email)
        {
            return EmailDA.InsertEmail(email);
        }

        /// <summary>
        /// 批量插入电子邮件
        /// </summary>
        /// <param name="emailList">电子邮件对象列表</param>
        /// <returns></returns>
        public bool BatchInsertMail(List<EmailEntity> emailList)
        {
            bool result = false;
            foreach (var email in emailList)
            {
                result = EmailDA.InsertEmail(email);
                if (!result)
                    break;
            }
            return result;
        }

        /// <summary>
        /// 查询电子邮件
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<EmailEntity> QueryMail(EmailQueryFilter filter)
        {
            QueryResult<EmailEntity> result = new QueryResult<EmailEntity>();
            int totalCounts = 0;
            var dataList = EmailDA.QueryMail(filter, out totalCounts);
            result.TotalCount = totalCounts;
            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.ResultList = dataList;
            return result;
        }
        #endregion

        #region 电子邮件发送服务处理电子邮件
        /// <summary>
        /// 获取待发送的电子邮件列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        public List<EmailEntity> GetWaitSendMailList(int topCnts)
        {
            return EmailDA.GetWaitSendMailList(topCnts);
        }
        
        /// <summary>
        /// 更新电子邮件状态
        /// </summary>
        /// <param name="sysNo">电子邮件编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        public void UpdateEmailStatus(long sysNo, EmailStatus status, string note = "")
        {
            EmailDA.UpdateEmailStatus(sysNo, status, note);
        }
        #endregion
    }
}
