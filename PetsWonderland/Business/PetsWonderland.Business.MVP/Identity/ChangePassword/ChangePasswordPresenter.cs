using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Args;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Contracts;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Views;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.ChangePassword
{
	public class ChangePasswordPresenter : Presenter<IChangePasswordView>, IChangePasswordPresenter
	{
		public ChangePasswordPresenter(IChangePasswordView view)
			: base(view)
		{
			this.View.EventChangePassword += ChangePassword;
		}

		public void ChangePassword(object sender, ChangePasswordEventArgs e)
		{
			var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();
			IdentityResult result = manager.ChangePassword(e.User.GetUserId(), e.OldPassword, e.NewPassword);

			if (result.Succeeded)
			{
				e.OwinCtx.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			}

			this.View.Model.Result = result;
		}
	}
}
