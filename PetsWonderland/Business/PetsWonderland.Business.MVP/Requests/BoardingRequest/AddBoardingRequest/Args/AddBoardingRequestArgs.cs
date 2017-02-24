using System;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args
{
    public class AddBoardingRequestArgs : EventArgs
    {
		public string PetName { get; set; }

        public int Age { get; set; }

        public DateTime DateOfRequest { get; set; }

		public string ImageUrl { get; set; }

		public string FromDate { get; set; }

        public string ToDate { get; set; } 

        public string PetBreed { get; set; }

        public string UserId { get; set; }

        public string HotelManagerId { get; set; }
	}
}
