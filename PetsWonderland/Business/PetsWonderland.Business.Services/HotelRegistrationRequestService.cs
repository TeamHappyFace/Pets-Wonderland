﻿using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class HotelRegistrationRequestService : IHotelRegistrationRequestService
	{
		private readonly IRepository<UserHotelRegistrationRequest> hotelRequestRepository;
		private readonly IUnitOfWork unitOfWork;

		public HotelRegistrationRequestService(IRepository<UserHotelRegistrationRequest> hotelRequestRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(hotelRequestRepository, "Hotel request repository is null!").IsNull();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull();

			this.hotelRequestRepository = hotelRequestRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddHotelRequest(UserHotelRegistrationRequest requestToAdd)
		{
			Guard.WhenArgument(requestToAdd, "Request to add is null!").IsNull();

			this.hotelRequestRepository.Add(requestToAdd);
			this.unitOfWork.SaveChanges();
		}

		public void DeleteHotelRequestById(object requestId)
		{
			Guard.WhenArgument(requestId, "Cannot delete request with id= null!").IsNull();

			this.hotelRequestRepository.Delete(requestId);
			this.unitOfWork.SaveChanges();
		}

		public IQueryable<UserHotelRegistrationRequest> GetAllHotelRequests()
		{
			return this.hotelRequestRepository.All();
		}

		public UserHotelRegistrationRequest GetById(int id)
		{
			return this.hotelRequestRepository.GetById(id);
		}
	}
}