using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                .Where(s => s.Position == sliderPosition)
                .FirstOrDefault();

            return slider;
        }
                
        public bool CreateSlider(string name, string position)
        {
            Guard.WhenArgument(name, "Slider must have a name!").IsEmpty().Throw();
            Guard.WhenArgument(position, "Slider must have a position!").IsEmpty().Throw();

            bool result;
            try
            {
                using (var uow = unitOfWork)
                {
                    var slider = new Slider { Name = name, Position = position };

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
    }
}
