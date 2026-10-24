using System.ComponentModel;
using System.Windows.Input;
using ProPresenter.DO.Looks;

namespace ProPresenter.UI.ViewModels;

public interface IToolBarVM : INotifyPropertyChanged
{
	ICaptureVM CaptureVM { get; }

	bool IsAudienceEnabled { get; }

	bool IsStageEnabled { get; }

	LiveAudienceLook LiveLook { get; }

	IAudienceLookCollection Looks { get; }

	ICommand TriggerLookCommand { get; }
}
