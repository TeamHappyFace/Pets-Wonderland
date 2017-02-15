using System;
using PetsWonderland.Business.MVP.Identity.Registration.Args;
using PetsWonderland.Business.MVP.Identity.Registration.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.Registration.Views
{
	public interface IRegistrationView : IView<RegistrationModel>
	{
		event EventHandler<RegistrationEventArgs> EventRegisterUser;

		event EventHandler<EventArgs> EventBindPageData;
	}
}
