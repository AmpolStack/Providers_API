namespace Providers_API.ViewModels
{
    public class VMCommentary
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public int Assessment { get; set; }

    }
}
