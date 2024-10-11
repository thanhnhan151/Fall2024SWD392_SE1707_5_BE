using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

public partial class Wine : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string WineName { get; set; } = null!;
    public decimal? AlcoholContent { get; set; }
    public string? BottleSize { get; set; }
    public int? AvailableStock { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public DateTime? MFD { get; set; }
    //FOREIGN KEY
    public long WineCategoryId { get; set; }
    public WineCategory WineCategory { get; set; } = null!;

    public ICollection<WineRoom> WineRooms { get; set; } = [];
}
