using System;
using System.Linq;
using System.Web.UI.WebControls;
using PetsWonderland.Business.MVP.Admin.ListSlider;
using PetsWonderland.Business.MVP.Admin.ListSlider.Args;
using PetsWonderland.Business.MVP.Admin.ListSlider.ViewModels;
using PetsWonderland.Business.MVP.Admin.ListSlider.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
    [PresenterBinding(typeof(ListSlidersPresenter))]
    public partial class AdminSlidersListControl : MvpUserControl<ListSlidersViewModel>, IListSlidersView
    {
        public event EventHandler<GetAllSlidersArgs> GetSlidersList;
        public event EventHandler<DeleteSliderArgs> DeleteSlider;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSlidersRepeater();
            }            
        }
     
        protected void BindSlidersRepeater()
        {
            var getAllSlidersEventArts = new GetAllSlidersArgs();
            this.GetSlidersList?.Invoke(this, getAllSlidersEventArts);

            this.AllSlidersTableRepeater.DataSource = this.Model.AllSliders.ToList();
            this.AllSlidersTableRepeater.DataBind();
        }

        protected void btnDeleteSlider_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)(sender);
            int sliderId = int.Parse(btn.CommandArgument);

            var deleteSliderEventArgs = new DeleteSliderArgs { SliderId = sliderId };
            this.DeleteSlider?.Invoke(this, deleteSliderEventArgs);

            BindSlidersRepeater();
        }
    }
}