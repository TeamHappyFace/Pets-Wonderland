namespace PetsWonderland.Business.Services.Contracts
{
    public interface IUserService
    {
        string GetImageByUserId(string id);

        void UploadImage(string id, string path);
    }
}
