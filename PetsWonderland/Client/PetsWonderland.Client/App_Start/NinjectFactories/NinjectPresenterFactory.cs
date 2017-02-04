using System;
using WebFormsMvp;
using WebFormsMvp.Binder;
using PetsWonderland.Client.NinjectFactories.Contracts;
using Bytes2you.Validation;

namespace PetsWonderland.Client.NinjectFactories
{
    public class NinjectPresenterFactory : IPresenterFactory
    {
        private readonly INinjectPresenterFactory presenterFactory;

        public NinjectPresenterFactory(INinjectPresenterFactory presenterFactory)
        {
			Guard.WhenArgument(presenterFactory, "An instance of presenter factory is required").IsNull();

            this.presenterFactory = presenterFactory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
			Guard.WhenArgument(presenterType, "Presenter type is required!").IsNull();
			Guard.WhenArgument(viewType, "View type is required!").IsNull();
			Guard.WhenArgument(viewInstance, "View instance is required!").IsNull();

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