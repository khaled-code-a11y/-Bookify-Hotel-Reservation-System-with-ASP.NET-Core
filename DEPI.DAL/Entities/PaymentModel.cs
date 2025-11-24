using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class PaymentModel
    {
        public int PaymentID { get; set; }
        public int Amount { get; set; } 
        public DateTime Date { get; set; } 
        public string PaymentMethod { get; set; }
        public int ReservedID { get; set; }
        public ReservedroomModel? ReservedroomModel { get; set; }
    }
}
