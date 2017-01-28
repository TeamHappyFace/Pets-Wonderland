using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Models.Users
{
	public class HotelManager 
	{
		[Key]
		public int Id { get; set; }

		public int? UserProfileId { get; set; }
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
