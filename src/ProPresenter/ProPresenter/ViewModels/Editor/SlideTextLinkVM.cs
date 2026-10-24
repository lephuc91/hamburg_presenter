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

public class SlideTextLinkVM : NotifyPropertyChangedBase, ISlideTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private SlideTextLinkedObject? SlideTextLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as SlideTextLinkedObject;

	private UndoStack? UndoStack => SlideTextLinkedObject?.UndoStack;

	public SlideTargetSourceMode SlideTargetSourceMode => SlideTextLinkedObject?.TargetSourceMode ?? SlideTargetSourceMode.Current;

	public SlideTextSourceMode SlideTextSourceMode
	{
		get
		{
			return SlideTextLinkedObject?.TextSourceMode ?? SlideTextSourceMode.TextOnly;
		}
		set
		{
			UpdateSlideTextLinks(value, PreserveNotesFormat, ElementMatchPattern, UndoActionTypes.LinkSlideText);
		}
	}

	public bool PreserveNotesFormat
	{
		get
		{
			return SlideTextLinkedObject?.PreserveNotesFormat ?? false;
		}
		set
		{
			UpdateSlideTextLinks(SlideTextSourceMode, value, ElementMatchPattern, UndoActionTypes.PreserveNotesFormat);
		}
	}

	public string ElementMatchPattern
	{
		get
		{
			return SlideTextLinkedObject?.ElementMatchPattern ?? string.Empty;
		}
		set
		{
			UpdateSlideTextLinks(SlideTextSourceMode, PreserveNotesFormat, value, UndoActionTypes.LinkElementPattern);
		}
	}

	public SlideTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("SlideTargetSourceMode");
		OnPropertyChanged("SlideTextSourceMode");
		OnPropertyChanged("PreserveNotesFormat");
		OnPropertyChanged("ElementMatchPattern");
	}

	private void UpdateSlideTextLinks(SlideTextSourceMode textSourceMode, bool preserveNotesFormat, string pattern, UndoActionTypes undoActionType)
	{
		UndoStack?.BeginCommit(undoActionType.ToAction());
		foreach (TextLink textLink in TextLinks)
		{
			if (textLink.LinkedObject is SlideTextLinkedObject slideTextLinkedObject)
			{
				slideTextLinkedObject.TextSourceMode = textSourceMode;
				slideTextLinkedObject.PreserveNotesFormat = preserveNotesFormat;
				slideTextLinkedObject.ElementMatchPattern = pattern;
			}
			else
			{
				textLink.LinkedObject = new SlideTextLinkedObject(SlideTargetSourceMode, textSourceMode, preserveNotesFormat, pattern);
			}
		}
		NotifyPropertyChanges();
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}
}
