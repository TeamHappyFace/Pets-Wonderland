using System.Linq;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Services.Contracts
{
	public interface IHotelRegistrationRequestService
	{
		IQueryable<UserHotelRegistrationRequest> GetAllHotelRequests();
		UserHotelRegistrationRequest GetById(int id);

		void AddHotelRequest(UserHotelRegistrationRequest requestToAdd);
		void DeleteHotelRequestById(object requestId);
		void DeleteHotelRequest(UserHotelRegistrationRequest requestToDelete);

		void UpdateAccepted(int userHotelRegistrationRequestId, bool isAccepted);
		void UpdateDeleted(int RequestId, bool isDeleted);
	}
}
