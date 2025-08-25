using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs;
using Server.Extensions;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Authorize]
    public class UsersController(AppDbContext dbContext, ITokenService tokenService) : ControllerProvider
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<UserDto>> RegisterUser(UserRegisterDto userRegisterDto)
        {
            bool userExists = await dbContext.Users.AnyAsync(x => x.Email == userRegisterDto.Email);
            if (userExists) return Unauthorized("Email address already exists");

            using var hmac = new HMACSHA512();

            User user = new()
            {
                Email = userRegisterDto.Email,
                Username = userRegisterDto.Username,
                ProfilePictureUrl = userRegisterDto.ProfilePictureUrl,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key,
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return user.GenerateToken(tokenService);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginUser(UserLoginDto userLoginDto)
        {
            User? user = await dbContext.Users.SingleOrDefaultAsync(x => x.Email == userLoginDto.Email);
            if (user == null) return Unauthorized("User does not exist");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            byte[] computedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for (int i = 0; i < computedPassword.Length; i++)
            {
                if (user.PasswordHash[i] != computedPassword[i])
                    return Unauthorized("Password does not match");
            }

            return user.GenerateToken(tokenService);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<UserOverviewDto>>> ListUsers()
        {
            List<User> users = await dbContext.Users.ToListAsync();
            var usersOverview = from user in users
                                select user.Overview();

            return usersOverview.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserOverviewDto>> GetUserById(string id)
        {
            User? user = await dbContext.Users.FindAsync(id);
            if (user == null) return NotFound();

            return user.Overview();
        }
    }
}
