using System;
using System.Linq;
using System.Reflection;
using Ninject;
using WebFormsMvp;
using WebFormsMvp.Binder;

using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Activation;
using Ninject.Parameters;
using PetsWonderland.Client.NinjectFactories;
using PetsWonderland.Client.NinjectFactories.Contracts;

namespace PetsWonderland.Client.NinjectBIndings
{
    public class MvpBindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<INinjectPresenterFactory>().ToFactory().InSingletonScope();
            this.Bind<IPresenterFactory>().To<NinjectPresenterFactory>().InSingletonScope();
            this.Bind<IPresenter>()
                .ToMethod(this.PresenterFactoryMethod)
                .NamedLikeFactoryMethod((INinjectPresenterFactory factory) => factory.GetPresenter(null, null, null));
        }

        protected bool CanUseConstructor(ConstructorInfo constructor, Type viewType, Type pageDataType)
        {
            var constructorParameters = constructor.GetParameters();

            return constructorParameters[0].ParameterType.IsAssignableFrom(viewType) &&
                   constructorParameters[1].ParameterType.IsAssignableFrom(pageDataType);
        }

        protected IPresenter PresenterFactoryMethod(IContext context)
        {
            /*var parameters = context.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[2].GetValue(context, null);
            var viewInstanceParameter = new ConstructorArgument("view", viewInstance);
                      
            return (IPresenter)context.Kernel.Get(requestedType);*/

            var parameters = context.Parameters.ToList();

            // The presenter class type
            var requestedType = parameters[0].GetValue(context, null) as Type;

            // The aspx.cs page type
            var viewType = parameters[1].GetValue(context, null) as Type;

            // IWhateverView interface
            var viewInterface = viewType.GetInterfaces().FirstOrDefault(i => i.Name.Contains("View") && !i.Name.Contains("IView"));

            // Instance of the aspx.cs page
            var view = parameters[2].GetValue(context, null) as IView;

            this.BindInterface(viewInterface, view);
            return context.Kernel.Get(requestedType) as IPresenter;
        }

        private void BindInterface(Type viewInterface, IView view)
        {
            var isInterfaceBinded = this.Kernel.GetBindings(viewInterface).Any();

            // After leaving the page the view gets destroyed, so the Model property
            // becomes null. The interface has to be rebinded.
            if (isInterfaceBinded)
            {
                this.Rebind(viewInterface).ToMethod(context => view);
                return;
            }

            // Bind the interface for the first time.
            this.Bind(viewInterface).ToMethod(context => view);
        }
    }
}