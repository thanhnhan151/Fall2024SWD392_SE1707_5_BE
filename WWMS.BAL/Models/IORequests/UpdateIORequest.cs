namespace WWMS.BAL.Models.IORequests
{
    public class UpdateIORequest
    {

        public DateTime? StartDate { get; set; }
        public string Comments { get; set; }
        public string IOType { get; set; } = string.Empty;

        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public long? SuplierId { get; set; }
        public long? CustomerId { get; set; }

        public ICollection<UpdateIORequestDetail> UpIORequestDetails { get; set; } = [];

    }
}
