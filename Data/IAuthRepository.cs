using FinalYearProject.Models;
using System.Threading.Tasks;

namespace FinalYearProject.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user,string password,string macadd);
        Task<ServiceResponse<string>> Login(String username, string password,string macadd);
        Task<bool> UserExists(string username);
        
    }
}