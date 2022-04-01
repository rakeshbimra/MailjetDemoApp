using Mailjet.Client;

namespace MailjetDemoApp
{
    public class MailjetClientFactory : IMailjetClientFactory
    {
        public const string MailjetPublicKey = "MailjetPublicKey";
        public const string MailjetSecretKey = "MailjetSecretKey";

        public IMailjetClient CreateClient()
        {
            string mailjetPublicKeyValue = Environment.GetEnvironmentVariable(MailjetPublicKey);

            Ensure.ConditionIsMet(mailjetPublicKeyValue.IsNotNullOrEmpty(),
                () => throw new ArgumentNullException($"{nameof(MailjetPublicKey)} not configured"));

            string mailjetSecretKeyValue = Environment.GetEnvironmentVariable(MailjetSecretKey);

            Ensure.ConditionIsMet(mailjetSecretKeyValue.IsNotNullOrEmpty(),
                () => throw new ArgumentNullException($"{nameof(mailjetSecretKeyValue)} not configured"));

            return new MailjetClient(mailjetPublicKeyValue, mailjetSecretKeyValue) { };
        }
    }
}
