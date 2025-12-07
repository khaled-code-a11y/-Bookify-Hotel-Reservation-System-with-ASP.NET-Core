

namespace DEPI.BLL.DTOS
{
    public class ReserveRoomDTO
    {

        public int roomId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int customerId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;

    }
}
