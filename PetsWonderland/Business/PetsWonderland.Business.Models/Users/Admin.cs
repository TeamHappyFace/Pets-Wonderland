using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users.Contracts;

namespace PetsWonderland.Business.Models.Users
{
	public class Admin : IAdmin
	{
		[Key, ForeignKey("UserProfile")]
		public string Id { get; set; }
		public virtual UserProfile UserProfile { get; set; }

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
