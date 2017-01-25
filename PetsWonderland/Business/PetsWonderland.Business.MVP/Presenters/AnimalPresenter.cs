using System;
using System.Collections.Generic;
using System.Linq;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Views.Contracts;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Presenters
{
	public class AnimalPresenter : Presenter<IAnimalView>
	{
	    private readonly IAnimalService animalService;

		public AnimalPresenter(IAnimalView view, IAnimalService animalService)
			: base(view)
		{
		    this.animalService = animalService;
            View.Finding += Finding;
            view.GetAll += GetAllAnimals;
            View.Model.Animals = new List<Animal>();
        }	

		private void GetAllAnimals(object sender, GetAllAnimalsArgs e)
		{
			var allAnimals = this.animalService.GetAllAnimals().ToList();

			View.Model.Animals = allAnimals;
			View.Model.ShowResults = true;
		}

		private void Finding(object sender, FindAnimalArgs e)
		{
			if ((!e.Id.HasValue || e.Id <= 0) && String.IsNullOrEmpty(e.Name))
			{
				return;
			}
			if (e.Id.HasValue && e.Id > 0)
			{
				//Animal animal = this.animalService.GetById((int)e.Id);
				//View.Model.Animals.Add(animal);
			}

			View.Model.ShowResults = true;
		}
	}
}
