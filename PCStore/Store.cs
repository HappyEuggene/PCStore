using System;
using System.Collections.Generic;

namespace PCStore;

public partial class Store
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public int? UsersId { get; set; }

    public int? ItemId { get; set; }

    public virtual Item? Item { get; set; }

    public virtual User? Users { get; set; }
}
