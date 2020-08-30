using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroService.Business;
using UserMicroService.Models;

namespace UserMicroService.RemoteServices.User
{
    public class UserService : IUsersServices
    {
        private readonly IUsersBusiness _usersBusiness;
        
        public UserService(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }

        public async Task<List<Users>> FindAllUsers()
        {
            return await _usersBusiness.FindAllUsers();
        }
        
        public async Task<Users> FindUserById(long userId)
        {
            return await _usersBusiness.FindUserById(userId);
        }
        
        public async Task<bool> SaveUser(Users user)
        {
            return await _usersBusiness.SaveUser(user);
        }
        
        public async Task<Users> AutenticateUser(Autentication autentication)
        {
            return await _usersBusiness.AutenticateUser(autentication);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _usersBusiness.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(long userId)
        {
            return await _usersBusiness.DeleteUser(userId);
        }
    }
}