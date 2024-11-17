namespace Providers_API.ViewModels
{
    public class RegisterVMUser
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string Password { get; set; } = null!;

        public string UserType { get; set; } = null!;

        public string? Description { get; set; }

        public string Email { get; set; } = null!;
    }
}
