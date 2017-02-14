using System;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Args
{
	public class AddHotelRequestArgs : EventArgs
	{
		public AddHotelRequestArgs(UserHotelRegistrationRequest hotelRequestToAdd)
		{
			Guard.WhenArgument(hotelRequestToAdd, "Hotel request to add is null!").IsNull().Throw();

			this.HotelRequestToAdd = hotelRequestToAdd;
		}

		public UserHotelRegistrationRequest HotelRequestToAdd { get; set; }
	}
}
