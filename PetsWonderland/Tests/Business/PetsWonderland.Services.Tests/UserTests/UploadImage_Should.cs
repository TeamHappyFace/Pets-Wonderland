using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserTests
{
	[TestFixture]
	public class UploadImage_Should
	{
		[Test]
		public void CallGetFirst_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);
			
			string path = "...";
			var userProfile = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(userProfile.Object);
			userService.UploadImage(userProfile.Object.Id, path);

			mockedRepository.Verify(repository => repository.GetById(userProfile.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChanges_WhenInvoked()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			string path = "...";
			var userProfile = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(userProfile.Object);
			userService.UploadImage(userProfile.Object.Id, path);

			mockedUnitOfWork.Verify(unitOfWork => unitOfWork.SaveChanges(), Times.Once);
		}

		[Test]
		public void UploadImage_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			string path = "...";
			var userProfile = new Mock<UserProfile>();
			mockedRepository.Setup(repository => repository.GetById(userProfile.Object.Id))
				.Returns(userProfile.Object);
			userService.UploadImage(userProfile.Object.Id, path);
			
			Assert.IsNotNull(userService.GetImageByUserId(userProfile.Object.Id));
		}
	}
}
