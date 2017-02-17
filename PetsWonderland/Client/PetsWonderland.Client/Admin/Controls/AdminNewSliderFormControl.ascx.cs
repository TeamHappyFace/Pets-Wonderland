﻿using System;
using PetsWonderland.Business.MVP.Admin.CreateSlider;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Args;
using PetsWonderland.Business.MVP.Admin.CreateSlider.ViewModels;
using PetsWonderland.Business.MVP.Admin.CreateSlider.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
    [PresenterBinding(typeof(CreateSliderPresenter))]
    public partial class AdminNewSliderFormControl : MvpUserControl<CreateSliderViewModel>, ICreateSliderView
    {
        public event EventHandler<CreateSliderArgs> CreateSlider;

        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected void CreateSliderBtn_Click(object sender, EventArgs e)
        {           
            //Code display data
            string sliderName = this.SliderName.Text;
            string sliderPosition = this.SliderPostion.Text;

            var sliderArgs = new CreateSliderArgs()
            {
                Name = sliderName,
                Postition = sliderPosition
            };

            this.CreateSlider?.Invoke(this, sliderArgs);
            Response.Redirect(Request.RawUrl);                 
        } 
    }
}