using Eshop.Core.DTOs.Account;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eshop.WebApi.Controllers
{

    public class AccountController : SiteBaseController
    {

        #region Constructor

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Register

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterUserDTO register)
        {
            if (ModelState.IsValid)
            {
                var res = _userService.RegisterUser(register);

                switch (res)
                {

                    case RegisterUserResult.EmailExists:
                        return JsonResponseStatus.Error(new
                        {
                            status = "EmailExist"
                        });

                }
            }
            return JsonResponseStatus.Success();

        }

        #endregion



        #region Login 
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDTO login)
        {
            if (ModelState.IsValid)
            {
                var res = _userService.LoginUser(login);

                switch (res)
                {

                    case LoginUserResult.IncorrectData:
                        return JsonResponseStatus.NotFound();

                    case LoginUserResult.NotActivated:
                        return JsonResponseStatus.Error(new
                        {
                            message="حساب کاربری شما فعال نشده است "
                        });


                    case LoginUserResult.Success:
                        var user = _userService.GetUserByEmail(login.Email);
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EshopJwtBearerSymmetricSecurityKey"));
                        var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                        var tokenOptions = new JwtSecurityToken(
                            issuer: "https://localhost:44381",
                            claims: new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Email),
                                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                            },
                            expires: DateTime.Now.AddDays(30),
                            signingCredentials: signInCredentials
                        );

                        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                        return JsonResponseStatus.Success(new
                        {
                            Token = tokenString,
                            expireTime = 30,
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            userId = user.Id,
                            address = user.Address
                        });
                }

            }

            return JsonResponseStatus.Error();

        }

        #endregion

        #region Sign Out

        [HttpGet("Sign_Out")]
        public IActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync();
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }
          
        #endregion

    }
}
