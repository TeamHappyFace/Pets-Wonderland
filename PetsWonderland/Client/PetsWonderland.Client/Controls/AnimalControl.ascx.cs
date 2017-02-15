using System;
using Microsoft.AspNet.Identity;
using PetsWonderland.Business.MVP.Animals;
using PetsWonderland.Business.MVP.Animals.Args;
using PetsWonderland.Business.MVP.Animals.ViewModels;
using PetsWonderland.Business.MVP.Animals.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace PetsWonderland.Client
{
	[PresenterBinding(typeof(AnimalPresenter))]
	public partial class AnimalControl : MvpUserControl<AnimalViewModel>, IAnimalView
	{
		public event EventHandler<FindAnimalArgs> Finding;
		public event EventHandler<GetAllAnimalsArgs> GetAll;

		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void FindClick(object sender, EventArgs e)
		{
			int? id = string.IsNullOrEmpty(studentId.Text) ? (int?)null : Convert.ToInt32(studentId.Text);
			OnFinding(id.Value);
		}

		private void OnFinding(int id)
		{
			GridView1.Visible = false;
			results.Visible = true;
			this.Finding(this, new FindAnimalArgs(id) { Id = id });
		}

		protected void FindAll(object sender, EventArgs e)
		{
			results.Visible = false;
			GridView1.Visible = true;

			var user = System.Web.HttpContext.Current.User;
			Console.WriteLine(user.Identity.GetUserName());

			this.GetAll(this, new GetAllAnimalsArgs());
		}
	}
}