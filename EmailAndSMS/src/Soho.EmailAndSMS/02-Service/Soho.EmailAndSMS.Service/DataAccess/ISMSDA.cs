using System.Data;
using System.Collections.Generic;

using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Service.DataAccess
{
    /// <summary>
    /// 短信数据处理接口
    /// </summary>
    internal interface ISMSDA
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <returns></returns>
        DataTable LoadConfig();

        /// <summary>
        /// 写入短信数据
        /// </summary>
        /// <param name="entity">短信对象</param>
        bool InsertSMS(SMSEntity entity);

        /// <summary>
        /// 查询短信数据
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="totalCounts">总记录数</param>
        /// <returns></returns>
        List<SMSEntity> QuerySMS(SMSQueryFilter filter, out int totalCounts);

        /// <summary>
        /// 获取待发送的短信列表
        /// </summary>
        /// <param name="topCnts">获取记录数</param>
        /// <returns></returns>
        List<SMSEntity> GetWaitSendSMSList(int topCnts);

        /// <summary>
        /// 更新短信状态
        /// </summary>
        /// <param name="sysNo">短信编号</param>
        /// <param name="status">状态</param>
        /// <param name="note">备注</param>
        void UpdateSMSStatus(long sysNo, SMSStatus status, string note);
    }
}
