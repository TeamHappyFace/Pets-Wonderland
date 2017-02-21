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

			var hotelLocation = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(hotelLocation.Object.Id))
				.Returns(hotelLocation.Object);
			userService.GetImageByUserId(hotelLocation.Object.Id);

			mockedRepository.Verify(repository => repository.GetById(hotelLocation.Object.Id), Times.Once);
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

		//[Test]
		//public void ReturnNull_WhenNoSuchUserProfile()
		//{
		//	var mockedRepository = new Mock<IRepository<UserProfile>>();
		//	var mockedUnitOfWork = new Mock<IUnitOfWork>();
		//	var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

		//	mockedRepository.Setup(repository => repository.GetById("")).Returns(() => null);

		//	Assert.IsNull(userService.GetImageByUserId(""));
		//}

		//[Test]
		//public void ThrowException_WhenNullBoardingRequest()
		//{
		//	var mockedRepository = new Mock<IRepository<HotelLocation>>();
		//	var mockedUnitOfWork = new Mock<IUnitOfWork>();
		//	var hotelLocationService = new HotelLocationService(mockedRepository.Object, mockedUnitOfWork.Object);

		//	Mock<HotelLocation> hotelLocation = null;

		//	Assert.Throws<NullReferenceException>(() => hotelLocationService.GetById(hotelLocation.Object.Id));
		//}
	}
}
