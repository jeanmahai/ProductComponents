using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soho.EmailAndSMS.Service.DataAccess.MongoDB
{
    public class SMSDA : ISMSDA
    {
        #region ISMSDA 成员

        public System.Data.DataTable LoadConfig()
        {
            throw new NotImplementedException();
        }

        public bool InsertSMS(Entity.SMSEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<Entity.SMSEntity> QuerySMS(Entity.SMSQueryFilter filter, out int totalCounts)
        {
            throw new NotImplementedException();
        }

        public List<Entity.SMSEntity> GetWaitSendSMSList(int topCnts)
        {
            throw new NotImplementedException();
        }

        public void UpdateSMSStatus(long sysNo, Entity.SMSStatus status, string note)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
