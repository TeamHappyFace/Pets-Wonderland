using System;
using Microsoft.Owin;

namespace PetsWonderland.Business.MVP.Identity.Login.Args
{
    public class LoginEventArgs : EventArgs
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMeChecked { get; set; }

        public bool ShouldLockOut { get; set; }

        public IOwinContext OwinCtx { get; set; }
    }
}
