using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class UserHotelService : IUserHotelService
	{
		private readonly IRepository<UserHotel> userHotelRepository;

		public UserHotelService(IRepository<UserHotel> userHotelRepository)
		{
			this.userHotelRepository = userHotelRepository;
		}

		public void AddHotel(UserHotel hotelToAdd)
		{
			this.userHotelRepository.Add(hotelToAdd);
		}

		public void DeleteHotel(UserHotel hotelToDelete)
		{
			this.userHotelRepository.Delete(hotelToDelete);
		}

		public void DeleteHotelById(object hotelId)
		{
			this.userHotelRepository.Delete(hotelId);
		}

		public IQueryable<UserHotel> GetAllHotels()
		{
			return this.userHotelRepository.All();
		}

		public UserHotel GetById(int id)
		{
			return this.userHotelRepository.GetById(id);
		}

		public UserHotel GetByName(string name)
		{
			return this.userHotelRepository.GetByName(name);
		}

		public HotelLocation GetHotelLocation(UserHotel hotel)
		{
			return hotel.Hotel.HotelLocation;
		}
	}
}
