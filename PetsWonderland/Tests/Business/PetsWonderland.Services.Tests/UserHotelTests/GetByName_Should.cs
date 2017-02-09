using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class GetByName_Should
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
			mockedRepository.Setup(repository => repository.GetByName(userHotel.Object.Hotel.Name));
			userHotelService.GetByName(userHotel.Object.Hotel.Name);

			//Assert
			mockedRepository.Verify(repository => repository.GetByName(userHotel.Object.Hotel.Name), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.GetByName("Pesho"), Times.Never);
		}

		[Test]
		public void ReturnUserHotel_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			var userHotel = new Mock<UserHotel>();
			mockedRepository.Setup(repository => repository.GetByName(userHotel.Object.Hotel.Name))
				.Returns(() => userHotel.Object);

			//Assert
			Assert.IsInstanceOf<UserHotel>(userHotelService.GetByName(userHotel.Object.Hotel.Name));
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
			mockedRepository.Setup(repository => repository.GetByName(userHotel.Object.Hotel.Name))
				.Returns(() => userHotel.Object);

			//Assert
			Assert.AreEqual(userHotelService.GetByName(userHotel.Object.Hotel.Name), userHotel.Object);
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
			mockedRepository.Setup(repository => repository.GetByName(userHotel.Object.Hotel.Name))
				.Returns(() => userHotel.Object);

			//Assert
			Assert.AreNotEqual(userHotelService.GetByName(userHotel.Object.Hotel.Name), userHotelToCompare.Object);
		}

		[Test]
		public void NotReturnUsreHotel_WhenNoSuchUserHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			mockedRepository.Setup(repository => repository.GetByName("Zoro")).Returns(() => null);

			//Assert
			Assert.IsNull(userHotelService.GetByName("Zoro"));
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
			Assert.Throws<NullReferenceException>(() => userHotelService.GetByName(userHotel.Object.Hotel.Name));
		}
	}
}
