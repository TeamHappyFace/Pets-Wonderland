using System.Linq;
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
			this.hotelRequestRepository = hotelRequestRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotelRequest(UserHotelRegistrationRequest requestToAdd)
		{
			this.hotelRequestRepository.Add(requestToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotelRequestById(object requestId)
		{
			this.hotelRequestRepository.Delete(requestId);
			this.unitOfWork.SaveChanges();
		}

		public IQueryable<UserHotelRegistrationRequest> GetAllHotelRequests()
		{
			return this.hotelRequestRepository.All();
		}

		public UserHotelRegistrationRequest GetById(int id)
		{
			return this.hotelRequestRepository.GetById(id);
		}
	}
}
