using System;
using System.Web.UI.WebControls;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Args;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.ViewModels;
using PetsWonderland.Business.MVP.Hotels.GetAllHotels.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.PageControls.Homepage
{
	[PresenterBinding(typeof(GetAllHotelsPresenter))]
	public partial class HomepageHotelsListControl : MvpUserControl<GetAllHotelsModel>, IGetAllHotelsView
	{
		public event EventHandler<GetAllHotelsArgs> GetAllHotels;

	    protected const int HotelsBatchIncrease = 3;

	    protected int HotelsListStartIndex {
            get { return (int)ViewState["HotelsListStartIndex"]; }
            set { ViewState["HotelsListStartIndex"] = value; }
        }

	    protected int HotelsListBatch
	    {
            get { return (int)ViewState["HotelsListBatch"]; }
            set { ViewState["HotelsListBatch"] = value; }
        } 

		protected void Page_Load(object sender, EventArgs e)
		{
		    if (!IsPostBack)
		    {
		        this.HotelsListStartIndex = 0;
		        this.HotelsListBatch = HotelsBatchIncrease;

		        RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
		    }
		    else
		    {
		        RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
		    }
		}

	    protected void RebindHotelsList(int startAt, int count)
	    {
            this.GetAllHotels?.Invoke(this, new GetAllHotelsArgs { StartAt = startAt, Count = count });

            Hotels.DataSource = this.Model.Hotels;
            Hotels.DataBind();
        
        }             

		protected void Hotels_ItemCreated(object sender, ListViewItemEventArgs e)
		{
			var hyperlink = e.Item.FindControl("boardingRequest") as HyperLink;

			if (!this.Page.User.IsInRole("User") || !this.Page.User.Identity.IsAuthenticated)
			{
				hyperlink.Visible = false;
			}
		}

        protected void btnLoadMoreHotels_Click(object sender, EventArgs e)
        {
            this.HotelsListBatch += HotelsBatchIncrease;

            RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
        }
	}
}