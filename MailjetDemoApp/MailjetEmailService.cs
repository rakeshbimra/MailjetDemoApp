using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailjetDemoApp
{
    public class MailjetEmailService : IMailjetEmailService
    {
        private readonly IMailjetClientFactory _mailjetClientFactory;
        private readonly IMailjetMessageBuilder _messageBuilder;

        public MailjetEmailService(IMailjetClientFactory mailjetClientFactory,
            IMailjetMessageBuilder messageBuilder)
        {
            _mailjetClientFactory = mailjetClientFactory;
            _messageBuilder = messageBuilder;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            await SendEmail(new MailjetEmailMessage(emailMessage));
        }

        private async Task SendEmail(MailjetEmailMessage emailMessage)
        {
            var mailjetMessage = _messageBuilder.BuildMailjetMessageFor(emailMessage);

            var mailjetClient = _mailjetClientFactory.CreateClient();

            var mailjetResponse = await mailjetClient.PostAsync(new MailjetRequest
            {
                Resource = Send.Resource
            }.Property(Send.Messages, mailjetMessage));

            if (!mailjetResponse.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(mailjetResponse.GetErrorMessage());
            }
        }
    }
}
