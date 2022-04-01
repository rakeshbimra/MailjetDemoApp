using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    /// <summary>
    /// Email message to sent to intended recipients
    /// </summary>
    public abstract class EmailMessage
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public EmailAttachment Attachment { get; set; }
        public int TemplateId { get; set; }
        public abstract IEnumerable<EmailTemplateParameter> GetEmailTemplateParameters();

        protected static EmailTemplateParameter NewParameter(string name, string value)
        {
            return new EmailTemplateParameter
            {
                Name = name,
                Value = value
            };
        }
    }
}
