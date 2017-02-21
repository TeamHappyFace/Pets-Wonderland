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
	public class GetImage_Should
	{
		[TestCase("1", "~/Images/1.jpg")]
		[TestCase("2", "~/Images/2.jpg")]
		[TestCase("3", "~/Images/3.jpg")]
		public void AtachUserAvatarUrlToTheModel(string id, string imageUrl)
		{
			var mockedChangeImageView = new Mock<IChangeImageView>();
			var mockedUserService = new Mock<IUserService>();

			var mockedModel = new ChangeImageModel();
			mockedChangeImageView.Setup(x => x.Model).Returns(mockedModel);
			mockedUserService.Setup(x => x.GetImageByUserId(id)).Returns(imageUrl);

			var changeImagePresenter = new ChangeImagePresenter(mockedChangeImageView.Object, mockedUserService.Object);
			var eventArgs = new GetImageArgs() { UserId = id };

			mockedChangeImageView.Raise(x => x.EventGetImage += null, eventArgs);

			Assert.AreEqual(imageUrl, mockedChangeImageView.Object.Model.ImagePath);
		}
	}
}
