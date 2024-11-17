using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public int CiiuCode { get; set; }

    public string? ActivityType { get; set; }

    public string ActivityName { get; set; } = null!;

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
