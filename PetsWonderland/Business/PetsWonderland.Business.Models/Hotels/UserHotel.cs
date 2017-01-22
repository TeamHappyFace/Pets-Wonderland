using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Hotels
{
	public class UserHotel
	{
		[Key]
		public int Id { get; set; }

		public int? UserId { get; set; }
		public virtual User User { get; set; }

		public int? HotelId { get; set; }
		public virtual Hotel Hotel { get; set; }

		public bool IsDeleted { get; set; }
	}
}
