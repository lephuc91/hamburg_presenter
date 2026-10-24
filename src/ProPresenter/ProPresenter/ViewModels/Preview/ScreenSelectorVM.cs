using System.ComponentModel;
using Pro.Common.Collections;
using Pro.Common.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.ViewModels.Preview;

namespace ProPresenter.ViewModels.Preview;

public class ScreenSelectorVM : NotifyPropertyChangedBase, IScreenSelectorVM, INotifyPropertyChanged
{
	private readonly PairedCollection<ScreenArrangementBase, IOutputScreenVM> _audienceScreens;

	private readonly PairedCollection<ScreenArrangementBase, IOutputScreenVM> _stageScreens;

	public INotifyEnumerableChanged<IOutputScreenVM> AudienceScreens => _audienceScreens;

	public INotifyEnumerableChanged<IOutputScreenVM> StageScreens => _stageScreens;

	public ScreenSelectorVM(IOutputService outputService, IOutputScreenVMFactory factory)
	{
		_audienceScreens = new PairedCollection<ScreenArrangementBase, IOutputScreenVM>(outputService.OutputRepository.AudienceScreenArrangementCollection, factory.Create);
		_stageScreens = new PairedCollection<ScreenArrangementBase, IOutputScreenVM>(outputService.OutputRepository.StageScreenArrangementCollection, factory.Create);
	}
}
