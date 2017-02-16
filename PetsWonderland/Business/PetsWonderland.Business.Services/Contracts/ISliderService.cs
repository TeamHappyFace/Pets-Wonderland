using System.Collections.Generic;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface ISliderService
    {
        IEnumerable<ISlider> GetAllSliders();

        ISlider GetSliderByPosition(string position);
   
        bool CreateSlider(string name, string position);
    }
}