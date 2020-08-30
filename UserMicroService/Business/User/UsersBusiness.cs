using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroService.Models;
using UserMicroService.Repositories;

namespace UserMicroService.Business.User
{
    public class UsersBusiness : IUsersBusiness
    {
        private readonly IUserMicroserviceRepository _userMicroserviceRepository;
        
        public UsersBusiness(IUserMicroserviceRepository userMicroserviceRepository)
        {
            _userMicroserviceRepository = userMicroserviceRepository;
        }

        public async Task<List<Users>> FindAllUsers()
        {
            return await _userMicroserviceRepository.FindAllUsers();
        }

        public async Task<Users> FindUserById(long userId)
        {
            return await _userMicroserviceRepository.FindUserById(userId);
        }
        
        public async Task<bool> SaveUser(Users user)
        {
            return await _userMicroserviceRepository.SaveUser(user);
        }

        public async Task<Users> AutenticateUser(Autentication autentication)
        {
            return await _userMicroserviceRepository.AutenticateUser(autentication);
        }

        public async Task<Users> UpdateUser(Users user)
        {
            return await _userMicroserviceRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(long userId)
        {
            return await _userMicroserviceRepository.DeleteUser(userId);
        }
    }
}