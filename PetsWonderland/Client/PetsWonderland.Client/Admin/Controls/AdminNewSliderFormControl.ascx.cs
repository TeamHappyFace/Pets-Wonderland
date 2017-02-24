using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        protected int NumberOfControls
        {
            get { return (int)this.ViewState["NumControls"]; }
            set { this.ViewState["NumControls"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.NumberOfControls = 0;
            }
            else
            {
                this.CreateControls();
            }                                 
        }
                
        protected void CreateSliderBtn_Click(object sender, EventArgs e)
        {           
            // ViewModel Data
            string sliderName = this.SliderName.Text;
            string sliderPosition = this.SliderPostion.Text;
            string imageStoragePath = HttpContext.Current.Server.MapPath("~/Images/Pages/Homepage/Slider/");
            var slidesOptions = new Dictionary<int, List<KeyValuePair<string, string>>>();
            var slidesImages = new Dictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>>();
           
            // Parse dynamically added slide controls values
            for (var i = 0; i < this.SliderSlidesPlaceholder2.Controls.Count; i++)
            {
                var currentControl = this.SliderSlidesPlaceholder2.Controls[i];
                slidesOptions.Add(i, new List<KeyValuePair<string, string>>());
                slidesImages.Add(i, new List<KeyValuePair<string, HttpPostedFileBase>>());

                if (!(currentControl is SlideControl)) { continue; }

                foreach (Control sc in currentControl.Controls)
                {
                    if (sc is TextBox)
                    {
                        TextBox tb = sc as TextBox;
                        var type = tb.ID;
                        var typeValue = tb.Text;
                        var pair = new KeyValuePair<string, string>(type, typeValue);

                        slidesOptions[i].Add(pair);
                    }
                    else if (sc is FileUpload)
                    {
                        FileUpload fupd = sc as FileUpload;

                        if (fupd.HasFile)
                        {
                            var postedImage = fupd.PostedFile;
                            var file = new HttpPostedFileWrapper(postedImage);
                            var fileName = file.FileName;
                            var fileStoragePath = "~/Images/Pages/Homepage/Slider/" + fileName;                                        

                            var filePair = new KeyValuePair<string, HttpPostedFileBase>("SlideImage", file);
                            var fileNamePair = new KeyValuePair<string, string>("SlideImageName", fileStoragePath);

                            slidesOptions[i].Add(fileNamePair);
                            slidesImages[i].Add(filePair);
                        }
                    }                   
                }
            }

            var sliderArgs = new CreateSliderArgs()
            {
                Name = sliderName,
                Postition = sliderPosition,
                ImageStoragePath = imageStoragePath,
                SlidesOptions = slidesOptions,
                SlidesImages = slidesImages
            };
            
            this.CreateSlider?.Invoke(this, sliderArgs);

            if (!this.Model.SliderCreatedSuccessfully)
            {
                this.Notificator.DisplaySuccessNotification("An error occured while trying to create the slider!");
            }
            
            Response.Redirect("ContentPages.aspx");                 
        }

        protected void addNewSlide_Click(object sender, EventArgs e)
        {
            SlideControl slide = (SlideControl)Page.LoadControl("~/Admin/Controls/SlideControl.ascx");
            slide.NameGroup = this.NumberOfControls.ToString();

            this.SliderSlidesPlaceholder2.Controls.Add(slide);
            this.NumberOfControls++;
        }

        private void CreateControls()
        {
            var count = this.NumberOfControls;

            for (var i = 0; i < count; i++)
            {
                SlideControl slide = (SlideControl)Page.LoadControl("~/Admin/Controls/SlideControl.ascx");

                slide.NameGroup = this.NumberOfControls.ToString();
                this.SliderSlidesPlaceholder2.Controls.Add(slide);
            }
        }
    }
}