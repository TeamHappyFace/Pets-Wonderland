using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Models.Pages.Contracts;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class SliderService : ISliderService
    {
        private readonly IRepository<Slider> slidersRepository;
        private readonly IUnitOfWork unitOfWork;

        public SliderService(IRepository<Slider> slidersRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(slidersRepository, "Sliders repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.slidersRepository = slidersRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ISlider> GetAllSliders()
        {
            return this.slidersRepository.All();
        }

        public ISlider GetSliderByPosition(string sliderPosition)
        {
            Guard.WhenArgument(sliderPosition, "Cannot get slider with unknown position!").IsEmpty().Throw();

            var slider = this.slidersRepository
                .Entities
                .Include(x => x.Slides)
                .Where(s => s.Position == sliderPosition && s.IsDeleted == false)
                .FirstOrDefault();

            return slider;
        }

        public bool CreateSlider(
            string name,
            string position, 
            Dictionary<int, List<KeyValuePair<string, string>>> slidesOptions,
            Dictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>> slidesImages)
        {
            Guard.WhenArgument(name, "Slider must have a name!").IsEmpty().Throw();
            Guard.WhenArgument(position, "Slider must have a position!").IsEmpty().Throw();

            bool result;
            try
            {
                using (var uow = unitOfWork)
                {
                    var slides = new List<Slide>();
                    foreach (var key in slidesOptions.Keys)
                    {
                        var slideTitle = slidesOptions[key]
                            .Where(x => x.Key == "SlideTitle")
                            .Select(x => x.Value).FirstOrDefault();
                        var slideCaption = slidesOptions[key]
                            .Where(x => x.Key == "SlideCaption")
                            .Select(x => x.Value).FirstOrDefault();
                        var slideImagePath = slidesOptions[key]
                            .Where(x => x.Key == "SlideImageName")
                            .Select(x => x.Value).FirstOrDefault();

                        var slide = new Slide
                        {
                            Title = slideTitle,
                            Caption = slideCaption,
                            Image = slideImagePath
                        };

                        slides.Add(slide);
                    }

                    var storagePath = HttpContext.Current.Server.MapPath("~/Images/Pages/Homepage/Slider/");
                    foreach (var key in slidesImages.Keys)
                    {
                        var slideImageFile = slidesImages[key]
                            .Where(x => x.Key == "SlideImage")
                            .Select(x => x.Value).FirstOrDefault();

                        slideImageFile?.SaveAs(storagePath + slideImageFile.FileName);
                    }

                    var slider = new Slider { Name = name, Position = position, Slides = slides};

                    this.slidersRepository.Add(slider);
                    uow.SaveChanges();

                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }

        public void DeleteSlider(int sliderId)
        {
            var foundSlider = this.slidersRepository.GetFirst(x => x.Id == sliderId);

            if (foundSlider != null)
            {                
                using (var uow = unitOfWork)
                {
                    foundSlider.IsDeleted = true;
                    uow.SaveChanges();
                }                                    
            }
        }
    }
}
