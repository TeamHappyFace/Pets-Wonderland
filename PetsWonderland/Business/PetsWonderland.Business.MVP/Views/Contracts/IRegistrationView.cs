using System;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Models;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Views.Contracts
{
	public interface IRegistrationView : IView<RegistrationModel>
	{
		event EventHandler<RegistrationEventArgs> EventRegisterUser;

		event EventHandler<EventArgs> EventBindPageData;
	}
}
