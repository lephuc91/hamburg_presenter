using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Editor;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.Editor.Links;
using ProPresenter.ViewModels.Editor.Links;

namespace ProPresenter.ViewModels.Editor;

public class TextLinkVM : LinkedNotifyPropertyChangedBase, ITextLinkVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003CGetAvailableLinkTypes_003Ed__98 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public TextLinkVM _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CGetAvailableLinkTypes_003Ed__98(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TextLinkVM textLinkVM = _003C_003E4__this;
			IEnumerable<ClosedBezierPath>? availableElementsCollection;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (textLinkVM.EditMode == EditMode.CCLITemplate)
				{
					_003C_003E2__current = LinkedTextType.CCLITemplate;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_00c9;
			case 1:
				_003C_003E1__state = -1;
				_003C_003E2__current = new Separator();
				_003C_003E1__state = 2;
				return true;
			case 2:
				_003C_003E1__state = -1;
				goto IL_00c9;
			case 3:
				_003C_003E1__state = -1;
				_003C_003E2__current = new Separator();
				_003C_003E1__state = 4;
				return true;
			case 4:
				_003C_003E1__state = -1;
				goto IL_0114;
			case 5:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.NextSlide;
				_003C_003E1__state = 6;
				return true;
			case 6:
				_003C_003E1__state = -1;
				_003C_003E2__current = new Separator();
				_003C_003E1__state = 7;
				return true;
			case 7:
				_003C_003E1__state = -1;
				if (textLinkVM.AvailableTimerCollection.Any())
				{
					_003C_003E2__current = LinkedTextType.Timer;
					_003C_003E1__state = 8;
					return true;
				}
				goto IL_0190;
			case 8:
				_003C_003E1__state = -1;
				goto IL_0190;
			case 9:
				_003C_003E1__state = -1;
				_003C_003E2__current = new Separator();
				_003C_003E1__state = 10;
				return true;
			case 10:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.StageMessage;
				_003C_003E1__state = 11;
				return true;
			case 11:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.VideoCountdown;
				_003C_003E1__state = 12;
				return true;
			case 12:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.AudioCountdown;
				_003C_003E1__state = 13;
				return true;
			case 13:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.PlaybackMarkerText;
				_003C_003E1__state = 14;
				return true;
			case 14:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.TimecodeText;
				_003C_003E1__state = 15;
				return true;
			case 15:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.GroupName;
				_003C_003E1__state = 16;
				return true;
			case 16:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.SlideLabel;
				_003C_003E1__state = 17;
				return true;
			case 17:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.SlideCount;
				_003C_003E1__state = 18;
				return true;
			case 18:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.PresentationName;
				_003C_003E1__state = 19;
				return true;
			case 19:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.PlaylistItem;
				_003C_003E1__state = 20;
				return true;
			case 20:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.Capture;
				_003C_003E1__state = 21;
				return true;
			case 21:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.AutoAdvanceTimeRemaing;
				_003C_003E1__state = 22;
				return true;
			case 22:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.PresentationNotes;
				_003C_003E1__state = 23;
				return true;
			case 23:
				_003C_003E1__state = -1;
				_003C_003E2__current = new Separator();
				_003C_003E1__state = 24;
				return true;
			case 24:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.FileFeed;
				_003C_003E1__state = 25;
				return true;
			case 25:
				_003C_003E1__state = -1;
				_003C_003E2__current = LinkedTextType.RssFeed;
				_003C_003E1__state = 26;
				return true;
			case 26:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_0114:
				_003C_003E2__current = LinkedTextType.CurrentSlide;
				_003C_003E1__state = 5;
				return true;
				IL_0190:
				_003C_003E2__current = LinkedTextType.Clock;
				_003C_003E1__state = 9;
				return true;
				IL_00c9:
				availableElementsCollection = textLinkVM.AvailableElementsCollection;
				if (availableElementsCollection != null && availableElementsCollection.Any())
				{
					_003C_003E2__current = LinkedTextType.Element;
					_003C_003E1__state = 3;
					return true;
				}
				goto IL_0114;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			_003CGetAvailableLinkTypes_003Ed__98 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetAvailableLinkTypes_003Ed__98(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}
	}

	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private readonly IApp _app;

	private readonly IGeneral _general;

	private CustomSlide? _selectedSlide;

	private EditMode _editMode;

	private TimerData? _selectedTimerData;

	public IClockTextLinkVM ClockTextLinkVM { get; }

	public ITimerTextLinkVM TimerTextLinkVM { get; }

	public IVideoCountdownLinkVM VideoCountdownLinkVM { get; }

	public IAudioCountdownVM AudioCountdownLinkVM { get; }

	public IStageMessageTextLinkVM StageMessageTextLinkVM { get; }

	public ISlideTextLinkVM SlideTextLinkVM { get; }

	public IGroupNameTextLinkVM GroupNameTextLinkVM { get; }

	public IPlaylistItemTextLinkVM PlaylistItemTextLinkVM { get; }

	public IAutoAdvanceTextLinkVM AutoAdvanceTextLinkVM { get; }

	public ICaptureTextLinkVM CaptureTextLinkVM { get; }

	public ISlideCountTextLinkVM SlideCountTextLinkVM { get; }

	public ISlideLabelTextLinkVM SlideLabelTextLinkVM { get; }

	public IPresentationNameTextLinkVM PresentationNameTextLinkVM { get; }

	public IFileFeedLinkVM FileFeedLinkVM { get; }

	public IRssFeedLinkVM RssFeedLinkVM { get; }

	public IPlaybackMarkerLinkVM PlaybackMarkerTextLinkVM { get; }

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		set
		{
			SetValue("SelectedSlide", ref _selectedSlide, value);
		}
	}

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault((ClosedBezierPath e) => e.IsEditModeActive) ?? SelectedElements.FirstOrDefault();

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public EditMode EditMode
	{
		get
		{
			return _editMode;
		}
		set
		{
			SetValue("EditMode", ref _editMode, value, (Action)delegate
			{
				OnPropertyChanged("AvailableLinkedTextTypes");
			}, (Predicate<EditMode>?)null, referenceComparison: false);
		}
	}

	public IImmutableObservableCollection<TimerData> AvailableTimerCollection { get; }

	public IEnumerable<ClosedBezierPath>? AvailableElementsCollection => SelectedSlide?.Elements?.OfType<ClosedBezierPath>().Where(delegate(ClosedBezierPath e)
	{
		if (!SelectedElements.Contains(e))
		{
			ILinkedTextObject? linkedObject = e.TextLink.LinkedObject;
			if (linkedObject == null)
			{
				return true;
			}
			return linkedObject.LinkedTextType != LinkedTextType.Element;
		}
		return false;
	});

	public bool IsTextLinkEnabled
	{
		get
		{
			return FirstElement?.TextLink.IsEnabled ?? false;
		}
		set
		{
			if (CanModifyTextLink)
			{
				UndoStack?.BeginCommit(UndoActionTypes.TextLinkEnabled.ToAction());
				SelectedElements.ForEach(delegate(ClosedBezierPath e)
				{
					e.TextLink.IsEnabled = value;
				});
				OnPropertyChanged("IsTextLinkEnabled");
				OnPropertyChanged("DisablePreserveFormatControls");
				UndoStack?.EndCommit(null, delegate
				{
					OnPropertyChanged("IsTextLinkEnabled");
				}, autoFinalize: true);
			}
		}
	}

	public CompositeCollection AvailableLinkedTextTypes
	{
		get
		{
			CompositeCollection compositeCollection = new CompositeCollection();
			compositeCollection.AddRange(GetAvailableLinkTypes());
			return compositeCollection;
		}
	}

	public LinkedTextType LinkedTextType
	{
		get
		{
			return FirstElement?.TextLink.LinkedObject?.LinkedTextType ?? LinkedTextType.None;
		}
		set
		{
			UndoStack?.BeginCommit(UndoActionTypes.LinkTextObject.ToAction());
			SelectedElements.Where(delegate(ClosedBezierPath e)
			{
				ILinkedTextObject? linkedObject = e.TextLink.LinkedObject;
				return linkedObject == null || linkedObject.LinkedTextType != value;
			}).ForEach(delegate(ClosedBezierPath e)
			{
				e.TextLink.LinkedObject = GenerateLinkedObject(value);
			});
			OnPropertyChanged("LinkedTextType");
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public TimerLinkedObject? SelectedTimerTextLink => FirstElement?.TextLink.LinkedObject as TimerLinkedObject;

	public ElementTextLinkedObject? SelectedElementTextLink => FirstElement?.TextLink.LinkedObject as ElementTextLinkedObject;

	public ICommand<TimerData> TimerTextLinkCommand => new RelayCommand<TimerData>(OnSetTimerTextLinkedCommand, (TimerData t) => t != null);

	public ICommand<ClosedBezierPath> ElementTextLinkCommand => new RelayCommand<ClosedBezierPath>(OnElementTextLinkCommand, (ClosedBezierPath p) => p != null);

	public ICommand<LinkedTextType> TextLinkCommand => new RelayCommand<LinkedTextType>(delegate(LinkedTextType l)
	{
		LinkedTextType = l;
	}, (LinkedTextType l) => CanModifyTextLink);

	public bool DisablePreserveFormatControls
	{
		get
		{
			if (IsTextLinkEnabled && SlideTextLinkVM.PreserveNotesFormat)
			{
				return SlideTextLinkVM.SlideTextSourceMode == SlideTextSourceMode.Notes;
			}
			return false;
		}
	}

	public bool AllowTextFill
	{
		get
		{
			if (IsTextLinkEnabled)
			{
				return !PlaybackMarkerTextLinkVM.PlaybackMarkerUsesMarkerColor;
			}
			return true;
		}
	}

	public bool CanModifyTextLink
	{
		get
		{
			if (EditMode == EditMode.CCLITemplate)
			{
				if (EditMode == EditMode.CCLITemplate)
				{
					if (IsTextLinkEnabled)
					{
						return CCLILinksRemain();
					}
					return true;
				}
				return false;
			}
			return true;
		}
	}

	public TextLinkVM(IImmutableObservableCollection<TimerData> timers, ObservableCollection<ICanvasElement> selectedElements, IApp app, IGeneral general)
	{
		ColorTriggerVMFactory colorTriggerVMFactory = new ColorTriggerVMFactory(app);
		ClockTextLinkVM = new ClockTextLinkVM(selectedElements, app);
		TimerTextLinkVM = new TimerTextLinkVM(selectedElements, colorTriggerVMFactory);
		VideoCountdownLinkVM = new VideoCountdownLinkVM(selectedElements, colorTriggerVMFactory);
		AudioCountdownLinkVM = new AudioCountdownVM(selectedElements, colorTriggerVMFactory);
		StageMessageTextLinkVM = new StageMessageTextLinkVM(selectedElements);
		SlideTextLinkVM = new SlideTextLinkVM(selectedElements);
		GroupNameTextLinkVM = new GroupNameTextLinkVM(selectedElements);
		PlaylistItemTextLinkVM = new PlaylistItemTextLinkVM(selectedElements);
		CaptureTextLinkVM = new CaptureTextLinkVM(selectedElements);
		AutoAdvanceTextLinkVM = new AutoAdvanceTextLinkVM(selectedElements);
		SlideCountTextLinkVM = new SlideCountTextLinkVM(selectedElements);
		SlideLabelTextLinkVM = new SlideLabelTextLinkVM(selectedElements);
		PresentationNameTextLinkVM = new PresentationNameTextLinkVM(selectedElements);
		FileFeedLinkVM = new FileFeedLinkVM(selectedElements);
		RssFeedLinkVM = new RssFeedLinkVM(selectedElements);
		PlaybackMarkerTextLinkVM = new PlaybackMarkerTextLinkVM(selectedElements);
		_app = app;
		_general = general;
		AvailableTimerCollection = timers;
		AvailableTimerCollection.CollectionChanged += delegate
		{
			OnPropertyChanged("AvailableLinkedTextTypes");
		};
		_selectedElements = selectedElements;
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated -= TextLink_LinkObjectUpdated;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath elem)
			{
				elem.TextLink.LinkObjectUpdated += TextLink_LinkObjectUpdated;
			});
			NotifyPropertyChanges();
		};
		LinkProperties(new string[2] { "PreserveNotesFormat", "SlideTextSourceMode" }, "DisablePreserveFormatControls");
		LinkProperties("PlaybackMarkerUsesMarkerColor", "AllowTextFill");
		SlideTextLinkVM.PropertyChanged += base.RaiseLinkedValues;
		PlaybackMarkerTextLinkVM.PropertyChanged += base.RaiseLinkedValues;
	}

	private void TextLink_LinkObjectUpdated()
	{
		OnPropertyChanged("LinkedTextType");
		OnPropertyChanged("SelectedTimerTextLink");
		OnPropertyChanged("SelectedElementTextLink");
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("LinkedTextType");
		OnPropertyChanged("IsTextLinkEnabled");
		OnPropertyChanged("AvailableLinkedTextTypes");
		OnPropertyChanged("AvailableElementsCollection");
		OnPropertyChanged("SelectedTimerTextLink");
		OnPropertyChanged("SelectedElementTextLink");
		OnPropertyChanged("CanModifyTextLink");
	}

	[IteratorStateMachine(typeof(_003CGetAvailableLinkTypes_003Ed__98))]
	private IEnumerable<object> GetAvailableLinkTypes()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetAvailableLinkTypes_003Ed__98(-2)
		{
			_003C_003E4__this = this
		};
	}

	private void OnSetTimerTextLinkedCommand(TimerData timerData)
	{
		UndoStack?.BeginCommit(UndoActionTypes.LinkTextObject.ToAction());
		_selectedTimerData = timerData;
		LinkedTextType = LinkedTextType.Timer;
		SelectedElements.Select((ClosedBezierPath e) => e.TextLink.LinkedObject).OfType<TimerLinkedObject>().ForEach(delegate(TimerLinkedObject t)
		{
			t.TimerData = _selectedTimerData;
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnElementTextLinkCommand(ClosedBezierPath element)
	{
		UndoStack?.BeginCommit(UndoActionTypes.LinkElement.ToAction());
		LinkedTextType = LinkedTextType.Element;
		SelectedElements.Select((ClosedBezierPath e) => e.TextLink.LinkedObject).OfType<ElementTextLinkedObject>().ForEach(delegate(ElementTextLinkedObject t)
		{
			t.Element = element;
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private ILinkedTextObject GenerateLinkedObject(LinkedTextType type)
	{
		return type switch
		{
			LinkedTextType.CCLITemplate => new CCLITextLinkedObject(_general), 
			LinkedTextType.Clock => new ClockTextLinkedObject(), 
			LinkedTextType.Element => new ElementTextLinkedObject(), 
			LinkedTextType.Timer => new TimerLinkedObject(_selectedTimerData, _app.DefaultColorTriggers.CloneItems()), 
			LinkedTextType.StageMessage => new StageMessageLinkedObject(), 
			LinkedTextType.CurrentSlide => new SlideTextLinkedObject(SlideTargetSourceMode.Current, SlideTextSourceMode.TextOnly), 
			LinkedTextType.NextSlide => new SlideTextLinkedObject(SlideTargetSourceMode.Next, SlideTextSourceMode.TextOnly), 
			LinkedTextType.VideoCountdown => new VideoCountdownLinkedObject(), 
			LinkedTextType.AudioCountdown => new AudioCountdownLinkedObject(), 
			LinkedTextType.GroupName => new GroupNameLinkedObject(), 
			LinkedTextType.SlideLabel => new SlideLabelTextLinkedObject(), 
			LinkedTextType.PresentationName => new PresentationNameLinkedObject(), 
			LinkedTextType.PlaylistItem => new PlaylistItemLinkedObject(), 
			LinkedTextType.AutoAdvanceTimeRemaing => new AutoAdvanceLinkedObject(), 
			LinkedTextType.PresentationNotes => new PresentationNotesLinkedObject(), 
			LinkedTextType.Capture => new CaptureTextLinkedObject(), 
			LinkedTextType.SlideCount => new SlideCountTextLinkedObject(), 
			LinkedTextType.FileFeed => new FileFeedLinkedObject(), 
			LinkedTextType.RssFeed => new RssFeedLinkedObject(), 
			LinkedTextType.PlaybackMarkerText => new PlaybackMarkerTextLinkedObject(), 
			LinkedTextType.TimecodeText => new TimecodeTextLinkedObject(), 
			_ => throw new NotSupportedException("Unsupported Linked Text Type"), 
		};
	}

	private bool CCLILinksRemain()
	{
		if (SelectedSlide != null)
		{
			return SelectedSlide.Elements.Except(SelectedElements).AnyOf((ClosedBezierPath e) => e.TextLink.LinkedObject is CCLITextLinkedObject);
		}
		return false;
	}
}
