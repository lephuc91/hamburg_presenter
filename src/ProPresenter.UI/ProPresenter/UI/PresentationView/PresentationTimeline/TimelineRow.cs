using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Operations;
using Pro.Common.Time;
using Pro.UI.Commands;
using Pro.UI.Utility;
using ProPresenter.UI.Controls;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

[TemplatePart(Name = "PART_SectionsContainer", Type = typeof(ItemsControl))]
[StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(TimelineSection))]
public class TimelineRow : ItemsControl
{
	private const string PART_ITEM_CONTAINER_STYLE = "ItemContainerStyle";

	private const string PART_SECTIONS_CONTAINER = "PART_SectionsContainer";

	private readonly List<ITimelineItemVM> _cachedRowItems = new List<ITimelineItemVM>();

	private static readonly DependencyPropertyKey _currentTimePropertyKey;

	private static readonly DependencyPropertyKey _hasGroupsPropertyKey;

	private static readonly DependencyPropertyKey _pixelStridePropertyKey;

	private static readonly DependencyPropertyKey _selectedItemsPropertyKey;

	public static readonly DependencyProperty AllowDrawPastBoundsProperty;

	public static readonly DependencyProperty AllowFillProperty;

	public static readonly DependencyProperty AllowGroupingProperty;

	public static readonly DependencyProperty CurrentTimeProperty;

	public static readonly DependencyProperty DurationProperty;

	public static readonly DependencyProperty GroupsProperty;

	public static readonly DependencyProperty HasGroupsProperty;

	public static readonly DependencyProperty IconProperty;

	public static readonly DependencyProperty PixelStrideProperty;

	public static readonly DependencyProperty SelectedItemsProperty;

	public static readonly DependencyProperty VisibleDurationProperty;

	public static readonly DependencyProperty VisibleDurationStartProperty;

	public bool AllowDrawPastBounds
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowDrawPastBoundsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowDrawPastBoundsProperty, (object)value);
		}
	}

	public bool AllowFill
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowFillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowFillProperty, (object)value);
		}
	}

	public bool AllowGrouping
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowGroupingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowGroupingProperty, (object)value);
		}
	}

	public TimeSlice CurrentTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(CurrentTimeProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_currentTimePropertyKey, (object)value);
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(DurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DurationProperty, (object)value);
		}
	}

	public ObservableCollection<TimelineSectionGroup>? Groups
	{
		get
		{
			return (ObservableCollection<TimelineSectionGroup>)((DependencyObject)this).GetValue(GroupsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GroupsProperty, (object)value);
		}
	}

	public bool HasGroups
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HasGroupsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_hasGroupsPropertyKey, (object)value);
		}
	}

	public DrawingImage Icon
	{
		get
		{
			return (DrawingImage)((DependencyObject)this).GetValue(IconProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconProperty, (object)value);
		}
	}

	public double PixelStride
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PixelStrideProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_pixelStridePropertyKey, (object)value);
		}
	}

	public ObservableCollection<ITimelineItemVM>? SelectedItems
	{
		get
		{
			return (ObservableCollection<ITimelineItemVM>)((DependencyObject)this).GetValue(SelectedItemsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_selectedItemsPropertyKey, (object)value);
		}
	}

	public TimeSlice VisibleDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(VisibleDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisibleDurationProperty, (object)value);
		}
	}

	public TimeSlice VisibleDurationStart
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(VisibleDurationStartProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisibleDurationStartProperty, (object)value);
		}
	}

	public event Action<RowClickedData>? Clicked;

	public event Action<ITimelineItemVM>? ItemDoubleClicked;

	public event Action<TimeSlice>? StartTimeChanged;

	static TimelineRow()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		_currentTimePropertyKey = DependencyProperty.RegisterReadOnly("CurrentTime", typeof(TimeSlice), typeof(TimelineRow), new PropertyMetadata());
		_hasGroupsPropertyKey = DependencyProperty.RegisterReadOnly("HasGroups", typeof(bool), typeof(TimelineRow), new PropertyMetadata());
		_pixelStridePropertyKey = DependencyProperty.RegisterReadOnly("PixelStride", typeof(double), typeof(TimelineRow), new PropertyMetadata());
		_selectedItemsPropertyKey = DependencyProperty.RegisterReadOnly("SelectedItems", typeof(ObservableCollection<ITimelineItemVM>), typeof(TimelineRow), new PropertyMetadata());
		AllowDrawPastBoundsProperty = DependencyProperty.Register("AllowDrawPastBounds", typeof(bool), typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((TimelineRow)(object)s).UpdateSections();
		}));
		AllowFillProperty = DependencyProperty.Register("AllowFill", typeof(bool), typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
		{
			((TimelineRow)(object)s).UpdateSections();
		}));
		AllowGroupingProperty = DependencyProperty.Register("AllowGrouping", typeof(bool), typeof(TimelineRow));
		CurrentTimeProperty = _currentTimePropertyKey.DependencyProperty;
		DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDurationPropertyChanged)));
		GroupsProperty = DependencyProperty.Register("Groups", typeof(ObservableCollection<TimelineSectionGroup>), typeof(TimelineRow));
		HasGroupsProperty = _hasGroupsPropertyKey.DependencyProperty;
		IconProperty = DependencyProperty.Register("Icon", typeof(DrawingImage), typeof(TimelineRow));
		PixelStrideProperty = _pixelStridePropertyKey.DependencyProperty;
		SelectedItemsProperty = _selectedItemsPropertyKey.DependencyProperty;
		VisibleDurationProperty = DependencyProperty.Register("VisibleDuration", typeof(TimeSlice), typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVisibleDurationPropertyChanged)));
		VisibleDurationStartProperty = DependencyProperty.Register("VisibleDurationStart", typeof(TimeSlice), typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVisibleDurationStartPropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineRow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineRow)));
	}

	public TimelineRow()
	{
		Groups = new ObservableCollection<TimelineSectionGroup>();
		SelectedItems = new ObservableCollection<ITimelineItemVM>();
		base.Loaded += delegate
		{
			UpdateItemsPropertyChangedWatchers();
			UpdatePixelStride();
			UpdateSections();
		};
		base.SizeChanged += delegate
		{
			UpdateItemsPropertyChangedWatchers();
			UpdatePixelStride();
			UpdateSections();
		};
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, SelectAll, () => base.HasItems);
		base.CommandBindings.Add(CommonApplicationCommands.DeselectAll, DeselectAll, () => SelectedItems?.Any() ?? false);
	}

	public void ClearSelection()
	{
		IEnumerable<ITimelineItemVM> enumerable = SelectedItems?.ToList();
		foreach (ITimelineItemVM item in enumerable ?? Enumerable.Empty<ITimelineItemVM>())
		{
			TimelineSection timelineSection = (TimelineSection)(object)base.ItemContainerGenerator.ContainerFromItem(item);
			if (timelineSection != null)
			{
				timelineSection.IsSelected = false;
			}
		}
		SelectedItems?.Clear();
	}

	public virtual bool IsSectionVisible(TimelineSection section)
	{
		TimeSlice timeSlice = section.StartTime + section.Duration;
		if (section.StartTime < VisibleDurationStart && timeSlice > VisibleDurationStart)
		{
			return true;
		}
		if (section.StartTime <= VisibleDurationStart + VisibleDuration)
		{
			return true;
		}
		return false;
	}

	public override void OnApplyTemplate()
	{
		TimelineControl timelineControl = ((DependencyObject)(object)this).FindVisualParent<TimelineControl>();
		if (timelineControl != null)
		{
			((DependencyObject?)(object)this).Bind(DurationProperty, timelineControl, "ActualDuration");
			((DependencyObject?)(object)this).Bind(VisibleDurationProperty, timelineControl, "VisibleDuration");
			((DependencyObject?)(object)this).Bind(VisibleDurationStartProperty, timelineControl, "VisibleDurationStart");
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		TimelineSection timelineSection = new TimelineSection();
		timelineSection.Initialize(this);
		return (DependencyObject)(object)timelineSection;
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		TimelineSection obj = item as TimelineSection;
		obj?.Initialize(this);
		return obj != null;
	}

	protected virtual void OnDurationChanged(TimeSlice oldValue, TimeSlice newValue)
	{
	}

	protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
	{
		if (oldValue is INotifyCollectionChanged notifyCollectionChanged)
		{
			notifyCollectionChanged.CollectionChanged -= ItemsSourceOnCollectionChanged;
		}
		if (newValue is INotifyCollectionChanged notifyCollectionChanged2)
		{
			notifyCollectionChanged2.CollectionChanged += ItemsSourceOnCollectionChanged;
		}
		UpdateSections();
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		bool flag = false;
		foreach (ITimelineItemVM item in (IEnumerable)base.Items)
		{
			if (((TimelineSection)(object)base.ItemContainerGenerator.ContainerFromItem(item)).IsMouseOver)
			{
				flag = true;
			}
		}
		Focus();
		this.Clicked?.Invoke(new RowClickedData(!flag, this));
		base.OnMouseUp(e);
	}

	internal void ClearTimelineSelection()
	{
		this.Clicked?.Invoke(new RowClickedData(ClearAllSelection: true, this));
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(this);
		double x = ((Point)(ref position)).X;
		CurrentTime = TimeSlice.FromMilliseconds(Math.Floor(x * PixelStride)).Add(VisibleDurationStart);
	}

	protected virtual void OnVisibleDurationChanged(TimeSlice oldValue, TimeSlice newValue)
	{
	}

	protected virtual void OnVisibleDurationStartChanged(TimeSlice oldValue, TimeSlice newValue)
	{
	}

	internal TimeSlice? CalculateTimeAdjustment(TimeSlice delta)
	{
		if (SelectedItems == null || !SelectedItems.Any())
		{
			return null;
		}
		List<ITimelineItemVM> source = SelectedItems.OrderBy((ITimelineItemVM i) => i.StartTime).ToList();
		if (!source.Any())
		{
			return null;
		}
		ITimelineItemVM timelineItemVM = source.FirstOrDefault();
		if (timelineItemVM == null)
		{
			return null;
		}
		TimeSlice timeSlice = timelineItemVM.StartTime + delta;
		if (timeSlice < TimeSlice.Zero)
		{
			return TimeSlice.Zero - timeSlice;
		}
		return null;
	}

	internal void RegisterEventHandlers(TimelineSection section)
	{
		if (section != null)
		{
			section.RefreshRequired += SectionOnRefreshRequired;
			section.IsSelectedChanged += SectionOnIsSelectedChanged;
			section.StartTimeChanged += SectionOnStartTimeChanged;
			section.MouseDoubleClick += SectionOnMouseDoubleClick;
		}
	}

	internal void UnRegisterEventHandlers(TimelineSection section)
	{
		if (section != null)
		{
			section.RefreshRequired -= SectionOnRefreshRequired;
			section.IsSelectedChanged -= SectionOnIsSelectedChanged;
			section.StartTimeChanged -= SectionOnStartTimeChanged;
			section.MouseDoubleClick -= SectionOnMouseDoubleClick;
		}
	}

	private void DeselectAll()
	{
		foreach (object item in (IEnumerable)base.Items)
		{
			if (base.ItemContainerGenerator.ContainerFromItem(item) is TimelineSection timelineSection)
			{
				timelineSection.IsSelected = false;
			}
		}
	}

	private Tuple<int, int> GetIndexRangeAdjacentGroupSections(List<ITimelineItemVM> orderedSections, int index)
	{
		string groupName = orderedSections[index].GroupName;
		int item = 0;
		for (int i = index; i < orderedSections.Count; i++)
		{
			string groupName2 = orderedSections[i].GroupName;
			if (string.Compare(groupName, groupName2, StringComparison.OrdinalIgnoreCase) != 0)
			{
				break;
			}
			item = i;
		}
		return new Tuple<int, int>(index, item);
	}

	private void ItemsSourceOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateItemsPropertyChangedWatchers();
		UpdateSections();
	}

	private static void OnDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineRow obj = (TimelineRow)(object)d;
		TimeSlice oldValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		TimeSlice newValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj.OnDurationChanged(oldValue, newValue);
		obj.UpdatePixelStride();
		obj.UpdateSections();
	}

	private void OnTimelineItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateSections();
	}

	private static void OnVisibleDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineRow obj = (TimelineRow)(object)d;
		TimeSlice oldValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		TimeSlice newValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj.OnVisibleDurationChanged(oldValue, newValue);
		obj.UpdatePixelStride();
		obj.UpdateSections();
	}

	private static void OnVisibleDurationStartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineRow obj = (TimelineRow)(object)d;
		TimeSlice oldValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		TimeSlice newValue = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj.OnVisibleDurationStartChanged(oldValue, newValue);
		obj.UpdatePixelStride();
		obj.UpdateSections();
	}

	private void SectionOnIsSelectedChanged(TimelineSection section)
	{
		if (SelectedItems == null)
		{
			return;
		}
		ITimelineItemVM item = section.Item;
		if (section.IsSelected)
		{
			if (!SelectedItems.Contains(item))
			{
				SelectedItems.Add(item);
			}
		}
		else if (SelectedItems.Contains(item))
		{
			SelectedItems.Remove(item);
		}
	}

	private void SectionOnMouseDoubleClick(object? sender, MouseButtonEventArgs e)
	{
		if (sender is TimelineSection timelineSection)
		{
			this.ItemDoubleClicked?.Invoke(timelineSection.Item);
		}
	}

	private void SectionOnRefreshRequired()
	{
		UpdateSections();
	}

	private void SectionOnStartTimeChanged(TimelineSection section, TimeSlice delta)
	{
		this.StartTimeChanged?.Invoke(delta);
		UpdateSections();
	}

	private void SelectAll()
	{
		foreach (object item in (IEnumerable)base.Items)
		{
			if (base.ItemContainerGenerator.ContainerFromItem(item) is TimelineSection timelineSection)
			{
				timelineSection.IsSelected = true;
			}
		}
	}

	private void UpdateGroups(List<ITimelineItemVM> orderedItems)
	{
		if (Groups == null)
		{
			return;
		}
		Groups.Clear();
		if (!AllowGrouping)
		{
			return;
		}
		int num = 0;
		while (num < orderedItems.Count)
		{
			Tuple<int, int> indexRangeAdjacentGroupSections = GetIndexRangeAdjacentGroupSections(orderedItems, num);
			ITimelineItemVM timelineItemVM = orderedItems[indexRangeAdjacentGroupSections.Item1];
			ITimelineItemVM timelineItemVM2 = orderedItems[indexRangeAdjacentGroupSections.Item2];
			string groupName = timelineItemVM.GroupName;
			TimelineSectionGroup timelineSectionGroup = new TimelineSectionGroup
			{
				GroupName = groupName,
				StartTime = timelineItemVM.StartTime,
				Duration = timelineItemVM2.StartTime + timelineItemVM2.Duration - timelineItemVM.StartTime,
				Background = timelineItemVM.Background,
				Label = groupName
			};
			timelineSectionGroup.Initialize(this);
			Groups.Add(timelineSectionGroup);
			int num2 = 0;
			for (int i = indexRangeAdjacentGroupSections.Item1; i <= indexRangeAdjacentGroupSections.Item2; i++)
			{
				TimelineSection timelineSection = (TimelineSection)(object)base.ItemContainerGenerator.ContainerFromItem(orderedItems[i]);
				if (timelineSection != null)
				{
					timelineSection.Index = num2;
				}
				num2++;
			}
			num = indexRangeAdjacentGroupSections.Item2 + 1;
		}
		for (num = 0; num < Groups.Count; num++)
		{
			TimelineSectionGroup timelineSectionGroup2 = Groups[num];
			TimelineSectionGroup nextSection = ((num < Groups.Count - 1) ? Groups[num + 1] : null);
			timelineSectionGroup2.Update(nextSection);
		}
		HasGroups = Groups.Any();
	}

	private void UpdateItemsPropertyChangedWatchers()
	{
		foreach (ITimelineItemVM item in base.Items.SourceCollection.Cast<ITimelineItemVM>())
		{
			if (!_cachedRowItems.Contains(item))
			{
				item.PropertyChanged += OnTimelineItemPropertyChanged;
				_cachedRowItems.Add(item);
			}
		}
		List<ITimelineItemVM> removeItems = new List<ITimelineItemVM>();
		_cachedRowItems.ForEach(delegate(ITimelineItemVM item)
		{
			if (!base.Items.SourceCollection.Cast<ITimelineItemVM>().Contains(item))
			{
				item.PropertyChanged -= OnTimelineItemPropertyChanged;
				removeItems.Add(item);
			}
		});
		_cachedRowItems.RemoveAll((ITimelineItemVM item) => removeItems.Contains(item));
	}

	private void UpdatePixelStride()
	{
		if (base.ActualWidth <= 0.0)
		{
			PixelStride = 0.0;
		}
		PixelStride = VisibleDuration.TotalMilliseconds / base.ActualWidth;
		if (double.IsInfinity(PixelStride))
		{
			PixelStride = 0.0;
		}
	}

	private void UpdateSections()
	{
		if (PixelStride == 0.0)
		{
			UpdatePixelStride();
		}
		List<ITimelineItemVM> list = (from ITimelineItemVM s in base.Items.SourceCollection
			orderby s.StartTime
			select s).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			ITimelineItemVM item = list[i];
			ITimelineItemVM timelineItemVM = ((i < list.Count - 1) ? list[i + 1] : null);
			TimelineSection timelineSection = (TimelineSection)(object)base.ItemContainerGenerator.ContainerFromItem(item);
			TimelineSection nextSection = null;
			if (timelineItemVM != null)
			{
				nextSection = (TimelineSection)(object)base.ItemContainerGenerator.ContainerFromItem(timelineItemVM);
			}
			timelineSection?.Update(nextSection);
		}
		UpdateGroups(list);
	}
}
