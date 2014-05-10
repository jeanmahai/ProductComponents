using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Configuration;
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

        #region 获取数据持久化实现类
        private IEmailDA GetDAInstance
        {
            get
            {
                IEmailDA _instance = null;

                string _DBType = string.Empty;
                if (ConfigurationManager.AppSettings["DBType"] == null)
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration\\EmailAndSMSConfig.xml");
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    _DBType = xmlDoc.SelectSingleNode("Root/DBType").InnerText;
                }
                else
                {
                    _DBType = ConfigurationManager.AppSettings["DBType"].ToString();
                }
                switch (_DBType)
                {
                    case "SQLServer":
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.SqlServer.EmailDA();
                        break;
                    case "MongoDB":
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.MongoDB.EmailDA();
                        break;
                    default:
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.SqlServer.EmailDA();
                        break;
                }
                return _instance;
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
            DataTable dt = GetDAInstance.LoadConfig();
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
        /// 说明：邮件若无审核，则初始状态写入200，否则写入0
        /// </summary>
        /// <param name="email">电子邮件对象</param>
        /// <returns></returns>
        public bool InsertMail(EmailEntity email)
        {
            return GetDAInstance.InsertEmail(email);
        }

        /// <summary>
        /// 批量插入电子邮件
        /// </summary>
        /// 说明：邮件若无审核，则初始状态写入200，否则写入0
        /// <param name="emailList">电子邮件对象列表</param>
        /// <returns></returns>
        public bool BatchInsertMail(List<EmailEntity> emailList)
        {
            bool result = false;
            foreach (var email in emailList)
            {
                result = GetDAInstance.InsertEmail(email);
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
            var dataList = GetDAInstance.QueryMail(filter, out totalCounts);
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
            return GetDAInstance.GetWaitSendMailList(topCnts);
        }
        
        /// <summary>
        /// 更新电子邮件状态
        /// </summary>
        /// <param name="sysNo">电子邮件编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        public void UpdateEmailStatus(long sysNo, EmailStatus status, string note = "")
        {
            GetDAInstance.UpdateEmailStatus(sysNo, status, note);
        }
        #endregion
    }
}
