using System.Collections.Generic;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.Models.Users.Contracts
{
    public interface IRegularUser
    {
        string Id { get; set; }

        ICollection<Animal> Animals { get; set; }

        bool IsDeleted { get; set; }
    }
}