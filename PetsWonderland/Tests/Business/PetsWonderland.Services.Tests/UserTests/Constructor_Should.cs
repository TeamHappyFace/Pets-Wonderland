using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserTests
{
	[TestFixture]
	public class Constructor_Should
	{
		[Test]
		public void CreateUserService_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userService = new UserService(mockedRepository.Object, mockedUnitOfWork.Object);

			Assert.That(userService, Is.InstanceOf<UserService>());
		}

		[Test]
		public void ThrowNullException_WhenRepositoryIsNull()
		{
			Mock<IRepository<UserProfile>> mockedRepository = null;
			var mockedUnitOfWork = new Mock<IUnitOfWork>();

			Assert.Throws<NullReferenceException>(() => new UserService(mockedRepository.Object, mockedUnitOfWork.Object));
		}

		[Test]
		public void ThrowNullException_WhenUnitofworkIsNull()
		{
			var mockedRepository = new Mock<IRepository<UserProfile>>();
			Mock<IUnitOfWork> mockedUnitOfWork = null;

			Assert.Throws<NullReferenceException>(() => new UserService(mockedRepository.Object, mockedUnitOfWork.Object));
		}
	}
}
