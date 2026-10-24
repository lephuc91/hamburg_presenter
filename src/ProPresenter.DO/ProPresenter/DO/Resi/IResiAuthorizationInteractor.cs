using System.ComponentModel;
using System.Threading.Tasks;

namespace ProPresenter.DO.Resi;

public interface IResiAuthorizationInteractor : INotifyPropertyChanged
{
	bool CanExecute { get; }

	Task ExecuteLoginAsync();

	Task ExecuteLogoutAsync();
}
