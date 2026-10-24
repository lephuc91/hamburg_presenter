using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class ElementFillLinkVM : NotifyPropertyChangedBase, IElementFillLinkVM
{
	private readonly ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private CustomSlide? _selectedSlide;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedCanvasElements.OfType<ClosedBezierPath>();

	public ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => SelectedSlide?.UndoStack;

	public IEnumerable<ClosedBezierPath>? LinkableElements => SelectedSlide?.Elements.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
	{
		ILinkedFillObject? linkedObject = e.FillLink.LinkedObject;
		return linkedObject == null || linkedObject.LinkedFillType != LinkedFillType.Element;
	});

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue<CustomSlide>("SelectedSlide", ref _selectedSlide, value, delegate(CustomSlide o, CustomSlide n)
			{
				if (o != null)
				{
					o.Elements.CollectionChanged -= SlideElementCollectionChanged;
					o.Elements.ForEach(delegate(SlideElementBase e)
					{
						e.PropertyChanged -= ElementPropertyChanged;
					});
				}
				if (n != null)
				{
					n.Elements.CollectionChanged += SlideElementCollectionChanged;
					n.Elements.ForEach(delegate(SlideElementBase e)
					{
						e.PropertyChanged += ElementPropertyChanged;
					});
				}
			});
		}
	}

	public ClosedBezierPath? LinkedElement
	{
		get
		{
			return (FirstElement?.FillLink.LinkedObject as ElementLinkedFillObject)?.Element;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.LinkElement.ToAction());
			foreach (FillLink item in SelectedElements.Select((ClosedBezierPath e) => e.FillLink))
			{
				ILinkedFillObject? linkedObject = item.LinkedObject;
				if (linkedObject != null && linkedObject.LinkedFillType == LinkedFillType.Element)
				{
					((ElementLinkedFillObject)item.LinkedObject).Element = value;
				}
				else
				{
					item.LinkedObject = new ElementLinkedFillObject(value);
				}
			}
			OnPropertyChanged("LinkedElement");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public ICommand<ClosedBezierPath> SelectElementCommand => new RelayCommand<ClosedBezierPath>(delegate(ClosedBezierPath p)
	{
		LinkedElement = p;
	}, (ClosedBezierPath p) => LinkableElements?.Any() ?? false);

	public ElementFillLinkVM(ObservableCollection<ICanvasElement> selectedCanvasElements)
	{
		_selectedCanvasElements = selectedCanvasElements;
		_selectedCanvasElements.CollectionChanged += delegate
		{
			NotifyPropertyChanges();
		};
	}

	private void SlideElementCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
		{
			p.PropertyChanged -= ElementPropertyChanged;
		});
		e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
		{
			p.PropertyChanged += ElementPropertyChanged;
		});
		NotifyPropertyChanges();
	}

	private void ElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Fill")
		{
			NotifyPropertyChanges();
		}
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("LinkableElements");
		OnPropertyChanged("LinkedElement");
	}
}
