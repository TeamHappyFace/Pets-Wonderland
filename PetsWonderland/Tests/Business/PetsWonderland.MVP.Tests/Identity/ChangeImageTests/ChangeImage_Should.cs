using System.Web;
using Moq;
using NUnit.Framework;
using PetsWonderland.Business.MVP.Identity.ChangeImage;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Args;
using PetsWonderland.Business.MVP.Identity.ChangeImage.ViewModel;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Views;
using PetsWonderland.Business.Services.Contracts;

namespace PetsWonderland.MVP.Tests.Identity.ChangeImageTests
{
	[TestFixture]
	public class ChangeImage_Should
	{
		[TestCase(1 * 1000 * 1000, "image/jpg")]
		[TestCase(5 * 1000 * 1000, "image/jpg")]
		public void CallUploadImage_WhenParamsAreValid(int contentLength, string contentType)
		{
			var mockedChangeImageView = new Mock<IChangeImageView>();
			var mockedUserService = new Mock<IUserService>();

			var mockedModel = new ChangeImageModel();
			mockedChangeImageView.Setup(x => x.Model).Returns(mockedModel);

			var changeImagePresenter = new ChangeImagePresenter(mockedChangeImageView.Object, mockedUserService.Object);
			var mockedFile = new Mock<HttpPostedFileBase>();
			mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
			mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

			var args = new ChangeImageArgs()
			{
				FileBase = mockedFile.Object,
				UserId = "User1",
				ImagePath = "~/Images",
                Location = "asdasd"                
			};

			mockedChangeImageView.Raise(x => x.EventChangeImage += null, args);
			mockedUserService.Verify(x => x.UploadImage(args.UserId, args.ImagePath), Times.Once());
		}

		[TestCase(10 * 1000 * 1000, "image/jpeg")]
		public void NotCall_UploadAvatar_FromAccountManagementServiceOnceWhenContentTypeOrContentLengthInAreValid(int contentLength, string contentType)
		{
			var mockedChangeImageView = new Mock<IChangeImageView>();
			var mockedUserService = new Mock<IUserService>();

			var mockedModel = new ChangeImageModel();
			mockedChangeImageView.Setup(x => x.Model).Returns(mockedModel);

			var changeImagePresenter = new ChangeImagePresenter(mockedChangeImageView.Object, mockedUserService.Object);
			var mockedFile = new Mock<HttpPostedFileBase>();
			mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
			mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

			var args = new ChangeImageArgs()
			{
				FileBase = mockedFile.Object,
				UserId = "User1",
				ImagePath = "~/Images",            
			};

			mockedChangeImageView.Raise(x => x.EventChangeImage += null, args);
			mockedUserService.Verify(x => x.UploadImage(args.UserId, args.ImagePath), Times.Never());
		}
	}
}
