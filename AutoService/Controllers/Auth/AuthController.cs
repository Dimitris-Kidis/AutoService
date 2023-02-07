using ApplicationCore.Domain.Entities;
using ApplicationCore.Services.Repository.AutoServiceRepository;
using AutoMapper;
using AutoService.Identity;
using Command.Auth.Login;
using Command.Auth.Registration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AutoService.Controllers.Auth
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AuthController(
            IMapper mapper,
            IMediator mediator,
            UserManager<User> userManager,
            SignInManager<User> signInManager
            )
        {
            _mapper = mapper;
            _mediator = mediator;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationCommand command)
        {
            if (command == null || !ModelState.IsValid) return BadRequest();
            var result = await _mediator.Send(command);
            if (result == -1) return BadRequest("An error occured...");
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, command.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var signinCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: AuthOptions.ISSUER,
                 audience: AuthOptions.AUDIENCE,
                 claims: new List<Claim>()
                 {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("role", $"{user.Role}"),
                     new Claim("fullname", $"{user.FirstName + " " + user.LastName}"),
                     new Claim("avatar", $"{user.Avatar}"),
                 },
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedToken });


        }

        [HttpPost]
        [Route("logout")]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }


        //[HttpGet("user-data/{userId}")]
        //public async Task<IActionResult> GetUserData(int userId)
        //{
        //    var result = await _mediator.Send(new GetUserQuery { UserId = userId });
        //    if (result == null)
        //    {
        //        return BadRequest("Entity is not found");
        //    }
        //    return Ok(_mapper.Map<UserViewModel>(result));
        //}
    }
}
