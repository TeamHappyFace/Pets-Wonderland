using System;
using System.Collections.Generic;
using System.Linq;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Data.Repositories;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Views;
using PetsWonderland.Business.MVP.Views.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Presenters
{
	public class AnimalPresenter : Presenter<IAnimalView>
	{
		private readonly IRepository<Animal> animalRepository;

		public AnimalPresenter(IAnimalView view)
			: this(view, new GenericRepository<Animal>())
        {
		}

		public AnimalPresenter(IAnimalView view, IRepository<Animal> animalRepository) : base(view)
        {
			this.animalRepository = animalRepository;
			View.Finding += Finding;
			view.GetAll += GetAllAnimals;
			View.Model.Animals = new List<Animal>();
		}

		private void GetAllAnimals(object sender, GetAllAnimalsArgs e)
		{
			IQueryable<Animal> allAnimals = this.animalRepository.All();
			View.Model.Animals = allAnimals.ToList();
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
				Animal animal = this.animalRepository.GetById((int)e.Id);
				View.Model.Animals.Add(animal);
			}

			View.Model.ShowResults = true;
		}
	}
}
