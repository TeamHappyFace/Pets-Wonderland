using PetsWonderland.Business.MVP.Identity.Login.Args;

namespace PetsWonderland.Business.MVP.Identity.Login.Contracts
{
	public interface ILoginPresenter
	{
		void LoginUser(object sender, LoginEventArgs e);
	}
}
