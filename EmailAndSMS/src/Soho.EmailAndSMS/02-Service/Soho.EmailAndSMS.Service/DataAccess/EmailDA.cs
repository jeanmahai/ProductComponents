using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Service.DataAccess
{
    /// <summary>
    /// Email数据处理
    /// </summary>
    public class EmailDA
    {
        /// <summary>
        /// 写入Email数据
        /// </summary>
        /// <param name="entity">Email对象</param>
        public static bool InsertEmail(EmailEntity entity)
        {
            return true;
        }

        /// <summary>
        /// 查询Email数据
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="totalCounts">总记录数</param>
        /// <returns></returns>
        public static List<EmailEntity> QueryMail(EmailQueryFilter filter, out int totalCounts)
        {
            totalCounts = 0;
            return null;
        }

        /// <summary>
        /// 获取待发送的电子邮件列表
        /// </summary>
        /// <returns></returns>
        public static List<EmailEntity> GetWaitSendMailList()
        {
            List<EmailEntity> result = new List<EmailEntity>();
            return result;
        }

        /// <summary>
        /// 更新电子邮件状态
        /// </summary>
        /// <param name="sysNo">电子邮件编号</param>
        /// <param name="status">状态</param>
        public static void UpdateEmailStatus(int sysNo, EmailStatus status)
        { }
    }
}
