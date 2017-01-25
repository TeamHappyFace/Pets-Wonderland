using System;
using WebFormsMvp;

namespace PetsWonderland.Client.NinjectFactories.Contracts
{
    public interface INinjectPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}