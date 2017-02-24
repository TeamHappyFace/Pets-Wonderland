using System;

namespace PetsWonderland.Business.MVP.Requests.HotelRegistrationRequest.AddHotelRequest.Args
{
	public class AddHotelRequestArgs : EventArgs
	{
		public string HotelName { get; set; }

		public string HotelLocation { get; set; }

		public string HotelManagerId { get; set; }

		public string HotelDescription { get; set; }

		public string ImageUrl { get; set; }

		public DateTime DateOfRequest { get; set; }

		public bool IsAccepted { get; set; }
    }
}
