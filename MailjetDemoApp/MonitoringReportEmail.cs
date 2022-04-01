using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    public class MonitoringReportEmail : EmailMessage
    {
        public override IEnumerable<EmailTemplateParameter> GetEmailTemplateParameters()
        {
            yield break;
        }
    }
}
