using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public int UserID { get; set; }

        public UserModel? User { get; set; }
        public ICollection<CustomerModel> Customer { get; set; }

    }
}
