using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class ReceivingMetadata
{
    [Display(Name = "Receiving ID")]
    public int ReceivingId { get; set; }

    [Display(Name = "Purchase Order ID")]
    public int? PurchaseOrderId { get; set; }

    [Display(Name = "Product ID")]
    public int? ProductId { get; set; }

    [Display(Name = "Quantity Received")]
    public int? QuantityReceived { get; set; }

    [Display(Name = "Received Date")]
    public DateOnly? ReceivedDate { get; set; }

    [Display(Name = "Supplier ID")]
    public int? SupplierId { get; set; }

    [Display(Name = "Quality Controls")]
    public virtual ICollection<QualityControl> QualityControls { get; set; } = new List<QualityControl>();
}

[ModelMetadataType(typeof(ReceivingMetadata))]
public partial class Receiving {}