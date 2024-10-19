namespace WWMS.BAL.Models.IORequests
{
    public class UpdateIORequest
    {
        //        public long Id { get; set; }
        //        public string RequestCode { get; set; } = null!;
        //        public DateTime? StartDate { get; set; }
        //        public DateTime? DueDate { get; set; }
        ////        public int? TotalQuantity { get; set; }
        //        public string? Comments { get; set; }
        //        public string IOType { get; set; } = string.Empty;
        //        public string PriorityLevel { get; set; } = string.Empty;
        //        public long RequesterId { get; set; }
        // //       public string? RequesterName { get; set; }

        //        public string Status { get; set; } = string.Empty;
        public long Id { get; set; }
        public string RequestCode { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string? SupplierName { get; set; }
        public string? CustomerName { get; set; }
        public string? CheckerName { get; set; }
        public long? RoomId { get; set; }
        public long? CheckerId { get; set; }
        public string Status { get; set; } = string.Empty;
        public ICollection<UpdateIORequestDetail> UpIORequestDetails { get; set; } = [];

    }
}
