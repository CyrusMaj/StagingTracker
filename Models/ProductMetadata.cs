using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class ProductMetadata
{
    [Display(Name = "Product ID")]
    public int ProductId { get; set; }

    [Display(Name = "Product Name")]
    public string? ProductName { get; set; }

    [Display(Name = "Unit Price")]
    public decimal? UnitPrice { get; set; }
}

[ModelMetadataType(typeof(ProductMetadata))]
public partial class Product{}