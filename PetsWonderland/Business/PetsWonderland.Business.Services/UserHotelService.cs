using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
	public class UserHotelService : IUserHotelService
	{
		private readonly IRepository<UserHotel> userHotelRepository;
		private readonly IUnitOfWork unitOfWork;

		public UserHotelService(IRepository<UserHotel> userHotelRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(userHotelRepository, "User hotel repository is null!").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

			this.userHotelRepository = userHotelRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddUserHotel(UserHotel userHotelToAdd)
		{
			Guard.WhenArgument(userHotelToAdd, "User hotel to add is null!").IsNull().Throw();
            
			using (var unitOfWork = this.unitOfWork)
			{
				this.userHotelRepository.Add(userHotelToAdd);
			    unitOfWork.SaveChanges();
			}
		}

		public void DeleteUserHotel(UserHotel userHotelToDelete)
		{
			Guard.WhenArgument(userHotelToDelete, "User hotel to delete is null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.userHotelRepository.Delete(userHotelToDelete);
				this.unitOfWork.SaveChanges();
			}
		}

		public void DeleteUserHotelById(object userHotelId)
		{
			Guard.WhenArgument(userHotelId, "Cannot delete user hotel with id=null!").IsNull().Throw();

			using (var unitOfWork = this.unitOfWork)
			{
				this.userHotelRepository.Delete(userHotelId);
				this.unitOfWork.SaveChanges();
			}
		}

		public IQueryable<UserHotel> GetAllUserHotels()
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

		public HotelLocation GetUserHotelLocation(UserHotel userHotel)
		{
			return userHotel.Hotel.Location;
		}
	}
}
