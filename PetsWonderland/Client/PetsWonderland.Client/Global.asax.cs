using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Migrations;
using PetsWonderland.Client.Logic;
using WebFormsMvp.Binder;

namespace PetsWonderland.Client
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.RegisterNinjectPresenterFactory();

			//Initialize database
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetsWonderlandDbContext, Configuration>());

			// Create the custom role and user.
			RoleActions roleActions = new RoleActions();
			roleActions.AddUserAndRole();
		}

        protected void RegisterNinjectPresenterFactory()
        {
            var ninjectPresenterFactory = NinjectWebCommon.Kernel.Get<IPresenterFactory>();
            PresenterBinder.Factory = ninjectPresenterFactory;
        }
	}
}