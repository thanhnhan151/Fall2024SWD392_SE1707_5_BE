using System;
using System.Collections.Generic;

namespace WWMS.DAL.Models;

public partial class Warehouse
{
    public long Id { get; set; }

    public string WarehouseName { get; set; } = null!;

    public string? LocationAddress { get; set; }

    public int? Capacity { get; set; }

    public int? CurrentOccupancy { get; set; }

    public string? ManagerName { get; set; }

    public string? ContactPhone { get; set; }

    public bool? ClimateControl { get; set; }

    public string? SecurityLevel { get; set; }

    public string? EmergencyContact { get; set; }

    public string? OperationalHours { get; set; }

    public int? YearBuilt { get; set; }

    public decimal? WarehouseArea { get; set; }

    public string? FireSafetyStatus { get; set; }

    public string? InsuranceCoverage { get; set; }

    public int? NumberOfEmployees { get; set; }

    public string? InspectionFrequency { get; set; }

    public virtual ICollection<CheckRequestWarehouse> CheckRequestWarehouses { get; set; } = new List<CheckRequestWarehouse>();

    public virtual ICollection<WineWarehouse> WineWarehouses { get; set; } = new List<WineWarehouse>();
}
