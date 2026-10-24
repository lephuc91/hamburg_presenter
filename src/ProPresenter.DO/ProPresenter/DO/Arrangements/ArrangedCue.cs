using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Time;
using Pro.DO;
using Pro.DO.Label;
using Pro.DO.Triggering;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Transition;

namespace ProPresenter.DO.Arrangements;

public class ArrangedCue : LinkedNotifyPropertyChangedBase, IThumbnailSource, INotifyPropertyChanged, IUniformViewSource, ITriggerable, IArrangedCue
{
	private readonly ObservableCollection<IScrimSource> _scrimItems = new ObservableCollection<IScrimSource>();

	private bool _showSlideHotkey;

	private bool _showGroupHotkey;

	private readonly SlideCueValidator _validator;

	private bool _showGroupLabel;

	private int _buildPosition;

	private int _index;

	public SlideCue Source { get; }

	private SlideBase? Slide => Source.SlideAction?.Slide;

	public CueGroup Group { get; }

	public bool IsGroupHead => Group.Cues.First() == Source;

	public bool IsGroupTail => Group.Cues.Last() == Source;

	internal bool ShowSlideHotkey
	{
		get
		{
			return _showSlideHotkey;
		}
		set
		{
			SetValue("ShowSlideHotkey", ref _showSlideHotkey, value, RebuildScrimItems);
		}
	}

	internal bool ShowGroupHotkey
	{
		get
		{
			return _showGroupHotkey;
		}
		set
		{
			SetValue("ShowGroupHotkey", ref _showGroupHotkey, value, RebuildScrimItems);
		}
	}

	public string Name
	{
		get
		{
			SlideAction? slideAction = Source.SlideAction;
			object obj;
			if (slideAction == null || slideAction.ActionType != ActionType.PropSlide)
			{
				if (!ShowGroupLabel)
				{
					return string.Empty;
				}
				obj = GroupLabel?.Text;
				if (obj == null)
				{
					return string.Empty;
				}
			}
			else
			{
				obj = Source.Name;
			}
			return (string)obj;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public bool CanRename => false;

	public bool IsEnabled => Source.IsEnabled;

	public bool IsMediaPending
	{
		get
		{
			if (Slide is CustomSlide customSlide)
			{
				return customSlide.IsBackgroundMediaPending;
			}
			return false;
		}
	}

	public bool IsValid => Source.IsValid;

	public Color BackgroundColor => Group.Label?.Color ?? Colors.Transparent;

	public LiveVideoInput? LiveVideoInput => Source.Actions.FirstOrDefaultOf((MediaAction m) => m.Media is LiveVideoMedia)?.LiveVideo?.LiveVideo.Input;

	public string LabelName => Source.SlideAction?.Label?.Text ?? string.Empty;

	public Color LabelColor => Source.SlideAction?.Label?.Color ?? Colors.Transparent;

	public Brush LabelForeground => Brushes.White;

	public GroupLabel? GroupLabel => Group.Label;

	public bool ShowGroupLabel
	{
		get
		{
			return _showGroupLabel;
		}
		set
		{
			SetValue("ShowGroupLabel", ref _showGroupLabel, value, (Action)delegate
			{
				OnPropertyChanged("Name");
			}, (Predicate<bool>?)null, referenceComparison: false);
		}
	}

	public bool ShowIndex => true;

	public int Index
	{
		get
		{
			return _index;
		}
		set
		{
			SetValue("Index", ref _index, value);
		}
	}

	public IEnumerable<IScrimSource> ScrimItems => _scrimItems;

	public double ThumbnailAspectRatio
	{
		get
		{
			if (Slide != null)
			{
				return Slide.Size.X / Slide.Size.Y;
			}
			return 1.0;
		}
	}

	public int BuildCount => Slide?.ManualBuildCount ?? 0;

	public int BuildPosition
	{
		get
		{
			return _buildPosition;
		}
		set
		{
			SetValue("BuildPosition", ref _buildPosition, value);
		}
	}

	public ScaleBehavior ScaleBehavior => (Source.GetPreviewMedia() as IDrawMedia)?.Drawing.ScaleBehavior ?? ScaleBehavior.StretchToFill;

	public ScaleAlignment ScaleAlignment => (Source.GetPreviewMedia() as IDrawMedia)?.Drawing.EffectiveScaleAlignment ?? ScaleAlignment.MiddleCenter;

	public TimeSlice Duration => Source.Actions.FirstOrDefaultOf((MediaAction m) => m.MediaDuration > TimeSlice.Zero)?.MediaDuration ?? TimeSlice.Zero;

	public string ContainerId => Source.ContainerId;

	public event Action? VisualInvalidated
	{
		add
		{
			if (Slide != null)
			{
				Slide.VisualInvalidated += value;
			}
		}
		remove
		{
			if (Slide != null)
			{
				Slide.VisualInvalidated -= value;
			}
		}
	}

	public ArrangedCue(SlideCue cue, CueGroup group)
	{
		Source = cue;
		Group = group;
		_validator = new SlideCueValidator(Source, CheckWarning);
		RebuildScrimItems();
		LinkProperties("Label", new string[4] { "Name", "LabelName", "LabelColor", "LabelForeground" });
		LinkProperties("Size", "ThumbnailAspectRatio");
		LinkProperties("ManualBuildCount", "BuildCount");
		LinkProperties("IsEnabled", "IsEnabled");
		LinkProperties("IsValid", "IsValid");
		LinkAction("Label", delegate
		{
			OnPropertyChanged("GroupLabel");
			OnPropertyChanged("BackgroundColor");
			OnPropertyChanged("LabelForeground");
			RebuildScrimItems();
		});
		LinkAction("MediaDuration", delegate
		{
			OnPropertyChanged("Duration");
			RebuildScrimItems();
		});
		LinkAction(new string[5] { "Hotkey", "SelectedTransition", "GotoNext", "CompletionTime", "CompletionTarget" }, RebuildScrimItems);
		LinkProperties("Name", "Name");
		LinkProperties("ScaleBehavior", "ScaleBehavior");
		LinkProperties("EffectiveScaleAlignment", "ScaleAlignment");
		LinkProperties("Input", "LiveVideoInput");
		LinkProperties("Duration", "Duration");
		LinkProperties("IsBackgroundMediaPending", "IsMediaPending");
		Source.Actions.CollectionChanged += Actions_CollectionChanged;
		if (Slide is CustomSlide customSlide)
		{
			customSlide.PropertyChanged += base.RaiseLinkedValues;
		}
		SetupActions(Source.Actions);
		Source.PropertyChanged += base.RaiseLinkedValues;
		if (Source.SlideAction != null)
		{
			Source.SlideAction.PropertyChanged += base.RaiseLinkedValues;
			Source.SlideAction.Slide.PropertyChanged += base.RaiseLinkedValues;
		}
		group.PropertyChanged += base.RaiseLinkedValues;
		if (group.Label != null)
		{
			group.Label.Hotkey.PropertyChanged += delegate
			{
				RebuildScrimItems();
			};
		}
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TeardownActions(e.OldItems?.OfType<ActionBase>());
		SetupActions(e.NewItems?.OfType<ActionBase>());
		RebuildScrimItems();
		OnPropertyChanged("LiveVideoInput");
		OnPropertyChanged("Duration");
		OnPropertyChanged("ScaleAlignment");
		OnPropertyChanged("ScaleBehavior");
	}

	private void SetupActions(IEnumerable<IAction>? actions)
	{
		actions?.ForEach(delegate(IAction a)
		{
			if (a is MediaAction mediaAction)
			{
				if (mediaAction.Media is IDrawMedia drawMedia)
				{
					drawMedia.Drawing.PropertyChanged += base.RaiseLinkedValues;
				}
				if (mediaAction.Media is ILiveVideoMedia liveVideoMedia)
				{
					liveVideoMedia.LiveVideo.PropertyChanged += base.RaiseLinkedValues;
				}
				mediaAction.PropertyChanged += base.RaiseLinkedValues;
			}
		});
		OnPropertyChanged("LiveVideoInput");
		OnPropertyChanged("Duration");
	}

	private void TeardownActions(IEnumerable<ActionBase>? actions)
	{
		actions?.ForEach(delegate(ActionBase a)
		{
			if (a is MediaAction mediaAction)
			{
				if (mediaAction.Media is IDrawMedia drawMedia)
				{
					drawMedia.Drawing.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (mediaAction.Media is ILiveVideoMedia liveVideoMedia)
				{
					liveVideoMedia.LiveVideo.PropertyChanged -= base.RaiseLinkedValues;
				}
			}
		});
	}

	public bool HasHotkey(Key key)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (ShowSlideHotkey)
		{
			Pro.DO.Hotkey? hotkey = Source.Hotkey;
			if ((object)hotkey != null && hotkey.Key == key)
			{
				return true;
			}
		}
		if (ShowGroupHotkey)
		{
			GroupLabel? groupLabel = GroupLabel;
			if (groupLabel == null)
			{
				return false;
			}
			return groupLabel.Hotkey?.Key == (Key?)key;
		}
		return false;
	}

	private void RebuildScrimItems()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		List<WarningScrimItem> items = _scrimItems.OfType<WarningScrimItem>().ToList();
		_scrimItems.Clear();
		if (ShowGroupHotkey && GroupLabel?.Hotkey?.IsValid() == true)
		{
			_scrimItems.Add(new SlideHotkey(GroupLabel.Hotkey.Key));
		}
		else if (ShowSlideHotkey)
		{
			Pro.DO.Hotkey? hotkey = Source.Hotkey;
			if ((object)hotkey != null && hotkey.IsValid())
			{
				_scrimItems.Add(new SlideHotkey(Source.Hotkey.Key));
			}
		}
		_scrimItems.AddRange(items);
		List<IScrimSource> list = new List<IScrimSource>();
		list.AddRange(Source.Actions.Where((IAction a) => a.ActionType != ActionType.Slide).OfType<IScrimSource>());
		if (Source.GotoNext != null)
		{
			list.Add(Source.GotoNext);
		}
		_scrimItems.AddRange(list);
		if (Slide?.SelectedTransition != null)
		{
			_scrimItems.Add(new TransitionScrimItem(Slide.SelectedTransition));
		}
		if (Duration != TimeSlice.Zero)
		{
			_scrimItems.Add(new VideoDurationScrimItem(Duration));
		}
		OnPropertyChanged("ScrimItems");
		OnPropertyChanged("ScaleBehavior");
	}

	private void CheckWarning(bool isValid, string message)
	{
		_scrimItems.RemoveIf((object? i) => i is WarningScrimItem);
		if (!isValid)
		{
			int index = _scrimItems.Count((IScrimSource _scrimItems) => _scrimItems is SlideHotkey);
			_scrimItems.Insert(index, new WarningScrimItem(message));
		}
		OnPropertyChanged("ScrimItems");
	}
}
