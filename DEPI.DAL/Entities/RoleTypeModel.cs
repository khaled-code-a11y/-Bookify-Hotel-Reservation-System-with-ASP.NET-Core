
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
