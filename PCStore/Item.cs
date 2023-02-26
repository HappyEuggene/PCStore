using System;
using System.Collections.Generic;

namespace PCStore;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? ItemSpec { get; set; }

    public string? ItemType { get; set; }

    public virtual ICollection<ItemSpec> ItemSpecs { get; } = new List<ItemSpec>();

    public virtual ICollection<ItemType> ItemTypes { get; } = new List<ItemType>();

    public virtual ICollection<Store> Stores { get; } = new List<Store>();
}
