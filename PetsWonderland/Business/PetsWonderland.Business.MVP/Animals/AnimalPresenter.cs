using System;
using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.MVP.Animals.Args;
using PetsWonderland.Business.MVP.Animals.Contracts;
using PetsWonderland.Business.MVP.Animals.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Animals
{
    public class AnimalPresenter : Presenter<IAnimalView>, IAnimalPresenter
    {
        private readonly IAnimalService animalService;

        public AnimalPresenter(IAnimalView view, IAnimalService animalService)
            : base(view)
        {
            Guard.WhenArgument(view, "View is null!").IsNull().Throw();
            Guard.WhenArgument(animalService, "AnimalService is null!").IsNull().Throw();

            this.animalService = animalService;

            View.Finding += this.Finding;
            View.GetAll += this.GetAllAnimals;
            View.Model.Animals = new List<Animal>();
        }

        public void GetAllAnimals(object sender, GetAllAnimalsArgs e)
        {
            var allAnimals = this.animalService.GetAllAnimals().ToList();

            View.Model.Animals = allAnimals;
            View.Model.ShowResults = true;
        }

        public void Finding(object sender, FindAnimalArgs e)
        {
            if ((!e.Id.HasValue || e.Id <= 0) && string.IsNullOrEmpty(e.Name))
            {
                return;
            }

            if (e.Id.HasValue && e.Id > 0)
            {
                var animal = this.animalService.GetById((int)e.Id);
                View.Model.Animals.Add(animal);
            }

            View.Model.ShowResults = true;
        }
    }
}
