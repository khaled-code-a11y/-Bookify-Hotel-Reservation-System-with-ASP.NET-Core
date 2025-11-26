
namespace DEPI.DAL.Entities
{
    public class StaffModel
    {
        public int StaffId { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public int Salary { get; set; }

        public UserModel? User { get; set; }
        public RoleTypeModel? RoleType { get; set; }
    }
}
