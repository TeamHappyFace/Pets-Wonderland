using System;
using PetsWonderland.Business.MVP.Content.Slider;
using PetsWonderland.Business.MVP.Content.Slider.Args;
using PetsWonderland.Business.MVP.Content.Slider.ViewModels;
using PetsWonderland.Business.MVP.Content.Slider.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.PageControls.Homepage
{
    [PresenterBinding(typeof(SliderPresenter))]
    public partial class HomepageSliderControl : MvpUserControl<SliderViewModel>, ISliderView
    {
        public event EventHandler<GetSliderDataArgs> GetSliderData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var sliderDataEventArgs = new GetSliderDataArgs("homepage");

                var onGetSliderData = this.GetSliderData;
                onGetSliderData?.Invoke(this, sliderDataEventArgs);
            }
        }
    }
}