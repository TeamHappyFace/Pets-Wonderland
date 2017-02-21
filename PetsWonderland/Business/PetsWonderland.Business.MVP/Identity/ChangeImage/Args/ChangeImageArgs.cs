using System;
using System.Web;

namespace PetsWonderland.Business.MVP.Identity.ChangeImage.Args
{
    public class ChangeImageArgs : EventArgs
    {
        public string UserId { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase FileBase { get; set; }

        public string Location { get; set; }
    }
}
