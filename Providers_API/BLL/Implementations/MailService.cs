
using Providers_API.BLL.Definitions;
using System.Net.Mail;
using System.Net;

namespace Providers_API.BLL.Implementations
{
    public class MailService : IMailService
    {
        private string _emailAddress = "htrsanbl@gmail.com";
        private string _credentialKey = "qdiwbwpfxenktigx";
        private string _alias = "providers_app";
        public async Task<bool> SendMail(string DestinationAddress, string subject, string message)
        {
            try
            {

                var credentials = new NetworkCredential(_emailAddress, _credentialKey);

                var mailForSend = new MailMessage()
                {
                    From = new MailAddress(_emailAddress, _alias),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,

                };

                mailForSend.To.Add(new MailAddress(DestinationAddress));

                var serverClient = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = credentials,
                    UseDefaultCredentials = false,
                    EnableSsl = true

                };


                serverClient.Send(mailForSend);
                serverClient.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
