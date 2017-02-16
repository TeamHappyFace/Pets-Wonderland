using System;
using System.Web;

namespace PetsWonderland.Business.MVP.Admin.CreateSlider.Args
{
    public class CreateSliderArgs : EventArgs
    {
        public string Name { get; set; }

        public string Postition { get; set; }

        public HttpPostedFile AvatarFile { get; set; }
    }
}
