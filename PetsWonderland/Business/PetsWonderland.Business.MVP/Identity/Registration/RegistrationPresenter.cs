using System;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.MVP.Identity.Registration.Args;
using PetsWonderland.Business.MVP.Identity.Registration.Contracts;
using PetsWonderland.Business.MVP.Identity.Registration.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.Registration
{
	public class RegistrationPresenter : Presenter<IRegistrationView>, IRegistrationPresenter
	{
		private readonly IRegistrationService registrationService;

		public RegistrationPresenter(IRegistrationView view, IRegistrationService registrationService)
			: base(view)
		{
			Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();

			this.registrationService = registrationService;

			this.View.EventRegisterUser += RegisterUser;
			this.View.EventBindPageData += BindPageData;
		}

		public void BindPageData(object sender, EventArgs e)
		{
			this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
		}

		public void RegisterUser(object sender, RegistrationEventArgs e)
		{
			var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();
			var signInManager = e.OwinCtx.Get<ApplicationSignInManager>();

			var user = new UserProfile()
			{
				Email = e.Email,
				UserName = e.Email,
				FirstName = e.FirstName,
				LastName = e.LastName
			};

			IdentityResult result = manager.Create(user, e.Password);

			manager.AddToRole(user.Id, e.UserType);

			if (e.UserType == "User")
			{
				this.registrationService.CreateRegularUser(user.Id);
			}
			else if (e.UserType == "Hotel manager")
			{
				this.registrationService.CreateHotelManager(user.Id);
			}

			signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
			this.View.Model.Result = result;
		}
	}
}
