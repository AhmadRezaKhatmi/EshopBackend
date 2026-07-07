using Eshop.Core.DTOs.Account;
using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
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

        #endregion

        #region Sign Out

        #endregion

    }
}
