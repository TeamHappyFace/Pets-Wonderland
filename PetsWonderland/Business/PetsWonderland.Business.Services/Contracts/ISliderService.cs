using System.Collections.Generic;
using System.Web;
using PetsWonderland.Business.Models.Pages.Contracts;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface ISliderService
    {
        IEnumerable<ISlider> GetAllSliders();

        ISlider GetSliderByPosition(string position);
   
        bool CreateSlider(
            string name, 
            string position, 
            Dictionary<int, List<KeyValuePair<string, string>>> slidesOptions,
            Dictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>> slidesImages);
    }
}