using PetsWonderland.Business.MVP.Admin.ListSlider.Args;

namespace PetsWonderland.Business.MVP.Admin.ListSlider.Contracts
{
    public interface IListSlidersPresenter
    {
        void GetAllSliders(object sender, GetAllSlidersArgs e);

        void DeleteSlider(object sender, DeleteSliderArgs e);
    }
}