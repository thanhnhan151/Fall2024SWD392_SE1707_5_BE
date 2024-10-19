namespace WWMS.BAL.Models.IORequests
{
    public class CreateIORequestDetail
    {


        public DateTime? CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public DateTime? DeletedTime { get; set; }

        public int Quantity { get; set; }

        public long WineId { get; set; }

//        public long IORequestId { get; set; }

        public string Status { get; set; } = string.Empty;


    }
}
