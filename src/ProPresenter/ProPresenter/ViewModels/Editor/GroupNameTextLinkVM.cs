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

public class GroupNameTextLinkVM : NotifyPropertyChangedBase, IGroupNameTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private GroupNameLinkedObject? GroupNameLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as GroupNameLinkedObject;

	private UndoStack? UndoStack => GroupNameLinkedObject?.UndoStack;

	public GroupSourceType GroupSource
	{
		get
		{
			return GroupNameLinkedObject?.GroupSource ?? GroupSourceType.CurrentSlide;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LinkSlideText));
			UpdateGroupNameLinks(value);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public GroupNameTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("GroupSource");
	}

	private void UpdateGroupNameLinks(GroupSourceType value)
	{
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is GroupNameLinkedObject groupNameLinkedObject)
			{
				groupNameLinkedObject.GroupSource = value;
				continue;
			}
			textLink.LinkedObject = new GroupNameLinkedObject
			{
				GroupSource = value
			};
		}
		NotifyPropertyChanges();
	}
}
