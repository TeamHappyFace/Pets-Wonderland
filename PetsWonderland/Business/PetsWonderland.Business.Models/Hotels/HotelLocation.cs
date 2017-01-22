using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Business.Models.Hotels
{
	public class HotelLocation
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstants.MinAddressDescription)]
		[MaxLength(ValidationConstants.MaxAddressDescription)]
		public string Address { get; set; }

		public bool IsDeleted { get; set; }
	}
}
