
namespace DEPI.DAL.Entities
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string NationalId { get; set; } = null!;
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
