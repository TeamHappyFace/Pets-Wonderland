﻿using System;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Views.Contracts;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Presenters
{
	public class RegistrationPresenter : Presenter<IRegistrationView>
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

		private void BindPageData(object sender, EventArgs e)
		{
			this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
		}

		private void RegisterUser(object sender, RegistrationEventArgs e)
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
