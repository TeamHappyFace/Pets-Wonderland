using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class GetById_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var userHotel = new Mock<UserHotel>();
			userHotelService.GetById(userHotel.Object.Id);

			//Assert
			mockedRepository.Verify(repository => repository.GetById(userHotel.Object.Id), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetById(1), Times.Never);
		}

		[Test]
		public void ReturnUserHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var userHotel = new Mock<UserHotel>();
			mockedRepository.Setup(repository => repository.GetById(userHotel.Object.Id))
				.Returns(() => userHotel.Object);

			//Act, Assert
			Assert.IsInstanceOf<UserHotel>(userHotelService.GetById(userHotel.Object.Id));
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var userHotel = new Mock<UserHotel>();
			mockedRepository.Setup(repository => repository.GetById(userHotel.Object.Id))
				.Returns(() => userHotel.Object);

			//Assert
			Assert.AreEqual(userHotelService.GetById(userHotel.Object.Id), userHotel.Object);
		}

		[Test]
		public void ReturnCorrectUserHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var userHotel = new Mock<UserHotel>();
			var userHotelToCompare = new Mock<UserHotel>();
			mockedRepository.Setup(repository => repository.GetById(userHotel.Object.Id))
				.Returns(() => userHotel.Object);

			//Assert
			Assert.AreNotEqual(userHotelService.GetById(userHotel.Object.Id), userHotelToCompare.Object);
		}

		[Test]
		public void NotReturnUserHotel_WhenNoSuchUserHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetById(0)).Returns(() => null);

			//Assert
			Assert.IsNull(userHotelService.GetById(0));
		}

		[Test]
		public void ThrowException_WhenNullUserHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			Mock<UserHotel> userHotel = null;

			//Assert
			Assert.Throws<NullReferenceException>(() => userHotelService.GetById(userHotel.Object.Id));
		}
	}
}
