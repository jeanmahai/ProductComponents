using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Service.Entity;
using System.Data;

namespace Soho.EmailAndSMS.Service.DataAccess
{
    /// <summary>
    /// Email数据处理接口
    /// </summary>
    internal interface IEmailDA
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        DataTable LoadConfig();

        /// <summary>
        /// 写入Email数据
        /// </summary>
        /// <param name="entity">Email对象</param>
        bool InsertEmail(EmailEntity entity);

        /// <summary>
        /// 查询Email数据
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="totalCounts">总记录数</param>
        /// <returns></returns>
        List<EmailEntity> QueryMail(EmailQueryFilter filter, out int totalCounts);

        /// <summary>
        /// 获取待发送的电子邮件列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        List<EmailEntity> GetWaitSendMailList(int topCnts);

        /// <summary>
        /// 更新电子邮件状态
        /// </summary>
        /// <param name="sysNo">电子邮件编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        void UpdateEmailStatus(long sysNo, EmailStatus status, string note);
    }
}
