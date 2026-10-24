using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.Editor;

public class SlideLabelColorFillLinkVM : NotifyPropertyChangedBase, ISlideLabelColorFillLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<FillLink> FillLinks => SelectedElements.Select((ClosedBezierPath e) => e.FillLink);

	private SlideLabelColorLinkedObject? SlideLabelColorLinkedObject => FillLinks.FirstOrDefault()?.LinkedObject as SlideLabelColorLinkedObject;

	private UndoStack? UndoStack => SlideLabelColorLinkedObject?.UndoStack;

	public SlideTargetSourceMode TargetSource
	{
		get
		{
			return SlideLabelColorLinkedObject?.TargetSource ?? SlideTargetSourceMode.Current;
		}
		set
		{
			OnTargetSourceChanged(value);
		}
	}

	public SlideLabelColorFillLinkVM(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.FillLink.LinkObjectUpdated -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.FillLink.LinkObjectUpdated += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("TargetSource");
	}

	private void OnTargetSourceChanged(SlideTargetSourceMode value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.LinkSlideLabelColor.ToAction());
		foreach (FillLink fillLink in FillLinks)
		{
			if (fillLink.LinkedObject is SlideLabelColorLinkedObject slideLabelColorLinkedObject)
			{
				slideLabelColorLinkedObject.TargetSource = value;
			}
			else
			{
				fillLink.LinkedObject = new SlideLabelColorLinkedObject(value);
			}
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		NotifyPropertyChanges();
	}
}
