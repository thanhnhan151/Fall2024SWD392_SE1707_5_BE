﻿using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class ExportRequest
{
    public long Id { get; set; }

    public string RequestCode { get; set; } = null!;

    public string? RequesterName { get; set; }

    public DateTime? ExportDate { get; set; }

    public string? DestinationAddress { get; set; }

    public int? TotalQuantity { get; set; }

    public string? Status { get; set; }

    public string? ShippingCompany { get; set; }

    public string? ShippingTrackingNumber { get; set; }

    public string? Comments { get; set; }

    public decimal? TotalValue { get; set; }

    public string? CustomsStatus { get; set; }

    public DateTime? ExpectedDelivery { get; set; }

    public string? InsuranceCoverage { get; set; }

    public string? DeliveryTerms { get; set; }

    public string? PackagingInstructions { get; set; }

    public bool? FragileItems { get; set; }

    public long UserId { get; set; }

    public long WineId { get; set; }

    public virtual ICollection<AdditionalImportRequest> AdditionalImportRequests { get; set; } = new List<AdditionalImportRequest>();

    public virtual ICollection<ExportWineWarehouse> ExportWineWarehouses { get; set; } = new List<ExportWineWarehouse>();

    public virtual Report? Report { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Wine Wine { get; set; } = null!;
}