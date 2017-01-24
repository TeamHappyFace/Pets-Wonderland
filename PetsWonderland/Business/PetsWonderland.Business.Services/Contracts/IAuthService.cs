namespace PetsWonderland.Business.Services.Contracts
{
    public interface IAuthService
    {
        void LoginUser(string email, string password);

        void RegisterUser();

        void LogoutUser();
    }
}