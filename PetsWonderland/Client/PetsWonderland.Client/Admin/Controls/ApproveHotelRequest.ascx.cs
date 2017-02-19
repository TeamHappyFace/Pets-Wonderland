using System;
using PetsWonderland.Business.Models.Hotels;
using PetsWonderland.Business.MVP.Hotels.AddHotel;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Args;
using PetsWonderland.Business.MVP.Hotels.AddHotel.ViewModels;
using PetsWonderland.Business.MVP.Hotels.AddHotel.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
	[PresenterBinding(typeof(AddHotelPresenter))]
	public partial class ApproveHotelRequest : MvpUserControl<AddHotelModel>, IAddHotelView
	{
		public event EventHandler<AddHotelArgs> AddHotel;

		public string HotelName
        {
            get
            {
                if (ViewState["hotelName"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (string)ViewState["hotelName"];
                }
                   
            }
		    set
		    {
		        ViewState["hotelName"] = value; 		        
		    }
        }

		public string Description {
            get
            {
                if (ViewState["hotelDescription"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (string)ViewState["hotelDescription"];
                }

            }
            set
            {
                ViewState["hotelDescription"] = value;
            }
        }

		//public string ImageUrl { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void OnApprove_Click(object sender, EventArgs e)
		{			                        
			var hotelArgs = new AddHotelArgs
			{
			    HotelName = this.HotelName,
                HotelDescription = this.Description
			};
			this.AddHotel?.Invoke(this, hotelArgs);

			//IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
		}
	}
}