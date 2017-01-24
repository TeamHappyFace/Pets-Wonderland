using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public void LoginUser(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterUser()
        {
            throw new System.NotImplementedException();
        }

        public void LogoutUser()
        {
            throw new System.NotImplementedException();
        }
    }
}