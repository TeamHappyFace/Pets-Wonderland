using System;
using System.Web;
using PetsWonderland.Business.MVP.Identity.ChangePassword;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Args;
using PetsWonderland.Business.MVP.Identity.ChangePassword.ViewModels;
using PetsWonderland.Business.MVP.Identity.ChangePassword.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.PageControls.Account
{
    [PresenterBinding(typeof(ChangePasswordPresenter))]
    public partial class ChangePasswordControl : MvpUserControl<ChangePasswordModel>, IChangePasswordView
    {
        public event EventHandler<ChangePasswordEventArgs> EventChangePassword;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            var owinCtx = this.Context.GetOwinContext();

            var args = new ChangePasswordEventArgs()
            {
                OldPassword = this.CurrentPassword.Text,
                NewPassword = this.NewPassword.Text,
                User = this.Page.User.Identity,
                OwinCtx = owinCtx
            };

            this.EventChangePassword?.Invoke(this, args);

            if (this.Model.Result.Succeeded)
            {
                this.Response.Redirect("~/Account/Login");
            }
            else
            {
                this.Notifier.DisplayErrorNotification(string.Join(Environment.NewLine, this.Model.Result.Errors));
            }
        }
    }
}