namespace Providers_API.ViewModels
{
    public class VMActive
    {
        public int ActiveId { get; set; }

        public string ActiveName { get; set; } = null!;

        public string ActiveType { get; set; } = null!;

        public string? ShippingMethod { get; set; }

        public int? ProductCode { get; set; }
    }
}
