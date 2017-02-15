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
            if (!IsPostBack)
            {
                var sliderDataEventArgs = new GetSliderDataArgs("homepage");
                this.GetSliderData?.Invoke(this, sliderDataEventArgs);

                if (this.Model.SliderData != null)
                {
                    this.SliderRepeater.DataSource = this.Model.SliderData.Slides;
                    this.SliderRepeater.DataBind();
                }                
            }
           
        }
    }
}