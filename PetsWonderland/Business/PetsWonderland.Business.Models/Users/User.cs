using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.Models.Users
{
	public class User 
	{
		[Key]
		public int Id { get; set; }

		public int? UserProfileId { get; set; }
		public virtual UserProfile UserProfile { get; set; }

		private ICollection<UserAnimal> animals;

		public User()
		{
			this.animals = new HashSet<UserAnimal>();
		}

		[Required]
		public virtual ICollection<UserAnimal> Animals
		{
			get
			{
				return this.animals;
			}
			set
			{
				this.animals = value;
			}
		}

		public bool IsDeleted { get; set; }
	}
}
