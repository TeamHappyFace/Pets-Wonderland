using System;
using WebFormsMvp;
using WebFormsMvp.Binder;
using PetsWonderland.Client.NinjectFactories.Contracts;

namespace PetsWonderland.Client.NinjectFactories
{
    public class NinjectPresenterFactory : IPresenterFactory
    {
        private readonly INinjectPresenterFactory presenterFactory;

        public NinjectPresenterFactory(INinjectPresenterFactory presenterFactory)
        {
            if (presenterFactory == null)
            {
                throw new ArgumentException("An instance of presenter factory is required", nameof(presenterFactory));
            }

            this.presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var presenter = this.presenterFactory.GetPresenter(presenterType, viewType, viewInstance);
            return presenter;
        }

        public void Release(IPresenter presenter)
        {
			var disposable = presenter as IDisposable;

			if (disposable != null)
			{
				disposable.Dispose();
			}
        }
    }
}