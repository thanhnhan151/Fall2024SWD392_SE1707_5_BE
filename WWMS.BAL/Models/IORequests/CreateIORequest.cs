using WWMS.DAL.Entities;

namespace WWMS.BAL.Models.IORequests
{
    public class CreateIORequest
    {

        public DateTime StartDate { get; set; }
        public string? Comments { get; set; }
        public string IOType { get; set; } = string.Empty;
        public long RoomId { get; set; }
        public long CheckerId { get; set; }
        public long? SuplierId { get; set; }
        public long? CustomerId { get; set; }


        /// </summary>
        public ICollection<CreateIORequestDetail> IORequestDetails { get; set; } = [];
    }
}
