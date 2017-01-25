using System;
using PetsWonderland.Business.MVP.Args;
using PetsWonderland.Business.MVP.Models;
using PetsWonderland.Business.MVP.Presenters;
using PetsWonderland.Business.MVP.Views;
using PetsWonderland.Business.MVP.Views.Contracts;
using PetsWonderland.Business.Services.Contracts;
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
			Finding(this, new FindAnimalArgs(id) { Id = id });
		}

		protected void FindAll(object sender, EventArgs e)
		{
			results.Visible = false;
			GridView1.Visible = true;
			GetAll(this, new GetAllAnimalsArgs());
		}
	    
	}
}