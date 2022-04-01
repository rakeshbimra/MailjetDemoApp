using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    public class MailjetMessageBuilder : IMailjetMessageBuilder
    {
        public JArray BuildMailjetMessageFor(MailjetEmailMessage emailMessage)
        {
            var message = emailMessage.Attachment != null
                ? WithEmailAttachment(emailMessage) : WithoutEmailAttachment(emailMessage);

            return new JArray(message);
        }

        private JObject WithoutEmailAttachment(MailjetEmailMessage emailMessage)
        {
            return new JObject
            {
                {
                    "FromEmail",Environment.GetEnvironmentVariable("FromEmail")
                },
                {
                    "FromName",Environment.GetEnvironmentVariable("FromName")
                },
                {
                    "Recipients",GetRecipient(emailMessage)
                },
                {
                    "Mj-TemplateID",emailMessage.TemplateId
                },
                {
                    "TemplateLanguage",true
                },
                {
                    "Variables",new JObject
                    {
                        emailMessage.TemplateParameters.Select(_=>new JProperty(
                            _.Name.Replace("{{","").Replace("}}",""),_.Value))
                    }
                }
            };
        }

        private JObject WithEmailAttachment(MailjetEmailMessage emailMessage)
        {
            return new JObject
            {
                {
                    "FromEmail",Environment.GetEnvironmentVariable("FromEmail")
                },
                {
                    "FromName",Environment.GetEnvironmentVariable("FromName")
                },
                {
                    "Recipients",GetRecipient(emailMessage)
                },
                {
                    "Mj-TemplateID",emailMessage.TemplateId
                },
                {
                    "TemplateLanguage",true
                },
                {
                    "Variables",new JObject
                    {
                        emailMessage.TemplateParameters.Select(_=>new JProperty(
                            _.Name.Replace("{{","").Replace("}}",""),_.Value))
                    }
                },
                {
                    "Attachments",new JArray
                    {
                        new JObject
                        {
                            {"Content-type",emailMessage.Attachment.ContentType },
                            {"Filename",emailMessage.Attachment.FileName },
                            {"content",emailMessage.Attachment.Base64EncodedContent }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Get email recipients
        /// </summary>
        /// <param name="emailMessage"></param>
        /// <returns></returns>
        private JArray GetRecipient(MailjetEmailMessage emailMessage)
        {
            var emails = emailMessage.Recipient.Split('|');
            JArray array = new JArray();
            foreach (var email in emails)
            {
                array.Add(new JObject { { "Email", email } });
            }
            return array;
        }
    }
}
