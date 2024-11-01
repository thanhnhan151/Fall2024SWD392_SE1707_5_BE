using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities;

[Table("Wine")]
public class Wine : CommonEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string WineName { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime MFD { get; set; } = DateTime.Now;
    public decimal ImportPrice { get; set; }
    public decimal ExportPrice { get; set; }

    public long CountryId { get; set; }
    public virtual Country Country { get; set; } = null!;

    public long TasteId { get; set; }
    public virtual Taste Taste { get; set; } = null!;

    public long ClassId { get; set; }
    public virtual Class Class { get; set; } = null!;

    public long QualificationId { get; set; }
    public virtual Qualification Qualification { get; set; } = null!;

    public long CorkId { get; set; }
    public virtual Cork Cork { get; set; } = null!;

    public long BrandId { get; set; }
    public virtual Brand Brand { get; set; } = null!;

    public long BottleSizeId { get; set; }
    public virtual BottleSize BottleSize { get; set; } = null!;

    public long AlcoholByVolumeId { get; set; }
    public virtual AlcoholByVolume AlcoholByVolume { get; set; } = null!;

    public long WineCategoryId { get; set; }
    public WineCategory WineCategory { get; set; } = null!;

    public ICollection<IORequestDetail> IORequestDetails { get; set; } = [];
    public ICollection<WineRoom> WineRooms { get; set; } = [];
}
