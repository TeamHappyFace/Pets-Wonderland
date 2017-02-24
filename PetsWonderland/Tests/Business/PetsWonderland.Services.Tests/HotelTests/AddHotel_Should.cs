using System;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.Services;

namespace PetsWonderland.Business.Tests.Services.HotelServiceTests
{
	[TestFixture]
	public class AddHotel_Should
	{
		[Test]
		public void InvokeAddMethod_WhenParamsAreValid()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var args = new Mock<AddHotelArgs>();
			hotelService.AddHotel(args.Object.HotelName, args.Object.HotelDescription,
				args.Object.HotelManagerId, new HotelLocation() { Address = args.Object.Location }, args.Object.ImageUrl);
			
			mockedRepository.Verify(repository => repository.Add(It.IsAny<Hotel>()));
		}

		[Test]
		public void InvokeAddMethodOnceForHotel_WhenParamsAreCorrect()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var args = new Mock<AddHotelArgs>();
			hotelService.AddHotel(args.Object.HotelName, args.Object.HotelDescription,
				args.Object.HotelManagerId, new HotelLocation() { Address = args.Object.Location }, args.Object.ImageUrl);

			mockedRepository.Verify(repository => repository.Add(It.IsAny<Hotel>()), Times.Once);
		}

		[Test]
		public void CallSaveChangesOnce_WhenHotelIsValid()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			var args = new Mock<AddHotelArgs>();
			hotelService.AddHotel(args.Object.HotelName, args.Object.HotelDescription,
				args.Object.HotelManagerId, new HotelLocation() { Address = args.Object.Location }, args.Object.ImageUrl);

			mockedUnitOfWork.Verify(unit => unit.SaveChanges(), Times.Once);
		}

		[Test]
		public void ThrowException_WhenHotelIsInvalid()
		{
			var mockedRepository = new Mock<IRepository<Hotel>>();
			var mockedUnitOfWork = new Mock<IUnitOfWork>();
			var hotelService = new HotelService(mockedRepository.Object, mockedUnitOfWork.Object);

			Mock<AddHotelArgs> args = null;

			Assert.Throws<NullReferenceException>(() => hotelService.AddHotel(args.Object.HotelName, args.Object.HotelDescription,
				args.Object.HotelManagerId, new HotelLocation() { Address = args.Object.Location }, args.Object.ImageUrl));
		}
	}
}
