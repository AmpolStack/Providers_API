using System;
using System.Collections.Generic;

namespace Providers_API.Models;

public partial class Provider
{
    public int ProviderId { get; set; }

    public int UserId { get; set; }

    public int Nit { get; set; }

    public string EntityName { get; set; } = null!;

    public string? AssociationPrefix { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Active> Actives { get; set; } = new List<Active>();

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
