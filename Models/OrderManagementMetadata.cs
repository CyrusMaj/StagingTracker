using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class OrderManagementMetadata
{
    [Display(Name = "Order ID")]
    public int OrderId { get; set; }

    [Display(Name = "Customer ID")]
    public int? CustomerId { get; set; }

    [Display(Name = "Order Date")]
    public DateOnly? OrderDate { get; set; }

    [Display(Name = "Required Dispatch Date")]
    public DateOnly? RequiredDispatchDate { get; set; }
}

[ModelMetadataType(typeof(OrderManagementMetadata))]
public partial class OrderManagement{}