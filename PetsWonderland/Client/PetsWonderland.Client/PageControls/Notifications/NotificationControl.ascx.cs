using System;

namespace PetsWonderland.Client.PageControls.Notifications
{
    public partial class NotificationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HideNotification();
        }

        public void DisplayErrorNotification(string errorText)
        {
            this.NotificationPanel.Visible = true;
            this.NotificationPanel.CssClass = "alert alert-danger";
            this.NotificationMessage.Text = errorText ?? "An error occured!";
        }

        public void DisplayWarningNotification(string warningText)
        {
            this.NotificationPanel.Visible = true;
            this.NotificationPanel.CssClass = "alert alert-warning";
            this.NotificationMessage.Text = warningText;
        }

        public void DisplayInfoNotification(string infoText)
        {
            this.NotificationPanel.Visible = true;
            this.NotificationPanel.CssClass = "alert alert-info";
            this.NotificationMessage.Text = infoText;
        }

        public void DisplaySuccessNotification(string successText)
        {
            this.NotificationPanel.Visible = true;
            this.NotificationPanel.CssClass = "alert alert-success";
            this.NotificationMessage.Text = successText ?? "Operation completed successfully!";
        }

        public void HideNotification()
        {
            this.NotificationPanel.Visible = false;
            this.NotificationPanel.CssClass = "";
            this.NotificationMessage.Text = "";
        }       
    }
}