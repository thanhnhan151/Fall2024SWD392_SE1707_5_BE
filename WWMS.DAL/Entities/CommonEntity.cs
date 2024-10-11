namespace WWMS.DAL.Entities
{
    public class CommonEntity
    {
        public DateTime? CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public string DeletedBy { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}