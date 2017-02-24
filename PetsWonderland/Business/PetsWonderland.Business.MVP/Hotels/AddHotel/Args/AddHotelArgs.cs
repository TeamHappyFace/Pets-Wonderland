using System;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Args
{
    public class AddHotelArgs : EventArgs
    {
        public int RequestId { get; set; }

        public string HotelManagerId { get; set; }

        public string HotelName { get; set; }

        public string HotelDescription { get; set; }

        public string ImageUrl { get; set; }

        public string Location { get; set; }

		public bool IsDeleted { get; set; }
	}
}
