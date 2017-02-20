using System;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;
using PetsWonderland.Business.MVP.Admin.ListSlider.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Admin.ListSlider.Views
{
    public interface IListSlidersView : IView<ListSlidersViewModel>
    {
        event EventHandler<GetAllSlidersArgs> GetSlidersList;

        event EventHandler<DeleteSliderArgs> DeleteSlider;
    }
}