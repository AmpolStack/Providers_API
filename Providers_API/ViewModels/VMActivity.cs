namespace Providers_API.ViewModels
{
    public class VMActivity
    {
        public int ActivityId { get; set; }

        public int CiiuCode { get; set; }

        public string? ActivityType { get; set; }

        public string ActivityName { get; set; } = null!;

    }
}
