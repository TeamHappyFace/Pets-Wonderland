using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Animals.Contracts;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.Models.Animals
{
	public class HotelAnimal : IHotelAnimal
	{
		[Key]
		public int Id { get; set; }

		public int? HotelId { get; set; }
		public virtual Hotel Hotel { get; set; }

		public int? AnimalId { get; set; }
		public virtual Animal Animal { get; set; }

		public bool IsDeleted { get; set; }
	}
}
