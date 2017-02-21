using System;
using System.Security.Principal;
using Microsoft.Owin;

namespace PetsWonderland.Business.MVP.Identity.ChangePassword.Args
{
	public class ChangePasswordEventArgs : EventArgs
	{
		public IIdentity User { get; set; }

		public string OldPassword { get; set; }

		public string NewPassword { get; set; }

		public IOwinContext OwinCtx { get; set; }
	}
}
