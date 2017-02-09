using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class DeleteUserHotelById_Should
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
			userHotelService.DeleteUserHotelById(validUserHotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validUserHotel.Object.Id));
		}

		[Test]
		public void BeInvokedOnceForTypeUserHotel_WhenParamsAreCorrect()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);
			userHotelService.DeleteUserHotelById(validUserHotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.Delete(validUserHotel.Object.Id), Times.Once);
		}

		[Test]
		public void CallSaveChangesTwice_WhenParamsAreValid()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var validUserHotel = new Mock<UserHotel>();
			userHotelService.AddUserHotel(validUserHotel.Object);
			userHotelService.DeleteUserHotelById(validUserHotel.Object.Id);

			//Assert
			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Exactly(2));
		}

		[Test]
		public void NotDeleteByIdUserHotel_WhichIsNotAdded()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userHotel = new Mock<UserHotel>();

			//Act, Assert
			mockedRepository.Verify(repository => repository.Delete(userHotel.Object.Id), Times.Never);
		}

		[Test]
		public void ThrowException_WhenHotelIsNull()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<UserHotel> userHotel = null;

			//Act, Assert
			Assert.Throws<NullReferenceException>(() => userHotelService.DeleteUserHotelById(userHotel.Object.Id));
		}
	}
}
