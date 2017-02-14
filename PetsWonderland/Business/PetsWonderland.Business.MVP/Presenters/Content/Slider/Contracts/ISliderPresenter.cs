using PetsWonderland.Business.MVP.Presenters.Content.Slider.Args;

namespace PetsWonderland.Business.MVP.Presenters.Content.Contracts
{
    public interface ISliderPresenter
    {
        void GetSliderData(object sender, GetSliderDataArgs e);
    }
}