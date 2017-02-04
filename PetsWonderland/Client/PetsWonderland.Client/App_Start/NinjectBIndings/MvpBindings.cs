using System;
using System.Linq;
using System.Reflection;

using WebFormsMvp;
using WebFormsMvp.Binder;

using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Activation;

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
            var parameters = context.Parameters.ToList();

            var requestedType = parameters[0].GetValue(context, null) as Type;
            var viewType = parameters[1].GetValue(context, null) as Type;
            var viewInterface = viewType.GetInterfaces().FirstOrDefault(i => i.Name.Contains("View") && !i.Name.Contains("IView"));
            var view = (IView)parameters[2].GetValue(context, null);

            this.BindInterface(viewInterface, view);
            return (IPresenter)context.Kernel.Get(requestedType);
        }

        private void BindInterface(Type viewInterface, IView view)
        {
            var isInterfaceBinded = this.Kernel.GetBindings(viewInterface).Any();


            if (isInterfaceBinded)
            {
                this.Rebind(viewInterface).ToMethod(context => view);
                return;
            }

            this.Bind(viewInterface).ToMethod(context => view);
        }
    }
}