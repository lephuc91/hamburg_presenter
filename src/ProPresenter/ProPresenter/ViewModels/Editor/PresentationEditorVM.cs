using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.ViewModels.Editor;

public class PresentationEditorVM : SlideEditorVM, IPresentationEditorVM, ISlideEditorVM, INotifyPropertyChanged
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass93_0
	{
		public CustomSlide slide;

		internal bool _003CGetSlideCueFromSelectedSlides_003Eb__1(SlideCue c)
		{
			return c.SlideAction?.Slide == slide;
		}
	}

	[CompilerGenerated]
	private sealed class _003CGetSlideCueFromSelectedSlides_003Ed__93 : IEnumerable<SlideCue>, IEnumerable, IEnumerator<SlideCue>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private SlideCue _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public PresentationEditorVM _003C_003E4__this;

		private IEnumerator<CustomSlide> _003C_003E7__wrap1;

		SlideCue IEnumerator<SlideCue>.Current
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
		public _003CGetSlideCueFromSelectedSlides_003Ed__93(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				PresentationEditorVM presentationEditorVM = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E7__wrap1 = presentationEditorVM.SelectedSlides.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003Ec__DisplayClass93_0 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass93_0
					{
						slide = _003C_003E7__wrap1.Current
					};
					SlideCue slideCue = (presentationEditorVM.Presentation?.DefaultArrangement.ArrangedCues.Select((ArrangedCue a) => a.Source))?.FirstOrDefault((SlideCue c) => c.SlideAction?.Slide == CS_0024_003C_003E8__locals1.slide);
					if (slideCue != null)
					{
						_003C_003E2__current = slideCue;
						_003C_003E1__state = 1;
						return true;
					}
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<SlideCue> IEnumerable<SlideCue>.GetEnumerator()
		{
			_003CGetSlideCueFromSelectedSlides_003Ed__93 result;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				result = this;
			}
			else
			{
				result = new _003CGetSlideCueFromSelectedSlides_003Ed__93(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			return result;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<SlideCue>)this).GetEnumerator();
		}
	}

	private readonly Dictionary<CueGroup, CueGroupKey> _cueGroupKeyCache = new Dictionary<CueGroup, CueGroupKey>();

	private CustomPresentation? _presentation;

	private Dictionary<CustomSlide, SlideCue>? _slideCueMap;

	private bool _applyTemplateMediaAction;

	public ObservableCollection<CueGroupKey> CueGroupKeys { get; } = new ObservableCollection<CueGroupKey>();

	public override CommandTargetType CommandTargetType => CommandTargetType.SlideEditor;

	public Theme StageTheme => DataVault.Themes.StageTheme;

	public CustomPresentation? Presentation
	{
		get
		{
			return _presentation;
		}
		set
		{
			SetValue<CustomPresentation>("Presentation", ref _presentation, value, delegate(CustomPresentation o, CustomPresentation n)
			{
				if (o != null)
				{
					TeardownPresentation(o);
				}
				if (n != null)
				{
					SetupPresentation(n);
				}
				base.DocumentInspectorVM.Presentation = n;
				base.SlideInspectorVM.Presentation = n;
				OnPropertyChanged("UseSecondaryBackground");
				OnPropertyChanged("SecondaryBackgroundColor");
				OnPropertyChanged("SecondaryBackground");
			});
		}
	}

	protected override Color PrimaryBackgroundColor => base.SelectedSlide?.BackgroundColor ?? base.PrimaryBackgroundColor;

	protected override Color SecondaryBackgroundColor => Presentation?.BackgroundColor ?? base.SecondaryBackgroundColor;

	public override string SelectedItemName
	{
		get
		{
			if (base.SelectedSlide == null || _slideCueMap == null || !_slideCueMap.TryGetValue(base.SelectedSlide, out SlideCue value))
			{
				return string.Empty;
			}
			return value.Name;
		}
		set
		{
			if (base.SelectedSlide != null && _slideCueMap != null)
			{
				_slideCueMap[base.SelectedSlide].Name = value;
				OnPropertyChanged("SelectedItemName");
			}
		}
	}

	public override bool UsePrimaryBackground
	{
		get
		{
			return base.SelectedSlide?.UseBackgroundColor ?? false;
		}
		set
		{
			if (base.SelectedSlide != null)
			{
				base.SelectedSlide.UseBackgroundColor = value;
			}
		}
	}

	public override bool UseSecondaryBackground
	{
		get
		{
			return Presentation?.UseBackgroundColor ?? false;
		}
		set
		{
			if (Presentation != null)
			{
				Presentation.UseBackgroundColor = value;
			}
		}
	}

	public override ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, () => base.SelectedSlides.Any());

	public override ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => base.SelectedSlides.Any());

	public override ICommand CutCommand => new RelayCommand(OnCutCommand, () => base.SelectedSlides.Any());

	public override ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, () => base.SelectedSlides.Any());

	public override ICommand PasteSlidesCommand => new RelayCommand(OnPasteCommand, CanPasteSlides);

	public override ICommand<TemplateSlide> AddCommand => new RelayCommand<TemplateSlide>(AddCommandExecuted, (TemplateSlide t) => Presentation != null && Presentation.IsAvailable);

	private IEnumerable<CustomSlide> SelectableSlides => CueGroupKeys.Where((CueGroupKey k) => k.IsVisible).SelectMany(GetSlidesFromKey);

	public override ICommand MoveNextSlideCommand => new RelayCommand(OnMoveNextSlideCommand, () => SelectableSlides.Any() && SelectableSlides.LastOrDefault() != base.SelectedSlide);

	public override ICommand MovePreviousSlideCommand => new RelayCommand(OnMovePreviousSlideCommand, () => SelectableSlides.Any() && SelectableSlides.FirstOrDefault() != base.SelectedSlide);

	public ICommand<ScreenArrangementBase> ShowStageLayoutToTargetScreenCommand => new RelayCommand<ScreenArrangementBase>(OnShowStageLayoutToTargetScreenCommand, (ScreenArrangementBase s) => base.SelectedSlide != null);

	public override ICommand BreakTextToNewSlideCommand => new RelayCommand(OnBreakTextToNewSlideCommand, () => base.EditMode == EditMode.Presentation);

	public override ICommand BreakTextToNextSlideCommand => new RelayCommand(OnBreakTextToNextSlideCommand, () => base.EditMode == EditMode.Presentation);

	public ICommand<TemplateSlide> ApplyTemplateToSelectedSlidesCommand => new RelayCommand<TemplateSlide>(ApplyTemplateToSelectedSlidesCommandExecuted, (TemplateSlide t) => base.EditMode == EditMode.Presentation && base.SelectedSlides.Any() && t != null);

	public override ICommand<TemplateSlide> SelectTemplateCommand => ApplyTemplateToSelectedSlidesCommand;

	public PresentationEditorVM(IEditorService service, IMessageService messageService, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, IApp app, ITimerFactory timerFactory, IImport import, IProPresenterResourceService resourceService, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IFlagService flagService, IGeneral general, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime)
		: base(service, app, timerFactory, import, resourceService, processHelper, fileSystem, advanced, general, importProcessFactory, factoryProvider, transitionDescriptions, messageDialogService, flagService, currentTime, overlayVMFactory)
	{
		messageService?.SubscribeToMessage<ThemePickerSettingsUpdatedMessage>(HandleSettingsUpdated);
		CueGroupKeys.CollectionChanged += OnCueGroupKeysChanged;
		LinkProperties("UseBackgroundColor", new string[2] { "UsePrimaryBackground", "Background" });
		LinkProperties("BackgroundColor", new string[2] { "PrimaryBackgroundColor", "Background" });
		LinkProperties("UseBackgroundColor", new string[2] { "UseSecondaryBackground", "SecondaryBackground" });
		LinkProperties("BackgroundColor", new string[2] { "SecondaryBackgroundColor", "SecondaryBackground" });
	}

	private void HandleSettingsUpdated(IMessage message)
	{
		if (message is ThemePickerSettingsUpdatedMessage themePickerSettingsUpdatedMessage && themePickerSettingsUpdatedMessage.Model.ContextualGroup == ThemePickerGroup.Presentation)
		{
			_applyTemplateMediaAction = themePickerSettingsUpdatedMessage.Model.MediaActionEnabled;
		}
	}

	protected override void OnSelectedSlideChanged(CustomSlide? oldValue, CustomSlide? newValue)
	{
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= SlideInvalidated;
			SlideCue cueFromSlide = GetCueFromSlide(oldValue);
			if (cueFromSlide != null)
			{
				cueFromSlide.MediaActionVisualInvalidated -= MediaAction_VisualInvalidated;
			}
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += SlideInvalidated;
			SlideCue cueFromSlide2 = GetCueFromSlide(newValue);
			if (cueFromSlide2 != null)
			{
				if (base.EditMode == EditMode.Stage)
				{
					base.StageLayoutInspectorVM.SlideCue = cueFromSlide2;
				}
				cueFromSlide2.MediaActionVisualInvalidated += MediaAction_VisualInvalidated;
			}
		}
		OnPropertyChanged("UsePrimaryBackground");
		OnPropertyChanged("PrimaryBackgroundColor");
		OnPropertyChanged("Background");
		OnPropertyChanged("IncludeBackground");
		OnPropertyChanged("BackgroundImageScale");
		OnPropertyChanged("BackgroundImageAlignment");
		OnPropertyChanged("SelectedItemName");
		MediaAction_VisualInvalidated();
	}

	private void MediaAction_VisualInvalidated()
	{
		LoadBackgroundImageAsync().ExecuteAsync();
	}

	private void SlideInvalidated()
	{
		OnPropertyChanged("IncludeBackground");
		OnPropertyChanged("BackgroundImageScale");
		OnPropertyChanged("BackgroundImageAlignment");
	}

	protected override ArrangedCue GetArrangedCueFromSelectedSlide()
	{
		if (base.SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		return Presentation.DefaultArrangement.ArrangedCues.First((ArrangedCue a) => a.Source.SlideAction?.Slide == base.SelectedSlide);
	}

	private void TeardownPresentation(CustomPresentation presentation)
	{
		presentation.PropertyChanged -= base.RaiseLinkedValues;
		presentation.ArrangementGroups.CollectionChanged -= ArrangementGroups_CollectionChanged;
		presentation.ArrangementGroups.ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged -= Cues_CollectionChanged;
			g.PropertyChanged -= CueGroup_PropertyChanged;
		});
		CueGroupKeys.ForEach(delegate(CueGroupKey k)
		{
			k.PropertyChanged -= CueGroupKeyUpdated;
		});
		CueGroupKeys.Clear();
		base.SelectedSlideElements.Clear();
		SelectSlides(Array.Empty<CustomSlide>());
		base.Slides.Clear();
	}

	private void SetupPresentation(CustomPresentation presentation)
	{
		GenerateDefaultSlideCue(presentation);
		presentation.PropertyChanged += base.RaiseLinkedValues;
		presentation.ArrangementGroups.CollectionChanged += ArrangementGroups_CollectionChanged;
		presentation.ArrangementGroups.ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged += Cues_CollectionChanged;
			g.PropertyChanged += CueGroup_PropertyChanged;
		});
		CueGroupCollection arrangementGroups = presentation.ArrangementGroups;
		IEnumerable<SlideCue> source = arrangementGroups.SelectMany((CueGroup g) => g.Cues);
		foreach (CueGroup item in arrangementGroups)
		{
			if (!_cueGroupKeyCache.TryGetValue(item, out CueGroupKey value))
			{
				value = new CueGroupKey(item);
				_cueGroupKeyCache.Add(item, value);
			}
			CueGroupKeys.Add(value);
		}
		base.Slides?.AddRange(source.Select((SlideCue c) => c.SlideAction?.Slide as CustomSlide).NotNull());
		InvalidateCueMap();
	}

	private static void GenerateDefaultSlideCue(CustomPresentation presentation)
	{
		if (presentation != null && presentation.ArrangementGroups.Empty())
		{
			presentation.AddCue();
		}
	}

	private void CueGroup_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Label")
		{
			InvalidateCueMap();
		}
	}

	private void ArrangementGroups_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged -= Cues_CollectionChanged;
			CueGroupKeys.RemoveIf((CueGroupKey k) => k.CueGroup == g);
		});
		e.NewItems?.Cast<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.Cues.CollectionChanged += Cues_CollectionChanged;
			CueGroupKeys.Insert(e.NewStartingIndex, new CueGroupKey(g));
			base.Slides?.AddRange(g.Cues.Select((SlideCue c) => c.SlideAction?.Slide as CustomSlide).NotNull());
		});
		InvalidateCueMap();
	}

	private void Cues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		InvalidateCueMap();
		(from SlideCue c in e.OldItems?
			select c.SlideAction?.Slide as CustomSlide).NotNull().ForEach(delegate(CustomSlide s)
		{
			base.Slides.Remove(s);
		});
		for (int i = 0; i < (_slideCueMap?.Count ?? 0); i++)
		{
			CustomSlide key = _slideCueMap.ElementAt(i).Key;
			if (base.Slides.ElementAtOrDefault(i) != key)
			{
				if (i < base.Slides.Count)
				{
					base.Slides[i] = key;
				}
				else
				{
					InsertSlide(key, i);
				}
			}
		}
		OnPropertyChanged("Slides");
	}

	private void OnDuplicateCommand()
	{
		List<SlidesCopyData> list = ClipboardManagerHelper.GetPasteableItems<SlidesCopyData>().ToList();
		OnCopyCommand();
		OnPasteCommand();
		if (list.Count > 0)
		{
			ClipboardManagerHelper.CopyFromCollection(list);
		}
	}

	private void OnCopyCommand()
	{
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		SlideCue[] slideCues = Presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).ToArray();
		ClipboardManagerHelper.CopyFromCollection((from c in base.SelectedSlides.Select(GetCueFromSlide).NotNull()
			orderby slideCues.IndexOf(c)
			select c).GetSlidesData(Presentation.CopyIdentifier));
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private bool IsPasteable(SlidesCopyData data)
	{
		return Presentation?.CopyIdentifier.CanPasteFrom(data.SourceCopyIdentifier) ?? false;
	}

	private bool CanPasteSlides()
	{
		return base.PasteStrategy.CanPasteSlides((SlidesCopyData d) => d.Slides.SelectMany(delegate(SlideCue s)
		{
			IEnumerable<SlideElementBase> enumerable = (s.SlideAction?.Slide as CustomSlide)?.Elements;
			return enumerable ?? Enumerable.Empty<SlideElementBase>();
		}), IsPasteable);
	}

	private void OnPasteCommand()
	{
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		int index = (base.OrderedSelectedSlides.Any() ? Presentation.ArrangementGroups.SelectMany((CueGroup g) => g.Cues).ToArray().IndexOf<SlideCue>(GetCueFromSlide(base.OrderedSelectedSlides.Last())) : 0);
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Presentation.UndoStack.BeginCommit(UndoActionTypes.PasteSlide.ToAction());
		StartIgnoringSelection();
		Presentation.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		CustomSlide[] pastedItems = (from c in base.PasteStrategy.PasteSlides<PresentationBase, SlidesCopyData>(Presentation, index, IsPasteable).SelectMany((SlidesCopyData s) => s.Slides)
			select c.SlideAction?.Slide as CustomSlide).NotNull().ToArray();
		StopIgnoringSelection();
		SelectSlides(pastedItems);
		Presentation.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(pastedItems);
			});
		});
		Presentation.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void AddCommandExecuted(TemplateSlide template)
	{
		Presentation.ThrowWhenNull("Presentation");
		CustomSlide lastSelectedSlide = base.OrderedSelectedSlides.LastOrDefault();
		Presentation.UndoStack.BeginCommit(UndoActionTypes.AddSlide.ToAction());
		StartIgnoringSelection();
		Presentation.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(lastSelectedSlide);
			});
		}, delegate
		{
		});
		SlideCue slideCue = Presentation.AddCue(template, GetCueFromSlide(lastSelectedSlide));
		IReadOnlyList<ITrackedMedia> mediaToAdd = slideCue.GetTrackedMedia();
		mediaToAdd.ForEach(delegate(ITrackedMedia x)
		{
			x.AddToMediaService(userInitiated: true);
		});
		Presentation.UndoStack.Commit(delegate
		{
			mediaToAdd.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
		}, delegate
		{
			mediaToAdd.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
		});
		CustomSlide newSlide = slideCue.SlideAction?.Slide as CustomSlide;
		if (_applyTemplateMediaAction)
		{
			slideCue.ApplyTemplateMediaAction(template);
		}
		StopIgnoringSelection();
		SelectSlide(newSlide);
		Presentation.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(newSlide);
			});
		});
		Presentation.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnDeleteCommand()
	{
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		SlideCue[] targetCues = base.SelectedSlides.Select(GetCueFromSlide).NotNull().ToArray();
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		CustomSlide selectedSlide = base.OrderedSelectedSlides.First();
		bool flag = false;
		CustomSlide nextSelectedSlide = SlideEditorVM.GetSlideAtOffset(SelectableSlides, selectedSlide, isForward: false);
		if (nextSelectedSlide == null)
		{
			flag = true;
			selectedSlide = base.OrderedSelectedSlides.Last();
			nextSelectedSlide = SlideEditorVM.GetSlideAtOffset(SelectableSlides, selectedSlide, isForward: true);
		}
		Presentation.UndoStack.BeginCommit(UndoActionTypes.RemoveSlides.ToAction());
		if (!SlidesInSameGroup(selectedSlide, nextSelectedSlide) && nextSelectedSlide != null)
		{
			CueGroupKey groupKey = CueGroupKeys.FirstOrDefault((CueGroupKey c) => GetSlidesFromKey(c).Contains(selectedSlide));
			nextSelectedSlide = GetSlidesFromKey(groupKey).FirstOrDefault((CustomSlide c) => !base.SelectedSlides.Contains(c));
			if (nextSelectedSlide == null)
			{
				int num = ((groupKey == null) ? (-1) : CueGroupKeys.IndexOf(groupKey));
				groupKey = CueGroupKeys.ElementAtOrDefault(num - 1);
				if (groupKey == null)
				{
					flag = true;
					groupKey = CueGroupKeys.ElementAtOrDefault(num + 1);
					groupKey.ThrowWhenNull("groupKey");
				}
				bool isVisible = groupKey.IsVisible;
				Presentation.UndoStack.Commit(delegate
				{
					groupKey.IsVisible = isVisible;
				}, delegate
				{
					groupKey.IsVisible = true;
				});
				groupKey.IsVisible = true;
				SlideCue slideCue;
				if (!flag)
				{
					CueCollection cues = groupKey.CueGroup.Cues;
					slideCue = cues[cues.Count - 1];
				}
				else
				{
					slideCue = groupKey.CueGroup.Cues[0];
				}
				nextSelectedSlide = slideCue.SlideAction?.Slide as CustomSlide;
			}
		}
		StartIgnoringSelection();
		Presentation.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		Presentation.RemoveCues(targetCues);
		Presentation.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(nextSelectedSlide ?? base.Slides.FirstOrDefault());
			});
		});
		StopIgnoringSelection();
		SelectSlide(nextSelectedSlide ?? base.Slides.FirstOrDefault());
		Presentation.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private bool SlidesInSameGroup(CustomSlide a, CustomSlide? b)
	{
		CueGroup cueGroup = CueGroupKeys.FirstOrDefault((CueGroupKey c) => GetSlidesFromKey(c).Contains(a))?.CueGroup;
		CueGroup cueGroup2 = CueGroupKeys.FirstOrDefault((CueGroupKey c) => GetSlidesFromKey(c).Contains<CustomSlide>(b))?.CueGroup;
		if (cueGroup != null && cueGroup2 != null)
		{
			return cueGroup == cueGroup2;
		}
		return false;
	}

	private void InvalidateCueMap()
	{
		_slideCueMap = (from c in Presentation?.ArrangementGroups.SelectMany((CueGroup g) => g.Cues)
			where c.SlideAction?.Slide is CustomSlide
			select c).ToDictionary((SlideCue k) => (CustomSlide)k.SlideAction.Slide, (SlideCue v) => v);
	}

	private void OnCueGroupKeysChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<CueGroupKey>().ForEach(delegate(CueGroupKey k)
		{
			k.PropertyChanged -= CueGroupKeyUpdated;
		});
		e.NewItems?.Cast<CueGroupKey>().ForEach(delegate(CueGroupKey k)
		{
			k.PropertyChanged += CueGroupKeyUpdated;
		});
	}

	private SlideCue? GetCueFromSlide(CustomSlide? slide)
	{
		if (_slideCueMap == null || slide == null || !_slideCueMap.TryGetValue(slide, out SlideCue value))
		{
			return null;
		}
		return value;
	}

	private static IEnumerable<CustomSlide> GetSlidesFromKey(CueGroupKey? key)
	{
		return key?.CueGroup.Cues.Select((SlideCue c) => c.SlideAction?.Slide).OfType<CustomSlide>() ?? Enumerable.Empty<CustomSlide>();
	}

	private void CueGroupKeyUpdated(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsVisible" && sender is CueGroupKey key)
		{
			OnCueGroupVisiblityChanged(key);
		}
	}

	private void OnCueGroupVisiblityChanged(CueGroupKey key)
	{
		if (base.SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		if (key.IsVisible)
		{
			return;
		}
		List<CustomSlide> list = (from s in GetSlidesFromKey(key)
			where base.SelectedSlides.Contains(s)
			select s).ToList();
		if (base.SelectedSlides.Count == list.Count)
		{
			if (!CueGroupKeys.Any((CueGroupKey k) => k.IsVisible))
			{
				list.Remove(base.SelectedSlide);
			}
			else
			{
				CustomSlide slide = GetSlidesFromKey(CueGroupKeys.FirstOrDefault((CueGroupKey k) => k.IsVisible)).FirstOrDefault();
				SelectSlide(slide);
			}
		}
		DeselectSlides(list);
	}

	protected override void OnSelectSlideCommand(CustomSlide slide)
	{
		SelectSlides(SelectableSlides, slide);
	}

	protected override void OnSelectAllSlidesCommand()
	{
		SelectSlides(SelectableSlides.Where((CustomSlide s) => !base.SelectedSlides.Contains(s)));
	}

	protected override void OnDropSlidesCommand(DragDropCommandParameters<CustomSlide, PresentationBase> e)
	{
		Presentation.ThrowWhenNull("Presentation");
		SlideCue target = GetCueFromSlide(e.TargetItem);
		target.ThrowWhenNull("target");
		IEnumerable<CustomSlide> slides = e.Items;
		slides.ThrowWhenNull("slides");
		if (!Presentation.ArrangementGroups.Any())
		{
			return;
		}
		CueGroup targetGroup = Presentation.ArrangementGroups.First((CueGroup g) => g.Cues.Contains(target));
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Presentation.UndoStack.BeginCommit(UndoActionTypes.MoveSlides.ToAction());
		StartIgnoringSelection();
		Presentation.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		Presentation.MoveCuesTo(slides.Select(GetCueFromSlide).NotNull(), target, e.DroppedBefore, insertNewGroup: false, targetGroup, e.Copy);
		StopIgnoringSelection();
		SelectSlides(slides);
		Presentation.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(slides);
			});
		});
		Presentation.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnMoveNextSlideCommand()
	{
		ShiftSelectedSlide(isForward: true);
	}

	private void OnMovePreviousSlideCommand()
	{
		ShiftSelectedSlide(isForward: false);
	}

	private void OnShowStageLayoutToTargetScreenCommand(ScreenArrangementBase screen)
	{
		SlideCue cueFromSlide = GetCueFromSlide(base.SelectedSlide);
		if (cueFromSlide != null)
		{
			base.EditorService.AssignStageScreen(screen, cueFromSlide);
		}
	}

	private void ShiftSelectedSlide(bool isForward)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		ModifierKeys modifiers = Keyboard.Modifiers;
		IEnumerable<CustomSlide> enumerable;
		if ((int)modifiers == 4)
		{
			enumerable = SelectionHelper<CustomSlide>.FindSelectedItems(SelectableSlides, base.SelectedSlides, isForward, modifiers).ToArray();
		}
		else
		{
			CustomSlide targetSlide = (isForward ? base.OrderedSelectedSlides.LastOrDefault() : base.OrderedSelectedSlides.FirstOrDefault());
			enumerable = SlideEditorVM.GetSlideAtOffset(SelectableSlides, targetSlide, isForward).ToEnumerable();
		}
		if (enumerable != null && enumerable.Any())
		{
			SelectSlides(enumerable);
		}
	}

	private void OnBreakTextToNewSlideCommand()
	{
		BreakText(breakToNewSlide: true);
	}

	private void OnBreakTextToNextSlideCommand()
	{
		BreakText(breakToNewSlide: false);
	}

	private void BreakText(bool breakToNewSlide)
	{
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		ClosedBezierPath closedBezierPath = base.SelectedCanvasElements.OfType<ClosedBezierPath>().FirstOrDefault((ClosedBezierPath p) => p.IsEditModeActive);
		SlideCue cueFromSlide = GetCueFromSlide(base.SelectedSlide);
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		if (cueFromSlide == null || closedBezierPath == null)
		{
			return;
		}
		Presentation.UndoStack.BeginCommit(UndoActionTypes.BreakSlides.ToAction());
		StartIgnoringSelection();
		Presentation.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		CustomSlide newSlide = Presentation.BreakSlideDocument(cueFromSlide, closedBezierPath.EditTextbox?.CaretIndex ?? 0, closedBezierPath, breakToNewSlide).SlideAction?.Slide as CustomSlide;
		Presentation.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(newSlide);
			});
		});
		StopIgnoringSelection();
		SelectSlide(newSlide);
		Presentation.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void ApplyTemplateToSelectedSlidesCommandExecuted(TemplateSlide selectedTemplate)
	{
		if (Presentation == null)
		{
			throw new InvalidOperationException("Presentation must be non null");
		}
		Presentation.ApplyTemplateToSlides(selectedTemplate, GetSlideCueFromSelectedSlides(), _applyTemplateMediaAction);
	}

	[IteratorStateMachine(typeof(_003CGetSlideCueFromSelectedSlides_003Ed__93))]
	private IEnumerable<SlideCue> GetSlideCueFromSelectedSlides()
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CGetSlideCueFromSelectedSlides_003Ed__93(-2)
		{
			_003C_003E4__this = this
		};
	}

	protected override CustomSlide? GetSlide(int slideIndex)
	{
		return (from c in CueGroupKeys.SelectMany((CueGroupKey c) => c.CueGroup.Cues)
			select c.SlideAction?.Slide).OfType<CustomSlide>().ElementAtOrDefault(slideIndex);
	}

	protected override IEnumerable<MediaAction> GetMediaActions()
	{
		return GetCueFromSlide(base.SelectedSlide)?.Actions.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>();
	}

	protected override bool GetIncludeBackground()
	{
		return GetCueFromSlide(base.SelectedSlide)?.GetIncludeBackground() ?? true;
	}
}
