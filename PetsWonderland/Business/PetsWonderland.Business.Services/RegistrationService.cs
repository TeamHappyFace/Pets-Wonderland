using System.Collections.Generic;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.UserRoles;
using PetsWonderland.Business.Models.Users;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class RegistrationService : IRegistrationService
	{
		private readonly IRepository<ApplicationRole> userRolesRepo;
		private readonly IRepository<RegularUser> userRepo;
		private readonly IRepository<HotelManager> hotelManagerRepo;
		private readonly IUnitOfWork unitOfWork;

		public RegistrationService(
			IRepository<ApplicationRole> userRolesRepo,
			IRepository<RegularUser> userRepo,
			IRepository<HotelManager> hotelManagerRepo,
			IUnitOfWork unitOfWork
			)
		{
			Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
			Guard.WhenArgument(userRepo, "userRepo").IsNull().Throw();
			Guard.WhenArgument(hotelManagerRepo, "hotelManagerRepo").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

			this.userRolesRepo = userRolesRepo;
			this.userRepo = userRepo;
			this.hotelManagerRepo = hotelManagerRepo;
			this.unitOfWork = unitOfWork;
		}

		public IEnumerable<ApplicationRole> GetAllUserRoles()
		{
			return this.userRolesRepo.All();
		}
	
		public void CreateHotelManager(string hotelManagerId)
		{
			Guard.WhenArgument(hotelManagerId, "hotelManagerId").IsNullOrEmpty().Throw();

			using (var uow = this.unitOfWork)
			{
				this.hotelManagerRepo.Add(new HotelManager()
				{
					Id = hotelManagerId
				});

				uow.SaveChanges();
			}
		}

		public void CreateRegularUser(string userId)
		{
			Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

			using (var uow = this.unitOfWork)
			{
				this.userRepo.Add(new RegularUser()
				{
					Id = userId
				});

				uow.SaveChanges();
			}
		}
	}
}
