using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Services.Tests.UserHotelTests
{
	[TestFixture]
	public class GetAllUserHotels_Should
	{
		[Test]
		public void BeCalled_WhenParamsAreValid()
		{
			//Arrange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			userHotelService.GetAllUserHotels();

			//Assert
			mockedRepository.Verify(repository => repository.All(), Times.Once);
		}

		[Test]
		public void NotBeCalled_WhenNotUsed()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act, Assert
			mockedRepository.Verify(repository => repository.All(), Times.Never);
		}

		[Test]
		public void ReturnIqueriable_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			IEnumerable<UserHotel> result = new List<UserHotel>() { new UserHotel(), new UserHotel(), new UserHotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Act, Assert
			Assert.IsInstanceOf<IQueryable<UserHotel>>(userHotelService.GetAllUserHotels());
		}

		[Test]
		public void WorksProperly_WhenInvoked()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotel> result = new List<UserHotel>() { new UserHotel(), new UserHotel(), new UserHotel() };
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.AreEqual(userHotelService.GetAllUserHotels(), result);
		}

		[Test]
		public void ReturnEmptyCollection_WhenNoUserHotels()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotel> result = new List<UserHotel>();
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.IsEmpty(userHotelService.GetAllUserHotels());
		}

		[Test]
		public void ThrowException_WhenNullUserHotel()
		{
			//Arange
			var mockedRepository = new Mock<IRepository<UserHotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var userHotelService = new UserHotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			//Act
			IEnumerable<UserHotel> result = null;
			mockedRepository.Setup(repository => repository.All()).Returns(() => result.AsQueryable());

			//Assert
			Assert.Throws<ArgumentNullException>(() => userHotelService.GetAllUserHotels());
		}
	}
}
