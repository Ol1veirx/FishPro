using FishPro.API.Models;
using FishPro.Application.Services.DTO;
using FishPro.Application.Services.Interfaces;
using FishPro.Core.Account;
using Microsoft.AspNetCore.Mvc;

namespace FishPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUserServices _userServices;
        private readonly ILogger<UserController> _logger;
        private IHttpContextAccessor _contextAccessor;

        public UserController(IAuthenticate authenticate, IUserServices userServices, ILogger<UserController> logger, IHttpContextAccessor contextAccessor)
        {
            _authenticate = authenticate;
            _userServices = userServices;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Create(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var emailExist = await _authenticate.UserExists(userDTO.Email);

            try
            {
                if (emailExist)
                {
                    return BadRequest("Email já cadastrado");
                }

                var user = await _userServices.CreateUserAsync(userDTO);
                if (user == null)
                {
                    return BadRequest("Ocorreu um erro ao cadastrar");
                }

                var token = _authenticate.GenerateToken(userDTO.Id, userDTO.Email);

                return new UserToken
                {
                    Token = token,
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, "Error");
                return StatusCode(500, "Erro");
            } 
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(LoginModel loginModel)
        {
            var existUser = await _authenticate.UserExists(loginModel.Email);

            if (!existUser)
            {
                return Unauthorized("Usuario não existe");
            }

            var result = await _authenticate.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Email ou senha inválidos");
            }

            var user = await _authenticate.GetUserByEmail(loginModel.Email);

            var token = _authenticate.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _contextAccessor.HttpContext.Response.Cookies.Delete("token");

            return Ok("Logout realizado com sucesso");
        }
    }
}
