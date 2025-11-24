using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class ReservedroomModel
    {
        public int ReservedID { get; set; }
        public int CustomerID { get; set; }
        public int RoomID { get; set; }
        public DateTime CheckIN { get; set; }  
        public DateTime CheckOUT { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public ICollection<PaymentModel> PaymentModel { get; set; }  
        public ICollection<BookingserviceModel> Bookingservice { get; set; }
        public RoomModel? Room { get; set; }
        public CustomerModel? CustomerModel { get; set; }


    }
}
