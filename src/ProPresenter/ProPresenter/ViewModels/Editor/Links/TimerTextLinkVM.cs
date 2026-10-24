using System.Collections.ObjectModel;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class TimerTextLinkVM : ITimerTextLinkVM
{
	public IFormatDataVM FormatDataVM { get; }

	public TimerTextLinkVM(ObservableCollection<ICanvasElement> selectedElements, IColorTriggerVMFactory colorTriggerVMFactory)
	{
		FormatDataVM = new FormatDataVM(selectedElements, UndoActionTypes.LinkFormatText, UndoActionTypes.TimeFormat, colorTriggerVMFactory);
	}
}
