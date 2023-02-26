using System;
using System.Collections.Generic;

namespace PCStore;

public partial class ItemSpec
{
    public int Id { get; set; }

    public int? ItemId { get; set; }

    public string Frequency { get; set; } = null!;

    public string MemCapacity { get; set; } = null!;

    public string MemType { get; set; } = null!;

    public string Cores { get; set; } = null!;

    public string Power { get; set; } = null!;

    public virtual Item? Item { get; set; }
}
