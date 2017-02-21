using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Common.Constants;
using PetsWonderland.Business.Models.Animals.Contracts;

namespace PetsWonderland.Business.Models.Animals
{
    public class AnimalType : IAnimalType
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
