using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class AddUserHotel_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(validUserHotel.Object));
		}

		[Test]
		public void InvokeAddMethodOnceForUserHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);

			//Assert
			mockedRepository.Verify(repository => repository.Add(It.IsAny<UserHotel>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenUserHotelIsValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenUserHotelIsInvalid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotel> userHotelToAdd = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => userHotelService.AddUserHotel(userHotelToAdd.Object));
		}
	}
}
