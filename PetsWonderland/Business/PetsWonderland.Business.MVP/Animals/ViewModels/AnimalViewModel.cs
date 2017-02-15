using System.Collections.Generic;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.MVP.Animals.ViewModels
{
	public class AnimalViewModel
	{
		public bool ShowResults { get; set; }

		public IList<Animal> Animals { get; set; }
	}
}
