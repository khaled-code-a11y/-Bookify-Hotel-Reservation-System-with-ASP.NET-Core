
namespace DEPI.DAL.Entities
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; } = null!;
        public int ReservedId { get; set; }

        public ReservedroomModel? ReservedRoom { get; set; }
    }
}
