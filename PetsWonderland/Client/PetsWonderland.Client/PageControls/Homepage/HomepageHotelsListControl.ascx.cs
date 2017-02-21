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
        protected const int HotelsBatchIncrease = 3;

        public event EventHandler<GetAllHotelsArgs> GetAllHotels;
      
        protected int HotelsListStartIndex
        {
            get { return (int)this.ViewState["HotelsListStartIndex"]; }
            set { this.ViewState["HotelsListStartIndex"] = value; }
        }

        protected int HotelsListBatch
        {
            get { return (int)this.ViewState["HotelsListBatch"]; }
            set { this.ViewState["HotelsListBatch"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.HotelsListStartIndex = 0;
                this.HotelsListBatch = HotelsBatchIncrease;

                this.RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
            }
            else
            {
                this.RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
            }
        }

        protected void RebindHotelsList(int startAt, int count)
        {
            this.GetAllHotels?.Invoke(this, new GetAllHotelsArgs { StartAt = startAt, Count = count });

            this.Hotels.DataSource = this.Model.Hotels;
            this.Hotels.DataBind();
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

            this.RebindHotelsList(this.HotelsListStartIndex, this.HotelsListBatch);
        }
    }
}