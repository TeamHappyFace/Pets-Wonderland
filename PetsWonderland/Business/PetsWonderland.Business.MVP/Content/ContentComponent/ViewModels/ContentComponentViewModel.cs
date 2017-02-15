using System.Collections.Generic;
using PetsWonderland.Business.Models.Hotels.Contracts;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.MVP.Content.ContentComponent.ViewModels
{
    public class ContentComponentViewModel
    {
        public IEnumerable<ISlider> AllSliders { get; set; }

        public IEnumerable<IHotel> AllHotels { get; set; }
    }
}