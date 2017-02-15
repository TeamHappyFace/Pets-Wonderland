using System.Data.Entity;
using System.Linq;
using Bytes2you.Validation;
using PetsWonderland.Business.Data.Contracts;
using PetsWonderland.Business.Models.Pages;
using PetsWonderland.Business.Models.Pages.Contracts;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.Business.Services
{
    public class PageContentService : IPageContentService
    {
        private readonly IRepository<Slider> slidersRepository;
        private readonly IUnitOfWork unitOfWork;

        public PageContentService(IRepository<Slider> slidersRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(slidersRepository, "Sliders repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.slidersRepository = slidersRepository;
            this.unitOfWork = unitOfWork;
        }

        public ISlider GetSliderByPosition(string sliderPosition)
        {
            Guard.WhenArgument(sliderPosition, "Cannot get slider with unknown position!").IsEmpty().Throw();

            var slider = this.slidersRepository.Entities.Include(x => x.Slides).Where(s => s.Position == sliderPosition).FirstOrDefault();

            return slider;           
        }
    }
}