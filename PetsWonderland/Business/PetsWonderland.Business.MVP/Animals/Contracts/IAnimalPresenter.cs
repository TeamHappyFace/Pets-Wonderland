using PetsWonderland.Business.MVP.Animals.Args;

namespace PetsWonderland.Business.MVP.Animals.Contracts
{
    public interface IAnimalPresenter
    {
        void GetAllAnimals(object sender, GetAllAnimalsArgs e);

        void Finding(object sender, FindAnimalArgs e);
    }
}
