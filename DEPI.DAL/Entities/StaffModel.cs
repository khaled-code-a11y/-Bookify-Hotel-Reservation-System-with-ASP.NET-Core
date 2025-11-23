using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class StaffModel
    {
        public int StaffId { get; set; }
        public int UserID { get; set; }
        public int TypeId { get; set; }
        public int Salary { get; set; }

        public UserModel? User { get; set; }
        public RoleTypeModel? RoleType { get; set; }
    }
}
