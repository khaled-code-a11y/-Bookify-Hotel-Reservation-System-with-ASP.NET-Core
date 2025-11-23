using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class RoleTypeModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? TypeDescription { get; set; }

        public ICollection<StaffModel>? StaffMembers { get; set; }

    }
}
