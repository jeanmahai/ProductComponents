using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Soho.EmailAndSMS.Send.Email;
using Soho.EmailAndSMS.Service.Entity;
using Soho.EmailAndSMS.Service.Processor;
using Soho.EmailAndSMS.Send.SMS;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            
            //SMSTest();
            //SMSTest();
            //QueryMailTest();
            //InsertMailTest();
            InsertSMSTest();

            Console.WriteLine(DateTime.Now);
            Console.ReadKey(true);
        }

        static void EmailTest()
        {
            //(new EmailSendService()).StartSendMail();

            EmailQueryFilter filter = new EmailQueryFilter();
            filter.UserSysNo = 1001;
            filter.ReceiveName = "r";
            filter.EmailAddress = "j";
            //filter.Keywords = "1";
            //filter.Status = EmailStatus.SendSuccess;
            filter.BeginInDate = "2014-05-01 23:56:33.237";
            filter.EndInDate = "2014-06-02 23:56:33.237";
            filter.PageSize = 6;
            filter.PageIndex = 1;
            QueryResult<EmailEntity> list = EmailProcessor.Instance.QueryMail(filter);
            Console.WriteLine("ResultListCount:" + list.ResultList != null ? list.ResultList.Count : 0);
            Console.WriteLine("TotalCount:" + list.TotalCount);
            Console.WriteLine("PageCount:" + list.PageCount);
            Console.WriteLine("PageIndex:" + list.PageIndex);

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
        }
        static void SMSTest()
        {
            (new SMSSendService()).StartSendSMS();

            //SMSQueryFilter filter = new SMSQueryFilter();
            //filter.UserSysNo = 1002;
            //filter.ReceiveName = "e";
            //filter.ReceivePhoneNumber = "3";
            //filter.Keywords = "o";
            //filter.Status = SMSStatus.AuditPassed;
            //filter.BeginInDate = DateTime.Parse("2014-05-01 23:56:33.237");
            //filter.EndInDate = DateTime.Parse("2014-06-02 23:56:33.237");
            //filter.PageSize = 6;
            //filter.PageIndex = 1;
            //QueryResult<SMSEntity> list = SMSProcessor.Instance.QuerySMS(filter);
            //Console.WriteLine("ResultListCount:" + list.ResultList != null ? list.ResultList.Count : 0);
            //Console.WriteLine("TotalCount:" + list.TotalCount);
            //Console.WriteLine("PageCount:" + list.PageCount);
            //Console.WriteLine("PageIndex:" + list.PageIndex);

            //List<SMSEntity> list = new List<SMSEntity>();
            //for (int i = 1; i < 41; i++)
            //{
            //    list.Add(new SMSEntity()
            //    {
            //        UserSysNo = 1002,
            //        ReceiveName = "Test",
            //        ReceivePhoneNumber = "13833441501",
            //        SMSBody = "Body",
            //        Status = SMSStatus.AuditPassed
            //    });
            //}
            //SMSProcessor.Instance.BatchInsertSMS(list);
        }
        static void QueryMailTest()
        {
            EmailQueryFilter filter = new EmailQueryFilter()
            {
                PageIndex = 1,
                PageSize = 100,
                BeginInDate = "2014-01-01",
                EndInDate = "2014-08-01",
                UserSysNo = 1001,
                ReceiveName = "t",
                EmailAddress = "t",
                Keywords = "测",
                Status = EmailStatus.AuditPassed
            };
            var data = EmailProcessor.Instance.QueryMail(filter);
            if (data.ResultList != null)
                Console.WriteLine(data.ResultList.Count);
            else
                Console.WriteLine("NULL Data");
        }
        static void InsertMailTest()
        {
            EmailEntity entity = new EmailEntity() 
            {
                ReceiveName = "ABC",
                ReceiveAddress = "a@b.com",
                EmailTitle = "Test",
                EmailBody = "Test content",
                IsBodyHtml = false,
                EmailPriority = System.Net.Mail.MailPriority.Normal,
                Status = EmailStatus.AuditPassed
            };
            EmailProcessor.Instance.InsertMail(entity);
        }
        static void InsertSMSTest()
        {
            SMSEntity entity = new SMSEntity()
            {
                ReceiveName = "ABC",
                ReceivePhoneNumber = "13833441501",
                SMSBody = "Test短信",
                Status = SMSStatus.AuditPassed
            };
            SMSProcessor.Instance.InsertSMS(entity);
        }
    }
}
