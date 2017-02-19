using System;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Args
{
	public class AddHotelArgs : EventArgs
	{
		public string HotelName { get; set; }

        public string HotelDescription { get; set; }
	}
}
