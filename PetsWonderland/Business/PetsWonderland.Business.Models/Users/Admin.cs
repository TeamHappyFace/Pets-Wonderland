using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Models.Users
{
	public class Admin : UserProfile
	{
		private ICollection<UserHotelRegistrationRequest> userHotelRegistrationRequests;

		public Admin()
		{
			this.userHotelRegistrationRequests = new HashSet<UserHotelRegistrationRequest>();
		}

		[Required]
		public virtual ICollection<UserHotelRegistrationRequest> UserHotelRegistrationRequests
		{
			get
			{
				return this.userHotelRegistrationRequests;
			}
			set
			{
				this.userHotelRegistrationRequests = value;
			}
		}

		public bool IsDeleted { get; set; }
	}
}
