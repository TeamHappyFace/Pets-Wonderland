using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Business.Models.Hotels
{
	public class Hotel
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MinLength(ValidationConstants.MinHotelLength)]
		[MaxLength(ValidationConstants.MaxHotelLength)]
		public string Name { get; set; }

		public string HotelImageUrl { get; set; }

		[MinLength(ValidationConstants.MinHotelDescription)]
		[MaxLength(ValidationConstants.MaxHotelDescription)]
		public string Description { get; set; }

		public int? HotelLocationId { get; set; }
		public virtual HotelLocation HotelLocation { get; set; }

		public bool IsDeleted { get; set; }
	}
}
