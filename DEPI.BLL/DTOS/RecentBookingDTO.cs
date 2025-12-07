
namespace DEPI.BLL.DTOS
{
    public class RecentBookingDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

    }
}
