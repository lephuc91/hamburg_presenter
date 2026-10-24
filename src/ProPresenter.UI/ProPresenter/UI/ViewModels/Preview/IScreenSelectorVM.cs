using System.ComponentModel;
using Pro.Common.Collections;

namespace ProPresenter.UI.ViewModels.Preview;

public interface IScreenSelectorVM : INotifyPropertyChanged
{
	INotifyEnumerableChanged<IOutputScreenVM> AudienceScreens { get; }

	INotifyEnumerableChanged<IOutputScreenVM> StageScreens { get; }
}
