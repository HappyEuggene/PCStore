using System;
using System.Collections.Generic;

namespace PCStore;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int? OrdersId { get; set; }

    public virtual Order? Orders { get; set; }

    public virtual ICollection<Store> Stores { get; } = new List<Store>();
}
