using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args
{
	public class GetAllHotelsArgs : EventArgs
	{
		public GetAllHotelsArgs()
		{

		}

		public GetAllHotelsArgs(IList<Hotel> allHotels)
		{
			Guard.WhenArgument(allHotels, "All hotels list is null!").IsNullOrEmpty().Throw();

			this.AllHotels = allHotels;
		}

		public IList<Hotel> AllHotels { get; set; }
	}
}
