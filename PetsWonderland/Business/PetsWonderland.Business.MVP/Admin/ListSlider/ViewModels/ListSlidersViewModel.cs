using System.Collections.Generic;
using PetsWonderland.Business.Models.Hotels.Contracts;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.MVP.Admin.ListSlider.ViewModels
{
    public class ListSlidersViewModel
    {
        public IEnumerable<ISlider> AllSliders { get; set; }

        public IEnumerable<IHotel> AllHotels { get; set; }
    }
}