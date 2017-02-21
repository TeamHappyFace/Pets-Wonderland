using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Animals;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Models.Requests;
using PetsWonderland.Business.Models.Users;

namespace PetsWonderland.Business.Data
{
    public class PetsWonderlandDbContext : IdentityDbContext, IPetsWonderlandDbContext
    {
        public PetsWonderlandDbContext()
                : base("PetsWonderland")
        {
        }
        
        public virtual DbSet<Animal> Animals { get; set; }

        public virtual DbSet<AnimalType> AnimalTypes { get; set; }

        public virtual DbSet<HotelAnimal> HotelAnimals { get; set; }

        public virtual DbSet<UserAnimal> UserAnimals { get; set; }

        public virtual DbSet<Hotel> Hotels { get; set; }

        public virtual DbSet<HotelLocation> HotelLocations { get; set; }

        public virtual DbSet<UserHotel> UserHotels { get; set; }

        public virtual DbSet<UserBoardingRequest> UserBoardingRequests { get; set; }

        public virtual DbSet<UserHotelRegistrationRequest> UserHotelRegistrationRequests { get; set; }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<HotelManager> HotelManagers { get; set; }

        public virtual DbSet<RegularUser> RegularUsers { get; set; }

        public virtual DbSet<Slider> Sliders { get; set; }

        public virtual DbSet<Slide> Slides { get; set; }

        public static PetsWonderlandDbContext Create()
        {
            return new PetsWonderlandDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }       
    }
}
