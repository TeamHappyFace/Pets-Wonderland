using System;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Hotels.AddHotel.Views
{
    public interface IAddHotelView : IView<AddHotelModel>
    {
        event EventHandler<AddHotelArgs> AddHotel;
    }
}
