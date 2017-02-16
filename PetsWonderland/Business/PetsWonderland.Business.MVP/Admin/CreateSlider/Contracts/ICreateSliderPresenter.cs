using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;

namespace PetsWonderland.Business.MVP.Admin.CreateSlider.Contracts
{
    public interface ICreateSliderPresenter
    {
        void CreateSlider(object sender, CreateSliderArgs e);
    }
}