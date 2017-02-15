using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Models;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Views.Contracts
{
	public interface IHotelRegistrationRequestView : IView<HotelRegistrationRequestModel>
	{
		event EventHandler<GetAllHotelRequestsArgs> GetAll;
		event EventHandler<AddHotelRequestArgs> AddHotelRegistrationRequest;
	}
}
