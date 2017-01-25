using System;
using WebFormsMvp;
using WebFormsMvp.Binder;
using PetsWonderland.Client.NinjectFactories.Contracts;

namespace PetsWonderland.Client.NinjectFactories
{
    public class NinjectPresenterFactory : IPresenterFactory
    {
        private readonly INinjectPresenterFactory _presenterFactory;

        public NinjectPresenterFactory(INinjectPresenterFactory presenterFactory)
        {
            if (presenterFactory == null)
            {
                throw new ArgumentException("An instance of presenter factory is required", nameof(presenterFactory));
            }

            this._presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var presenter = this._presenterFactory.GetPresenter(presenterType, viewType, viewInstance);
            return presenter;
        }

        public void Release(IPresenter presenter)
        {
        }
    }
}