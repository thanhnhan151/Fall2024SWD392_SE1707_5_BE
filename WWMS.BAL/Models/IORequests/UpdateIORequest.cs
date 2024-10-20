namespace WWMS.BAL.Models.IORequests
{
    public class UpdateIORequest
    {
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string? SupplierName { get; set; }
        public string? CustomerName { get; set; }
        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<UpdateIORequestDetail> UpIORequestDetails { get; set; } = [];

    }
}
