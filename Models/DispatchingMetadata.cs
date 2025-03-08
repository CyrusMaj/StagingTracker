using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class DispatchingMetadata
{
    [Display(Name = "Dispatch ID")]
    public int DispatchId { get; set; }

    [Display(Name = "Order ID")]
    public int? OrderId { get; set; }

    // public int? ProductId { get; set; }

    [Display(Name = "Quantity Dispatched")]
    public int? QuantityDispatched { get; set; }

    [Display(Name = "Dispatch Date")]
    public DateOnly? DispatchDate { get; set; }

    [Display(Name = "Carrier ID")]
    public int? CarrierId { get; set; }

    // public virtual OrderManagement? Order { get; set; }
}

[ModelMetadataType(typeof(DispatchingMetadata))]
public partial class Dispatching{}