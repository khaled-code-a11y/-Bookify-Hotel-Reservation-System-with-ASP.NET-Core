

namespace DEPI.BLL.DTOS
{
    public class LoginResponseDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
