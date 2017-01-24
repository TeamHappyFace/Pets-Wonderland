using System;

namespace PetsWonderland.Business.MVP.Args
{
	public class FindAnimalArgs : EventArgs
	{
		public FindAnimalArgs(int id)
		{
			this.Id = id;
		}

		public FindAnimalArgs(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int? Id { get; set; }
		public string Name { get; set; }
	}
}
