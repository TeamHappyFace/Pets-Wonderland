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
			Guard.WhenArgument(boardingRequestRepository, "Boarding request repository is null!").IsNull();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull();

			this.boardingRequestRepository = boardingRequestRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddBoardingRequest(UserBoardingRequest requestToAdd)
		{
			Guard.WhenArgument(requestToAdd, "Request to add is null!").IsNull();

			this.boardingRequestRepository.Add(requestToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteBoardingRequestById(object requestId)
		{
			Guard.WhenArgument(requestId, "Cannot delete request with id= null!").IsNull();

			this.boardingRequestRepository.Delete(requestId);
			this.unitOfWork.SaveChanges();
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
