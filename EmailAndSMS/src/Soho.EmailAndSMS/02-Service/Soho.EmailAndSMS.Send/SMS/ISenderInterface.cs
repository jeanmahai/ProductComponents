using System.Collections.Generic;

using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Send.SMS
{
    /// <summary>
    /// 短信发送接口
    /// </summary>
    internal interface ISenderInterface
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="serivceConfig">服务配置</param>
        /// <param name="sms">短信对象</param>
        void Send(Dictionary<string, string> serivceConfig, SMSEntity sms);
    }
}
