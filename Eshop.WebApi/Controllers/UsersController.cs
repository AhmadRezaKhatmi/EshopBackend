using Eshop.Core.Services.Interfaces;
using Eshop.Core.Utilities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{

    public class UsersController : SiteBaseController
    {

        #region Constructor

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion



        #region Users List

        [HttpGet("Users")]
        public IActionResult Users()
        {
            var users = _userService.GetAllUsers();

            return JsonResponseStatus.Success(users);
        }

        #endregion
    }
}
