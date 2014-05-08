using System;
using System.Text;
using System.Net.Mail;
using System.ComponentModel;
using System.Collections.Generic;

using Soho.EmailAndSMS.Service;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Service.Processor;

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
        public void Send(Dictionary<string, string> serivceConfig, EmailEntity email)
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
                SmtpClient smtp = new SmtpClient(serivceConfig["PersonalEmailServerHost"], 25);
                smtp.UseDefaultCredentials = true;
                //指定发送方式
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //指定登录名和密码
                smtp.Credentials = new System.Net.NetworkCredential(serivceConfig["PersonalSendEmail"], serivceConfig["PersonalSendEmailPassword"]);

                //超时时间
                smtp.Timeout = int.Parse(serivceConfig["PersonalSendTimeout"]);
                smtp.SendCompleted += new SendCompletedEventHandler(SendCompleted);
                object userState = email;
                smtp.SendAsync(mail, userState);
            }

            catch (Exception ex)
            {
                Logger.WriteException(ex.ToString());
            } 
        }

        /// <summary>
        /// 异步发送完成处理该封电子邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">电子邮件对象</param>
        private void SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            bool bSendResult = true;
            string sendResult = string.Format("{0}：OK；", DateTime.Now);

            EmailEntity email = e.UserState as EmailEntity;

            if (e.Cancelled)
            {
                bSendResult = false;
                sendResult = string.Format("{0}：Cancelled；", DateTime.Now);
            }
            if (e.Error != null)
            {
                bSendResult = false;
                sendResult = string.Format("{0}：{1}；", DateTime.Now, e.Error.Message);
            }

            //更新电子邮件发送结果
            EmailStatus status = bSendResult ? EmailStatus.SendSuccess : EmailStatus.SendFailure;
            EmailProcessor.Instance.UpdateEmailStatus(email.SysNo.Value, status, sendResult);
        }
    }
}
