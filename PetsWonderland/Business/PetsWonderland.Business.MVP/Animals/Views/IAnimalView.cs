using System;
using PetsWonderland.Business.MVP.Animals.Args;
using PetsWonderland.Business.MVP.Animals.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Animals.Views
{
	public interface IAnimalView : IView<AnimalViewModel>
	{
		event EventHandler<FindAnimalArgs> Finding;
		event EventHandler<GetAllAnimalsArgs> GetAll;
	}
}
