using System.ComponentModel;
using Pro.Common.Collections;
using Pro.UI.Components;

namespace ProPresenter.UI.ViewModels.Preview;

public interface IWindowedOutputVM : INotifyPropertyChanged
{
	INotifyEnumerableChanged<IOutputScreenVM> AudienceScreens { get; }

	INotifyEnumerableChanged<IOutputScreenVM> StageScreens { get; }

	ICommand<IOutputScreenVM?> CreateOutputWindowCommand { get; }
}
