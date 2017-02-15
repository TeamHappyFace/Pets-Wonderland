using System;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Requests.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests
{
	public class UserBoardingRequest : IUserBoardingRequest
	{
		[Key]
		public int Id { get; set; }

		public DateTime DateOfRequest { get; set; }

		public string UserId { get; set; }
		public virtual RegularUser User { get; set; }

		public bool IsAccepted { get; set; }

		public bool IsDeleted { get; set; }
	}
}
