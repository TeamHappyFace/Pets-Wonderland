using PetsWonderland.Business.MVP.Args;

namespace PetsWonderland.Business.MVP.Presenters.Contracts
{
    public interface IAnimalPresenter
    {
        void GetAllAnimals(object sender, GetAllAnimalsArgs e);

        void Finding(object sender, FindAnimalArgs e);
    }
}