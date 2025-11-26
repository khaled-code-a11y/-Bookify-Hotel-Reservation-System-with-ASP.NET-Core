
namespace DEPI.DAL.Entities
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceType { get; set; } = null!;
        public int ServicePrice { get; set; }
        public string? Description { get; set; }

        public ICollection<BookingServiceModel>? BookingServices { get; set; }

    }
}
