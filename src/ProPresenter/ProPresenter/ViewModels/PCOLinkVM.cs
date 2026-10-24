using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class PCOLinkVM : NotifyPropertyChangedBase, IPCOLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedCanvasElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public PCOLiveTheme PCOLiveTheme
	{
		get
		{
			return (FirstElement?.FillLink.LinkedObject as PCOLiveLinkedObject)?.Theme ?? PCOLiveTheme.Light;
		}
		set
		{
			if (PCOLiveTheme == value)
			{
				return;
			}
			UndoStack?.BeginCommit(UndoActionTypes.PCOLiveTheme.ToAction());
			foreach (ClosedBezierPath selectedElement in SelectedElements)
			{
				ILinkedFillObject? linkedObject = selectedElement.FillLink.LinkedObject;
				if (linkedObject != null && linkedObject.LinkedFillType == LinkedFillType.PCOLive)
				{
					((PCOLiveLinkedObject)selectedElement.FillLink.LinkedObject).Theme = value;
				}
				else
				{
					selectedElement.FillLink.LinkedObject = new PCOLiveLinkedObject(value, PCOLiveCountdownType);
				}
			}
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			OnPropertyChanged("PCOLiveTheme");
		}
	}

	public PCOLiveCountdownType PCOLiveCountdownType
	{
		get
		{
			return (FirstElement?.FillLink.LinkedObject as PCOLiveLinkedObject)?.CountdownType ?? PCOLiveCountdownType.FullItemLength;
		}
		set
		{
			if (PCOLiveCountdownType == value)
			{
				return;
			}
			UndoStack?.BeginCommit(UndoActionTypes.PCOLiveCountdownType.ToAction());
			foreach (ClosedBezierPath selectedElement in SelectedElements)
			{
				ILinkedFillObject? linkedObject = selectedElement.FillLink.LinkedObject;
				if (linkedObject != null && linkedObject.LinkedFillType == LinkedFillType.PCOLive)
				{
					((PCOLiveLinkedObject)selectedElement.FillLink.LinkedObject).CountdownType = value;
				}
				else
				{
					selectedElement.FillLink.LinkedObject = new PCOLiveLinkedObject(PCOLiveTheme, value);
				}
			}
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			OnPropertyChanged("PCOLiveCountdownType");
		}
	}

	public PCOLinkVM(ObservableCollection<ICanvasElement> selectedCanvasElements)
	{
		_selectedCanvasElements = selectedCanvasElements;
		_selectedCanvasElements.CollectionChanged += delegate
		{
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("PCOLiveTheme");
		OnPropertyChanged("PCOLiveCountdownType");
	}
}
