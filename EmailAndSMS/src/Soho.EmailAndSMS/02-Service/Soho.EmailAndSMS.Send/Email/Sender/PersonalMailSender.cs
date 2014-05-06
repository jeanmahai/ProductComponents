using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Service.Entity;

namespace Soho.EmailAndSMS.Send.Email.Sender
{
    /// <summary>
    /// 个人邮箱发送方式
    /// </summary>
    public class PersonalMailSender : ISenderInterface
    {
        public bool Send(EmailEntity email)
        {
            throw new NotImplementedException();
        }
    }
}
