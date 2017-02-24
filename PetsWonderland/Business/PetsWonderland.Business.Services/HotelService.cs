using System.Collections.Generic;
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

        public void AddHotel(string hotelName, string hotelDescription, string hotelManagerId,
				HotelLocation location, string imageUrl)
        {
			var hotelToAdd = new Hotel()
			{
				Name = hotelName,
				Description = hotelDescription,
				HotelManagerId = hotelManagerId,
				ImageUrl = imageUrl
			};

			using (var unitOfWork = this.unitOfWork)
            {
                this.hotelRepository.Add(hotelToAdd);
                unitOfWork.SaveChanges();
            }
        }

        public IList<Hotel> GetHotels(int startAt, int count)
        {
            return this.hotelRepository.All().OrderByDescending(x => x.Id).Skip(startAt).Take(count).ToList();
        }

        public IQueryable<Hotel> GetAllHotels()
        {
            return this.hotelRepository.All();
        }

        public Hotel GetById(int id)
        {
            return this.hotelRepository.GetById(id);
        }

        public HotelLocation GetHotelLocation(Hotel hotel)
        {
            return hotel.Location;
        }
    }
}
