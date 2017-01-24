using System;
using System.Collections.Generic;
using PetsWonderland.Business.Models.Animals;

namespace PetsWonderland.Business.MVP.Args
{
	public class GetAllAnimalsArgs : EventArgs
	{
		public GetAllAnimalsArgs()
		{
		}

		public GetAllAnimalsArgs(IList<Animal> allAnimals)
		{
			this.AllAnimals = allAnimals;
		}

		public IList<Animal> AllAnimals { get; set; }
	}
}
