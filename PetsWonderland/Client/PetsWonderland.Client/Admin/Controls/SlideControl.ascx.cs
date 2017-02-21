using System;

namespace PetsWonderland.Client.Admin.Controls
{
    public partial class SlideControl : System.Web.UI.UserControl
    {
        public string NameGroup
        {
            get { return this.ViewState["NameGroup"].ToString(); }
            set { this.ViewState["NameGroup"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }        
    }
}