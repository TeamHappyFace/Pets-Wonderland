using System;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Args;
using PetsWonderland.Business.MVP.Identity.ChangeImage.ViewModel;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.ChangeImage.Views
{
	public interface IChangeImageView : IView<ChangeImageModel>
	{
		event EventHandler<GetImageArgs> EventGetImage;

		event EventHandler<ChangeImageArgs> EventChangeImage;
	}
}
