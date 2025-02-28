using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class OrderManagement
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? RequiredDispatchDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Dispatching> Dispatchings { get; set; } = new List<Dispatching>();
}
