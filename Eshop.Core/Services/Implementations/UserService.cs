using Eshop.Core.Services.Interfaces;
using Eshop.Data.Entities.Account;
using Eshop.Data.Repository;
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


        #region Dispose
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
        #endregion
    }
}
