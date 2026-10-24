using System.Collections.ObjectModel;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class VideoCountdownLinkVM : IVideoCountdownLinkVM, ITimerTextLinkVM
{
	public IIgnoreLoopVM IgnoreLoopVM { get; }

	public ICountdownSourceVM CountdownSourceVM { get; }

	public IFormatDataVM FormatDataVM { get; }

	public VideoCountdownLinkVM(ObservableCollection<ICanvasElement> selectedElements, IColorTriggerVMFactory colorTriggerVMFactory)
	{
		IgnoreLoopVM = new IgnoreLoopVM(selectedElements, UndoActionTypes.IgnoreLoopingVideos);
		CountdownSourceVM = new CountdownSourceVM(selectedElements, UndoActionTypes.VideoCountdownSource);
		FormatDataVM = new FormatDataVM(selectedElements, UndoActionTypes.LinkFormatText, UndoActionTypes.VideoCountdownTimerFormat, colorTriggerVMFactory);
	}
}
