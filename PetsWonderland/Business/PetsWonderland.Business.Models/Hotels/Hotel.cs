using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Hotels.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Hotels
{
	public class Hotel : IHotel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MinLength(ValidationConstants.MinHotelLength)]
		[MaxLength(ValidationConstants.MaxHotelLength)]
		public string Name { get; set; }

		public string ImageUrl { get; set; }

		[MinLength(ValidationConstants.MinHotelDescription)]
		[MaxLength(ValidationConstants.MaxHotelDescription)]
		public string Description { get; set; }

		public string HotelManagerId { get; set; }
		public virtual HotelManager HotelManager { get; set; }
		
		public int? LocationId { get; set; }
		public virtual HotelLocation Location { get; set; }

		public bool IsDeleted { get; set; }
	}
}
