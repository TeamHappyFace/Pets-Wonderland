using PetsWonderland.Business.MVP.Identity.ChangePassword.Args;

namespace PetsWonderland.Business.MVP.Identity.ChangePassword.Contracts
{
    public interface IChangePasswordPresenter
    {
        void ChangePassword(object sender, ChangePasswordEventArgs e);
    }
}
