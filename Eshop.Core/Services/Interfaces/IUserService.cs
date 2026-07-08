using Eshop.Core.DTOs.Account;
using Eshop.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Interfaces
{
    //را هم پیاده کند IDisposable  را پیاده سازی کند باید حتما متد های  IUserService پس هر کلاسی که 
    public interface IUserService : IDisposable
    {
        List<User> GetAllUsers();

        RegisterUserResult RegisterUser(RegisterUserDTO register);

        bool IsUserExistsByEmail(string email);

        LoginUserResult LoginUser(LoginUserDTO loginUser);

        User GetUserByEmail(string email);

    }
}
