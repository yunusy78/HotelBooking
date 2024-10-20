using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HotellBooking.Application.Interfaces;
using HotellBooking.Domain.DTOs.ApplicationUserDto;
using HotellBooking.Domain.DTOs.ReservationDto;
using HotellBooking.Domain.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotellBooking.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    
    
    public AuthController(IEfApplicationUserRepository applicationUserRepository, IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        _applicationUserRepository = applicationUserRepository;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    private readonly IEfApplicationUserRepository _applicationUserRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    [HttpPost("login")]
    
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (ModelState.IsValid)
        {
            // User authentication process
            var user = await _applicationUserRepository.Authenticate(model.Email!, model.Password);

            if (user != null)
            {
                // User is authenticated, get user roles
                var roles = await _applicationUserRepository.GetUserRoles(user);

                // User is authenticated, create a JWT token
                var token = CreateToken(user, roles);

                // Return JWT token to the user
                return Ok(new { token });
            }
            else
            {
                return BadRequest("Username or password is incorrect");
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    
    private string CreateToken(ApplicationUser user, string roles)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, roles),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(180),
            signingCredentials: creds
        );
        var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenHandler;
    }
    
    
    [HttpPost("register")]
    
    public async Task<IActionResult> Register(RegisterUserDto model)
    {
        if (ModelState.IsValid)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ProfilePicture = model.ProfilePicture
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok("User created successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
    
    
}