﻿using System;
using Microsoft.Owin;

namespace PetsWonderland.Business.MVP.Identity.Registration.Args
{
    public class RegistrationEventArgs : EventArgs
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string UserType { get; set; }

        public IOwinContext OwinCtx { get; set; }
    }
}
