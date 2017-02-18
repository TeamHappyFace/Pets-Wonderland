using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetsWonderland.Client.Admin.Controls
{
    public partial class SlideControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string NameGroup
        {
            get { return ViewState["NameGroup"].ToString(); }
            set { ViewState["NameGroup"] = value; }
        }
    }
}