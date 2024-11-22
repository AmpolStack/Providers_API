using Providers_API.Models;

namespace Providers_API.ViewModels
{
    public class VMProvider
    {
        public int ProviderId { get; set; }

        //public int UserId { get; set; }

        public int Nit { get; set; }

        public string EntityName { get; set; } = null!;

        public string? AssociationPrefix { get; set; }

        public List<VMContact>? Contacts { get; set; }

        public List<VMActive>? Actives { get; set; }

        public List<VMActivity>? Activities { get; set; }
        public VMUser User { get; set; }
        public List<VMPost> Posts { get; set; }
    }
}
