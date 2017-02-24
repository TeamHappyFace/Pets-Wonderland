using System;
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

        public void AddHotelRequest(string hotelName, string hotelLocation, string hotelManagerId,
				string hotelDescription, DateTime dateOfRequest, string ImageUrl, bool isAccepted)
        {
			var requestToAdd = new UserHotelRegistrationRequest()
			{
				HotelName = hotelName,
				HotelLocation = hotelLocation,
				HotelManagerId = hotelManagerId,
				HotelDescription = hotelDescription,
				DateOfRequest = dateOfRequest,
				HotelImageUrl = ImageUrl,
				IsAccepted = isAccepted
			};

			using (var unitOfWork = this.unitOfWork)
            {
                this.hotelRequestRepository.Add(requestToAdd);
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
            using (var unitOfWork = this.unitOfWork)
            {
                this.GetById(userHotelRegistrationRequestId).IsAccepted = isAccepted;
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
