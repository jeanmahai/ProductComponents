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
    /// 短信服务
    /// </summary>
    public class SMSProcessor
    {
        #region 短信服务实例
        private static SMSProcessor _Instance = null;
        public static SMSProcessor Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SMSProcessor();
                return _Instance;
            }
        }
        #endregion

        #region 获取数据持久化实现类
        private ISMSDA GetDAInstance
        {
            get
            {
                ISMSDA _instance = null;

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
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.SqlServer.SMSDA();
                        break;
                    case "MongoDB":
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.MongoDB.SMSDA();
                        break;
                    default:
                        _instance = new Soho.EmailAndSMS.Service.DataAccess.SqlServer.SMSDA();
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
            Dictionary<string, string> configs = new Dictionary<string, string>();
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

        #region 系统读写短信
        /// <summary>
        /// 插入短信
        /// 说明：短信若无审核，则初始状态写入200，否则写入0
        /// </summary>
        /// <param name="sms">短信对象</param>
        /// <returns></returns>
        public bool InsertSMS(SMSEntity sms)
        {
            return GetDAInstance.InsertSMS(sms);
        }

        /// <summary>
        /// 批量插入短信
        /// 说明：短信若无审核，则初始状态写入200，否则写入0
        /// </summary>
        /// <param name="smsList">短信对象列表</param>
        /// <returns></returns>
        public bool BatchInsertSMS(List<SMSEntity> smsList)
        {
            bool result = false;
            foreach (var sms in smsList)
            {
                result = GetDAInstance.InsertSMS(sms);
                if (!result)
                    break;
            }
            return result;
        }

        /// <summary>
        /// 查询短信
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<SMSEntity> QuerySMS(SMSQueryFilter filter)
        {
            QueryResult<SMSEntity> result = new QueryResult<SMSEntity>();
            int totalCounts = 0;
            var dataList = GetDAInstance.QuerySMS(filter, out totalCounts);
            result.TotalCount = totalCounts;
            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.ResultList = dataList;
            return result;
        }
        #endregion

        #region 短信发送服务读取短信
        /// <summary>
        /// 获取待发送的短信列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        public List<SMSEntity> GetWaitSendSMSList(int topCnts)
        {
            return GetDAInstance.GetWaitSendSMSList(topCnts);
        }

        /// <summary>
        /// 更新短信状态
        /// </summary>
        /// <param name="sysNo">短信编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        public void UpdateSMSStatus(long sysNo, SMSStatus status, string note = "")
        {
            GetDAInstance.UpdateSMSStatus(sysNo, status, note);
        }
        #endregion
    }
}
