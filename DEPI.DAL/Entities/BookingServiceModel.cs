
namespace DEPI.DAL.Entities
{
    public class BookingServiceModel
    {
        public int BookingServiceId { get; set; }
        public int ServiceId { get; set; }
        public int ReservedId { get; set; }
        public int Quantity { get; set; }


        public ServiceModel? Service { get; set; }
        public ReservedroomModel? ReservedRoom { get; set; }
    }
}
