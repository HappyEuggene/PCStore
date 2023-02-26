using System;
using System.Collections.Generic;

namespace PCStore;

public partial class ItemType
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string? Model { get; set; }

    public string? Type { get; set; }

    public string? Manufacture { get; set; }

    public virtual Item? Item { get; set; }
}
