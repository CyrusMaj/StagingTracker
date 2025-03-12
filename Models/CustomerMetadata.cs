using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class CustomerMetadata
{
    [Display(Name = "Customer ID")]
    public int CustomerId { get; set; }

    [Display(Name = "Customer Name")]
    public string? CustomerName { get; set; }

    [Display(Name = "Contact Email")]
    public string? ContactEmail { get; set; }

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    // public virtual ICollection<OrderManagement> OrderManagements { get; set; } = new List<OrderManagement>();
}

[ModelMetadataType(typeof(CustomerMetadata))]
public partial class Customer{}