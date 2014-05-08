using System.Collections.Generic;

using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Send.Email
{
    /// <summary>
    /// 电子邮件发送接口
    /// </summary>
    internal interface ISenderInterface
    {
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="serivceConfig">服务配置</param>
        /// <param name="email">电子邮件对象</param>
        void Send(Dictionary<string, string> serivceConfig, EmailEntity email);
    }
}
