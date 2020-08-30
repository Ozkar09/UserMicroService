using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroService.Models;

namespace UserMicroService.RemoteServices
{
    public interface IUsersServices
    {
        Task<List<Users>> FindAllUsers();
        Task<Users> FindUserById(long userId);
        Task<bool> SaveUser(Users user);
        Task<Users> AutenticateUser(Autentication autentication);
        Task<Users> UpdateUser(Users user);
        Task<bool> DeleteUser(long userId);
    }
}