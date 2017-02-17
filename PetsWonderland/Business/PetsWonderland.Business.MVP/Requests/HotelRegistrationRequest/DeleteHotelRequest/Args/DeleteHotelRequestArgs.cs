using System;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.DeleteHotelRequest.Args
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
