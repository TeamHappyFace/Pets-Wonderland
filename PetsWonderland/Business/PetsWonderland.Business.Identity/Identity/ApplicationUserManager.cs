using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<UserProfile>
    {
        public ApplicationUserManager(IUserStore<UserProfile> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<UserProfile>(context.Get<PetsWonderlandDbContext>()));

            // Configure validation logic for usernames
            userManager.UserValidator = new UserValidator<UserProfile>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            userManager.RegisterTwoFactorProvider(
                "Phone Code", 
                new PhoneNumberTokenProvider<UserProfile>
            {
                MessageFormat = "Your security code is {0}"
            });
            userManager.RegisterTwoFactorProvider(
                "Email Code",
                new EmailTokenProvider<UserProfile>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            // Configure user lockout defaults
            userManager.UserLockoutEnabledByDefault = true;
            userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            userManager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // userManager.EmailService = new EmailService();
            // userManager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                userManager.UserTokenProvider = new DataProtectorTokenProvider<UserProfile>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return userManager;
        }
    }
}