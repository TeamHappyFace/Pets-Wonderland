using System;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests.Contracts
{
    public interface IUserBoardingRequest
    {
		int Id { get; set; }

		DateTime DateOfRequest { get; set; }

		string UserId { get; set; }

		RegularUser User { get; set; }

		bool IsAccepted { get; set; }

		bool IsDeleted { get; set; }
	}
}