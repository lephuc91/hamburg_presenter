using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.UI.FloatingHeaders;
using ProPresenter.UI.Theming;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.PresentationView;

public partial class PresentationView : UserControl, IVirtualizableControl, IComponentConnector
{
	private readonly Dictionary<OutputDestination, ProPresenterCue> _triggeredCueSource = new Dictionary<OutputDestination, ProPresenterCue>();

	public static readonly DependencyProperty PresentationVMProperty = DependencyProperty.Register("PresentationVM", typeof(IPresentationVM), typeof(PresentationView), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PresentationView)(object)s).OnPresentationVMChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as IPresentationVM, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IPresentationVM);
	}));

	public static readonly DependencyProperty CueProperty = DependencyProperty.Register("Cue", typeof(ProPresenterCue), typeof(PresentationView), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(CueChangedCallback)));

	public static readonly DependencyProperty ThumbnailContextMenuProperty = DependencyProperty.Register("ThumbnailContextMenu", typeof(ContextMenu), typeof(PresentationView));

	private static readonly DependencyProperty DocumentCueProperty = DependencyProperty.Register("DocumentCue", typeof(IDocumentCue), typeof(PresentationView));

	public IPresentationVM? PresentationVM
	{
		get
		{
			return (IPresentationVM)((DependencyObject)this).GetValue(PresentationVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PresentationVMProperty, (object)value);
		}
	}

	public ProPresenterCue? Cue
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(CueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CueProperty, (object)value);
		}
	}

	public ContextMenu ThumbnailContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(ThumbnailContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThumbnailContextMenuProperty, (object)value);
		}
	}

	public bool InView
	{
		get
		{
			return thumbnailPanel.InView;
		}
		set
		{
			thumbnailPanel.InView = value;
			thumbnailPanel.InvalidateArrange();
		}
	}

	public Rect<double> Viewport
	{
		get
		{
			return thumbnailPanel.Viewport;
		}
		set
		{
			thumbnailPanel.Viewport = value;
			thumbnailPanel.InvalidateArrange();
		}
	}

	private IDocumentCue DocumentCue
	{
		get
		{
			return (IDocumentCue)((DependencyObject)this).GetValue(DocumentCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentCueProperty, (object)value);
		}
	}

	private static void CueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PresentationView)(object)d).OnCueChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}

	public PresentationView()
	{
		InitializeComponent();
		thumbnailPanel.InvalidateParentMeasure += delegate
		{
			if (base.Parent is UIElement uIElement)
			{
				PlaylistItemFloatingHeaderControl playlistItemFloatingHeaderControl = ((DependencyObject)(object)uIElement).FindVisualParent<PlaylistItemFloatingHeaderControl>();
				if (playlistItemFloatingHeaderControl != null)
				{
					playlistItemFloatingHeaderControl.InvalidateMeasure();
				}
				else
				{
					uIElement.InvalidateMeasure();
				}
			}
		};
		thumbnailPanel.GetSlideActiveBrush = (ArrangedCue i) => CheckBrushByContentDestination(i, (Brush)AppTheme.Active.THUMBNAILPRESENTATION, (Brush)AppTheme.Active.THUMBNAILANNOUNCEMENT);
		thumbnailPanel.GetSlideActiveListBrush = (ArrangedCue i) => CheckBrushByContentDestination(i, (Brush)AppTheme.Active.THUMBNAILLISTPRESENTATION, (Brush)AppTheme.Active.THUMBNAILLISTANNOUNCEMENT);
		thumbnailPanel.GetSlideActiveBorderBrush = (ArrangedCue i) => CheckBrushByContentDestination(i, (Brush)AppTheme.Active.THUMBNAILPRESENTATIONBORDER, (Brush)AppTheme.Active.THUMBNAILANNOUNCEMENTBORDER);
		thumbnailPanel.SelectItemPredicate = (ArrangedCue i) => PresentationVM != null && PresentationVM.SelectedSlides.Contains(i) && Cue == PresentationVM.ActivePlaylistItem;
		thumbnailPanel.ActiveItemPredicate = (ArrangedCue i) => PresentationVM != null && (PresentationVM.ActiveSlides[OutputDestination.Presentation] == i || PresentationVM.ActiveSlides[OutputDestination.Announcement] == i) && Cue != null && _triggeredCueSource.ContainsValue(Cue);
		thumbnailPanel.IsPanelActivePredicate = (ArrangedCue i) => Cue != null && _triggeredCueSource.ContainsValue(Cue);
	}

	private Brush CheckBrushByContentDestination(ArrangedCue arrangedCue, Brush presentation, Brush announcement)
	{
		ArrangedCue arrangedCue2 = PresentationVM?.ActiveSlides[OutputDestination.Presentation];
		ArrangedCue arrangedCue3 = PresentationVM?.ActiveSlides[OutputDestination.Announcement];
		if (arrangedCue2 != null && arrangedCue2 == arrangedCue)
		{
			return presentation;
		}
		if (arrangedCue3 != null && arrangedCue3 == arrangedCue)
		{
			return announcement;
		}
		return Brushes.Transparent;
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		base.OnMouseDown(e);
		if (PresentationVM != null && Cue != null)
		{
			PresentationVM.ActivePlaylistItem = Cue;
		}
	}

	private void OnPresentationVMChanged(IPresentationVM? oldValue, IPresentationVM? newValue)
	{
		if (oldValue != null)
		{
			oldValue.SlideTriggered -= OnSlideTriggered;
			oldValue.SlideCleared -= OnSlideCleared;
			oldValue.PropertyChanged -= OnPresentationPropertyChanged;
		}
		if (newValue != null)
		{
			newValue.SlideTriggered += OnSlideTriggered;
			newValue.SlideCleared += OnSlideCleared;
			newValue.PropertyChanged += OnPresentationPropertyChanged;
		}
	}

	private void OnPresentationPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveSlides")
		{
			InvalidateVisual();
		}
	}

	private void OnSlideTriggered(ArrangedCue slide, int buildIndex, OutputDestination destination)
	{
		if (PresentationVM?.ActiveSlideParent is IDocumentCue { DocumentAction: not null } documentCue)
		{
			_triggeredCueSource[documentCue.DocumentAction.Destination] = PresentationVM.ActiveSlideParent;
		}
		thumbnailPanel.UpdateActiveItems();
	}

	private void OnSlideCleared(OutputDestination _)
	{
		thumbnailPanel.UpdateActiveItems();
	}

	private void OnCueChanged(ProPresenterCue? cue)
	{
		if (cue == null)
		{
			((DependencyObject)this).SetCurrentValue(DocumentCueProperty, (object)null);
		}
		else if (cue is IDocumentCue source)
		{
			SetBinding(DocumentCueProperty, new Binding
			{
				Source = source
			});
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
