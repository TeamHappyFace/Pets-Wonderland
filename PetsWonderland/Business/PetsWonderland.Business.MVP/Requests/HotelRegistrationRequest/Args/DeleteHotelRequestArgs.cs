using System;
using Bytes2you.Validation;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.Args
{
	public class DeleteHotelRequestArgs : EventArgs
	{
		public DeleteHotelRequestArgs(int hotelRequestToDeleteId)
		{
			this.HotelRequestToDeleteId = hotelRequestToDeleteId;
		}

		public int HotelRequestToDeleteId { get; set; }
	}
}
