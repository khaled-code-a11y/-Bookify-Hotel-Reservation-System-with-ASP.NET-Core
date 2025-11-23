using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPI.DAL.Entities
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string NationalID { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly DOB { get; set; }
        public string Gender { get; set; } = null!;
        public string? Address { get; set; }

        public CustomerModel? Customer { get; set; }
        public StaffModel? Staff { get; set; }

    }
}
