using AutoMapper;
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
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        public record _credentials(int id, string password);

        public record _vmUser(string name, string address, string password, string userType, string description, string email);

        public UserController(IGenericRepository<User> repo, IMailService mailService, IMapper mapper)
        {
            _userRepository = repo;
            _mailService = mailService;
            _mapper = mapper;
        }


        [HttpGet("getUserList")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string user)
        {
            IQueryable userList = await _userRepository.GetAll();
            return Ok(new { userDeploy = user, data = userList });
        }

        
        [HttpPost("GetUserByCredentials")]
        public async Task<IActionResult> getUserByPassword([FromBody] _credentials credentials)
        {
            User resultUser = await _userRepository.Select((x) => (x.UserId == credentials.id) && (x.Password == credentials.password));
            if (resultUser == null)
            {
                return BadRequest("El usuario o contraseña son incorrectos");
            }
            return Ok(resultUser);
        }

        // Create users, the input variables are an record objects like mapper
        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> createNewUser([FromBody] RegisterVMUser user)
        {

            User convertUser = _mapper.Map<User>(user);
            var outputUser = await _userRepository.Create(convertUser);
            if(outputUser == null)
            {
                return BadRequest("No se pudo crear el usuario");
            }
            return Ok(outputUser);
        }


        [HttpGet("SendMail")]
        public async Task<IActionResult> sendMail()
        {
            bool response = await _mailService.SendMail("meryblanco000@gmail.com", "test message", "the code is 394202,We waiting you response");
            return Ok(response);
        }




    }
}
