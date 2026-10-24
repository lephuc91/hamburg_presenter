using System.Collections.Generic;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls;

namespace ProPresenter.UI.ViewModels.TestPattern;

public interface ITestPatternVM : INotifyPropertyChanged
{
	IEnumerable<ITestPatternItemVM> TestPatterns { get; }

	ITestPatternStateVM CurrentState { get; }

	ITestPatternItemVM? SelectedPattern { get; }

	IRelayCommand<RequestRenderParameter> RequestRenderCommand { get; }

	void LoadPatterns();
}
