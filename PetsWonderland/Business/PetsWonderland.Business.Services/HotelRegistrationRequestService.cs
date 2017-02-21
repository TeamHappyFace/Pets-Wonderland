using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class HotelRegistrationRequestService : IHotelRegistrationRequestService
    {
        private readonly IRepository<UserHotelRegistrationRequest> hotelRequestRepository;
        private readonly IUnitOfWork unitOfWork;

        public HotelRegistrationRequestService(IRepository<UserHotelRegistrationRequest> hotelRequestRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(hotelRequestRepository, "Hotel request repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.hotelRequestRepository = hotelRequestRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddHotelRequest(UserHotelRegistrationRequest requestToAdd)
        {
            Guard.WhenArgument(requestToAdd, "Request to add is null!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.hotelRequestRepository.Add(requestToAdd);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteHotelRequest(UserHotelRegistrationRequest requestToDelete)
        {
            Guard.WhenArgument(requestToDelete, "Request is null!").IsNull().Throw();

            using (var unitOfWork = this.unitOfWork)
            {
                this.hotelRequestRepository.Delete(requestToDelete);
                unitOfWork.SaveChanges();
            }
        }

        public void DeleteHotelRequestById(object requestId)
        {
            using (var unitOfWork = this.unitOfWork)
            {
                this.hotelRequestRepository.Delete(requestId);
                unitOfWork.SaveChanges();
            }
        }

        public IQueryable<UserHotelRegistrationRequest> GetAllHotelRequests()
        {
            return this.hotelRequestRepository.All()
                    .Where(req => req.IsDeleted == false)
                    .Where(req => req.IsAccepted == false);
        }

        public UserHotelRegistrationRequest GetById(int id)
        {
            return this.hotelRequestRepository.GetById(id);
        }

        public void UpdateAccepted(int userHotelRegistrationRequestId, bool isAccepted)
        {
            var userHotelRegistrationRequest = this.GetById(userHotelRegistrationRequestId);

            using (var unitOfWork = this.unitOfWork)
            {
                userHotelRegistrationRequest.IsAccepted = isAccepted;
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateDeleted(int requestId, bool isDeleted)
        {
            using (var unitOfWork = this.unitOfWork)
            {
                this.GetById(requestId).IsDeleted = isDeleted;
                unitOfWork.SaveChanges();
            }
        }
    }
}
