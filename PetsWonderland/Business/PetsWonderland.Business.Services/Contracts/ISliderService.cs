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
            string imageStoragePath,
            IDictionary<int, List<KeyValuePair<string, string>>> slidesOptions,
            IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>> slidesImages);

        void DeleteSlider(int id);
    }
}