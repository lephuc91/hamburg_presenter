using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.PresentationView.PresentationTimeline;
using ProPresenter.UI.Thumbnails;

namespace ProPresenter.UI.FloatingHeaders;

public class PlaylistItemFloatingHeaderControl : FloatingHeaderControl<ProPresenterCue, INotifyEnumerableChanged<ProPresenterCue>, CueType, CueType>
{
	public static readonly DependencyProperty ActivePlaylistItemProperty = DependencyProperty.Register("ActivePlaylistItem", typeof(ProPresenterCue), typeof(PlaylistItemFloatingHeaderControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PlaylistItemFloatingHeaderControl)(object)s).OnActivePlaylistItemChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}));

	public static readonly DependencyProperty ActiveSlideProperty = DependencyProperty.Register("ActiveSlide", typeof(ArrangedCue), typeof(PlaylistItemFloatingHeaderControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PlaylistItemFloatingHeaderControl)(object)s).OnActiveSlideChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ArrangedCue);
	}));

	public static readonly DependencyProperty ViewSettingsProperty = DependencyProperty.Register("ViewSettings", typeof(IPanelViewSettings), typeof(PlaylistItemFloatingHeaderControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((PlaylistItemFloatingHeaderControl)(object)s).OnViewSettingsChanged();
	}));

	public static readonly DependencyProperty CanScrollToCueProperty = DependencyProperty.Register("CanScrollToCue", typeof(bool), typeof(PlaylistItemFloatingHeaderControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty CanScrollToSlideProperty = DependencyProperty.Register("CanScrollToSlide", typeof(bool), typeof(PlaylistItemFloatingHeaderControl), new PropertyMetadata((object)false));

	public ProPresenterCue? ActivePlaylistItem
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(ActivePlaylistItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivePlaylistItemProperty, (object)value);
		}
	}

	public ArrangedCue? ActiveSlide
	{
		get
		{
			return (ArrangedCue)((DependencyObject)this).GetValue(ActiveSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveSlideProperty, (object)value);
		}
	}

	public IPanelViewSettings? ViewSettings
	{
		get
		{
			return (IPanelViewSettings)((DependencyObject)this).GetValue(ViewSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ViewSettingsProperty, (object)value);
		}
	}

	public bool CanScrollToCue
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollToCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollToCueProperty, (object)value);
		}
	}

	public bool CanScrollToSlide
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanScrollToSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanScrollToSlideProperty, (object)value);
		}
	}

	private void OnActivePlaylistItemChanged(ProPresenterCue? cue)
	{
		if (CanScrollToCue)
		{
			ScrollIntoView(cue, 0.0, null, scrollToTop: true);
		}
	}

	private void OnViewSettingsChanged()
	{
		OnActiveSlideChanged(ActiveSlide, preserveLocation: false);
	}

	private void OnActiveSlideChanged(ArrangedCue? cue, bool preserveLocation = true)
	{
		double topOffset = 0.0;
		double? itemHeight = null;
		if (!CanScrollToSlide || (preserveLocation && cue == null))
		{
			return;
		}
		if (cue != null && ActivePlaylistItem != null)
		{
			FrameworkElement itemControl = GetItemControl(ActivePlaylistItem);
			CustomPresentationThumbnailPanel customPresentationThumbnailPanel = (itemControl as CustomPresentationThumbnailPanel) ?? ((DependencyObject)(object)itemControl)?.FindVisualChild<CustomPresentationThumbnailPanel>();
			if (customPresentationThumbnailPanel != null)
			{
				if (customPresentationThumbnailPanel.ViewSettings != ViewSettings)
				{
					customPresentationThumbnailPanel.ViewSettingsChanged += OnPanelSettingsChanged;
					return;
				}
				customPresentationThumbnailPanel.UpdateLayout();
				CalculateOffsets(ActivePlaylistItem, customPresentationThumbnailPanel.GetThumbnailBounds(cue), out topOffset, out var heightOffset);
				itemHeight = heightOffset;
			}
		}
		ScrollIntoView(ActivePlaylistItem, topOffset, itemHeight);
	}

	protected override void OnPostScrollIntoView()
	{
		if (ActivePlaylistItem != null)
		{
			FrameworkElement itemControl = GetItemControl(ActivePlaylistItem);
			((itemControl as CustomPresentationThumbnailPanel) ?? ((DependencyObject)(object)itemControl)?.FindVisualChild<CustomPresentationThumbnailPanel>())?.UpdateActiveItems();
		}
	}

	private void OnPanelSettingsChanged(UniformViewPanel<ArrangedCue, Thumbnail> thumbnailPanel)
	{
		thumbnailPanel.ViewSettingsChanged -= OnPanelSettingsChanged;
		OnViewSettingsChanged();
	}

	protected override CueType GetHeaderKey(ProPresenterCue item)
	{
		return item.Type;
	}

	protected override CueType GetItemKey(ProPresenterCue item)
	{
		return item.Type;
	}

	protected override DataTemplate? FindHeaderTemplate(CueType key)
	{
		return base.HeaderTemplates?.FirstOrDefault((DataTemplate t) => (CueType?)((TaggedDataTemplate)t).Tag == key) ?? null;
	}

	protected override DataTemplate? FindItemTemplate(CueType key)
	{
		return base.ItemTemplates?.FirstOrDefault((DataTemplate t) => (CueType?)((TaggedDataTemplate)t).Tag == key) ?? null;
	}

	internal void UpdatePresentationViewVisibility(ProPresenterCue item, bool hideView)
	{
		ProPresenter.UI.PresentationView.PresentationView presentationView = ((DependencyObject)(object)this).FindVisualChild((ProPresenter.UI.PresentationView.PresentationView view) => view.Cue == item);
		if (presentationView != null)
		{
			presentationView.Visibility = (hideView ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	internal void UpdateMediaViewVisibility(ProPresenterCue item, bool hideView)
	{
		MediaView mediaView = ((DependencyObject)(object)this).FindVisualChild((MediaView m) => m.DataContext == item);
		if (mediaView != null)
		{
			mediaView.Visibility = (hideView ? Visibility.Collapsed : Visibility.Visible);
		}
	}

	protected override bool CanScroll(MouseWheelEventArgs e)
	{
		TimelineScrollBar? timelineScrollBar = e.FindHitElement<TimelineScrollBar>(this);
		if (timelineScrollBar == null)
		{
			return true;
		}
		return !timelineScrollBar.CanScroll();
	}
}
