using System.ComponentModel;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.ViewModels;

public interface IStageLayoutInspectorVM : INotifyPropertyChanged
{
	SlideCue? SlideCue { get; set; }

	ICommand<ColorPair> ColorChangeFinishedCommand { get; }
}
