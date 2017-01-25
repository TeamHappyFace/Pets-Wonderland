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
            var parameters = context.Parameters.ToList();

            var requestedType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[2].GetValue(context, null);
            var viewInstanceParameter = new ConstructorArgument("view", viewInstance);
                      
            return (IPresenter)context.Kernel.Get(requestedType, viewInstanceParameter);
        }
    }
}