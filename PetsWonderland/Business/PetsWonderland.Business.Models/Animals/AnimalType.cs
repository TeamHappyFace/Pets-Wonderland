using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Business.Models.Animals
{
	public class AnimalType
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Index(IsUnique = true)]
		[MinLength(ValidationConstants.MinTypeLength)]
		[MaxLength(ValidationConstants.MaxTypeLength)]
		public string Name { get; set; }

		public bool IsDeleted { get; set; }
	}
}
