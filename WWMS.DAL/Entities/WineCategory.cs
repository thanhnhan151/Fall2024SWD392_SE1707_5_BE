namespace WWMS.DAL.Entities;

public partial class WineCategory
{
    public long Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Region { get; set; }

    public string? GrapeVariety { get; set; }

    public string? Color { get; set; }

    public string? AromaProfile { get; set; }

    public string? FlavorProfile { get; set; }

    public string? ProductionMethod { get; set; }

    public string? IdealServingTemp { get; set; }

    public string? FoodPairing { get; set; }

    public string? AgeingPotential { get; set; }

    public string? BottleShape { get; set; }

    public string? SugarContent { get; set; }

    public string? TanninLevel { get; set; }

    public string? AcidityLevel { get; set; }

    public string? Vineyard { get; set; }

    public virtual ICollection<Wine> Wines { get; set; } = [];
}
