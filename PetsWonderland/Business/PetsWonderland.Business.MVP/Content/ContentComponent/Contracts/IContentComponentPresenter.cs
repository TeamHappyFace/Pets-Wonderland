using PetsWonderland.Business.MVP.Content.ContentComponent.Args;

namespace PetsWonderland.Business.MVP.Content.ContentComponent.Contracts
{
    public interface IContentComponentPresenter
    {
        void GetAllSliders(object sender, GetAllSlidersArgs e);
    }
}