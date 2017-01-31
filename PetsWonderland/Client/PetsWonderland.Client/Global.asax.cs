using System;
using System.Data.Entity;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Data.Migrations;

namespace PetsWonderland.Client
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

			//Initialize database
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<PetsWonderlandDbContext, Configuration>());
		}
	}
}