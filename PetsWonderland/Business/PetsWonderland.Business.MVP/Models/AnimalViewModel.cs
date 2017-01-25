using System;
using System.Collections.Generic;
using System.Linq;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.MVP.Models
{
	public class AnimalViewModel
	{
		public bool ShowResults { get; set; }

		public IList<Animal> Animals { get; set; }
	}
}
