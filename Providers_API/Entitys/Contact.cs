using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public int ProviderId { get; set; }

    public string ContactType { get; set; } = null!;

    public string ContactDescription { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;
}
