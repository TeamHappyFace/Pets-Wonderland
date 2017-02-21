using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Animals.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Animals
{
    public class UserAnimal : IUserAnimal
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }

        public int? AnimalId { get; set; }

        public virtual Animal Animal { get; set; }

        public bool IsDeleted { get; set; }
    }
}
