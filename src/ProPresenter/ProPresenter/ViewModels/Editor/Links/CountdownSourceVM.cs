using System.Collections.ObjectModel;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class CountdownSourceVM : LinkedTextObjectVMBase, ICountdownSourceVM
{
	private readonly UndoActionTypes _sourceUndoType;

	public SourceType Source
	{
		get
		{
			return (base.LinkedTextObject as ICountdownSource)?.Source ?? SourceType.Presentation;
		}
		set
		{
			UpdateTimerTextLinks(value);
		}
	}

	public CountdownSourceVM(ObservableCollection<ICanvasElement> selectedElements, UndoActionTypes sourceUndoType)
		: base(selectedElements)
	{
		_sourceUndoType = sourceUndoType;
	}

	protected override void NotifyPropertyChanges()
	{
		OnPropertyChanged("Source");
	}

	private void UpdateTimerTextLinks(SourceType source)
	{
		base.UndoStack?.BeginCommit(_sourceUndoType.ToAction());
		foreach (TextLink textLink in base.TextLinks)
		{
			if (textLink.LinkedObject is VideoCountdownLinkedObject videoCountdownLinkedObject)
			{
				videoCountdownLinkedObject.Source = source;
				continue;
			}
			VideoCountdownLinkedObject videoCountdownLinkedObject2 = base.LinkedTextObject?.Clone() as VideoCountdownLinkedObject;
			if (videoCountdownLinkedObject2 != null)
			{
				videoCountdownLinkedObject2.Source = source;
			}
			textLink.LinkedObject = videoCountdownLinkedObject2;
		}
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
