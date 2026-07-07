using Eshop.Core.DTOs.Account;
using Eshop.Core.Services.Interfaces;
using Eshop.Data.Entities.Account;
using Eshop.Data.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Contstructor

        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> UserRepository)
        {
            _userRepository = UserRepository;
        }
        #endregion



        #region User Section
        public List<User> GetAllUsers()
        {
            return _userRepository.GetEntitiesQuery().ToList();
        }
        #endregion



        public RegisterUserResult RegisterUser(RegisterUserDTO register)
        {      
            
            if (IsUserExistsByEmail(register.Email))
                return RegisterUserResult.EmailExists;


            _userRepository.AddEntity(new User
            {              
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Address = register.Address,
                EmailActiveCode=Guid.NewGuid().ToString(),

            });

            _userRepository.SaveChanges();

            return RegisterUserResult.Success;
        }


        public bool IsUserExistsByEmail(string email)
        {
            return _userRepository.GetEntitiesQuery().Any(u => u.Email == email.ToLower().Trim());
        }


        #region Dispose
        public void Dispose()
        {
            _userRepository?.Dispose();
        }

        #endregion
    }
}
