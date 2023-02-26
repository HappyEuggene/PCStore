using System;
using System.Collections.Generic;

namespace PCStore;

public partial class Order
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? Price { get; set; }

    public string? Name { get; set; }

    public string? Delivery { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
