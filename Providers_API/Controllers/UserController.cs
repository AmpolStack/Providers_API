using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Providers_API.BLL.Definitions;
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
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IActiveService _activeService;
        public record credentials(string email, string password);
        public record provider_user_Register(RegisterVMUser user, VMProvider provider);
        public record provider_user_every(VMUser user, VMProvider Provider);

        public UserController(IUserService userService, 
            IMailService mailService, 
            IMapper mapper, 
            IProviderService providerService,
            IPostService postService,
            IActiveService activeService)
        {
            _userService = userService;
            _mailService = mailService;
            _mapper = mapper;
            _providerService = providerService;
            _postService = postService;
            _activeService = activeService;
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

        [HttpPost("GetUserById")]
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

        [HttpGet("temp/{idUser}")]
        public async Task<IActionResult> getProviderById([FromRoute] int idUser)
        {
            var response = await _providerService.GetProvider(idUser);
            var mapResponse = _mapper.Map<VMProvider>(response);
            return Ok(mapResponse);
        }

        [HttpPost("CreateAUserWithProvider")]
        public async Task<IActionResult> CreateAUserWithProvider([FromBody] provider_user_Register provider_User_Register )
        {
            User mapperUser = _mapper.Map<User>(provider_User_Register.user);
            var outputUser = await _userService.createNewUser(mapperUser);
            if (outputUser == null)
            {
                return BadRequest("No se pudo crear el usuario, ya existe una cuenta vinculada a este correo");
            }
            var responseUser = _mapper.Map<VMUser>(outputUser);
            var providerMapped = _mapper.Map<Provider>(provider_User_Register.provider);
            providerMapped.UserId = responseUser.UserId;
            var coincidense = await _userService.getUserById(providerMapped.UserId);
            if(coincidense == null)
            {
                return NotFound("El usuario no existe");
            }
      
            var response = await _providerService.creteNewProvider(providerMapped);

            if(response == null)
            {
                return NotFound("no se pudo crear el usuario proveedor");
            }
            var providerReponse = _mapper.Map<VMProvider>(response);
            return Ok(new { userResponse = responseUser, providerReponse = providerReponse });
        }

        [HttpGet("GetAllProvidersWithAllProperties")]
        public async Task<IActionResult> GetAllProviders()
        {
            var response = await _providerService.GetAllProvidersWithAllData();
            var convertResponse = _mapper.Map <List<VMProvider>>(response);
            return Ok(convertResponse);
        }
        [HttpGet("GetProviderWithAllPropertiesById")]
        public async Task<IActionResult> GetProviderById([FromQuery] int ProviderId)
        {
            var response = await _providerService.GetProviderWithAllDataById(ProviderId);
            var convertResponse = _mapper.Map<VMProvider>(response);
            return Ok(convertResponse);
        }

        [HttpGet("GetAllProvidersToMinimalResponse")]
        public async Task<IActionResult> GetMinimalProvidersToHome()
        {
            var reponse = await _providerService.GetAllProviders();
            return Ok(_mapper.Map<List<MinimalVMResponse>>(reponse));
        }

        [HttpGet("GetAllPostsToMinimalResponse")]
        public async  Task<IActionResult> GetAllPostToHome()
        {
            var response = await _postService.getAllPosts();
            if(response == null)
            {
                return NotFound("No se encontró ningún post");
            }
            var mapperRespone = _mapper.Map<List<MinimalVMResponse>>(response);
            return Ok(mapperRespone);
        }

        [HttpGet("GetAllActivesToMinimalResponse")]
        public async Task<IActionResult> GetAllActivesToMinimalResponse()
        {
            var response = await _activeService.getAllActives();
            if (response == null)
            {
                return NotFound("No se encontró ningún activo");
            }
            var mapperRespone = _mapper.Map<List<MinimalVMResponse>>(response);
            return Ok(mapperRespone);
        }

        [HttpPost("UpdateProvider")]
        public async Task<IActionResult> UpdateProvider([FromBody] VMProvider provider)
        {
            var response = await _providerService.UpdateProvider(_mapper.Map<Provider>(provider));
            if(response == false)
            {
                return BadRequest("no se pudo realizar la operación");
            }
            return Ok(response);
        }

    }
}
