using System;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Hotels;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Args
{
	public class AddHotelArgs : EventArgs
	{
		public string HotelName { get; set; }

        public string HotelDescription { get; set; }
	}
}
