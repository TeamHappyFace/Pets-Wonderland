using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.MVP.Identity.Login;
using PetsWonderland.Business.MVP.Identity.Login.Args;
using PetsWonderland.Business.MVP.Identity.Login.ViewModels;
using PetsWonderland.Business.MVP.Identity.Login.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginModel>, ILoginView
    {
        public event EventHandler<LoginEventArgs> EventLoginUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterHyperLink.NavigateUrl = "Register";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                this.RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            var owinCtx = Context.GetOwinContext();

            var eventArgs = new LoginEventArgs()
            {
                Email = this.Email.Text,
                Password = this.Password.Text,
                RememberMeChecked = this.RememberMe.Checked,
                ShouldLockOut = false,
                OwinCtx = owinCtx
            };

            this.EventLoginUser(this, eventArgs);

            var result = this.Model.Result;

            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], this.Response);
                    break;
                case SignInStatus.LockedOut:
                    Response.Redirect("/Account/Lockout");
                    break;
                case SignInStatus.RequiresVerification:
                    Response.Redirect($"/Account/TwoFactorAuthenticationSignIn?ReturnUrl={Request.QueryString["ReturnUrl"]}&RememberMe={RememberMe.Checked}", true);
                    break;
                case SignInStatus.Failure:
                default:
                    this.FailureText.Text = "Invalid login attempt";
                    this.ErrorMessage.Visible = true;
                    break;
            }
        }
    }
}