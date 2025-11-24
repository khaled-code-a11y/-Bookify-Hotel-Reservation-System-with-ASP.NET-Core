using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class BookingserviceModel
    { 
        public int BookingServiceID { get; set; }
        public int ServiceID { get; set; }
        public int ReservedID { get; set; }
        public int Quantity { get; set; } 
        public ServiceModel? ServiceModel { get; set; }
        public ReservedroomModel? ReservedroomModel { get; set; }
    }
}
