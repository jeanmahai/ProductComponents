using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Service.Entity;
using System.Net.Mail;

namespace Soho.EmailAndSMS.Send.Email.Sender
{
    /// <summary>
    /// 个人邮箱发送方式
    /// </summary>
    public class PersonalMailSender : ISenderInterface
    {
        /// <summary>
        /// 个人邮箱发送方式
        /// </summary>
        /// <param name="serivceConfig">服务配置</param>
        /// <param name="email">电子邮件对象</param>
        /// <returns>返回发送结果，OK-发送成功；其他-发送失败</returns>
        public string Send(Dictionary<string, string> serivceConfig, EmailEntity email)
        {
            try
            {
                //邮件发送类 
                MailMessage mail = new MailMessage();
                //是谁发送的邮件
                mail.From = new MailAddress(serivceConfig["PersonalSendEmail"], serivceConfig["PersonalSendEmailNickName"]);
                
                //发送给谁
                foreach (string receiveAddress in email.ReceiveAddress.Split(';'))
                {
                    mail.To.Add(receiveAddress);
                }
                //抄送给谁
                if (!string.IsNullOrWhiteSpace(email.CCAddress))
                {
                    foreach (string ccAddress in email.CCAddress.Split(';'))
                    {
                        mail.CC.Add(ccAddress);
                    }
                }

                //标题 
                mail.Subject = email.EmailTitle;
                //内容编码 
                mail.BodyEncoding = Encoding.Default;
                //发送优先级 
                mail.Priority = email.EmailPriority;
                //邮件内容
                mail.Body = email.EmailBody;
                //是否HTML形式发送
                mail.IsBodyHtml = email.IsBodyHtml;

                //附件
                //if (fujian.Length > 0)
                //{
                //    mail.Attachments.Add(new Attachment(fujian));
                //}

                //邮件服务器和端口
                SmtpClient smtp = new SmtpClient("smtp.163.com", 25);
                smtp.UseDefaultCredentials = true;
                //指定发送方式
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //指定登录名和密码
                smtp.Credentials = new System.Net.NetworkCredential(serivceConfig["PersonalSendEmail"], serivceConfig["PersonalSendEmailPassword"]);

                //超时时间
                smtp.Timeout = 60000;
                smtp.Send(mail);
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            } 
        }
    }
}
