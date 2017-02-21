using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Identity.Registration;
using PetsWonderland.Business.MVP.Identity.Registration.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Identity.RegistrationPresenterTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenAllArgumentsAreValid()
		{
			var mockedRegistrationView = new Mock<IRegistrationView>();
			var mockedRegistrationService = new Mock<IRegistrationService>();
			
			Assert.DoesNotThrow(() => 
				new RegistrationPresenter(mockedRegistrationView.Object, mockedRegistrationService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenRegistrationServiceIsNull()
		{
			var mockedRegistrationView = new Mock<IRegistrationView>();

			Assert.That(() => 
				new RegistrationPresenter(mockedRegistrationView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("registrationService"));
		}
	}
}
