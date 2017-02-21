using Microsoft.AspNet.Identity.Owin;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.MVP.Identity.Login.Args;
using PetsWonderland.Business.MVP.Identity.Login.Contracts;
using PetsWonderland.Business.MVP.Identity.Login.Views;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.Login
{
    public class LoginPresenter : Presenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView view)
            : base(view)
        {
            this.View.EventLoginUser += this.LoginUser;
        }

        public void LoginUser(object sender, LoginEventArgs e)
        {
            var signInManager = e.OwinCtx.Get<ApplicationSignInManager>();

            var result = signInManager.PasswordSignIn(e.Email, e.Password, e.RememberMeChecked, e.ShouldLockOut);

            this.View.Model.Result = result;
        }
    }
}
