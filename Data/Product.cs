using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual ICollection<Dispatching> Dispatchings { get; set; } = new List<Dispatching>();

    public virtual ICollection<Receiving> Receivings { get; set; } = new List<Receiving>();
}
