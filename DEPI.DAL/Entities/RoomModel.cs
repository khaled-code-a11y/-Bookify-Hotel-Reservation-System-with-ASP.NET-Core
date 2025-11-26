
namespace DEPI.DAL.Entities
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public bool isAvailable { get; set; }
        public int RoomNumber { get; set; }
        public int TypeId { get; set; }

        public RoomTypeModel? RoomType { get; set; }
        public ICollection<ReservedroomModel>? ReservedRooms { get; set; }


    }
}
