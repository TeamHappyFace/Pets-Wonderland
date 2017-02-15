using System;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Requests.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests
{
	public class UserHotelRegistrationRequest : IUserHotelRegistrationRequest
	{
		[Key]
		public int Id { get; set; }

		public DateTime DateOfRequest { get; set; }

		public string HotelManagerId { get; set; }
		public virtual HotelManager HotelManager { get; set; }

		public bool IsAccepted { get; set; }

		public bool IsDeleted { get; set; }

		public string Description { get; set; }
	}
}
