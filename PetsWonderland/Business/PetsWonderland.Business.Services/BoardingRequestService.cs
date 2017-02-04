using System.Linq;
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
			this.boardingRequestRepository = boardingRequestRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddBoardingRequest(UserBoardingRequest requestToAdd)
		{
			this.boardingRequestRepository.Add(requestToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteBoardingRequestById(object requestId)
		{
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
