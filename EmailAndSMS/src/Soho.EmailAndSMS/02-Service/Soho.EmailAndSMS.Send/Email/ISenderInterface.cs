using System.Collections.Generic;
using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Send.Email
{
    /// <summary>
    /// 电子邮件发送接口
    /// </summary>
    public interface ISenderInterface
    {
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="serivceConfig">服务配置</param>
        /// <param name="email">电子邮件对象</param>
        /// <returns>返回发送结果，OK-发送成功；其他-发送失败</returns>
        string Send(Dictionary<string, string> serivceConfig, EmailEntity email);
    }
}
