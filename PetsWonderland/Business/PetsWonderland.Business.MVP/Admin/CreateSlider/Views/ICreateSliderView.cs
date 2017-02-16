using System;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;
using PetsWonderland.Business.MVP.Admin.CreateSlider.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Admin.CreateSlider.Views
{
    public interface ICreateSliderView : IView<CreateSliderViewModel>
    {
        event EventHandler<CreateSliderArgs> CreateSlider;
    }
}