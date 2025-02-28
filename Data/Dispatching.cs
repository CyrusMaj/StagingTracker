using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class Dispatching
{
    public int DispatchId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityDispatched { get; set; }

    public DateOnly? DispatchDate { get; set; }

    public int? CarrierId { get; set; }

    public virtual OrderManagement? Order { get; set; }

    public virtual Product? Product { get; set; }
}
