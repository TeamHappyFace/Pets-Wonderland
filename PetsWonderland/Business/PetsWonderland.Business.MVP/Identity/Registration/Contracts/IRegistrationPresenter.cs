using System;
using PetsWonderland.Business.MVP.Identity.Registration.Args;

namespace PetsWonderland.Business.MVP.Identity.Registration.Contracts
{
    public interface IRegistrationPresenter
    {
        void BindPageData(object sender, EventArgs e);

        void RegisterUser(object sender, RegistrationEventArgs e);
    }
}
