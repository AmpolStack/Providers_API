using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class Active
{
    public int ActiveId { get; set; }

    public string ActiveName { get; set; } = null!;

    public string ActiveType { get; set; } = null!;

    public string? ShippingMethod { get; set; }

    public int? ProductCode { get; set; }

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
