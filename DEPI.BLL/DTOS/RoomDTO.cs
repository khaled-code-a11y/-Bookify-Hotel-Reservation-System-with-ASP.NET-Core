
using DEPI.DAL.Entities;

namespace DEPI.BLL.DTOS
{
    public class RoomDTO
    {
        public int RoomNumber { get; set; }
        public int TypeId { get; set; }
        public bool isAvailable { get; set; }

       
    }
}
