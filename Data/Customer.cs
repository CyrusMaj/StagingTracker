using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? ContactEmail { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<OrderManagement> OrderManagements { get; set; } = new List<OrderManagement>();
}
