using AutoMapper;
using Azure.Core.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;
using Providers_API.ViewModels;

namespace Providers_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public record credentials(string email, string password);

        public UserController(IUserService userService, IMailService mailService, IMapper mapper)
        {
            _userService = userService;
            _mailService = mailService;
            _mapper = mapper;
        }


        [HttpGet("getUserList")]
        public async Task<List<VMUser>> GetAllUsers()
        {
            List<User> userList = await _userService.getUsersList();
            return _mapper.Map<List<VMUser>>(userList);
        }

        
        [HttpPost("GetUserByCredentials")]
        public async Task<IActionResult> getUserByPassword([FromBody] credentials credentials)
        {
            var response = await _userService.getUserByCredentials(credentials.email, credentials.password);
            if(response == null)
            {
                return NotFound("el usuario o contraseña son erroneos");
            }

            return Ok(_mapper.Map<VMUser>(response));
        }

        [HttpPost("GetUserByCredentials")]
        public async Task<IActionResult> getUserById([FromQuery] int id)
        {
            var response = await _userService.getUserById(id);
            if (response == null)
            {
                return NotFound("No existe usuario vinculado a este id");
            }

            return Ok(_mapper.Map<VMUser>(response));
        }

        // Create users, the input variables are an record objects like mapper
        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> createNewUser([FromBody] RegisterVMUser user)
        {

            User mapperUser = _mapper.Map<User>(user);
            var outputUser = await _userService.createNewUser(mapperUser);
            if(outputUser == null)
            {
                return BadRequest("No se pudo crear el usuario, ya existe una cuenta vinculada a este correo");
            }
            return Ok(_mapper.Map<VMUser>(outputUser));
        }


        [HttpGet("SendMail")]
        public async Task<IActionResult> sendMail()
        {
            bool response = await _mailService.SendMail("meryblanco000@gmail.com", "test message", "the code is 394202,We waiting you response");
            return Ok(response);
        }




    }
}
