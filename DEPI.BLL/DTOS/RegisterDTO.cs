

namespace DEPI.BLL.DTOS
{
    public class RegisterDTO
    {
        public string NationalId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string? Address { get; set; }


    }
}
