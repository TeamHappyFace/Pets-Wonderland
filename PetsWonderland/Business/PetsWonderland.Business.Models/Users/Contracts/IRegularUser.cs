using System.Collections.Generic;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.Models.Users.Contracts
{
    public interface IRegularUser
    {
        ICollection<UserAnimal> Animals { get; set; }

        bool IsDeleted { get; set; }
    }
}