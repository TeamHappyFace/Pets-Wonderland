using System;
using System.Linq;
using System.Web.UI;
using PetsWonderland.Business.MVP.Content.ContentComponent;
using PetsWonderland.Business.MVP.Content.ContentComponent.Args;
using PetsWonderland.Business.MVP.Content.ContentComponent.ViewModels;
using PetsWonderland.Business.MVP.Content.ContentComponent.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.Admin.Controls
{
    [PresenterBinding(typeof(ContentComponentPresenter))]
    public partial class AdminSlidersListControl : MvpUserControl<ContentComponentViewModel>, IContentComponentView
    {
        public event EventHandler<GetAllSlidersArgs> GetSlidersList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var getAllSlidersEventArts = new GetAllSlidersArgs();
                this.GetSlidersList?.Invoke(this, getAllSlidersEventArts);

                this.AllSlidersTableRepeater.DataSource = this.Model.AllSliders.ToList();
                this.AllSlidersTableRepeater.DataBind();
            }
        }

        protected void btnEditSlider_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnDeleteSlider_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnNewSlider_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}