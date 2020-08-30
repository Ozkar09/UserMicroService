using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserMicroService.API.Facades;
using UserMicroService.Models;

namespace UserMicroService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutenticateController : ControllerBase
    {
        private readonly UsersMicroserviceFacade _usersMicroserviceFacade;

        public AutenticateController(UsersMicroserviceFacade usersMicroserviceFacade)
        {
            _usersMicroserviceFacade = usersMicroserviceFacade;
        }
        
        [HttpPost]
        public async Task<ActionResult<Users>> AutenticateUser(Autentication autentication)
        {
            return await _usersMicroserviceFacade.AutenticateUser(autentication);
        }
    }
}