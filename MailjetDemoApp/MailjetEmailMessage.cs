using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    /// <summary>
    /// Mailjet email message
    /// </summary>
    public class MailjetEmailMessage
    {
        public MailjetEmailMessage(EmailMessage emailMessage)
        {
            TemplateId = emailMessage.TemplateId;
            TemplateParameters = emailMessage.GetEmailTemplateParameters();
            Recipient = emailMessage.Recipient;
            Subject = emailMessage.Subject;
            Attachment = emailMessage.Attachment;
        }
        public string Subject { get; set; }
        public string Recipient { get; set; }
        public IEnumerable<EmailTemplateParameter> TemplateParameters { get; set; }
        public EmailAttachment Attachment { get; set; }
        public int TemplateId { get; set; }
    }
}
