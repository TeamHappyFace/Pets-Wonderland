using PetsWonderland.Business.MVP.Identity.ChangeImage.Args;

namespace PetsWonderland.Business.MVP.Identity.ChangeImage.Contracts
{
	public interface IChangeImagePresenter
	{
		void GetImage(object sender, GetImageArgs e);

		void ChangeImage(object sender, ChangeImageArgs e);
	}
}
