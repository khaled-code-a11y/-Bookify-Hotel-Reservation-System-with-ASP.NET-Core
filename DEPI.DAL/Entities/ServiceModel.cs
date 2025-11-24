using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class ServiceModel
    {
        public int ServiceID { get; set; }
        public string ServiceType { get; set; }

        public int ServicePrice { get; set; } 
        public string Description { get; set; }
        public ICollection<BookingserviceModel> BookingserviceModel { get; set; }

    }
}
