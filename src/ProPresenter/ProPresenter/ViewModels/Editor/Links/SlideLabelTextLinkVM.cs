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
using ProPresenter.UI.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public class SlideLabelTextLinkVM : NotifyPropertyChangedBase, ISlideLabelTextLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private SlideLabelTextLinkedObject? SlideLabelTextLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as SlideLabelTextLinkedObject;

	private UndoStack? UndoStack => SlideLabelTextLinkedObject?.UndoStack;

	public SlideTargetSourceMode TargetSource
	{
		get
		{
			return SlideLabelTextLinkedObject?.TargetSource ?? SlideTargetSourceMode.Current;
		}
		set
		{
			OnTargetSourceChanged(value);
		}
	}

	public SlideLabelTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		UndoStack?.BeginCommit(UndoActionTypes.SlideLabelSource.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is SlideLabelTextLinkedObject slideLabelTextLinkedObject)
			{
				slideLabelTextLinkedObject.TargetSource = value;
			}
			else
			{
				textLink.LinkedObject = new SlideLabelTextLinkedObject(value);
			}
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		NotifyPropertyChanges();
	}
}
