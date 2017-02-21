using System;
using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.MVP.Identity.ChangeImage;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Args;
using PetsWonderland.Business.MVP.Identity.ChangeImage.ViewModel;
using PetsWonderland.Business.MVP.Identity.ChangeImage.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client.PageControls.Account
{
    [PresenterBinding(typeof(ChangeImagePresenter))]
    public partial class ChangeImageControl : MvpUserControl<ChangeImageModel>, IChangeImageView
    {
        public event EventHandler<ChangeImageArgs> EventChangeImage;

        public event EventHandler<GetImageArgs> EventGetImage;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.UploadBtn);

            if (!this.IsPostBack)
            {
                var args = new GetImageArgs()
                {
                    UserId = this.Page.User.Identity.GetUserId()
                };

                this.EventGetImage?.Invoke(this, args);
                this.Image.ImageUrl = this.Model.ImagePath;
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (this.ImageUpload.HasFile)
            {
                string username = this.Context.User.Identity.Name;
                HttpPostedFile postedFile = this.ImageUpload.PostedFile;
                HttpPostedFileBase fileBase = new HttpPostedFileWrapper(postedFile);

                string extension = Path.GetExtension(postedFile.FileName);
                string filename = username + extension;
                string imageFilePath = "/Images/" + filename;
                string location = Server.MapPath($"~{imageFilePath}");

                var args = new ChangeImageArgs()
                {
                    ImagePath = imageFilePath,
                    Location = location,
                    FileBase = fileBase,
                    UserId = this.Page.User.Identity.GetUserId()
                };

                this.EventChangeImage?.Invoke(this, args);
            }

            if (this.Model.IsUploaded)
            {
                Response.Redirect("~/Account/Manage");
            }
        }
    }
}