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

public class PresentationNameTextLinkVM : NotifyPropertyChangedBase, IPresentationNameTextLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private PresentationNameLinkedObject? PresentationNameLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as PresentationNameLinkedObject;

	private UndoStack? UndoStack => PresentationNameLinkedObject?.UndoStack;

	public SourceType SourceType
	{
		get
		{
			return PresentationNameLinkedObject?.Source ?? SourceType.Presentation;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.PresentationSource.ToAction());
			UpdatePresentationLinks(value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public PresentationNameTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("SourceType");
	}

	private void UpdatePresentationLinks(SourceType sourceType)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is PresentationNameLinkedObject presentationNameLinkedObject)
			{
				presentationNameLinkedObject.Source = sourceType;
			}
			else
			{
				textLink.LinkedObject = new PresentationNameLinkedObject(sourceType);
			}
		}
		NotifyPropertyChanges();
	}
}
