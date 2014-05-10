using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soho.EmailAndSMS.Service.DataAccess.MongoDB
{
    public class EmailDA : IEmailDA
    {
        #region IEmailDA 成员

        public System.Data.DataTable LoadConfig()
        {
            throw new NotImplementedException();
        }

        public bool InsertEmail(Entity.EmailEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entity.EmailEntity> QueryMail(Entity.EmailQueryFilter filter, out int totalCounts)
        {
            throw new NotImplementedException();
        }

        public List<Entity.EmailEntity> GetWaitSendMailList(int topCnts)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmailStatus(long sysNo, Entity.EmailStatus status, string note)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
