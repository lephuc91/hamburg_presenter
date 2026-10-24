using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;
using ProPresenter.UI.ErrorHandling;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Thumbnails;

public class PresentationThumbnailPanel : DragDropCommandThumbnailPanel<ArrangedCue, IPresentation>
{
	private const double HeaderFontSize = 20.0;

	private const double HeaderHorizontalMargin = 7.0;

	private const double HeaderVerticalMargin = 4.0;

	private static readonly Color FallbackColor = (Color)AppTheme.Active.THUMBNAILGRADIENTEND_COLOR;

	private readonly ModificationWhileEnumerationReportingDictionary<CueGroup, TextBlock> _labels = new ModificationWhileEnumerationReportingDictionary<CueGroup, TextBlock>();

	internal Predicate<ArrangedCue>? SelectItemPredicate { get; set; }

	internal Predicate<ArrangedCue>? ActiveItemPredicate { get; set; }

	internal Predicate<ArrangedCue>? IsPanelActivePredicate { get; set; }

	internal Func<ArrangedCue, Brush>? GetSlideActiveBrush { get; set; }

	internal Func<ArrangedCue, Brush>? GetSlideActiveListBrush { get; set; }

	internal Func<ArrangedCue, Brush>? GetSlideActiveBorderBrush { get; set; }

	protected override IDragDropCollection<ArrangedCue> SourceCollection => this;

	public PresentationThumbnailPanel()
	{
		AddDropType(null, (DraggedItems<ArrangedCue> i, DragEventArgs e) => true);
	}

	protected override Brush GetActiveBrush(ArrangedCue item)
	{
		return GetSlideActiveBrush?.Invoke(item) ?? base.GetActiveBrush(item);
	}

	protected override Brush GetActiveListBrush(ArrangedCue item)
	{
		return GetSlideActiveListBrush?.Invoke(item) ?? base.GetActiveListBrush(item);
	}

	protected override Brush GetActiveBorderBrush(ArrangedCue item)
	{
		return GetSlideActiveBorderBrush?.Invoke(item) ?? base.GetActiveBorderBrush(item);
	}

	protected override bool CanSelect(ArrangedCue item)
	{
		return SelectItemPredicate?.Invoke(item) ?? base.CanSelect(item);
	}

	protected override bool CanActivate(ArrangedCue item)
	{
		return ActiveItemPredicate?.Invoke(item) ?? base.CanActivate(item);
	}

	protected override bool IsPanelActive(ArrangedCue item)
	{
		return IsPanelActivePredicate?.Invoke(item) ?? base.IsPanelActive(item);
	}

	protected override void OnRenderThumbnailPreview(ArrangedCue cue, Vector2<int> size, Action<ArrangedCue, IBitmapHandle> completedCallback)
	{
		if (!(cue.Source.SlideAction?.Slide is CustomSlide slide))
		{
			return;
		}
		SlidePreviewRenderParams renderParams = new SlidePreviewRenderParams(size, IncludeBackground: false, IncludeBackgroundMedia: false, cue.Source.ParentPresentation?.BackgroundColor ?? Colors.Transparent);
		if (SlidePreviewRenderer.TryGetBitmap(slide, renderParams, out CachedBitmapHandle bitmap))
		{
			completedCallback(cue, bitmap);
			return;
		}
		SlidePreviewRenderer.RenderSlidePreviewDeferred(slide, renderParams, delegate(CustomSlide s, IBitmapHandle b)
		{
			completedCallback(cue, b);
		});
	}

	protected override Color OnGetItemBackgroundColor(ArrangedCue source, Color? settingsColor)
	{
		return settingsColor ?? Colors.Transparent;
	}

	protected override Color OnGetItemPreviewColor(ArrangedCue cue, Color? settingsColor)
	{
		if (base.ViewSettings == null || cue == null || Advanced.Settings.IgnoreBackgroundColors || (base.ViewSettings.ViewType == PanelViewType.EasyView && !base.ViewSettings.ShowMediaActions))
		{
			return Colors.Transparent;
		}
		SlideBase slideBase = cue.Source.SlideAction?.Slide;
		IPresentation parentPresentation = cue.Source.ParentPresentation;
		bool includeBackground = cue.Source.GetIncludeBackground();
		if (settingsColor.HasValue)
		{
			return settingsColor.Value;
		}
		if (includeBackground)
		{
			if (slideBase == null || !slideBase.UseBackgroundColor)
			{
				if (parentPresentation == null || !parentPresentation.UseBackgroundColor)
				{
					return Colors.Transparent;
				}
				return parentPresentation.BackgroundColor;
			}
			return slideBase.BackgroundColor;
		}
		return Colors.Transparent;
	}

	protected override void ShowDropIndicator(AdornerPosition dropPosition)
	{
		if (base.TargetItem != null && !base.DroppedOutside && IsGroupAdornerVisible(base.TargetItem, dropPosition))
		{
			base.TargetThumbnail?.AddAdorner(new SlideGroupPointer(base.TargetThumbnail, (base.TargetItem.BackgroundColor == Colors.Transparent) ? FallbackColor : base.TargetItem.BackgroundColor, dropPosition));
		}
		else
		{
			base.ShowDropIndicator(dropPosition);
		}
	}

	protected virtual bool IsGroupAdornerVisible(ArrangedCue slide, AdornerPosition adornerPosition)
	{
		if (base.InDeadSpace)
		{
			return false;
		}
		bool num = slide.Group.Cues.First() == slide.Source;
		bool flag = slide.Group.Cues.Last() == slide.Source;
		if (!num || (adornerPosition != 0 && adornerPosition != AdornerPosition.Top))
		{
			if (flag)
			{
				if (adornerPosition != AdornerPosition.Right)
				{
					return adornerPosition == AdornerPosition.Bottom;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	protected override double OnMeasureHeight(IEnumerable<ThumbnailData> thumbnails, double availableWidth)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		IPanelViewSettings? viewSettings = base.ViewSettings;
		if (viewSettings != null && viewSettings.ByGroups)
		{
			double num = 0.0;
			KeyValuePair<CueGroup, TextBlock>[] array = _labels.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				KeyValuePair<CueGroup, TextBlock> label = array[i];
				TextBlock value = label.Value;
				value.Measure(new Vector2<double>(double.PositiveInfinity, double.PositiveInfinity));
				double num2 = num;
				Size desiredSize = value.DesiredSize;
				num = num2 + ((Size)(ref desiredSize)).Height;
				num += MeasureThumbnailVerticalExtent(thumbnails.Where((UniformViewPanel<ArrangedCue, Thumbnail>.ThumbnailData t) => t.Source.Group == label.Key), availableWidth);
			}
			return num;
		}
		return base.OnMeasureHeight(thumbnails, availableWidth);
	}

	protected override void OnArrangeThumbnails(IEnumerable<ThumbnailData> thumbnails)
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		IPanelViewSettings? viewSettings = base.ViewSettings;
		if (viewSettings != null && viewSettings.ByGroups)
		{
			Vector2<double> vector = -base.Viewport.Position;
			{
				foreach (UniformViewPanel<ArrangedCue, Thumbnail>.ThumbnailData[] item in thumbnails.ContiguousGroups((UniformViewPanel<ArrangedCue, Thumbnail>.ThumbnailData l, UniformViewPanel<ArrangedCue, Thumbnail>.ThumbnailData r) => l.Source.Group == r.Source.Group))
				{
					CueGroup group = item.First().Source.Group;
					TextBlock textBlock = _labels[group];
					textBlock.Arrange(new Rect((Point)vector, textBlock.DesiredSize));
					double y = vector.Y;
					Size desiredSize = textBlock.DesiredSize;
					vector.Y = y + ((Size)(ref desiredSize)).Height;
					vector.Y += ArrangeThumbnails(item, vector);
				}
				return;
			}
		}
		base.OnArrangeThumbnails(thumbnails);
	}

	protected override void OnItemInserted(int index, ArrangedCue item)
	{
		if (!_labels.ContainsKey(item.Group))
		{
			TextBlock textBlock = new TextBlock();
			textBlock.Text = GetArrangementGroupText(item.Group);
			textBlock.FontSize = 20.0;
			IPanelViewSettings? viewSettings = base.ViewSettings;
			textBlock.Visibility = ((viewSettings == null || !viewSettings.ByGroups) ? Visibility.Collapsed : Visibility.Visible);
			textBlock.Margin = new Thickness(7.0, 4.0, 7.0, 4.0);
			textBlock.Foreground = AppTheme.Active.PANELCONTENT;
			TextBlock textBlock2 = textBlock;
			textBlock2.SetBinding(TextBlock.ForegroundProperty, new Binding("PANELCONTENT")
			{
				Source = AppTheme.Active
			});
			_labels.Add(item.Group, textBlock2);
			AddChild(textBlock2);
			item.Group.PropertyChanged += ArrangementGroup_PropertyChanged;
		}
	}

	protected override void OnItemRemoved(ArrangedCue item)
	{
		IEnumerable<ArrangedCue>? items = base.Items;
		if ((items == null || !items.Any((ArrangedCue i) => i != item && i.Group == item.Group)) && _labels.TryGetValue(item.Group, out TextBlock value))
		{
			item.Group.PropertyChanged -= ArrangementGroup_PropertyChanged;
			_labels.Remove(item.Group);
			RemoveChild(value);
		}
	}

	protected override void OnMoveTo(IEnumerable<ArrangedCue> items, int index)
	{
		if (base.ActiveItem != null && items.Contains<ArrangedCue>(base.ActiveItem))
		{
			ReloadActiveItems(base.ActiveItems, new ArrangedCue[1] { items.First((ArrangedCue i) => i.Source == base.ActiveItem.Source) });
		}
	}

	protected override void OnRenderBackgroundContent(ArrangedCue cue, Vector2<int> size, Action<ArrangedCue, IBitmapHandle?> completedCallback)
	{
		base.OnRenderBackgroundContent(cue, size, completedCallback);
		if (cue != null)
		{
			IBitmapHandle arg = (cue.Source.GetPreviewMedia() as IDrawMedia)?.Drawing.PreviewImage?.ToBitmapHandle();
			completedCallback(cue, arg);
		}
	}

	private void ArrangementGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (sender is CueGroup cueGroup && e.PropertyName == "Label")
		{
			_labels[cueGroup].Text = GetArrangementGroupText(cueGroup);
		}
	}

	private static string GetArrangementGroupText(CueGroup group)
	{
		return group.Label.Text;
	}

	private void UpdateLabelsVisibility(bool isGroupingEnabled)
	{
		_labels.Values.ForEach(delegate(TextBlock t)
		{
			t.Visibility = ((!isGroupingEnabled) ? Visibility.Collapsed : Visibility.Visible);
		});
		InvalidateMeasure();
		InvalidateArrange();
	}

	protected override void UpdateViewSettings(IPanelViewSettings oldSettings, IPanelViewSettings newSettings)
	{
		base.UpdateViewSettings(oldSettings, newSettings);
		if (oldSettings != null)
		{
			oldSettings.PropertyChanged -= ViewSettings_PropertyChanged;
		}
		if (newSettings != null)
		{
			newSettings.PropertyChanged += ViewSettings_PropertyChanged;
		}
		UpdateLabelsVisibility(base.ViewSettings?.ByGroups ?? false);
	}

	private void ViewSettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ByGroups")
		{
			UpdateLabelsVisibility(base.ViewSettings?.ByGroups ?? false);
		}
	}
}
