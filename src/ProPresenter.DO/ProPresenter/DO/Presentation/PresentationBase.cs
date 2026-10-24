using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Media;
using Google.Protobuf;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Label;
using Pro.DO.Reversibility;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Transitions;

namespace ProPresenter.DO.Presentation;

public abstract class PresentationBase : NotifyPropertyChangedBase, IPresentation, ICloneable<IPresentation>, ISizeableTarget, INotifyPropertyChanged, ICutPasteCollection<SlidesCopyData>, ICutCollection<SlidesCopyData>
{
	private static readonly TimeSlice DataModifiedNotificationDelay = TimeSlice.FromMilliseconds(200.0);

	private readonly CueGroupCollection _arrangementGroups;

	private readonly ArrangementCollection _arrangements;

	private readonly List<ArrangedCue> _clickedCues = new List<ArrangedCue>();

	private readonly CCLIData _ccliData = new CCLIData();

	private IPresentationLoadData? _pendingLoadData;

	private IArrangement? _activeArrangement;

	private string? _activeArrangementName;

	private TransitionParameters? _selectedTransition;

	private string _name = "Default";

	private string _notes = string.Empty;

	private DateTime? _lastUsed;

	private DateTime _lastModifiedDate;

	private bool _useBackgroundColor;

	private System.Windows.Media.Color _backgroundColor = Colors.Black;

	private Timeline _timeline;

	private OutputDestination _destination;

	private RelativePath? _sourceFile;

	private double _slideShowDuration = 15.0;

	private bool _slideShowEnabled;

	private Key? _baseKey;

	private Key? _targetKey;

	private IOneShotTimer? _timer;

	private bool? _hasMissingFonts;

	private Vector2<double> _size;

	protected ICurrentTime CurrentTime { get; }

	protected IMessageDialogService MessageDialogService { get; }

	protected ITimerFactory TimerFactory { get; }

	protected IApp App { get; }

	protected IMediaFactory MediaFactory { get; }

	protected IProPresenterDOFactoryProvider FactoryProvider { get; }

	protected string DefaultGroupName { get; } = LocalizedStrings.Get("PRESENTATION_HEADER_ARRANGEMENTS_DEFAULT_GROUP_name");

	public Guid ID { get; private set; } = Guid.NewGuid();

	public virtual PresentationType PresentationType => PresentationType.Standard;

	public virtual bool IsAvailable => true;

	public bool HasDataLoaded { get; private set; }

	public bool IsPendingLoad { get; private set; }

	public Arrangement DefaultArrangement => Arrangements.MasterArrangement;

	public IArrangement? ActiveArrangement
	{
		get
		{
			EnsureLoaded();
			return _activeArrangement;
		}
		set
		{
			if (value != null && !Arrangements.Contains(value) && value != DefaultArrangement)
			{
				throw new InvalidOperationException();
			}
			if (_activeArrangement != null)
			{
				_activeArrangement.PropertyChanged -= ActiveArrangementOnPropertyChanged;
			}
			SetValue("ActiveArrangement", ref _activeArrangement, value, (System.Action)delegate
			{
				if (_activeArrangement != null)
				{
					_activeArrangement.PropertyChanged += ActiveArrangementOnPropertyChanged;
				}
				ActiveArrangementName = _activeArrangement?.Name;
				ResetCueClick();
				OnDataModified();
			}, (Predicate<IArrangement>?)null, referenceComparison: false);
		}
	}

	public string? ActiveArrangementName
	{
		get
		{
			return _activeArrangementName;
		}
		set
		{
			SetValue("ActiveArrangementName", ref _activeArrangementName, value);
		}
	}

	public Key? BaseKey
	{
		get
		{
			EnsureLoaded();
			return _baseKey;
		}
		set
		{
			SetValue("BaseKey", ref _baseKey, value, OnDataModified);
		}
	}

	public Key? TargetKey
	{
		get
		{
			EnsureLoaded();
			return _targetKey;
		}
		set
		{
			SetValue("TargetKey", ref _targetKey, value, OnDataModified);
		}
	}

	public virtual bool SupportsChords => false;

	public ArrangementCollection Arrangements
	{
		get
		{
			EnsureLoaded();
			return _arrangements;
		}
	}

	public CueGroupCollection ArrangementGroups
	{
		get
		{
			EnsureLoaded();
			return _arrangementGroups;
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			EnsureLoaded();
			return _selectedTransition;
		}
		set
		{
			EnsureLoaded();
			SetValue<TransitionParameters>("SelectedTransition", ref _selectedTransition, value, delegate(TransitionParameters o, TransitionParameters n)
			{
				UndoStack.Commit(UndoActionTypes.ChangePresentationTransition.ToAction(), this, "SelectedTransition", o, n);
				OnDataModified();
			});
		}
	}

	public OutputDestination Destination
	{
		get
		{
			return _destination;
		}
		set
		{
			SetValue("Destination", ref _destination, value, OnDataModified);
		}
	}

	public CCLIData CCLIInfo => _ccliData;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (value != _name)
			{
				this.NameChanging?.Invoke(this);
			}
			if (SourceFile == null)
			{
				SetValue("Name", ref _name, value, delegate(string o, string n)
				{
					this.FileNameModified?.Invoke(this, n);
					this.NameChanged?.Invoke(this);
				});
			}
			else if (string.Equals(_name, value, StringComparison.OrdinalIgnoreCase) || LibraryHelper.ValidateName(Path.GetDirectoryName(SourceFile) ?? string.Empty, MessageDialogService.ShowAlert, value, ".pro"))
			{
				SetValue("Name", ref _name, value, delegate(string o, string n)
				{
					this.FileNameModified?.Invoke(this, n);
					this.NameChanged?.Invoke(this);
				});
			}
		}
	}

	public RelativePath? SourceFile
	{
		get
		{
			return _sourceFile;
		}
		set
		{
			SetValue("SourceFile", ref _sourceFile, value);
		}
	}

	public Vector2<double> Size
	{
		get
		{
			EnsureLoaded();
			return Cues.FirstOrDefault()?.SlideAction?.Slide.Size ?? _size;
		}
		private set
		{
			EnsureLoaded();
			Cues.ForEach(delegate(SlideCue s)
			{
				s.SlideAction?.Slide.ChangeSize(value);
			});
			_size = value;
			OnPropertyChanged("Size");
			OnDataModified();
		}
	}

	public string Notes
	{
		get
		{
			EnsureLoaded();
			return _notes;
		}
		set
		{
			SetValue("Notes", ref _notes, value, OnDataModified);
		}
	}

	public IEnumerable<string> Content => Cues.SelectMany((SlideCue c) => c.SlideAction?.Slide.GetAllText() ?? Enumerable.Empty<string>()).NotNull();

	public DateTime? LastUsed
	{
		get
		{
			return _lastUsed;
		}
		set
		{
			SetValue("LastUsed", ref _lastUsed, value, OnDataModified);
		}
	}

	public bool UseBackgroundColor
	{
		get
		{
			EnsureLoaded();
			return _useBackgroundColor;
		}
		set
		{
			SetValue("UseBackgroundColor", ref _useBackgroundColor, value, delegate(bool o, bool n)
			{
				UndoStack.Commit(UndoActionTypes.UseDocumentColor.ToAction(), this, "UseBackgroundColor", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public System.Windows.Media.Color BackgroundColor
	{
		get
		{
			EnsureLoaded();
			return _backgroundColor;
		}
		set
		{
			SetValue("BackgroundColor", ref _backgroundColor, value, delegate(System.Windows.Media.Color o, System.Windows.Media.Color n)
			{
				UndoStack.Commit(UndoActionTypes.ChangeDocumentColor.ToAction(), this, "BackgroundColor", o, n);
				OnDataModified();
			});
		}
	}

	public Timeline PresentationTimeline
	{
		get
		{
			EnsureLoaded();
			return _timeline;
		}
	}

	public double SlideShowDuration
	{
		get
		{
			EnsureLoaded();
			return _slideShowDuration;
		}
		set
		{
			SetValue("SlideShowDuration", ref _slideShowDuration, value, OnDataModified);
		}
	}

	public bool SlideShowEnabled
	{
		get
		{
			EnsureLoaded();
			return _slideShowEnabled;
		}
		set
		{
			SetValue("SlideShowEnabled", ref _slideShowEnabled, value, delegate(bool o, bool n)
			{
				if (!n)
				{
					SlideShowDuration = 15.0;
				}
				OnDataModified();
			});
		}
	}

	public UndoStack UndoStack { get; } = new UndoStack();

	public abstract ICopyPresentationIdentifier CopyIdentifier { get; }

	public virtual bool HasMissingFonts
	{
		get
		{
			if (!IsAvailable)
			{
				return false;
			}
			if (!_hasMissingFonts.HasValue)
			{
				RefreshMissingFontsCache();
			}
			if (_hasMissingFonts.HasValue)
			{
				return _hasMissingFonts.Value;
			}
			return false;
		}
	}

	protected IEnumerable<SlideCue> Cues => ArrangementGroups.SelectMany((CueGroup g) => g.Cues);

	protected virtual bool CanShowGroupLabel => true;

	protected virtual bool HasVariableSlideSizes => false;

	protected bool DeserializationInProgress { get; set; }

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	public virtual string ContainerId => ID.ToString();

	public event Action<IPresentation>? DataFirstLoaded;

	public event Action<IPresentation>? DataModified;

	public event Action<IPresentation, string>? FileNameModified;

	public event Action<IPresentation>? NameChanging;

	public event Action<IPresentation>? NameChanged;

	public virtual ObjectBinder<PresentationBase, Pro.Entity.IPresentation> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation entityDoc)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder = new ObjectBinder<PresentationBase, Pro.Entity.IPresentation>(this, entityDoc);
		BindCuesAndGroups(objectBinder, scheduler, factoryProvider, actionBinderFactory);
		objectBinder.Bind((PresentationBase l) => l.WhenPropertyChanges("ID"), (Pro.Entity.IPresentation r) => r.Uuid.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PresentationBase l) => l.WhenPropertyChanges("Name"), (Pro.Entity.IPresentation r) => r.Name.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
		{
			r.Name.Set(l.Name);
		}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
		{
			l.Name = r.Name.Value;
		}, null, scheduler.Scheduler).Bind((PresentationBase l) => l.WhenPropertyChanges("Notes"), (Pro.Entity.IPresentation r) => r.Notes.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
		{
			r.Notes.Set(l.Notes);
		}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
		{
			l.Notes = r.Notes.Value;
		})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("BackgroundColor").Merge(l.WhenPropertyChanges("UseBackgroundColor")), (Pro.Entity.IPresentation r) => r.Background.WhenAnyValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				IBackground background = entityFactory.Create<IBackground>();
				background.IsEnabled.Set(l.UseBackgroundColor);
				IBackground.Types.IFill.IColor color = entityFactory.Create<IBackground.Types.IFill.IColor>();
				color.Set(l.BackgroundColor.ToEntityColor());
				background.Fill.Set(color);
				r.Background.Set(background);
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				if (r.Background.Value != null)
				{
					l.UseBackgroundColor = r.Background.Value.IsEnabled.Value;
					if (r.Background.Value.Fill.Value is IBackground.Types.IFill.IColor color2)
					{
						l.BackgroundColor = color2.Value.ToColor();
					}
					else
					{
						l.BackgroundColor = Colors.Transparent;
					}
				}
				else
				{
					l.UseBackgroundColor = false;
					l.BackgroundColor = Colors.Transparent;
				}
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("ActiveArrangement"), (Pro.Entity.IPresentation r) => r.SelectedArrangement.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				r.SelectedArrangement.Set((l.ActiveArrangement ?? l.DefaultArrangement).ID);
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				l.ActiveArrangement = l.Arrangements.FirstOrDefault(delegate(IArrangement a)
				{
					Guid iD = a.ID;
					Guid? value = r.SelectedArrangement.Value;
					return iD == value;
				});
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("CCLIInfo"), (Pro.Entity.IPresentation r) => r.Ccli.WhenValueChanges.ToUnit(), delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				Pro.Entity.IPresentation.Types.ICcli ccli = entityFactory.Create<Pro.Entity.IPresentation.Types.ICcli>();
				ObjectBinder<CCLIData, Pro.Entity.IPresentation.Types.ICcli> objectBinder2 = CCLIData.CreateBinder(l.CCLIInfo, ccli);
				objectBinder2.InitializeRightFromLeft();
				ccli.RegisterLinkedDisposable(objectBinder2);
				r.Ccli.Set(ccli);
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				ObjectBinder<CCLIData, Pro.Entity.IPresentation.Types.ICcli> objectBinder3 = CCLIData.CreateBinder(l.CCLIInfo, r.Ccli.Value);
				objectBinder3.InitializeLeftFromRight();
				r.Ccli.Value.RegisterLinkedDisposable(objectBinder3);
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("PresentationTimeline"), (Pro.Entity.IPresentation r) => r.Timeline.WhenValueChanges.ToUnit(), delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				Pro.Entity.IPresentation.Types.ITimeline timeline = entityFactory.Create<Pro.Entity.IPresentation.Types.ITimeline>();
				ObjectBinder<Timeline, Pro.Entity.IPresentation.Types.ITimeline> objectBinder4 = PresentationTimeline.Bind(entityFactory, actionBinderFactory, timeline);
				objectBinder4.InitializeRightFromLeft();
				timeline.RegisterLinkedDisposable(objectBinder4);
				r.Timeline.Set(timeline);
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				ObjectBinder<Timeline, Pro.Entity.IPresentation.Types.ITimeline> objectBinder5 = PresentationTimeline.Bind(entityFactory, actionBinderFactory, r.Timeline.Value);
				objectBinder5.InitializeLeftFromRight();
				r.Timeline.Value.RegisterLinkedDisposable(objectBinder5);
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("SelectedTransition"), (Pro.Entity.IPresentation r) => r.Transition.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				if (l.SelectedTransition != null)
				{
					ITransition transition = entityFactory.Create<ITransition>();
					r.Transition.Set(transition);
					ObjectBinder<TransitionParameters, ITransition> objectBinder6 = TransitionParameters.CreateBinder(factoryProvider.EntityFactory, l.SelectedTransition, r.Transition.Value);
					objectBinder6.InitializeRightFromLeft();
					transition.RegisterLinkedDisposable(objectBinder6);
				}
				else
				{
					r.Transition.Set(null);
				}
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				if (r.Transition.Value != null)
				{
					l.SelectedTransition = r.Transition.Value.ToTransition(l.TransitionDescriptions);
					ObjectBinder<TransitionParameters, ITransition> objectBinder7 = TransitionParameters.CreateBinder(factoryProvider.EntityFactory, l.SelectedTransition, r.Transition.Value);
					objectBinder7.InitializeLeftFromRight();
					r.Transition.Value.RegisterLinkedDisposable(objectBinder7);
				}
				else
				{
					l.SelectedTransition = null;
				}
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("Destination"), (Pro.Entity.IPresentation r) => r.ContentDestination.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				r.ContentDestination.Set(l.Destination.ToContentDestination());
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				l.Destination = r.ContentDestination.Value.ToOutputDestination();
			})
			.Bind<Unit, Unit>(null, (Pro.Entity.IPresentation r) => r.Music.WhenValueChanges.ToUnit(), delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				Pro.Entity.IPresentation.Types.IMusic music = entityFactory.Create<Pro.Entity.IPresentation.Types.IMusic>();
				ObjectBinder<PresentationBase, Pro.Entity.IPresentation.Types.IMusic> objectBinder8 = CreateMusicBinder(entityFactory, l, music);
				objectBinder8.InitializeRightFromLeft();
				music.RegisterLinkedDisposable(objectBinder8);
				r.Music.Set(music);
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				if (r.Music.Value != null)
				{
					ObjectBinder<PresentationBase, Pro.Entity.IPresentation.Types.IMusic> objectBinder9 = CreateMusicBinder(entityFactory, l, r.Music.Value);
					objectBinder9.InitializeLeftFromRight();
					r.Music.Value.RegisterLinkedDisposable(objectBinder9);
				}
				else
				{
					l.BaseKey = null;
					l.TargetKey = null;
				}
			})
			.Bind((PresentationBase l) => l.WhenPropertyChanges("SlideShowEnabled").ToUnit().Merge(l.WhenPropertyChanges("SlideShowDuration").ToUnit()), (Pro.Entity.IPresentation r) => r.SlideShow.WhenValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation r)
			{
				if (!l.SlideShowEnabled)
				{
					r.SlideShow.Set(null);
				}
				else
				{
					Pro.Entity.IPresentation.Types.ISlideShow.ISlideShowDuration slideShowDuration = r.SlideShow.Value as Pro.Entity.IPresentation.Types.ISlideShow.ISlideShowDuration;
					if (slideShowDuration == null)
					{
						slideShowDuration = entityFactory.Create<Pro.Entity.IPresentation.Types.ISlideShow.ISlideShowDuration>();
						r.SlideShow.Set(slideShowDuration);
					}
					slideShowDuration.Set(l.SlideShowDuration);
				}
			}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
			{
				if (r.SlideShow.Value is Pro.Entity.IPresentation.Types.ISlideShow.ISlideShowDuration slideShowDuration2)
				{
					l.SlideShowDuration = slideShowDuration2.Value;
					l.SlideShowEnabled = true;
				}
				else
				{
					l.SlideShowEnabled = false;
				}
			});
		return objectBinder;
	}

	private void BindCuesAndGroups(ObjectBinder<PresentationBase, Pro.Entity.IPresentation> binder, IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		binder.Bind((PresentationBase l) => Observable.Merge<Unit>(l.ArrangementGroups.WhenCollectionChanges().ToUnit(), Observable.FromEvent(delegate(Action<CueGroupCollection> h)
		{
			l.ArrangementGroups.CuesChanged += h;
		}, delegate(Action<CueGroupCollection> h)
		{
			l.ArrangementGroups.CuesChanged -= h;
		}).ToUnit(), l.Arrangements.WhenCollectionChanges().ToUnit()), (Pro.Entity.IPresentation r) => Observable.Merge<Unit>(r.CueGroups.WhenCollectionChanges.ToUnit(), r.Cues.WhenCollectionChanges.ToUnit(), r.Arrangements.WhenCollectionChanges.ToUnit()), delegate(PresentationBase l, Pro.Entity.IPresentation r)
		{
			r.CueGroups.SynchronizeFrom(l.ArrangementGroups, (CueGroup m, Pro.Entity.IPresentation.Types.ICueGroup e) => m.ID == e.Group.Value.Uuid.Value, delegate(CueGroup m)
			{
				Pro.Entity.IPresentation.Types.ICueGroup cueGroup = factoryProvider.EntityFactory.Create<Pro.Entity.IPresentation.Types.ICueGroup>();
				ObjectBinder<CueGroup, Pro.Entity.IPresentation.Types.ICueGroup> objectBinder = CueGroup.CreateBinder(factoryProvider, m, cueGroup);
				cueGroup.RegisterLinkedDisposable(objectBinder);
				objectBinder.InitializeRightFromLeft();
				return cueGroup;
			});
			foreach (CueGroup group in l.ArrangementGroups)
			{
				Pro.Entity.IPresentation.Types.ICueGroup entityGroup = r.CueGroups.Items.FirstOrDefault((Pro.Entity.IPresentation.Types.ICueGroup g) => g.Group.Value.Uuid.Value == group.ID);
				if (entityGroup != null)
				{
					group.Cues.SynchronizeTo(entityGroup.CueIdentifiers.Items, (SlideCue m, Guid e) => m.ID == e, delegate(SlideCue m, int i)
					{
						entityGroup.CueIdentifiers.Insert(i, m.ID);
					}, entityGroup.CueIdentifiers.Move, entityGroup.CueIdentifiers.RemoveAt);
				}
			}
			HashSet<Guid> localCueIds = new HashSet<Guid>(l.Cues.Select((SlideCue c) => c.ID));
			foreach (Guid item in r.Cues.Items.Keys.Where((Guid k) => !localCueIds.Contains(k)).ToList())
			{
				r.Cues.Remove(item);
			}
			foreach (SlideCue cue2 in l.Cues)
			{
				if (!r.Cues.Items.ContainsKey(cue2.ID))
				{
					ICue cue = entityFactory.Create<ICue>();
					ObjectBinder<Pro.DO.Triggering.Cue, ICue> objectBinder2 = Pro.DO.Triggering.Cue.CreateBinder(scheduler, entityFactory, actionBinderFactory, cue2, cue);
					cue.RegisterLinkedDisposable(objectBinder2);
					objectBinder2.InitializeRightFromLeft();
					r.Cues.Add(cue2.ID, cue);
				}
			}
			r.Arrangements.SynchronizeFrom(l.Arrangements.OfType<Arrangement>().ToList(), (Arrangement m, Pro.Entity.IPresentation.Types.IArrangement e) => m.ID == e.Uuid.Value, delegate(Arrangement m)
			{
				Pro.Entity.IPresentation.Types.IArrangement arrangement = entityFactory.Create<Pro.Entity.IPresentation.Types.IArrangement>();
				ObjectBinder<Arrangement, Pro.Entity.IPresentation.Types.IArrangement> objectBinder3 = m.Bind(scheduler, arrangement, () => l.ArrangementGroups);
				arrangement.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeRightFromLeft();
				return arrangement;
			});
		}, delegate(Pro.Entity.IPresentation r, PresentationBase l)
		{
			r.CueGroups.Items.SynchronizeTo(l.ArrangementGroups, (Pro.Entity.IPresentation.Types.ICueGroup e, CueGroup m) => m.ID == e.Group.Value.Uuid.Value, delegate(Pro.Entity.IPresentation.Types.ICueGroup e, int i)
			{
				GroupLabel label = new GroupLabel(e.Group.Value.Name.Value, e.Group.Value.Color.Value?.ToColor() ?? Colors.Transparent);
				CueGroup cueGroup2 = new CueGroup(l, label, factoryProvider, l.TransitionDescriptions);
				ObjectBinder<CueGroup, Pro.Entity.IPresentation.Types.ICueGroup> objectBinder4 = CueGroup.CreateBinder(factoryProvider, cueGroup2, e);
				e.RegisterLinkedDisposable(objectBinder4);
				objectBinder4.InitializeLeftFromRight();
				l.ArrangementGroups.InsertArrangementGroup(i, cueGroup2);
			}, l.ArrangementGroups.Move, delegate(int i)
			{
				CueGroup cueGroup3 = l.ArrangementGroups.ElementAtOrDefault(i);
				if (cueGroup3 != null)
				{
					l.ArrangementGroups.RemoveArrangementGroup(cueGroup3);
				}
			});
			foreach (Pro.Entity.IPresentation.Types.ICueGroup entityGroup2 in r.CueGroups.Items)
			{
				CueGroup group2 = l.ArrangementGroups.FirstOrDefault((CueGroup g) => g.ID == entityGroup2.Group.Value.Uuid.Value);
				if (group2 != null)
				{
					entityGroup2.CueIdentifiers.Items.SynchronizeTo(group2.Cues, (Guid e, SlideCue m) => m != null && m.ID == e, delegate(Guid e, int i)
					{
						if (r.Cues.Items.TryGetValue(e, out ICue value))
						{
							SlideCue slideCue = new SlideCue(factoryProvider, new CustomSlide(factoryProvider, l.TransitionDescriptions), l.TransitionDescriptions);
							slideCue.UpdateContainerId(l.ContainerId);
							ObjectBinder<Pro.DO.Triggering.Cue, ICue> objectBinder5 = Pro.DO.Triggering.Cue.CreateBinder(scheduler, entityFactory, actionBinderFactory, slideCue, value);
							value.RegisterLinkedDisposable(objectBinder5);
							objectBinder5.InitializeLeftFromRight();
							group2.Cues.InsertCue(i, slideCue);
						}
					}, group2.Cues.Move, delegate(int i)
					{
						SlideCue slideCue2 = group2.Cues.ElementAtOrDefault(i);
						if (slideCue2 != null)
						{
							group2.Cues.RemoveCue(slideCue2);
						}
					});
				}
			}
			r.Arrangements.Items.SynchronizeTo(l.Arrangements, (Pro.Entity.IPresentation.Types.IArrangement e, IArrangement m) => m.ID == e.Uuid.Value, delegate(Pro.Entity.IPresentation.Types.IArrangement e, int i)
			{
				Arrangement arrangement2 = new Arrangement(l.UndoStack, canShowGroupLabel: true);
				ObjectBinder<Arrangement, Pro.Entity.IPresentation.Types.IArrangement> objectBinder6 = arrangement2.Bind(scheduler, e, () => l.ArrangementGroups);
				e.RegisterLinkedDisposable(objectBinder6);
				objectBinder6.InitializeLeftFromRight();
				l.Arrangements.InsertArrangement(i, arrangement2);
			}, l.Arrangements.Move, delegate(int i)
			{
				IArrangement arrangement3 = l.Arrangements.ElementAtOrDefault(i);
				if (arrangement3 != null)
				{
					l.Arrangements.RemoveArrangement(arrangement3);
				}
			});
		}, null, scheduler.Scheduler);
	}

	private static ObjectBinder<PresentationBase, Pro.Entity.IPresentation.Types.IMusic> CreateMusicBinder(IEntityFactory entifyFactory, PresentationBase left, Pro.Entity.IPresentation.Types.IMusic right)
	{
		ObjectBinder<PresentationBase, Pro.Entity.IPresentation.Types.IMusic> objectBinder = new ObjectBinder<PresentationBase, Pro.Entity.IPresentation.Types.IMusic>(left, right);
		objectBinder.Bind((PresentationBase l) => l.WhenPropertyChanges("BaseKey"), (Pro.Entity.IPresentation.Types.IMusic r) => r.Original.WhenAnyValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation.Types.IMusic r)
		{
			IMusicKeyScale musicKeyScale = entifyFactory.Create<IMusicKeyScale>();
			musicKeyScale.MusicKey.Set(l.BaseKey?.Note.ToEntityMusicNote() ?? IMusicKeyScale.Types.MusicKey.AFlat);
			musicKeyScale.MusicScale.Set(l.BaseKey?.Scale.ToEntityMusicScale() ?? IMusicKeyScale.Types.MusicScale.Major);
			r.Original.Set(musicKeyScale);
		}, delegate(Pro.Entity.IPresentation.Types.IMusic r, PresentationBase l)
		{
			l.BaseKey = new Key(r.Original.Value.MusicKey.Value.ToNote(), r.Original.Value.MusicScale.Value.ToScale());
		}).Bind((PresentationBase l) => l.WhenPropertyChanges("TargetKey"), (Pro.Entity.IPresentation.Types.IMusic r) => r.User.WhenAnyValueChanges, delegate(PresentationBase l, Pro.Entity.IPresentation.Types.IMusic r)
		{
			IMusicKeyScale musicKeyScale2 = entifyFactory.Create<IMusicKeyScale>();
			musicKeyScale2.MusicKey.Set(l.TargetKey?.Note.ToEntityMusicNote() ?? IMusicKeyScale.Types.MusicKey.AFlat);
			musicKeyScale2.MusicScale.Set(l.TargetKey?.Scale.ToEntityMusicScale() ?? IMusicKeyScale.Types.MusicScale.Major);
			r.User.Set(musicKeyScale2);
		}, delegate(Pro.Entity.IPresentation.Types.IMusic r, PresentationBase l)
		{
			l.TargetKey = new Key(r.User.Value.MusicKey.Value.ToNote(), r.User.Value.MusicScale.Value.ToScale());
		});
		return objectBinder;
	}

	protected virtual void RefreshMissingFontsCache()
	{
		_hasMissingFonts = false;
	}

	private void ActiveArrangementOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		ActiveArrangementName = ActiveArrangement?.Name;
	}

	protected PresentationBase(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime)
	{
		App = app;
		TimerFactory = timerFactory;
		FactoryProvider = factoryProvider;
		MediaFactory = factoryProvider.MediaFactory;
		TransitionDescriptions = transitionDescriptions;
		MessageDialogService = messageDialogService;
		CurrentTime = currentTime;
		_arrangementGroups = new CueGroupCollection(this, factoryProvider, transitionDescriptions);
		_arrangements = new ArrangementCollection(this, CanShowGroupLabel);
		_timeline = new Timeline(this, app, MediaFactory, transitionDescriptions);
		_lastModifiedDate = CurrentTime.Now;
		ArrangementGroups.DataModifed += delegate
		{
			OnDataModified();
		};
		Arrangements.DataModified += delegate
		{
			OnDataModified();
		};
		PresentationTimeline.DataModified += delegate
		{
			OnDataModified();
		};
		CCLIInfo.UndoStack = UndoStack;
		CCLIInfo.DataModified += delegate
		{
			OnDataModified();
		};
	}

	public abstract IPresentation Clone();

	public IEnumerable<string> GetAllMediaFilePaths()
	{
		IEnumerable<string> enumerable = Array.Empty<string>();
		Pro.SerializationInterop.RVProtoData.Presentation presentation = _pendingLoadData?.ProtoData;
		if (presentation != null)
		{
			RepeatedField<Pro.SerializationInterop.RVProtoData.Cue> cues = presentation.Cues;
			if (cues != null)
			{
				enumerable = enumerable.Concat(cues.SelectMany((Pro.SerializationInterop.RVProtoData.Cue c) => getMediaActionPaths(c.Actions)));
				enumerable = enumerable.Concat((from f in cues.GetProtoMediaFills()
					select f.Url into u
					select new RelativePath(u).FullPath).NonNull());
			}
			Pro.SerializationInterop.RVProtoData.Presentation.Types.Timeline timeline = presentation.Timeline;
			if (timeline != null)
			{
				enumerable = enumerable.Concat(getMediaActionPaths((from c in timeline.Cues.Concat(timeline.CuesV2)
					select c.Action).NotNull()));
				URL uRL = timeline.AudioAction?.Media?.Element.Url;
				if (uRL != null)
				{
					string fullPath = new RelativePath(uRL).FullPath;
					if (fullPath != null)
					{
						enumerable = enumerable.Append(fullPath);
					}
				}
			}
			return enumerable.Distinct();
		}
		enumerable = enumerable.Concat(Cues.SelectMany((SlideCue c) => from m in c.Actions.FindAllMedia().OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull());
		foreach (SlideCue cue in Cues)
		{
			SlideElementCollection elements = (cue.SlideAction?.Slide as CustomSlide)?.Elements;
			enumerable = enumerable.Concat((from m in elements.FindAllMedia().OfType<FileMediaBase>()
				select m.SourceFile.FullPath).NonNull());
		}
		return enumerable.Concat((from m in PresentationTimeline.Select((TimelineItemInfo t) => t.Item).OfType<Pro.DO.Triggering.IAction>().FindAllMedia()
				.OfType<FileMediaBase>()
			select m.SourceFile.FullPath).NonNull());
		static IEnumerable<string> getMediaActionPaths(IEnumerable<Pro.SerializationInterop.RVProtoData.Action> actions)
		{
			return (from u in actions.Select((Pro.SerializationInterop.RVProtoData.Action a) => a.Media?.Element.Url).NonNull()
				select new RelativePath(u).FullPath).NonNull();
		}
	}

	public IPresentation CloneWithID()
	{
		PresentationBase obj = (PresentationBase)Clone();
		obj.ID = ID;
		return obj;
	}

	public Pro.DO.Triggering.IAction? AddSlideAction(IEnumerable<SlideCue> targetSlideCues, Pro.DO.Triggering.IAction action, bool cloneAction, ArrangedCue? selectedSlide = null)
	{
		if (action == null)
		{
			return action;
		}
		UndoStack.BeginCommit(new TaggedUndoAction<Pro.DO.Reversibility.UndoActionTypes>(Pro.DO.Reversibility.UndoActionTypes.AddAction));
		Pro.DO.Triggering.IAction actionToEdit = null;
		targetSlideCues.ForEach(delegate(SlideCue c)
		{
			Pro.DO.Triggering.IAction action2 = (cloneAction ? action.Clone() : action);
			c.AddAction(action2);
			if (selectedSlide == null || c.Equals(selectedSlide.Source))
			{
				actionToEdit = action2;
			}
		});
		UndoStack.EndCommit(null, null, autoFinalize: true);
		return actionToEdit;
	}

	public void AddGoToNextTimer(IEnumerable<SlideCue> targetSlideCues, TimeSlice time, bool loopToBeginning)
	{
		UndoStack.BeginCommit(new TaggedUndoAction<Pro.DO.Reversibility.UndoActionTypes>(Pro.DO.Reversibility.UndoActionTypes.AddAction));
		targetSlideCues.ForEach(delegate(SlideCue cue)
		{
			cue.GotoNext = new GotoNext(time, loopToBeginning: false);
		});
		GotoNext gotoNext = targetSlideCues.Last().GotoNext;
		if (gotoNext != null)
		{
			gotoNext.LoopToBeginning = loopToBeginning;
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void AssignSlideLabel(ActionLabel? label, IEnumerable<SlideCue> cues)
	{
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignSlideLabel.ToAction());
		cues.ForEach(delegate(SlideCue c)
		{
			if (c.SlideAction != null)
			{
				c.SlideAction.Label = label;
			}
		});
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void AssignSlideColor(System.Windows.Media.Color color, IEnumerable<SlideCue> cues)
	{
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignSlideLabel.ToAction());
		cues.Select((SlideCue s) => s.SlideAction?.Label).NonNull().ForEach(delegate(ActionLabel l)
		{
			l.Color = color;
		});
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void AssignGroupLabel(GroupLabel? label, IEnumerable<ArrangedCue>? cues)
	{
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignLabel.ToAction());
		foreach (ArrangedCue groupHeader in GetGroupHeaders(cues))
		{
			CueGroup group = groupHeader.Group;
			if (groupHeader.IsGroupHead)
			{
				ReplaceGroup(label ?? new GroupLabel(), group);
			}
			else
			{
				SplitGroup(label ?? new GroupLabel(), groupHeader, group);
			}
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void AssignGroupColor(System.Windows.Media.Color color, IEnumerable<ArrangedCue>? cues)
	{
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignLabel.ToAction());
		cues?.Select((ArrangedCue s) => s.Group.Label).NonNull().Distinct()
			.ForEach(delegate(GroupLabel l)
			{
				l.Color = color;
			});
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void UngroupCues(IEnumerable<ArrangedCue> cues, IArrangement? activeArrangement = null)
	{
		activeArrangement = activeArrangement ?? ActiveArrangement ?? DefaultArrangement;
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignLabel.ToAction());
		ArrangedCue[] array = GetGroupHeaders(cues).ToArray();
		if (array.Any((ArrangedCue c) => c.IsGroupHead))
		{
			foreach (CueGroup[] item in array.Select((ArrangedCue c) => c.Group).Distinct().ContiguousGroups((CueGroup g1, CueGroup g2) => g1 == g2))
			{
				MergeGroups(item, activeArrangement);
			}
		}
		else
		{
			ArrangedCue[] array2 = array;
			foreach (ArrangedCue arrangedCue in array2)
			{
				SplitGroup(new GroupLabel(DefaultGroupName), arrangedCue, arrangedCue.Group);
			}
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	private static IEnumerable<ArrangedCue> GetGroupHeaders(IEnumerable<ArrangedCue>? cues)
	{
		return (from s in cues?.Distinct((ArrangedCue s) => s.Source)
			group s by s.GroupLabel into g
			select g.First()) ?? Enumerable.Empty<ArrangedCue>();
	}

	private void MergeGroups(IEnumerable<CueGroup> groupsToMerge, IEnumerable<CueGroup> availableGroups)
	{
		foreach (CueGroup item in groupsToMerge)
		{
			bool isNext2;
			CueGroup cueGroup = findAdjacentGroup(item, out isNext2);
			if (cueGroup == null)
			{
				ReplaceGroup(new GroupLabel(DefaultGroupName), item);
				continue;
			}
			SlideCue[] cues = item.Cues.ToArray();
			item.Cues.Clear();
			cueGroup.Cues.InsertCues((!isNext2) ? cueGroup.Cues.Count : 0, cues);
			RemoveEmptyGroups();
		}
		CueGroup? findAdjacentGroup(CueGroup target, out bool isNext)
		{
			CueGroup previous = availableGroups.GetPrevious(target);
			isNext = previous == null;
			return previous ?? availableGroups.GetNext(target);
		}
	}

	private static void ReplaceGroup(GroupLabel label, CueGroup group)
	{
		group.AssignLabel(label);
	}

	private void SplitGroup(GroupLabel label, ArrangedCue firstSlide, CueGroup group)
	{
		IArrangement arrangement = Arrangements.FirstOrDefault((IArrangement a) => a.ArrangedCues.Contains(firstSlide));
		SlideCue[] cues = group.Cues.SkipWhile((SlideCue s) => s != firstSlide.Source).ToArray();
		int index = ArrangementGroups.IndexOf(group) + 1;
		CueGroup newGroup = new CueGroup(this, label, FactoryProvider, TransitionDescriptions);
		group.Cues.RemoveCues(cues);
		newGroup.Cues.AddCues(cues);
		ArrangementGroups.InsertArrangementGroup(index, newGroup);
		UndoStack.Commit(delegate
		{
			ArrangementGroups.RemoveArrangementGroup(newGroup);
		}, delegate
		{
			ArrangementGroups.InsertArrangementGroup(index, newGroup);
		});
		arrangement?.InsertArrangementGroup(arrangement.IndexOf(group) + 1, newGroup);
	}

	private void RemoveEmptyGroups()
	{
		CueGroup[] array = ArrangementGroups.Where((CueGroup g) => !g.Cues.Any()).ToArray();
		foreach (CueGroup group in array)
		{
			int index = ArrangementGroups.IndexOf(group);
			ArrangementGroups.RemoveArrangementGroup(group);
			foreach (IArrangement item in Arrangements.Where((IArrangement a) => a.Contains(group)))
			{
				CueGroup[] group2 = item.Where((CueGroup g) => g.IsSameGroup(group)).Distinct().ToArray();
				item.RemoveArrangementGroups(group2);
			}
			if (UndoStack.IsRecording)
			{
				UndoStack.Commit(delegate
				{
					ArrangementGroups.InsertArrangementGroup(index, group);
				}, delegate
				{
					ArrangementGroups.RemoveArrangementGroup(group);
				});
			}
		}
	}

	public void ResetCueClick()
	{
		_clickedCues.Clear();
	}

	public void IncreaseCueClick(ArrangedCue clickedCue)
	{
		IArrangement arrangement = ActiveArrangement ?? DefaultArrangement;
		if (arrangement.ArrangedCues.Any() && arrangement.ArrangedCues.Count > 1 && !_clickedCues.Contains(clickedCue) && arrangement.ArrangedCues.Contains(clickedCue))
		{
			_clickedCues.Add(clickedCue);
			if ((double)_clickedCues.Count >= Math.Ceiling((double)arrangement.ArrangedCues.Count / 2.0))
			{
				LastUsed = DateTime.Now;
				_clickedCues.Clear();
			}
		}
	}

	public void ToggleCues(IEnumerable<ArrangedCue> cues, bool isEnabled)
	{
		UndoStack.BeginCommit(new TaggedUndoAction<Pro.DO.Reversibility.UndoActionTypes>(Pro.DO.Reversibility.UndoActionTypes.CueEnabled));
		cues.Select((ArrangedCue c) => c.Source).Distinct().ForEach(delegate(SlideCue a)
		{
			a.IsEnabled = isEnabled;
		});
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void AssignHotkey(SlideCue cue, SlideHotkey? hotkey)
	{
		UndoStack.BeginCommit(Pro.DO.Reversibility.UndoActionTypes.AssignHotkey.ToAction());
		Cues.Where((SlideCue c) => c.Hotkey == hotkey).ForEach(delegate(SlideCue c)
		{
			c.Hotkey = null;
		});
		cue.Hotkey = hotkey;
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void ChangeSize(Vector2<double> size)
	{
		UndoStack.BeginCommit(UndoActionTypes.ChangePresentationResolution.ToAction());
		Size = size;
		UndoStack.EndCommit(null, delegate
		{
			OnPropertyChanged("Size");
		}, autoFinalize: true);
	}

	public void CuesDroppedInto(IEnumerable<SlideCue> cues, SlideCue targetCue, bool droppedBefore, bool insertNewGroup, CueGroup targetGroup)
	{
		EnsureLoaded();
		UndoStack.BeginCommit(UndoActionTypes.AddSlide.ToAction());
		int index = targetGroup.Cues.IndexOf(targetCue) + ((!droppedBefore) ? 1 : 0);
		if (insertNewGroup)
		{
			targetGroup = CreateNewGroup(targetGroup, droppedBefore);
		}
		OnInsertCues(targetGroup, cues, index);
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	private CueGroup CreateNewGroup(CueGroup targetGroup, bool insertBefore)
	{
		int index = ArrangementGroups.IndexOf(targetGroup) + ((!insertBefore) ? 1 : 0);
		CueGroup newGroup = ArrangementGroups.InsertArrangementGroup(index, new GroupLabel(DefaultGroupName));
		int newGroupIndex = ArrangementGroups.IndexOf(newGroup);
		UndoStack.Commit(delegate
		{
			ArrangementGroups.RemoveArrangementGroup(newGroup);
		}, delegate
		{
			ArrangementGroups.InsertArrangementGroup(newGroupIndex, newGroup);
		});
		return newGroup;
	}

	public void MoveCuesTo(IEnumerable<SlideCue> cues, SlideCue targetCue, bool droppedBefore, bool insertNewGroup, CueGroup targetGroup, bool copy, IArrangement? activeArrangement = null)
	{
		if (!cues.All((SlideCue c) => c.ParentPresentation == this))
		{
			throw new InvalidOperationException("Slides must be part of this presentation");
		}
		if (activeArrangement == null)
		{
			activeArrangement = ActiveArrangement ?? DefaultArrangement;
		}
		UndoStack.BeginCommit(UndoActionTypes.MoveSlides.ToAction());
		CueGroup[] array = ArrangementGroups.Where((CueGroup g) => g.Cues.ContainsAny(cues)).ToArray();
		if (insertNewGroup && array.Length == 1 && cues.ContainsAll(array[0].Cues))
		{
			if (activeArrangement != Arrangements.MasterArrangement)
			{
				activeArrangement.MoveArrangementGroups(array, activeArrangement.IndexOf(targetGroup) + ((!droppedBefore) ? 1 : 0));
			}
			else
			{
				ArrangementGroups.MoveArrangementGroups(ArrangementGroups.IndexOf(targetGroup) + ((!droppedBefore) ? 1 : 0), array);
			}
		}
		else
		{
			List<SlideCue> list = new List<SlideCue>();
			foreach (SlideCue cue in cues)
			{
				if (copy || list.Contains(cue))
				{
					list.Add((SlideCue)cue.Clone());
				}
				else
				{
					list.Add(cue);
				}
			}
			int num = -1;
			if (!copy)
			{
				if (cues.Contains(targetCue))
				{
					num = targetGroup.Cues.IndexOf(targetCue) - cues.IndexOf(targetCue);
				}
				OnRemoveCues(cues, removeEmptyGroups: false, notifySlidesDeleted: false);
			}
			if (num < 0)
			{
				num = targetGroup.Cues.IndexOf(targetCue) + ((!droppedBefore) ? 1 : 0);
			}
			if (insertNewGroup)
			{
				CueGroup cueGroup = CreateNewGroup(targetGroup, droppedBefore);
				if (activeArrangement != Arrangements.MasterArrangement)
				{
					activeArrangement.InsertArrangementGroup(activeArrangement.IndexOf(targetGroup) + ((!droppedBefore) ? 1 : 0), cueGroup);
				}
				targetGroup = cueGroup;
			}
			targetGroup.Cues.InsertCues(num, list);
			RemoveEmptyGroups();
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public virtual void CutFrom(IEnumerable<SlidesCopyData> data)
	{
		UndoStack.BeginCommit(UndoActionTypes.CutSlide.ToAction());
		IEnumerable<SlideCue> cues = data.SelectMany((SlidesCopyData d) => d.Slides);
		OnRemoveCues(cues);
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public virtual void PasteInto(IEnumerable<SlidesCopyData> data, int index)
	{
		UndoStack.BeginCommit(UndoActionTypes.PasteSlide.ToAction());
		if (index < 0)
		{
			foreach (SlidesCopyData d in data)
			{
				IArrangement arrangement = Arrangements.FirstOrDefaultBy((IArrangement a) => d.ArrangementID.HasValue && d.ArrangementID.Value == a.ID, (IArrangement a) => d.ArrangementName == a.Name) ?? ActiveArrangement ?? DefaultArrangement;
				if (d.CreateGroup && CanShowGroupLabel)
				{
					index = ArrangementGroups.Count();
					d.Label.ThrowWhenNull("d.Label");
					CueGroup cueGroup = ArrangementGroups.InsertArrangementGroup(index, d.Label);
					cueGroup.Cues.AddCues(d.Slides);
					if (!arrangement.IsMaster)
					{
						arrangement.AddArrangementGroup(cueGroup);
					}
				}
				else
				{
					arrangement.LastOrDefault()?.Cues.AddCues(d.Slides);
				}
			}
		}
		else
		{
			OnInsertCues(data.SelectMany((SlidesCopyData s) => s.Slides), Cues.ElementAtOrDefault(index));
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	protected void OnDataModified()
	{
		if (DeserializationInProgress)
		{
			return;
		}
		_lastModifiedDate = CurrentTime.Now;
		if (UnitTestDetector.IsInUnitTest)
		{
			this.DataModified?.Invoke(this);
			return;
		}
		if (_timer == null)
		{
			_timer = TimerFactory.CreateOneShotDispatched(DataModifiedNotificationDelay, delegate
			{
				this.DataModified?.Invoke(this);
			});
		}
		if (!_timer.IsRunning())
		{
			_timer.Start();
		}
	}

	protected void OnInsertCue(SlideCue slide, SlideCue? targetSlide = null)
	{
		OnInsertCues(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(slide), targetSlide);
	}

	protected void OnInsertCues(IEnumerable<SlideCue> cues, SlideCue? cue = null, IArrangement? activeArrangement = null, bool insertBefore = false)
	{
		EnsureLoaded();
		IEnumerable<CueGroup> source = (IEnumerable<CueGroup>)(((object)activeArrangement) ?? ((object)ArrangementGroups));
		CueGroup cueGroup = ((cue != null) ? source.FirstOrDefault((CueGroup g) => g.Cues.Contains(cue)) : source.LastOrDefault()) ?? ArrangementGroups.AddArrangementGroup(new GroupLabel(DefaultGroupName));
		if (activeArrangement != null && !activeArrangement.Contains(cueGroup))
		{
			activeArrangement.AddArrangementGroup(cueGroup);
		}
		int index = ((cue != null) ? (cueGroup.Cues.IndexOf(cue) + ((!insertBefore) ? 1 : 0)) : cueGroup.Cues.Count);
		OnInsertCues(cueGroup, cues, index);
	}

	protected void OnInsertCues(CueGroup group, IEnumerable<SlideCue> cues, int index)
	{
		foreach (SlideCue cue in cues)
		{
			cue.Name = cue.Name.DuplicateName(Cues, (SlideCue c) => c.Name);
			if (!HasVariableSlideSizes && Size != Vector2<double>.Zero)
			{
				cue.SlideAction?.Slide.ChangeSize(Size);
			}
		}
		if (UndoStack.IsRecording)
		{
			UndoStack.Commit(RemoveEmptyGroups, delegate
			{
			});
		}
		group.Cues.InsertCues(index, cues);
	}

	protected void OnRemoveCues(IEnumerable<SlideCue> cues, bool removeEmptyGroups = true, bool notifySlidesDeleted = true)
	{
		cues = cues.Where(Cues.Contains<SlideCue>).Distinct().ToArray();
		if (!cues.Any() || !ArrangementGroups.Any())
		{
			return;
		}
		foreach (IGrouping<CueGroup, SlideCue> item in from s in cues
			group s by ArrangementGroups.First((CueGroup g) => g.Cues.Contains(s)))
		{
			item.Key.Cues.RemoveCues(item);
		}
		if (removeEmptyGroups)
		{
			RemoveEmptyGroups();
		}
		if (notifySlidesDeleted)
		{
			PresentationTimeline.RemoveItems(cues);
		}
	}

	protected PresentationBase CopyProperties(PresentationBase presentation)
	{
		presentation._name = Name;
		presentation.UseBackgroundColor = UseBackgroundColor;
		presentation.BackgroundColor = BackgroundColor;
		presentation._destination = _destination;
		presentation._notes = Notes;
		presentation._ccliData.Copy(CCLIInfo);
		presentation.SelectedTransition = _selectedTransition?.CloneTransitionParameters();
		presentation.SourceFile = SourceFile?.Clone();
		presentation.SlideShowEnabled = SlideShowEnabled;
		presentation.SlideShowDuration = SlideShowDuration;
		presentation.BaseKey = BaseKey;
		presentation.TargetKey = TargetKey;
		Dictionary<SlideCue, SlideCue> dictionary = new Dictionary<SlideCue, SlideCue>();
		Dictionary<Guid, CueGroup> groupMap = new Dictionary<Guid, CueGroup>();
		Dictionary<IArrangement, IArrangement> dictionary2 = new Dictionary<IArrangement, IArrangement>();
		foreach (CueGroup arrangementGroup in ArrangementGroups)
		{
			CueGroup cueGroup = presentation.ArrangementGroups.AddArrangementGroup(arrangementGroup.Label.Clone());
			groupMap.Add(arrangementGroup.ID, cueGroup);
			foreach (SlideCue cue in arrangementGroup.Cues)
			{
				SlideCue slideCue = (SlideCue)cue.Clone();
				dictionary.Add(cue, slideCue);
				cueGroup.Cues.AddCue(slideCue);
			}
		}
		foreach (IArrangement arrangement in Arrangements)
		{
			dictionary2.Add(arrangement, presentation.Arrangements.AddArrangement(arrangement.Name, arrangement.Select((CueGroup g) => groupMap.GetValueOrDefault(g.ID)).NonNull()));
		}
		if (ActiveArrangement != null && dictionary2.TryGetValue(ActiveArrangement, out var value))
		{
			presentation.ActiveArrangement = value;
		}
		presentation._timeline = new Timeline(_timeline, presentation);
		foreach (TimelineItemInfo item2 in PresentationTimeline)
		{
			Timeline presentationTimeline = presentation.PresentationTimeline;
			ITimelineItem item;
			if (!(item2.Item is SlideCue key))
			{
				item = item2.Item;
			}
			else
			{
				ITimelineItem timelineItem = dictionary[key];
				item = timelineItem;
			}
			presentationTimeline.AddItem(item, item2.SlideTime, item2.Name);
		}
		presentation.ChangeSize(Size);
		return presentation;
	}

	public Pro.SerializationInterop.RVProtoData.Presentation Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Presentation presentation = new Pro.SerializationInterop.RVProtoData.Presentation
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize(),
			Uuid = ID.ToUUID(),
			LastDateUsed = (LastUsed.HasValue ? LastUsed.Value.ToTimeStamp() : null),
			LastModifiedDate = _lastModifiedDate.ToTimeStamp(),
			Category = string.Empty,
			Notes = Notes,
			Name = Name,
			SelectedArrangement = (ActiveArrangement ?? DefaultArrangement).ID.ToUUID(),
			Ccli = CCLIInfo.Serialize(),
			Transition = SelectedTransition?.Serialize(),
			Timeline = PresentationTimeline.Serialize(),
			ContentDestination = Destination.ToProtoDestination()
		};
		presentation.Background = new Background
		{
			Color = BackgroundColor.ToProtoColor(),
			IsEnabled = UseBackgroundColor
		};
		presentation.Arrangements.AddRange(Arrangements.Select((IArrangement a) => a.Serialize()));
		presentation.CueGroups.AddRange(ArrangementGroups.Select((CueGroup a) => a.Serialize()));
		presentation.Cues.AddRange(from a in ArrangementGroups.SelectMany((CueGroup g) => g.Cues)
			select a.Serialize());
		presentation.BibleReference = SerializeBibleReference();
		presentation.MultiTracksLicensing = SerializeMultiTracksLicensing();
		if (SlideShowEnabled)
		{
			presentation.SlideShowDuration = SlideShowDuration;
		}
		if (BaseKey != null || TargetKey != null)
		{
			presentation.Music = new Pro.SerializationInterop.RVProtoData.Presentation.Types.Music
			{
				Original = BaseKey?.ToProtoMusicKeyScale(),
				User = TargetKey?.ToProtoMusicKeyScale()
			};
		}
		return presentation;
	}

	protected virtual Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference? SerializeBibleReference()
	{
		return null;
	}

	protected virtual Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing? SerializeMultiTracksLicensing()
	{
		return null;
	}

	public void Deserialize(IPresentationLoadData data, string filename)
	{
		if (data != null)
		{
			DeserializationInProgress = true;
			UndoStack.StartIgnoring();
			ID = data.PresentationID ?? Guid.NewGuid();
			Destination = data.PresentationDestination.GetValueOrDefault();
			ActiveArrangementName = data.PresentationActiveArrangementName;
			LastUsed = data.PresentationLastUsed;
			_lastModifiedDate = data.PresentationLastModified ?? DateTime.MinValue;
			_name = filename;
			if (data.CopyrightInfoData != null)
			{
				Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI cCLI = new Pro.SerializationInterop.RVProtoData.Presentation.Types.CCLI();
				cCLI.MergeFrom(data.CopyrightInfoData);
				_ccliData.Deserialize(cCLI);
			}
			_pendingLoadData = data;
			IsPendingLoad = true;
			UndoStack.StopIgnoring();
			DeserializationInProgress = false;
		}
	}

	public void EnsureLoaded()
	{
		if (!IsPendingLoad)
		{
			return;
		}
		IsPendingLoad = false;
		Pro.SerializationInterop.RVProtoData.Presentation data = _pendingLoadData?.ProtoData;
		_pendingLoadData = null;
		if (data == null)
		{
			return;
		}
		DeserializationInProgress = true;
		ApplicationData applicationData = ApplicationData.Deserialize(data.ApplicationInfo);
		UndoStack.StartIgnoring();
		Notes = data.Notes;
		BackgroundColor = data.Background?.Color?.ToColor() ?? Colors.Transparent;
		UseBackgroundColor = data.Background?.IsEnabled ?? false;
		ArrangementGroups.Clear();
		Arrangements.Deserialize(data.Arrangements);
		ActiveArrangement = Arrangements.FirstOrDefault(delegate(IArrangement a)
		{
			Guid iD = a.ID;
			Guid? obj = data.SelectedArrangement?.ToGuid();
			return iD == obj;
		});
		if (data.SlideShowCase == Pro.SerializationInterop.RVProtoData.Presentation.SlideShowOneofCase.SlideShowDuration)
		{
			SlideShowDuration = data.SlideShowDuration;
			SlideShowEnabled = true;
		}
		BaseKey = data.Music?.Original?.ToKey();
		TargetKey = data.Music?.User?.ToKey();
		DeserializeMultiTracksLicensing(data.MultiTracksLicensing);
		_ccliData.Deserialize(data.Ccli);
		TransitionDescriptions.ThrowWhenNull("TransitionDescriptions");
		SelectedTransition = data.Transition?.ToTransition(TransitionDescriptions);
		foreach (Pro.SerializationInterop.RVProtoData.Presentation.Types.CueGroup cueGroup3 in data.CueGroups)
		{
			GroupLabel group = ((cueGroup3.Group == null) ? new GroupLabel() : new GroupLabel(cueGroup3.Group.Name, cueGroup3.Group.Color?.ToColor()));
			CueGroup cueGroup = ArrangementGroups.AddArrangementGroup(group);
			if (cueGroup3.Group?.Uuid != null)
			{
				Guid protoGroupID = cueGroup3.Group.Uuid.ToGuid();
				if (ArrangementGroups.Any((CueGroup g) => g.ID == protoGroupID))
				{
					cueGroup3.Group.Uuid = null;
				}
			}
			cueGroup.Deserialize(cueGroup3, data.Cues, applicationData, ContainerId);
		}
		foreach (Pro.SerializationInterop.RVProtoData.Presentation.Types.Arrangement protoArrangement in data.Arrangements)
		{
			IArrangement arrangement = Arrangements.FirstOrDefault(delegate(IArrangement a)
			{
				Guid iD2 = a.ID;
				Guid? obj2 = protoArrangement.Uuid?.ToGuid();
				return iD2 == obj2;
			});
			if (arrangement == null)
			{
				continue;
			}
			arrangement.Clear();
			foreach (UUID groupID in protoArrangement.GroupIdentifiers)
			{
				CueGroup cueGroup2 = ArrangementGroups.FirstOrDefault((CueGroup g) => g.ID == groupID.ToGuid());
				if (cueGroup2 != null)
				{
					arrangement.AddArrangementGroup(cueGroup2);
				}
			}
		}
		PresentationTimeline.Deserialize(data.Timeline, applicationData, ContainerId);
		DeserializeBibleReference(data.BibleReference);
		UndoStack.StopIgnoring();
		DeserializationInProgress = false;
		if (!HasDataLoaded)
		{
			HasDataLoaded = true;
			this.DataFirstLoaded?.Invoke(this);
		}
	}

	protected virtual void DeserializeBibleReference(Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference bibleReference)
	{
	}

	protected virtual void DeserializeMultiTracksLicensing(Pro.SerializationInterop.RVProtoData.Presentation.Types.MultiTracksLicensing multiTracksLicensing)
	{
	}

	public void ResetID(bool notifyDataModified)
	{
		ID = Guid.NewGuid();
		if (notifyDataModified)
		{
			OnDataModified();
		}
	}

	public int FixDuplicatedFillMediaIds()
	{
		return (_pendingLoadData?.ProtoData)?.Cues.FixMediaFillIds() ?? Cues.FixMediaFillIds();
	}

	public void InvalidateMissingFontsCache()
	{
		_hasMissingFonts = null;
		OnPropertyChanged("HasMissingFonts");
	}
}
