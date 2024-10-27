namespace WWMS.BAL.Models.IORequests
{
    public class GetIORequest
    {

        public long Id { get; set; }
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public long? SuplierId { get; set; }
        public long? CustomerId { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<GetIORequestDetail> IORequestDetails { get; set; } = [];
    }
}
