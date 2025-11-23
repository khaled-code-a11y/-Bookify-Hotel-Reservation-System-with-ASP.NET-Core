using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public bool isAvailable { get; set; }
        public int RoomNumber { get; set; }
        public int TypeId { get; set; }

        public RoomTypeModel? RoomType { get; set; }
    }
}
