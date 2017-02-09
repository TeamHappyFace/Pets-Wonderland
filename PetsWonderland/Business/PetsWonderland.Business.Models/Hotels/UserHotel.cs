using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Hotels.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Hotels
{
	public class UserHotel : IUserHotel
	{
		[Key]
		public int Id { get; set; }

		public string HotelManagerId { get; set; }
		public virtual HotelManager HotelManager{ get; set; }

		public int? HotelId { get; set; }
		public virtual Hotel Hotel { get; set; }

		public bool IsDeleted { get; set; }
	}
}
