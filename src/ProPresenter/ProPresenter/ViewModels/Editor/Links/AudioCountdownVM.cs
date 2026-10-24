using System.Collections.ObjectModel;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class AudioCountdownVM : LinkedTextObjectVMBase, IAudioCountdownVM, ITimerTextLinkVM
{
	public IIgnoreLoopVM IgnoreLoopVM { get; }

	public IFormatDataVM FormatDataVM { get; }

	public AudioCountdownVM(ObservableCollection<ICanvasElement> selectedElements, IColorTriggerVMFactory colorTriggerVMFactory)
		: base(selectedElements)
	{
		IgnoreLoopVM = new IgnoreLoopVM(selectedElements, UndoActionTypes.IgnoreLoopingAudio);
		FormatDataVM = new FormatDataVM(selectedElements, UndoActionTypes.LinkFormatText, UndoActionTypes.AudioCountdownTimerFormat, colorTriggerVMFactory);
	}
}
