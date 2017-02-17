using System;
using Bytes2you.Validation;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.MVP.Requests.BoardingRequest.AddBoardingRequest.Args
{
	public class AddBoardingRequestArgs : EventArgs
	{
		public AddBoardingRequestArgs(UserBoardingRequest boardingRequestToAdd)
		{
			Guard.WhenArgument(boardingRequestToAdd, "Boarding request to add is null!").IsNull().Throw();

			this.BoardingRequestToAdd = boardingRequestToAdd;
		}

		public UserBoardingRequest BoardingRequestToAdd { get; set; }
	}
}
