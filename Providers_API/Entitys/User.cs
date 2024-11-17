using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string Password { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public string? Description { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Commentary> Commentaries { get; set; } = new List<Commentary>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
