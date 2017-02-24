using System;
using System.Collections.Generic;
using System.Web;

namespace PetsWonderland.Business.MVP.Admin.CreateSlider.Args
{
    public class CreateSliderArgs : EventArgs
    {
        public string Name { get; set; }

        public string Postition { get; set; }

        public string ImageStoragePath { get; set; }

        public IDictionary<int, List<KeyValuePair<string, string>>> SlidesOptions { get; set; }

        public IDictionary<int, List<KeyValuePair<string, HttpPostedFileBase>>> SlidesImages { get; set; }
    }
}
