using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    public interface IMailjetEmailService
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
