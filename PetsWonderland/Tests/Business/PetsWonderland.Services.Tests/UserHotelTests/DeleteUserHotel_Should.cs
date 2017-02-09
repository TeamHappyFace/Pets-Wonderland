using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class DeleteUserHotel_Should
	{
		[Test]
		public void BeInvoked_WhenUserHoteltoDeleteIsValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);
			userHotelService.DeleteUserHotel(validUserHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validUserHotel.Object));
		}

		[Test]
		public void BeInvokedOnceForUserHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);
			userHotelService.DeleteUserHotel(validUserHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(It.IsAny<UserHotel>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenUserHotelIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);
			userHotelService.DeleteUserHotel(validUserHotel.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotCallSaveChanges_WhenUserHotelIsNotDeleted()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Never);
		}

		[Test]
		public void NotDeleteUserHotel_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userHotel = new Mock<UserHotel>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(userHotel.Object), Times.Never);
		}

		[Test]
		public void ThrowException_WhenUserHotelIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotel> userHotel = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => userHotelService.DeleteUserHotel(userHotel.Object));
		}
	}
}
