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

public class GroupColorFillLinkVM : NotifyPropertyChangedBase, IGroupColorFillLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<FillLink> FillLinks => SelectedElements.Select((ClosedBezierPath e) => e.FillLink);

	private GroupColorLinkedObject? GroupNameLinkedObject => FillLinks.FirstOrDefault()?.LinkedObject as GroupColorLinkedObject;

	private UndoStack? UndoStack => GroupNameLinkedObject?.UndoStack;

	public GroupSourceType GroupSource
	{
		get
		{
			return GroupNameLinkedObject?.GroupSource ?? GroupSourceType.CurrentSlide;
		}
		set
		{
			OnGroupSourceChanged(value);
		}
	}

	public GroupColorFillLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("GroupSource");
	}

	private void OnGroupSourceChanged(GroupSourceType value)
	{
		UndoStack?.BeginCommit(UndoActionTypes.LinkGroupColor.ToAction());
		foreach (FillLink fillLink in FillLinks)
		{
			if (fillLink.LinkedObject is GroupColorLinkedObject groupColorLinkedObject)
			{
				groupColorLinkedObject.GroupSource = value;
			}
			else
			{
				fillLink.LinkedObject = new GroupColorLinkedObject(value);
			}
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		NotifyPropertyChanges();
	}
}
