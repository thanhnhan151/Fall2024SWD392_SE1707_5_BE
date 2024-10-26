namespace WWMS.BAL.Models.IORequests
{
    public class UpdateIORequest
    {
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string Comments { get; set; }
        public string IOType { get; set; } = string.Empty;

        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public long? SuplierId { get; set; }
        public long? CustomerId { get; set; }

        //public string? SupplierName { get; set; }
        //public string? CustomerName { get; set; }
        //public string? CheckerName { get; set; }
        public string status { get; set; }
        public ICollection<UpdateIORequestDetail> UpIORequestDetails { get; set; } = [];

    }
}
