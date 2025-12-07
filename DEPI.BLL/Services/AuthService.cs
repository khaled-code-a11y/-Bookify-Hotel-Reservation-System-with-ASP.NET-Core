


using DEPI.DAL;
using Microsoft.EntityFrameworkCore;

namespace DEPI.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _dbContext;

        public AuthService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (user == null)
                throw new InvalidOperationException("Invalid email or password");

            if (user.Password != loginDTO.Password)
                throw new InvalidOperationException("Invalid email or password");

            string role = user.Email.ToLower() == "admin@admin.com" ? "Admin" : "Customer";

            return new LoginResponseDTO
            {
                Id = user.UserId,
                Email = user.Email,
                NationalId = user.NationalId,
                Name = user.Name,
                Role = role
            };
        }

        public async Task<RegisterDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            if (_dbContext.Users.Any(u => u.NationalId == registerDTO.NationalId))
                throw new InvalidOperationException("National ID already exists");

            if (_dbContext.Users.Any(u => u.Email == registerDTO.Email))
                throw new InvalidOperationException("Email already exists");

            var user = new UserModel
            {
                NationalId = registerDTO.NationalId,
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Phone = registerDTO.Phone,
                DOB = registerDTO.DOB,
                Gender = registerDTO.Gender,
                Address = registerDTO.Address,
                Password = registerDTO.Password,
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var customer = new CustomerModel
            {
                UserId = user.UserId,
            };
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            return new RegisterDTO
            {
                NationalId = user.NationalId,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                DOB = user.DOB,
                Gender = user.Gender,
                Address = user.Address,
            };
        }


    }
}
