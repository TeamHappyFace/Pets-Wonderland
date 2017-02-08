using System;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests
{
	public class UserBoardingRequest
	{
		[Key]
		public int Id { get; set; }

		public DateTime DateOfRequest { get; set; }

		public string UserId { get; set; }
		public virtual User User { get; set; }

		public int? HotelId { get; set; }
		public virtual Hotel Hotel { get; set; }

		public int? UserAnimalId { get; set; }
		public virtual UserAnimal UserAnimal { get; set; }

		public bool IsAccepted { get; set; }

		public bool IsDeleted { get; set; }
	}
}
