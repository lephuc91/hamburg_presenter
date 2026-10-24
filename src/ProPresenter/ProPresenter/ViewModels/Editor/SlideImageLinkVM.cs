using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class SlideImageLinkVM : NotifyPropertyChangedBase, ISlideImageLinkVM
{
	private ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedCanvasElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public SlideTargetSourceMode SlideTargetSourceMode
	{
		get
		{
			return (FirstElement?.FillLink.LinkedObject as SlideImageLinkedObject)?.TargetSourceMode ?? SlideTargetSourceMode.Current;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.LinkSlideImage.ToAction());
			foreach (ClosedBezierPath selectedElement in SelectedElements)
			{
				ILinkedFillObject? linkedObject = selectedElement.FillLink.LinkedObject;
				if (linkedObject != null && linkedObject.LinkedFillType == LinkedFillType.SlidePreview)
				{
					((SlideImageLinkedObject)selectedElement.FillLink.LinkedObject).TargetSourceMode = value;
				}
				else
				{
					selectedElement.FillLink.LinkedObject = new SlideImageLinkedObject(value);
				}
			}
			UndoStack?.EndCommit(null, null, autoFinalize: true);
			OnPropertyChanged("SlideTargetSourceMode");
		}
	}

	public ICommand<SlideTargetSourceMode> SlideImageFillCommand => new RelayCommand<SlideTargetSourceMode>(delegate(SlideTargetSourceMode m)
	{
		SlideTargetSourceMode = m;
	});

	public SlideImageLinkVM(ObservableCollection<ICanvasElement> selectedCanvasElements)
	{
		_selectedCanvasElements = selectedCanvasElements;
		_selectedCanvasElements.CollectionChanged += delegate
		{
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("SlideTargetSourceMode");
	}
}
