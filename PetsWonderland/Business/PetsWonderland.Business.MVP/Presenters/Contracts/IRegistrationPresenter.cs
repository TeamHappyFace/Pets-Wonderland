using System;
using PetsWonderland.Business.MVP.Args;

namespace PetsWonderland.Business.MVP.Presenters.Contracts
{
	public interface IRegistrationPresenter
	{
		void BindPageData(object sender, EventArgs e);

		void RegisterUser(object sender, RegistrationEventArgs e);
	}
}
