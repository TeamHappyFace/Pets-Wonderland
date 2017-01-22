using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Business.Models.Users
{
	public abstract class UserProfile
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string FirstName { get; set; }

		[Required]
		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string LastName { get; set; }

		[Required]
		[RegularExpression(RegexConstants.EmailRegex)]
		public string Email { get; set; }

		[Range(ValidationConstants.MinAge, ValidationConstants.MaxAge)]
		public int Age { get; set; }

		public string AvatarUrl { get; set; }
	}
}
