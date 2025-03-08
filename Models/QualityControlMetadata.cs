using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace StagingTracker.Data;

public class QualityControlMetadata
{
    [Display(Name = "Quality Control ID")]
    public int Qcid { get; set; }

    [Display(Name = "Receiving ID")]
    public int? ReceivingId { get; set; }

    [Display(Name = "Inspection Date")]
    public DateOnly? InspectionDate { get; set; }

    [Display(Name = "Inspection Result")]
    public string? InspectionResult { get; set; }

    [Display(Name = "Inspector Name")]
    public string? InspectorName { get; set; }
}

[ModelMetadataType(typeof(QualityControlMetadata))]
public partial class QualityControl{}