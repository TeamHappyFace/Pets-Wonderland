using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IPageContentService
    {
        ISlider GetSliderByPosition(string position);
    }
}