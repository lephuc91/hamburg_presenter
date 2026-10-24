using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.ViewModels.Editor.Links;

public abstract class LinkedTextObjectVMBase : LinkedNotifyPropertyChangedBase
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	protected IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	protected IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	protected ILinkedTextObject? LinkedTextObject => TextLinks.FirstOrDefault()?.LinkedObject;

	protected UndoStack? UndoStack => LinkedTextObject?.UndoStack;

	protected LinkedTextObjectVMBase(ObservableCollection<ICanvasElement> selectedElements)
	{
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += SelectedElements_CollectionChanged;
	}

	protected virtual void NotifyPropertyChanges()
	{
	}

	private void SelectedElements_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath s)
		{
			s.TextLink.LinkObjectUpdated -= NotifyPropertyChanges;
		});
		e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath s)
		{
			s.TextLink.LinkObjectUpdated += NotifyPropertyChanges;
		});
		NotifyPropertyChanges();
	}
}
