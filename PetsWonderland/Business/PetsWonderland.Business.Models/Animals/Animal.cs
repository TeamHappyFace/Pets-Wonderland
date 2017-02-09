using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Business.Models.Animals
{
	public class Animal : IAnimal
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string Name { get; set; }

		[Required]
		public int Age { get; set; }

		public string AvatarUrl { get; set; }

		[MinLength(ValidationConstants.MinAnimalDescription)]
		[MaxLength(ValidationConstants.MaxAnimalDescription)]
		public string Description { get; set; }

		public int? AnimalTypeId { get; set; }
		public virtual AnimalType AnimalType { get; set; }

		public bool IsDeleted { get; set; }
	}
}
