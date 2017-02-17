using System;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Args
{
	public class AddHotelArgs : EventArgs
	{
		public AddHotelArgs(Hotel hotelToAdd)
		{
			Guard.WhenArgument(hotelToAdd, "Hotel to add is null!").IsNull().Throw();

			this.HotelToAdd = hotelToAdd;
		}

		public Hotel HotelToAdd { get; set; }
	}
}
