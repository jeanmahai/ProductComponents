using System;

using Newegg.Oversea.Framework.JobConsole.Client;
using Soho.EmailAndSMS.Send.Email;

namespace Soho.EmailAndSMS.EmailJobHost
{
    public class Program : IJobAction
    {
        public void Run(JobContext context)
        {
            (new EmailSendService()).StartSendMail();
            context.Message = " The Job run finish, status is OK.";
            Console.Write(context.Message);
        }
    }
}
