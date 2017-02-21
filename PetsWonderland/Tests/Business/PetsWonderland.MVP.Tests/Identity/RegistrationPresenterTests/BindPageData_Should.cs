using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Models.UserRoles;
using PetsWonderland.Business.MVP.Identity.Registration;
using PetsWonderland.Business.MVP.Identity.Registration.ViewModels;
using PetsWonderland.Business.MVP.Identity.Registration.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Identity.RegistrationPresenterTests
{
	[TestFixture]
	public class BindPageData_Should
	{
		[Test]
		public void BindUserRoles_WhenArumentsAreValid()
		{
			var mockedRegisterView = new Mock<IRegistrationView>();
			var mockedRegistrationService = new Mock<IRegistrationService>();

			mockedRegisterView
				.SetupGet(x => x.Model)
				.Returns(new RegistrationModel());

			var expectedRoles = new List<ApplicationRole>()
			{
				new ApplicationRole(),
				new ApplicationRole(),
				new ApplicationRole()
			};

			mockedRegistrationService
				.Setup(x => x.GetAllUserRoles())
				.Returns(expectedRoles);

			var registrationPresenter = new RegistrationPresenter(
					 mockedRegisterView.Object,
					 mockedRegistrationService.Object);

			mockedRegisterView.Raise(x => x.EventBindPageData += null, EventArgs.Empty);

			Assert.AreEqual(expectedRoles, mockedRegisterView.Object.Model.UserRoles);
		}
	}
}
