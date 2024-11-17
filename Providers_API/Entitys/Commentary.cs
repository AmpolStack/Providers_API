using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class Commentary
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Text { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int Assessment { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
