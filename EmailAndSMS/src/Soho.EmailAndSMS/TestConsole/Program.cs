using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Send.Email;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Service.Processor;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

            //(new EmailSendService()).StartSendMail();

            //EmailQueryFilter filter = new EmailQueryFilter();
            //filter.UserSysNo = 1001;
            //filter.ReceiveName = "r";
            ////filter.Keywords = "1";
            //filter.Status = EmailStatus.SendSuccess;
            //filter.BeginInDate = DateTime.Parse("2014-05-01 23:56:33.237");
            //filter.EndInDate = DateTime.Parse("2014-06-02 23:56:33.237");
            //filter.PageSize = 6;
            //filter.PageIndex = 1;
            //QueryResult<EmailEntity> list = EmailProcessor.Instance.QueryMail(filter);
            //Console.WriteLine("ResultListCount:" + list.ResultList != null ? list.ResultList.Count : 0);
            //Console.WriteLine("TotalCount:" + list.TotalCount);
            //Console.WriteLine("PageCount:" + list.PageCount);
            //Console.WriteLine("PageIndex:" + list.PageIndex);

            //EmailEntity entity = new EmailEntity()
            //{
            //    UserSysNo = 1002,
            //    ReceiveName = "Test",
            //    ReceiveAddress = "Test@163.com",
            //    CCAddress = "",
            //    EmailTitle = "Test Tilte",
            //    EmailBody = "Body",
            //    IsBodyHtml = true,
            //    EmailPriority = System.Net.Mail.MailPriority.Normal,
            //    Status = EmailStatus.AuditPassed
            //};
            //EmailProcessor.Instance.InsertMail(entity);

            Console.WriteLine(DateTime.Now);
            Console.ReadKey(true);
        }
    }
}
