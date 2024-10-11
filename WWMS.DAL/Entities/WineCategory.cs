using System.ComponentModel.DataAnnotations.Schema;

namespace WWMS.DAL.Entities
{
    public class WineCategory : CommonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string WineType { get; set; } = string.Empty;
        public ICollection<Wine> Wines { get; set; } = [];
    }
}