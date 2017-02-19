using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using PetsWonderland.Business.Models.Pages;

namespace PetsWonderland.Business.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<PetsWonderlandDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PetsWonderlandDbContext context)
        {
            if (!context.Sliders.Any())
            {
                var slider = new Slider
                {
                    Name = "HomepageSlider",
                    Position = "homepage",
                    Slides = new List<Slide>
                    {
                        new Slide
                        {
                            Title = "PetsWonderland",
                            Caption = "Find the best boarding service for your pet",
                            Image = "~/Images/Pages/Homepage/Slider/pets_01.jpg"
                        },
                        new Slide
                        {
                            Title = "PetsWonderland",
                            Caption = "Find the best boarding service for your pet",
                            Image = "~/Images/Pages/Homepage/Slider/pets_04.jpg"
                        },
                        new Slide
                        {
                            Title = "PetsWonderland",
                            Caption = "Find the best boarding service for your pet",
                            Image = "~/Images/Pages/Homepage/Slider/pets_03.jpg"
                        }
                    }                    
                };

                context.Sliders.Add(slider);
                context.SaveChanges();
            }
        }
    }
}
