using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinalYearProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinalYearProject.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }
        public async Task<ServiceResponse<string>> Login(string username, string password, string macadd)
        {
            var response = new ServiceResponse<String>();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            if (user == null)
            {
                response.Success = false;
                response.Message = "Authentication failed";
            }
            else if (!VerifyHashes(password, macadd, user.PasswordHash, user.PasswordSalt, user.UserMacHash))
            {
                response.Success = false;
                response.Message = "Authentication failed";
            }
            else
            {
                response.Data = CreateJWToken(user);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password, string macadd)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists!";
                return response;
            }
            CreatePasswordHash(password, macadd, out byte[] passwordHash, out byte[] passwordSalt, out byte[] machash);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserMacHash = machash;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            response.Message = "User added Succesfully!";
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, string macadd, out byte[] passwordHash, out byte[] passwordSalt, out byte[] machash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                machash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(macadd));
            }
        }

        private bool VerifyHashes(string password, string macadd, byte[] passwordHash, byte[] passwordSalt, byte[] machash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedPassHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedPassHash.Length; i++)
                {
                    if (computedPassHash[i] != passwordHash[i])
                        return false;
                }
                var computedMacHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(macadd));
                for (int i = 0; i < computedMacHash.Length; i++)
                {
                    if (computedMacHash[i] != machash[i])
                        return false;
                }
                return true;
            }

        }

        private string CreateJWToken(User user)
        {
            var claims = new List<Claim>{
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials (key,SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
            Subject = new ClaimsIdentity(claims),
            Expires = System.DateTime.Now.AddDays(1),
            SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}