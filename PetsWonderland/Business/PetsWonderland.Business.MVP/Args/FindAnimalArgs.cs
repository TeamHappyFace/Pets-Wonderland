using System;
using Bytes2you.Validation;

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
			Guard.WhenArgument(name, "Name is null!").IsNullOrEmpty();

			this.Id = id;
			this.Name = name;
		}

		public int? Id { get; set; }
		public string Name { get; set; }
	}
}
