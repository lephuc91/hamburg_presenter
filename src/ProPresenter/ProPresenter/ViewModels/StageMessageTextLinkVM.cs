using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class StageMessageTextLinkVM : NotifyPropertyChangedBase, IStageMessageTextLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private IEnumerable<TextLink> TextLinks => SelectedElements.Select((ClosedBezierPath e) => e.TextLink);

	private StageMessageLinkedObject? StageMessageLinkedObject => TextLinks.FirstOrDefault()?.LinkedObject as StageMessageLinkedObject;

	private UndoStack? UndoStack => StageMessageLinkedObject?.UndoStack;

	public bool ShouldFlash
	{
		get
		{
			return StageMessageLinkedObject?.ShouldFlash ?? false;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.StageMessageShouldFlash));
			UpdateStageMessageTextLinks(value, FlashColor);
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public Color FlashColor
	{
		get
		{
			return StageMessageLinkedObject?.FlashColor ?? Colors.Green;
		}
		set
		{
			UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.StageMessageFlashColor));
			UpdateStageMessageTextLinks(ShouldFlash, value);
			UndoStack?.EndCommit();
		}
	}

	public StageMessageTextLinkVM(ObservableCollection<ICanvasElement> selectedElements)
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
		OnPropertyChanged("ShouldFlash");
		OnPropertyChanged("FlashColor");
	}

	private void UpdateStageMessageTextLinks(bool shouldFlash, Color flashColor)
	{
		foreach (TextLink textLink in TextLinks)
		{
			ILinkedTextObject? linkedObject = textLink.LinkedObject;
			if (linkedObject != null && linkedObject.LinkedTextType == LinkedTextType.StageMessage)
			{
				StageMessageLinkedObject obj = (StageMessageLinkedObject)textLink.LinkedObject;
				obj.ShouldFlash = shouldFlash;
				obj.FlashColor = flashColor;
			}
			else
			{
				textLink.LinkedObject = new StageMessageLinkedObject
				{
					ShouldFlash = shouldFlash,
					FlashColor = flashColor
				};
			}
		}
		NotifyPropertyChanges();
	}
}
