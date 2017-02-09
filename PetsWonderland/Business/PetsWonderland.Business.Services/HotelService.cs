using System;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelService : IHotelService
	{
        private readonly IRepository<Hotel> hotelRepository;
		private readonly IUnitOfWork unitOfWork;

		public HotelService(IRepository<Hotel> hotelRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(hotelRepository, "Hotel repository is null!").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

			this.hotelRepository = hotelRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotel(Hotel hotelToAdd)
		{
			Guard.WhenArgument(hotelToAdd, "Hotel to add is null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.hotelRepository.Add(hotelToAdd);
				this.unitOfWork.SaveChanges();
			}
		}

		public int Count()
		{
			return this.hotelRepository.All().Count();
		}

		public void DeleteHotel(Hotel hotelToDelete)
		{
			Guard.WhenArgument(hotelToDelete, "Hotel to delete is null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.hotelRepository.Delete(hotelToDelete);
				this.unitOfWork.SaveChanges();
			}
		}

		public void DeleteHotelById(object hotelId)
		{
			Guard.WhenArgument(hotelId, "Cannot delete hotel with id=null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.hotelRepository.Delete(hotelId);
				this.unitOfWork.SaveChanges();
			}
		}

		public IQueryable<Hotel> GetAllHotels()
		{
			return this.hotelRepository.All();
		}

		public Hotel GetById(int id)
		{
			return this.hotelRepository.GetById(id);
		}

		public Hotel GetByName(string name)
		{
			return this.hotelRepository.GetByName(name);
		}

		public HotelLocation GetHotelLocation(Hotel hotel)
		{
			return hotel.Location;
		}
	}
}
