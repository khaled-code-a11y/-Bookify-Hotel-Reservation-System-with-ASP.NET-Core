
namespace DEPI.DAL.Entities
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public UserModel? User { get; set; }
        public ICollection<ReservedroomModel>? ReservedRooms { get; set; }

    }
}
