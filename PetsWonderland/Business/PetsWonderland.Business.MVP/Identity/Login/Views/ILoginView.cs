using System;
using PetsWonderland.Business.MVP.Identity.Login.Args;
using PetsWonderland.Business.MVP.Identity.Login.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.Login.Views
{
    public interface ILoginView : IView<LoginModel>
    {
        event EventHandler<LoginEventArgs> EventLoginUser;
    }
}
