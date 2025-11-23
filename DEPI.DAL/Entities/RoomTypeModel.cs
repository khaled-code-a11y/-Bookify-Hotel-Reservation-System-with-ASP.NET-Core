using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class RoomTypeModel
    {
        public int TypeId { get; set; }
        public int RoomCapacity { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }

        public ICollection<RoomModel>? Rooms { get; set; }
    }
}
