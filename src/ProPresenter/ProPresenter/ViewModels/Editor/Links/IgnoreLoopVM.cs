using System.Collections.ObjectModel;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class IgnoreLoopVM : LinkedTextObjectVMBase, IIgnoreLoopVM
{
	private readonly UndoActionTypes _ignoreLoopingUndoType;

	public bool IgnoreLooping
	{
		get
		{
			return (base.LinkedTextObject as ILoopToggle)?.IgnoreLooping ?? false;
		}
		set
		{
			UpdateTimerTextLinks(value);
		}
	}

	public IgnoreLoopVM(ObservableCollection<ICanvasElement> selectedElements, UndoActionTypes ignoreLoopUndoType)
		: base(selectedElements)
	{
		_ignoreLoopingUndoType = ignoreLoopUndoType;
	}

	protected override void NotifyPropertyChanges()
	{
		OnPropertyChanged("IgnoreLooping");
	}

	private void UpdateTimerTextLinks(bool ignoreLoop)
	{
		base.UndoStack?.BeginCommit(_ignoreLoopingUndoType.ToAction());
		foreach (TextLink textLink in base.TextLinks)
		{
			if (textLink.LinkedObject is ILoopToggle loopToggle)
			{
				loopToggle.IgnoreLooping = ignoreLoop;
				continue;
			}
			ILinkedTextObject linkedTextObject = base.LinkedTextObject?.Clone();
			if (linkedTextObject is ILoopToggle loopToggle2)
			{
				loopToggle2.IgnoreLooping = ignoreLoop;
			}
			textLink.LinkedObject = linkedTextObject;
		}
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
