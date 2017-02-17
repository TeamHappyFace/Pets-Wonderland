using System;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views
{
	public interface IGetAllHotelsView : IView<GetAllHotelsModel>
	{
		event EventHandler<GetAllHotelsArgs> GetAllHotels;
	}
}
