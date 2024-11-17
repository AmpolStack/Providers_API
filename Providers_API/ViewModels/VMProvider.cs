namespace Providers_API.ViewModels
{
    public class VMProvider
    {
        public int ProviderId { get; set; }

        public int UserId { get; set; }

        public int Nit { get; set; }

        public string EntityName { get; set; } = null!;

        public string? AssociationPrefix { get; set; }
    }
}
