using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using ProPresenter.DO.PanelSourcing;

namespace ProPresenter.UI.Thumbnails;

public abstract class ThumbnailPanel<TSource> : UniformViewPanel<TSource, Thumbnail> where TSource : class, IThumbnailSource
{
	public static readonly DependencyProperty HideBackgroundImageProperty = DependencyProperty.Register("HideBackgroundImage", typeof(bool), typeof(ThumbnailPanel<TSource>), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(HideBackgroundImagePropertyChanged)));

	public bool HideBackgroundImage
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideBackgroundImageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideBackgroundImageProperty, (object)value);
		}
	}

	private static void HideBackgroundImagePropertyChanged(DependencyObject callerObject, DependencyPropertyChangedEventArgs e)
	{
		((ThumbnailPanel<TSource>)(object)callerObject).UpdateBackgroundVisibility();
	}

	private void UpdateBackgroundVisibility()
	{
		base.Thumbnails.Where((UniformViewPanel<TSource, Thumbnail>.ThumbnailData t) => t.HasControl).ForEach(delegate(UniformViewPanel<TSource, Thumbnail>.ThumbnailData t)
		{
			t.Control.HideBackgroundImage = HideBackgroundImage;
		});
	}

	protected override void OnUpdateActiveItem(ThumbnailData thumbnail)
	{
		if (thumbnail.Control != null)
		{
			thumbnail.Control.ActiveBrush = GetActiveBrush(thumbnail.Source);
			thumbnail.Control.ActiveListBrush = GetActiveListBrush(thumbnail.Source);
			thumbnail.Control.ActiveBorderBrush = GetActiveBorderBrush(thumbnail.Source);
			thumbnail.Control.IsActive = CanActivate(thumbnail.Source);
			thumbnail.Control.WasActive = WasActive(thumbnail.Control);
		}
		base.OnUpdateActiveItem(thumbnail);
	}

	protected override void OnSetupThumbnailControl(Thumbnail thumbnailControl, TSource item)
	{
		base.OnSetupThumbnailControl(thumbnailControl, item);
		thumbnailControl.SetUIDelegates(base.OnThumbnailClicked, OnThumbnailDragged, base.OnThumbnailMenuOpening);
		thumbnailControl.SetRenderingDelegates(delegate(IThumbnailSource t, Vector2<int> s, Action<IThumbnailSource, IBitmapHandle?> c)
		{
			RenderThumbnailPreview((TSource)t, s, c);
		}, delegate(IThumbnailSource t, Vector2<int> s, Action<IThumbnailSource, IBitmapHandle?> c)
		{
			RenderBackgroundContent((TSource)t, s, c);
		}, (IThumbnailSource t, Color? c) => GetItemBackgroundColor((TSource)t, c), (IThumbnailSource t, Color? c) => GetItemPreviewColor((TSource)t, c), (IThumbnailSource t) => GetItemContent((TSource)t), (IThumbnailSource t) => GetItemSecondaryContent((TSource)t), (IThumbnailSource t) => GetItemSecondaryContentLabel((TSource)t));
		thumbnailControl.ViewSettings = base.ViewSettings;
		thumbnailControl.ContextMenu = base.ThumbnailContextMenu;
		thumbnailControl.ActiveBrush = GetActiveBrush(item);
		thumbnailControl.ActiveListBrush = GetActiveListBrush(item);
		thumbnailControl.ActiveBorderBrush = GetActiveBorderBrush(item);
		thumbnailControl.HideBackgroundImage = HideBackgroundImage;
		thumbnailControl.DisplayMode = base.DisplayMode;
		thumbnailControl.IsSelected = CanSelect(item);
		thumbnailControl.IsActive = CanActivate(item);
		thumbnailControl.WasActive = WasActive(thumbnailControl);
		thumbnailControl.ShowIndex = base.ShowIndex;
	}

	protected void RenderThumbnailPreview(TSource source, Vector2<int> size, Action<TSource, IBitmapHandle> completedCallback)
	{
		OnRenderThumbnailPreview(source, size, completedCallback);
	}

	protected abstract void OnRenderThumbnailPreview(TSource cue, Vector2<int> size, Action<TSource, IBitmapHandle> completedCallback);

	protected void RenderBackgroundContent(TSource source, Vector2<int> size, Action<TSource, IBitmapHandle?> completedCallback)
	{
		OnRenderBackgroundContent(source, size, completedCallback);
	}

	protected virtual void OnRenderBackgroundContent(TSource cue, Vector2<int> size, Action<TSource, IBitmapHandle?> completedCallback)
	{
	}

	protected Color GetItemBackgroundColor(TSource source, Color? settingsColor)
	{
		return OnGetItemBackgroundColor(source, settingsColor);
	}

	protected virtual Color OnGetItemBackgroundColor(TSource source, Color? settingsColor)
	{
		return settingsColor ?? Colors.Black;
	}

	private Color GetItemPreviewColor(TSource source, Color? settingsColor)
	{
		return OnGetItemPreviewColor(source, settingsColor);
	}

	protected virtual Color OnGetItemPreviewColor(TSource source, Color? settingsColor)
	{
		return settingsColor ?? Colors.Black;
	}

	protected string GetItemContent(TSource source)
	{
		return OnGetItemContent(source);
	}

	protected virtual string OnGetItemContent(TSource source)
	{
		return string.Empty;
	}

	protected string GetItemSecondaryContent(TSource source)
	{
		return OnGetItemSecondaryContent(source);
	}

	protected virtual string OnGetItemSecondaryContent(TSource source)
	{
		return string.Empty;
	}

	protected string GetItemSecondaryContentLabel(TSource source)
	{
		return OnGetItemSecondaryContentLabel(source);
	}

	protected virtual string OnGetItemSecondaryContentLabel(TSource source)
	{
		return string.Empty;
	}

	protected virtual Brush GetActiveBrush(TSource item)
	{
		return base.ActiveBrush ?? Brushes.Transparent;
	}

	protected virtual Brush GetActiveListBrush(TSource item)
	{
		return base.ActiveListBrush ?? Brushes.Transparent;
	}

	protected virtual Brush GetActiveBorderBrush(TSource item)
	{
		return base.ActiveBorderBrush ?? Brushes.Transparent;
	}

	protected bool WasActive(Thumbnail thumbnail)
	{
		if (!thumbnail.IsActive && base.WasActiveItem != null && thumbnail.Source == base.WasActiveItem && IsPanelActive((TSource)thumbnail.Source))
		{
			if (base.ActiveItems != null)
			{
				return base.ActiveItems.Any();
			}
			return true;
		}
		return false;
	}
}
