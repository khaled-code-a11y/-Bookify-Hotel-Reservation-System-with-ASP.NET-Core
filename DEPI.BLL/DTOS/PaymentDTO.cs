
namespace DEPI.BLL.DTOS
{
    public class PaymentDTO
    {
        public string Email { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public int roomId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int customerId { get; set; }
    }
}
