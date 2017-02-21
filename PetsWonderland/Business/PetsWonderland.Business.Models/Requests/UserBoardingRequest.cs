using System;
using System.ComponentModel.DataAnnotations;
using PetsWonderland.Business.Models.Requests.Contracts;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Models.Requests
{
    public class UserBoardingRequest : IUserBoardingRequest
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOfRequest { get; set; }

        public string PetName { get; set; }

        public string PetBreed { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string UserId { get; set; }

        public virtual RegularUser User { get; set; }

        public string HotelManagerId { get; set; }

        public virtual HotelManager HotelManager { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
