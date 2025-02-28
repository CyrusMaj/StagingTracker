using System;
using System.Collections.Generic;

namespace StagingTracker.Data;

public partial class QualityControl
{
    public int Qcid { get; set; }

    public int? ReceivingId { get; set; }

    public DateOnly? InspectionDate { get; set; }

    public string? InspectionResult { get; set; }

    public string? InspectorName { get; set; }

    public virtual Receiving? Receiving { get; set; }
}
