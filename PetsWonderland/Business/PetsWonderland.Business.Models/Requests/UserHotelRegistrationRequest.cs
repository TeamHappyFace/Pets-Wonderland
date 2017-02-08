using System;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests
{
	public class UserHotelRegistrationRequest
	{
		[Key]
		public int Id { get; set; }

		public DateTime DateOfRequest { get; set; }

		public string HotelManagerId { get; set; }
		public virtual HotelManager HotelManager { get; set; }

		public int? HotelId { get; set; }
		public virtual Hotel Hotel { get; set; }

		public bool IsAccepted { get; set; }

		public bool IsDeleted { get; set; }
	}
}
