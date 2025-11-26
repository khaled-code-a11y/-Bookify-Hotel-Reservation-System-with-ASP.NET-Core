
namespace DEPI.DAL.Entities
{
    public class ReservedroomModel
    {
        public int ReservedId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIN { get; set; }
        public DateTime CheckOUT { get; set; }
        public string Status { get; set; } = null!;

        public ICollection<PaymentModel>? Payment { get; set; }
        public ICollection<BookingServiceModel>? BookingService { get; set; }
        public RoomModel? Room { get; set; }
        public CustomerModel? Customer { get; set; }


    }
}
