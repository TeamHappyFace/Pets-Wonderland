using System;
using System.Linq;
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

        protected void btnEditSlider_Click(object sender, EventArgs e)
        {
          
            this.BindSlidersRepeater();
        }

        protected void btnDeleteSlider_Click(object sender, EventArgs e)
        {   
            this.BindSlidersRepeater();
        }

        protected void btnNewSlider_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}