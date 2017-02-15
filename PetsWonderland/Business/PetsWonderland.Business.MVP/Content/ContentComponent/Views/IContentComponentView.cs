using System;
using PetsWonderland.Business.MVP.Content.ContentComponent.Args;
using PetsWonderland.Business.MVP.Content.ContentComponent.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.ContentComponent.Views
{
    public interface IContentComponentView : IView<ContentComponentViewModel>
    {
        event EventHandler<GetAllSlidersArgs> GetSlidersList;
    }
}