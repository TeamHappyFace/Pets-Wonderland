using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Content.ContentComponent.Args;
using PetsWonderland.Business.MVP.Content.ContentComponent.Contracts;
using PetsWonderland.Business.MVP.Content.ContentComponent.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Content.ContentComponent
{
    public class ContentComponentPresenter: Presenter<IContentComponentView>, IContentComponentPresenter
    {
        private readonly IPageContentService contentService;

        public ContentComponentPresenter(IContentComponentView view, IPageContentService contentService)
            : base(view)
        {
            Guard.WhenArgument(view, "View cannot be null!").IsNull().Throw();
            Guard.WhenArgument(contentService, "ContentService cannot be null!").IsNull().Throw();

            this.contentService = contentService;

            View.GetSlidersList += GetAllSliders;
        }

        public void GetAllSliders(object sender, GetAllSlidersArgs e)
        {
            this.View.Model.AllSliders = this.contentService.GetAllSliders();
        }
    }
}
