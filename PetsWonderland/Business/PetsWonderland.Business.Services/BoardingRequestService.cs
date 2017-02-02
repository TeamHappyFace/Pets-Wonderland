using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class BoardingRequestService : IBoardingRequestService
	{
		private readonly IRepository<UserBoardingRequest> boardingRequestRepository;

		public BoardingRequestService(IRepository<UserBoardingRequest> boardingRequestRepository)
		{
			this.boardingRequestRepository = boardingRequestRepository;
		}

		public void AddBoardingRequest(UserBoardingRequest requestToAdd)
		{
			this.boardingRequestRepository.Add(requestToAdd);
		}

		public void DeleteBoardingRequestById(object requestId)
		{
			this.boardingRequestRepository.Delete(requestId);
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
