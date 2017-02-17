using System;
using Bytes2you.Validation;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args
{
	public class DeleteHotelRequestArgs : EventArgs
	{
		public DeleteHotelRequestArgs(int hotelRequestToDeleteId)
		{
			Guard.WhenArgument(hotelRequestToDeleteId, "Hotel request id is less than zero!").IsLessThan(0).Throw();

			this.HotelRequestToDeleteId = hotelRequestToDeleteId;
		}

		public int HotelRequestToDeleteId { get; set; }
	}
}
