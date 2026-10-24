using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class SlideCountTextLinkVM : NotifyPropertyChangedBase, ISlideCountTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private SlideCountTextLinkedObject? SlideCountTextLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as SlideCountTextLinkedObject;

	private UndoStack? UndoStack => SlideCountTextLinkedObject?.UndoStack;

	public SlideCountType SlideCountType
	{
		get
		{
			return SlideCountTextLinkedObject?.SlideCountType ?? SlideCountType.Current;
		}
		set
		{
			OnSlideCountTypeChanged(value);
		}
	}

	public SlideCountTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("SlideCountType");
	}

	private void OnSlideCountTypeChanged(SlideCountType value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.LinkSlideCount.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is SlideCountTextLinkedObject slideCountTextLinkedObject)
			{
				slideCountTextLinkedObject.SlideCountType = value;
			}
			else
			{
				textLink.LinkedObject = new SlideCountTextLinkedObject(value);
			}
		}
		NotifyPropertyChanges();
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
