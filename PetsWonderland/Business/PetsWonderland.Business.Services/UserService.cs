using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserProfile> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<UserProfile> userRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRepository, "Userrepository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public string GetImageByUserId(string id)
        {
            return this.userRepository.GetById(id).AvatarUrl;
        }

        public void UploadImage(string id, string path)
        {
            Guard.WhenArgument(path, "path").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.userRepository.GetById(id).AvatarUrl = path;
                unitOfWork.SaveChanges();
            }
        }
    }
}
