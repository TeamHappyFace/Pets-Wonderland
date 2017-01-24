using System;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public void CreateBoardingRequest()
        {
            throw new NotImplementedException();
        }
    }
}
