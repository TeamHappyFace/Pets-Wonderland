using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using PetsWonderland.Business.Identity;
using PetsWonderland.Business.MVP.Identity.Registration;
using PetsWonderland.Business.MVP.Identity.Registration.Args;
using PetsWonderland.Business.MVP.Identity.Registration.ViewModels;
using PetsWonderland.Business.MVP.Identity.Registration.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Account
{
	[PresenterBinding(typeof(RegistrationPresenter))]
	public partial class Register : MvpPage<RegistrationModel>, IRegistrationView
	{
		public event EventHandler<EventArgs> EventBindPageData;
		public event EventHandler<RegistrationEventArgs> EventRegisterUser;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				// Bind the roles

				this.EventBindPageData(this, e);
				this.UserType.DataSource = this.Model.UserRoles.ToList();
				this.UserType.DataBind();
				this.UserType.SelectedIndex = 1;
			}
		}

		protected void CreateUser_Click(object sender, EventArgs e)
		{
			var owinCtx = Context.GetOwinContext();
			var selectedRole = this.UserType.SelectedItem.Value;

			var eventArgs = new RegistrationEventArgs()
			{
				OwinCtx = owinCtx,
				Email = this.Email.Text,
				FirstName = this.FirstName.Text,
				LastName = this.LastName.Text,
				UserName = this.Email.Text,
				UserType = this.UserType.SelectedItem.Text,
				Password = this.Password.Text,
				ConfirmedPassword = this.ConfirmPassword.Text
			};

			EventRegisterUser(this, eventArgs);

			var result = this.Model.Result;

			if (result.Succeeded)
			{
				IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
			}
			else
			{
				ErrorMessage.Text = result.Errors.FirstOrDefault();
			}
		}
	}
}