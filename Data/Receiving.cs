using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class Receiving
{
    public int ReceivingId { get; set; }

    public int? PurchaseOrderId { get; set; }

    public int? ProductId { get; set; }

    public int? QuantityReceived { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public int? SupplierId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<QualityControl> QualityControls { get; set; } = new List<QualityControl>();
}
