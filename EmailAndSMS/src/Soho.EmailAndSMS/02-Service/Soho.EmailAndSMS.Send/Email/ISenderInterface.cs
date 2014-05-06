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
        /// <param name="email">电子邮件对象</param>
        /// <returns>发送成功失败</returns>
        bool Send(EmailEntity email);
    }
}
