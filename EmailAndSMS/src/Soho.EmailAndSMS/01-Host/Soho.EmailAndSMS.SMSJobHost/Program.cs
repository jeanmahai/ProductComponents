using System;

using Newegg.Oversea.Framework.JobConsole.Client;
using Soho.EmailAndSMS.Send.SMS;

namespace Soho.EmailAndSMS.SMSJobHost
{
    public class Program : IJobAction
    {
        public void Run(JobContext context)
        {
            (new SMSSendService()).StartSendSMS();
            context.Message = " The Job run finish, status is OK.";
            Console.Write(context.Message);
        }
    }
}
