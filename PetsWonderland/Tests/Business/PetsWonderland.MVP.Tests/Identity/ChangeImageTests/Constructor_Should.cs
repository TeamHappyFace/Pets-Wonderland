using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Identity.ChangeImage;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Identity.ChangeImageTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreatePresenter_WhenAllArgumentsAreValid()
		{
			var mockedChangeImageView = new Mock<IChangeImageView>();
			var mockedUserService = new Mock<IUserService>();

			Assert.DoesNotThrow(() =>
				new ChangeImagePresenter(mockedChangeImageView.Object, mockedUserService.Object));
		}

		[Test]
		public void ThrowArgumentNullException_WhenUserServiceIsNull()
		{
			var mockedChangeImageView = new Mock<IChangeImageView>();

			Assert.That(() =>
				new ChangeImagePresenter(mockedChangeImageView.Object, null),
				Throws.ArgumentNullException.With.Message.Contain("userService"));
		}
	}
}
