namespace Providers_API.ViewModels
{
    public class VMPost
    {
        public int PostId { get; set; }

        public int ProviderId { get; set; }

        public string? ImageUrl { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
