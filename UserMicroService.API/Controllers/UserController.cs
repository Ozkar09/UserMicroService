using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserMicroService.API.Facades;
using UserMicroService.Models;

namespace UserMicroService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersMicroserviceFacade _usersMicroserviceFacade;

        public UserController(UsersMicroserviceFacade usersMicroserviceFacade)
        {
            _usersMicroserviceFacade = usersMicroserviceFacade;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Users>>> FindAllUsers()
        {
            var users = await _usersMicroserviceFacade.FindAllUsers();
        
            return users;
        }
        
        [HttpGet("{userId}")]
        public async Task<ActionResult<Users>> FindUserById(long userId)
        {
            var user = await _usersMicroserviceFacade.FindUserById(userId);
        
            return user;
        }
        
        [HttpPost]
        public async Task<ActionResult<string>> SaveUser(Users user)
        {
            if (await _usersMicroserviceFacade.SaveUser(user))
                return "user successfully registered";
            
            return BadRequest("User was not registered");
        }
        
        [HttpPut]
        public async Task<ActionResult<Users>> UpdateUser(Users user)
        {
            return await _usersMicroserviceFacade.UpdateUser(user);
        }
        
        [HttpDelete("{userId}")]
        public async Task<ActionResult<bool>> DeleteUser(long userId)
        {
            return await _usersMicroserviceFacade.DeleteUser(userId);
        }
    }
}