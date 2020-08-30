using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroService.Models;
using UserMicroService.RemoteServices;

namespace UserMicroService.API.Facades
{
    public class UsersMicroserviceFacade
    {
        private readonly IUsersServices _usersServices;
        
        public UsersMicroserviceFacade(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        public async Task<List<Users>> FindAllUsers()
        {
            return await _usersServices.FindAllUsers();
        }
        
        public async Task<Users> FindUserById(long userId)
        {
            return await _usersServices.FindUserById(userId);
        }
        
        public async Task<bool> SaveUser(Users user)
        {
            return await _usersServices.SaveUser(user);
        }
        public async Task<Users> AutenticateUser(Autentication autentication)
        {
            return await _usersServices.AutenticateUser(autentication);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _usersServices.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(long userId)
        {
            return await _usersServices.DeleteUser(userId);
        }
    }
}