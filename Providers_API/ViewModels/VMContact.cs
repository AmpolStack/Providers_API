namespace Providers_API.ViewModels
{
    public class VMContact
    {
        public int ContactId { get; set; }

        //public int ProviderId { get; set; }

        public string ContactType { get; set; } = null!;

        public string ContactDescription { get; set; } = null!;

        public string Value { get; set; } = null!;
    }
}
