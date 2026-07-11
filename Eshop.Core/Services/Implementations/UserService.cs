using Eshop.Core.DTOs.Account;
using Eshop.Core.Security;
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
        private readonly IPasswordHelper _passwordHelper;
        public UserService(IGenericRepository<User> UserRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = UserRepository;
            _passwordHelper = passwordHelper;   
        }
        #endregion



        #region User Section
        public List<User> GetAllUsers()
        {
            return _userRepository.GetEntitiesQuery().ToList();
        }

        public bool IsUserExistsByEmail(string email)
        {
            return _userRepository.GetEntitiesQuery().Any(u => u.Email == email.ToLower().Trim());
        }

        public bool IsUserExistsByEmailAndPassword(string email,string password)
        {
            return _userRepository.GetEntitiesQuery().Any(u => u.Email == email.ToLower().Trim() && u.Password==password);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetEntitiesQuery().SingleOrDefault(u => u.Email == email.ToLower().Trim());
        }

        public User GetUserByUserId(long userId)
        {
            return _userRepository.GetEntityById(userId);
        }

        #endregion

        #region Account

        public RegisterUserResult RegisterUser(RegisterUserDTO register)
        {      
            
            if (IsUserExistsByEmail(register.Email))
                return RegisterUserResult.EmailExists;


            _userRepository.AddEntity(new User
            {              
                Email = register.Email.SanitizeText(),
                FirstName = register.FirstName.SanitizeText(),
                LastName = register.LastName.SanitizeText(),
                Address = register.Address.SanitizeText(),
                EmailActiveCode=Guid.NewGuid().ToString(),
                Password = _passwordHelper.EncodePasswordMd5(register.Password)
            });

            _userRepository.SaveChanges();

            return RegisterUserResult.Success;
        }



        public LoginUserResult LoginUser(LoginUserDTO login)
        {
            //****************************************Check Email Exist

            if (!IsUserExistsByEmail(login.Email))
                return LoginUserResult.IncorrectData;

            //****************************************Check Activated
            var user = GetUserByEmail(login.Email);
            if(!user.IsActivated)
                return LoginUserResult.NotActivated;

            var loginHashedPassword = _passwordHelper.EncodePasswordMd5(login.Password);

            //****************************************Check Email & Password
            if (!IsUserExistsByEmailAndPassword(login.Email, loginHashedPassword))
                return LoginUserResult.IncorrectData;

            return LoginUserResult.Success;
        }

        #endregion


        #region Dispose
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
        #endregion
    }
}
