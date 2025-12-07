

namespace DEPI.BLL.IServices
{
    public interface IAuthService
    {
        Task<RegisterDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
    }
}
