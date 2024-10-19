using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.IORequests
{
    public class CreateIORequest
    {

        public string RequestCode { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public string SupplierName { get; set; }
        public string CustomerName { get; set; }
 //       public string CheckerName { get; set; }
        public long RoomId { get; set; }
        public long CheckerId { get; set; }
        /// </summary>
        public ICollection<CreateIORequestDetail> IORequestDetails { get; set; } = [];
    }
}
