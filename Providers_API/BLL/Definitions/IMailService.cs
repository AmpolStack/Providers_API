namespace Providers_API.BLL.Definitions
{
    public interface IMailService
    {
        public Task<bool> SendMail(string DestinationAddress, string subject, string message); 
    }
}
