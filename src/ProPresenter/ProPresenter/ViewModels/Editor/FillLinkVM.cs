using System;
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
using Pro.Entity;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Links;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class FillLinkVM : NotifyPropertyChangedBase, IFillLinkVM, INotifyPropertyChanged
{
	private readonly ObservableCollection<ICanvasElement> _selectedCanvasElements;

	private CustomSlide? _selectedSlide;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedCanvasElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => SelectedSlide?.UndoStack;

	public IElementFillLinkVM ElementFillLinkVM { get; }

	public IOutputScreenLinkVM OutputScreenLinkVM { get; }

	public ISlideImageLinkVM SlideImageLinkVM { get; }

	public IPCOLinkVM PCOLinkVM { get; }

	public IGroupColorFillLinkVM GroupColorFillLinkVM { get; }

	public ISlideLabelColorFillLinkVM SlideLabelColorFillLinkVM { get; }

	public IPlaybackMarkerLinkVM PlaybackMarkerColorFillLinkVM { get; }

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
				ElementFillLinkVM.SelectedSlide = n;
			});
		}
	}

	public EditMode EditMode { get; set; }

	public LinkedFillType LinkedFillType
	{
		get
		{
			return FirstElement?.FillLink.LinkedObject?.LinkedFillType ?? LinkedFillType.None;
		}
		set
		{
			ClosedBezierPath? firstElement = FirstElement;
			if (firstElement != null && firstElement.FillLink.LinkedObject?.LinkedFillType == value)
			{
				return;
			}
			UndoStack?.BeginCommit(UndoActionTypes.LinkFillObject.ToAction());
			if (value != LinkedFillType.None)
			{
				SelectedElements.Where(delegate(ClosedBezierPath e)
				{
					ILinkedFillObject? linkedObject = e.FillLink.LinkedObject;
					return linkedObject == null || linkedObject.LinkedFillType != value;
				}).ForEach(delegate(ClosedBezierPath e)
				{
					e.FillLink.LinkedObject = GenerateLinkedObject(value);
					e.Fill = new SolidColorFill
					{
						Color = Colors.Transparent
					};
				});
			}
			OnPropertyChanged("LinkedFillType");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public ICommand<LinkedFillType> SetLinkedFillCommand => new RelayCommand<LinkedFillType>(delegate(LinkedFillType l)
	{
		LinkedFillType = l;
	});

	public FillLinkVM(IEntityFactory entityFactory, ObservableCollection<ICanvasElement> selectedCanvasElements)
	{
		_selectedCanvasElements = selectedCanvasElements;
		_selectedCanvasElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
			{
				p.FillLink.LinkObjectUpdated -= NotifyPropertyChanges;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
			{
				p.FillLink.LinkObjectUpdated += NotifyPropertyChanges;
			});
			NotifyPropertyChanges();
		};
		ElementFillLinkVM = new ElementFillLinkVM(selectedCanvasElements);
		OutputScreenLinkVM = new OutputScreenLinkVM(selectedCanvasElements);
		SlideImageLinkVM = new SlideImageLinkVM(selectedCanvasElements);
		PCOLinkVM = new PCOLinkVM(selectedCanvasElements);
		GroupColorFillLinkVM = new GroupColorFillLinkVM(selectedCanvasElements);
		SlideLabelColorFillLinkVM = new SlideLabelColorFillLinkVM(selectedCanvasElements);
		PlaybackMarkerColorFillLinkVM = new PlaybackMarkerColorFillLinkVM(selectedCanvasElements);
	}

	private ILinkedFillObject GenerateLinkedObject(LinkedFillType type)
	{
		return type switch
		{
			LinkedFillType.ChordChart => new ChordChartLinkedObject(), 
			LinkedFillType.Element => new ElementLinkedFillObject(), 
			LinkedFillType.PreviewScreen => new OutputScreenLinkedObject(OutputVault.AudienceScreenArrangementCollection?.FirstOrDefault()), 
			LinkedFillType.PCOLive => new PCOLiveLinkedObject(), 
			LinkedFillType.SlidePreview => new SlideImageLinkedObject(SlideTargetSourceMode.Current), 
			LinkedFillType.GroupColor => new GroupColorLinkedObject(), 
			LinkedFillType.SlideLabelColor => new SlideLabelColorLinkedObject(), 
			LinkedFillType.CaptureStatusColor => new CaptureStatusColorLinkedObject(), 
			LinkedFillType.PlaybackMarkerColor => new PlaybackMarkerColorLinkedObject(), 
			LinkedFillType.TimecodeStatusColor => new TimecodeStatusColorLinkedObject(), 
			_ => throw new NotSupportedException("Unknown linked object type"), 
		};
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("LinkedFillType");
	}
}
