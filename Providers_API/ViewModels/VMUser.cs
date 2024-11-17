namespace Providers_API.ViewModels
{
    public class VMUser
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string UserType { get; set; } = null!;

        public string? Description { get; set; }

        public string Email { get; set; } = null!;
    }
}
