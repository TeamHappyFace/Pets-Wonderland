using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users.Contracts;

namespace PetsWonderland.Business.Models.Users
{
	public class HotelManager : IHotelManager
	{
		[Key, ForeignKey("UserProfile")]
		public string Id { get; set; }
		public virtual UserProfile UserProfile { get; set; }

		private ICollection<Hotel> hotels;
		private ICollection<UserBoardingRequest> userBoardingRequests;

		public HotelManager()
		{
			this.hotels = new HashSet<Hotel>();
			this.userBoardingRequests = new HashSet<UserBoardingRequest>();
		}

		[Required]
		public virtual ICollection<Hotel> Hotels
		{
			get
			{
				return this.hotels;
			}
			set
			{
				this.hotels = value;
			}
		}

		[Required]
		public virtual ICollection<UserBoardingRequest> UserBoardingRequests
		{
			get
			{
				return this.userBoardingRequests;
			}
			set
			{
				this.userBoardingRequests = value;
			}
		}

		public bool IsDeleted { get; set; }
	}
}
