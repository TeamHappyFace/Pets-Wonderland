using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserTests
{
	[TestFixture]
	public class GetImageByUserId_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userProfile = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(userProfile.Object);
			userService.GetImageByUserId(userProfile.Object.Id);

			mockedRepository.Verify(repository => repository.GetById(userProfile.Object.Id), Times.Once);
		}

		[Test]
		public void ReturnAvatar_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userProfile = new Mock<UserProfile>();
			userProfile.Object.AvatarUrl = "unknown";
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(userProfile.Object);

			Assert.IsInstanceOf<string>(userService.GetImageByUserId(userProfile.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userProfile = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(() => userProfile.Object);

			Assert.AreEqual(userService.GetImageByUserId(userProfile.Object.Id), userProfile.Object.AvatarUrl);
		}

		[Test]
		public void ReturnCorrectImage_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userProfile = new Mock<UserProfile>();
			userProfile.Object.AvatarUrl = "..";
			var userProfileToCompare = new Mock<UserProfile>();
			userProfile.Object.AvatarUrl = "unknown";
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(() => userProfile.Object);

			Assert.AreNotEqual(userService.GetImageByUserId(userProfile.Object.Id), userProfileToCompare.Object.AvatarUrl);
		}

		[Test]
		public void ThrowException_WhenUserIsNull()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserProfile> userProfile = null;

			Assert.Throws<NullReferenceException>(() => userService.GetImageByUserId(userProfile.Object.Id));
		}
	}
}
