using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Hotels.Contracts;

namespace PetsWonderland.Business.Models.Hotels
{
	public class HotelLocation : IHotelLocation
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
