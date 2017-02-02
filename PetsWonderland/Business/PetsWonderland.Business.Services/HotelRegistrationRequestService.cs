using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelRegistrationRequestService : IHotelRegistrationRequestService
	{
		private readonly IRepository<UserHotelRegistrationRequest> hotelRequestRepository;

		public HotelRegistrationRequestService(IRepository<UserHotelRegistrationRequest> hotelRequestRepository)
		{
			this.hotelRequestRepository = hotelRequestRepository;
		}

		public void AddHotelRequest(UserHotelRegistrationRequest requestToAdd)
		{
			this.hotelRequestRepository.Add(requestToAdd);
		}

		public void DeleteHotelRequestById(object requestId)
		{
			this.hotelRequestRepository.Delete(requestId);
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
