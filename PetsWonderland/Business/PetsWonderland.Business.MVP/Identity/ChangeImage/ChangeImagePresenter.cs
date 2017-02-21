using System.Web;
using Bytes2you.Validation;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Args;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Contracts;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Views;
using PetsWonderland.Business.Services.Contracts;
using WebFormsMvp;

namespace PetsWonderland.Business.MVP.Identity.ChangeImage
{
	public class ChangeImagePresenter : Presenter<IChangeImageView>, IChangeImagePresenter
	{
		private const int ImageMaxSize = 5 * 1000 * 1000;

		private readonly IUserService userService;

		public ChangeImagePresenter(IChangeImageView view, IUserService userService) 
			: base(view)
		{
			Guard.WhenArgument(userService, "userService").IsNull().Throw();

			this.userService = userService;

			this.View.EventChangeImage += ChangeImage;
			this.View.EventGetImage += GetImage;
		}

		public void ChangeImage(object sender, ChangeImageArgs e)
		{
			HttpPostedFileBase uploadedFile = e.FileBase;
			if (uploadedFile.ContentLength <= ImageMaxSize)
			{
				uploadedFile.SaveAs(e.Location);

				this.userService.UploadImage(e.UserId, e.ImagePath);
				this.View.Model.IsUploaded = true;
				this.View.Model.ImagePath = e.ImagePath;
			}
		}

		public void GetImage(object sender, GetImageArgs e)
		{
			this.View.Model.ImagePath = this.userService.GetImageByUserId(e.UserId);
		}
	}
}
