using System.Collections.Generic;
using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Service.Processor
{
    /// <summary>
    /// 短信服务
    /// </summary>
    public class SMSProcessor
    {
        #region 短信服务实例
        private SMSProcessor _Instance = null;
        public SMSProcessor Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SMSProcessor();
                return _Instance;
            }
        }
        #endregion

        #region 系统读写短信
        /// <summary>
        /// 插入短信
        /// </summary>
        /// <param name="sms">短信对象</param>
        /// <returns></returns>
        public bool InsertSMS(SMSEntity sms)
        {
            return true;
        }

        /// <summary>
        /// 批量插入短信
        /// </summary>
        /// <param name="smsList">短信对象列表</param>
        /// <returns></returns>
        public bool BatchInsertSMS(List<SMSEntity> smsList)
        {
            return true;
        }

        /// <summary>
        /// 查询短信
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public QueryResult<SMSEntity> QuerySMS(SMSQueryFilter filter)
        {
            return null;
        }
        #endregion

        #region 短信发送服务读取短信
        /// <summary>
        /// 获取待发送的短信列表
        /// </summary>
        /// <returns></returns>
        public List<SMSEntity> GetWaitSendSMSList()
        {
            return null;
        }
        #endregion
    }
}
