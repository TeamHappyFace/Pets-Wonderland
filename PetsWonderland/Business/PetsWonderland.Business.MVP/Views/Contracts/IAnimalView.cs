using System;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Models;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Views.Contracts
{
	public interface IAnimalView : IView<AnimalViewModel>
	{
		event EventHandler<FindAnimalArgs> Finding;
		event EventHandler<GetAllAnimalsArgs> GetAll;
	}
}
