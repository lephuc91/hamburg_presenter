using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Components;
using Pro.UI.InputActions;
using ProPresenter.DO.InputActionMap;
using ProPresenter.UI.ViewModels.Preview;
using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.ViewModels.Preview;

public class WindowedOutputVM : NotifyPropertyChangedBase, IWindowedOutputVM, INotifyPropertyChanged
{
	private readonly IProCoreInstance _proCoreInstance;

	private readonly PairedCollection<InputAction, IOutputScreenVM> _audienceScreens;

	private readonly PairedCollection<InputAction, IOutputScreenVM> _stageScreens;

	public INotifyEnumerableChanged<IOutputScreenVM> AudienceScreens => _audienceScreens;

	public INotifyEnumerableChanged<IOutputScreenVM> StageScreens => _stageScreens;

	public ICommand<IOutputScreenVM?> CreateOutputWindowCommand => new RelayCommand<IOutputScreenVM>(ExecuteCreateOutputWindowCommand, (IOutputScreenVM? s) => s != null);

	public WindowedOutputVM(IProCoreInstance proCoreInstance, IWindowMenuGroup windowMenuGroup, IOutputScreenVMFactory factory)
	{
		_proCoreInstance = proCoreInstance;
		_audienceScreens = new PairedCollection<InputAction, IOutputScreenVM>(windowMenuGroup.AudienceScreens, factory.Create);
		_stageScreens = new PairedCollection<InputAction, IOutputScreenVM>(windowMenuGroup.StageScreens, factory.Create);
	}

	private void ExecuteCreateOutputWindowCommand(IOutputScreenVM? screen)
	{
		_proCoreInstance.CreateOutputWindow(screen.Id);
	}
}
