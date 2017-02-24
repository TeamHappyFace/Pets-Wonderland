using System;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class BoardingRequestService : IBoardingRequestService
    {
        private readonly IRepository<UserBoardingRequest> boardingRequestRepository;
        private readonly IUnitOfWork unitOfWork;

        public BoardingRequestService(IRepository<UserBoardingRequest> boardingRequestRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(boardingRequestRepository, "Boarding request repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.boardingRequestRepository = boardingRequestRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddBoardingRequest(string petName, int age, DateTime dateOfRequest, string fromDate, string toDate,
						string petBreed, string imageUrl, string userId, string hotelManagerId)
        {
			var requestToAdd = new UserBoardingRequest()
			{
				PetName = petName,
				Age = age,
				DateOfRequest = dateOfRequest,
				FromDate = fromDate,
				ToDate = toDate,
				PetBreed = petBreed,
				ImageUrl = imageUrl,
				UserId = userId,
				HotelManagerId = hotelManagerId
			};

			using (var unitOfWork = this.unitOfWork)
            {
                this.boardingRequestRepository.Add(requestToAdd);
                unitOfWork.SaveChanges();
            }
        }

        public IQueryable<UserBoardingRequest> GetAllBoardingRequests()
        {
            return this.boardingRequestRepository.All();
        }

        public UserBoardingRequest GetById(int id)
        {
            return this.boardingRequestRepository.GetById(id);
        }
    }
}
