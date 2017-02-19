using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelLocationService : IHotelLocationService
	{
		private readonly IRepository<HotelLocation> hotelLocationRepository;
		private readonly IUnitOfWork unitOfWork;

		public HotelLocationService(IRepository<HotelLocation> hotelLocationRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(hotelLocationRepository, "Hotel location repository is null!").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

			this.hotelLocationRepository = hotelLocationRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotelLocation(HotelLocation locationToAdd)
		{
			Guard.WhenArgument(locationToAdd, "Hotel to add is null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.hotelLocationRepository.Add(locationToAdd);
				this.unitOfWork.SaveChanges();
			}
		}

		public HotelLocation GetById(int id)
		{
			return this.hotelLocationRepository.GetById(id);
		}

		public HotelLocation GetByAddress(string address)
		{
			return this.hotelLocationRepository.GetFirst(location => location.Address == address);
		}
	}
}
