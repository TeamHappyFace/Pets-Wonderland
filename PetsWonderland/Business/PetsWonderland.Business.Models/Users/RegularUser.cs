using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Users.Contracts;

namespace PetsWonderland.Business.Models.Users
{
    public class RegularUser : IRegularUser
    {
        private ICollection<Animal> animals;

        public RegularUser()
        {
            this.animals = new HashSet<Animal>();
        }

        [Key, ForeignKey("UserProfile")]
        public string Id { get; set; }

        public virtual UserProfile UserProfile { get; set; }
      
        [Required]
        public virtual ICollection<Animal> Animals
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
