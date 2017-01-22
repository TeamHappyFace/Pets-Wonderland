using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Animals
{
	public class UserAnimal
	{
		[Key]
		public int Id { get; set; }

		public int? UserId { get; set; }
		public virtual User User { get; set; }

		public int? AnimalId { get; set; }
		public virtual Animal Animal { get; set; }

		public bool IsDeleted { get; set; }
	}
}
