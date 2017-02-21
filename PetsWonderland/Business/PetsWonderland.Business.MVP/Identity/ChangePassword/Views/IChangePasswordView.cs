using System;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Args;
using PetsWonderland.Business.MVP.Identity.ChangePassword.ViewModels;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.ChangePassword.Views
{
    public interface IChangePasswordView : IView<ChangePasswordModel>
    {
        event EventHandler<ChangePasswordEventArgs> EventChangePassword;
    }
}
