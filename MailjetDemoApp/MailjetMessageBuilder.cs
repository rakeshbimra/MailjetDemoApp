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
                    "Mj-TemplateID",emailMessage.
                }

            };
        }
    }
}
