using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class PropsEditorVM : SlideEditorVM, IPropsEditorVM, ISlideEditorVM, INotifyPropertyChanged
{
	private IPropGroup? _propGroup;

	private IPropCue? _selectedProp;

	private readonly IPropSource _propSource;

	public override CommandTargetType CommandTargetType => CommandTargetType.PropEditor;

	public IEnumerable<IPropGroup> Groups => _propSource.PropGroups;

	public IPropGroup? SelectedPropGroup
	{
		get
		{
			return _propGroup;
		}
		set
		{
			SetValue<IPropGroup>("SelectedPropGroup", ref _propGroup, value, delegate(IPropGroup o, IPropGroup n)
			{
				base.Slides.Clear();
				SlideContainers.Clear();
				if (o != null)
				{
					o.CollectionChanged -= PropGroup_CollectionChanged;
				}
				if (n != null)
				{
					n.CollectionChanged += PropGroup_CollectionChanged;
					foreach (IPropCue item2 in n)
					{
						if (item2.SlideAction?.Slide is CustomSlide item)
						{
							base.Slides.Add(item);
						}
						SlideContainers.Add(new PropCueContainer(item2));
					}
					SelectSlide(base.Slides.FirstOrDefault());
					this.StackChanged?.Invoke(n.UndoStack);
				}
				OnPropertyChanged("SelectedItemName");
			});
		}
	}

	public IPropCue? SelectedProp
	{
		get
		{
			return _selectedProp;
		}
		set
		{
			SetValue<IPropCue>("SelectedProp", ref _selectedProp, value, delegate(IPropCue o, IPropCue n)
			{
				SelectSlide(n.SlideAction?.Slide as CustomSlide);
			});
		}
	}

	public ObservableCollection<SlideContainerBase> SlideContainers { get; } = new ObservableCollection<SlideContainerBase>();

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

	protected override Color PrimaryBackgroundColor => base.SelectedSlide?.BackgroundColor ?? Colors.Transparent;

	public override bool UseSecondaryBackground
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override string SelectedItemName
	{
		get
		{
			return SelectedPropGroup?.Name ?? string.Empty;
		}
		set
		{
			if (SelectedPropGroup != null)
			{
				SelectedPropGroup.Name = value;
				OnPropertyChanged("SelectedItemName");
			}
		}
	}

	public override ICommand<TemplateSlide> AddCommand => new RelayCommand<TemplateSlide>(OnAddCommandExecuted);

	public override ICommand DuplicateCommand => new RelayCommand<IPropCue>(OnDuplicateCommandExecuted);

	public override ICommand CopyCommand => new RelayCommand(OnCopyCommandExecuted);

	public override ICommand CutCommand => new RelayCommand(OnCutCommandExecuted);

	public override ICommand PasteSlidesCommand => new RelayCommand(OnPasteCommandExecuted);

	public override ICommand DeleteCommand => new RelayCommand(OnDeleteCommandExecuted);

	public ICommand<IPropGroup> SelectPropGroupCommand => new RelayCommand<IPropGroup>(delegate(IPropGroup g)
	{
		SelectedPropGroup = g;
	});

	public event Action<UndoStack?>? StackChanged;

	private void PropGroup_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		int startIndex = e.NewStartingIndex;
		e.OldItems?.Cast<IPropCue>().ForEach(delegate(IPropCue t)
		{
			if (t.SlideAction?.Slide is CustomSlide item)
			{
				base.Slides.Remove(item);
			}
			SlideContainers.RemoveIf((SlideContainerBase c) => c.Slide == t.SlideAction?.Slide as CustomSlide);
		});
		e.NewItems?.Cast<IPropCue>().ForEach(delegate(IPropCue t)
		{
			int index = startIndex++;
			if (t.SlideAction?.Slide is CustomSlide slide)
			{
				InsertSlide(slide, index);
			}
			SlideContainers.Insert(index, new PropCueContainer(t));
		});
		OnPropertyChanged("Slides");
	}

	public PropsEditorVM(IPropSource propSource, IEditorService editorService, IApp app, ITimerFactory timerFactory, IImport import, IProPresenterResourceService resourceService, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IFlagService flagService, IGeneral general, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime)
		: base(editorService, app, timerFactory, import, resourceService, processHelper, fileSystem, advanced, general, importProcessFactory, factoryProvider, transitionDescriptions, messageDialogService, flagService, currentTime)
	{
		_propSource = propSource;
		LinkProperties("UseBackgroundColor", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "UsePrimaryBackground", "Background" }));
		LinkProperties("BackgroundColor", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PrimaryBackgroundColor", "Background" }));
	}

	private void OnAddCommandExecuted(TemplateSlide? template)
	{
		CustomSlide customSlide = base.OrderedSelectedSlides.LastOrDefault();
		int num = ((customSlide == null) ? (-1) : (base.Slides.IndexOf(customSlide) + 1));
		if (num < 0)
		{
			SelectedPropGroup?.AddProp(template);
		}
		else
		{
			SelectedPropGroup?.InsertProp(template, num);
		}
	}

	private void OnDuplicateCommandExecuted(IPropCue cue)
	{
		OnCopyCommandExecuted();
		OnPasteCommandExecuted();
	}

	private void OnCopyCommandExecuted()
	{
		ClipboardManagerHelper.CopyFromCollection(GetPropCueFromSlides(base.OrderedSelectedSlides));
	}

	private IEnumerable<IPropCue> GetPropCueFromSlides(IEnumerable<CustomSlide> slides)
	{
		return slides.Select((CustomSlide s) => SelectedPropGroup?.FirstOrDefault((IPropCue p) => p.SlideAction?.Slide == s)).NotNull();
	}

	private void OnCutCommandExecuted()
	{
		OnCopyCommandExecuted();
		OnDeleteCommandExecuted();
	}

	private void OnPasteCommandExecuted()
	{
		SelectedPropGroup.ThrowWhenNull("SelectedPropGroup");
		int index = base.Slides.IndexOf(base.OrderedSelectedSlides.Last()) + 1;
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		SelectedPropGroup.UndoStack?.BeginCommit(UndoActionTypes.PasteSlide.ToAction());
		StartIgnoringSelection();
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		CustomSlide[] pastedItems = (from c in base.PasteStrategy.PasteSlides<IPropGroup, IPropCue>(SelectedPropGroup, index)
			select c.SlideAction?.Slide).OfType<CustomSlide>().ToArray();
		StopIgnoringSelection();
		SelectSlides(pastedItems);
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(pastedItems);
			});
		});
		SelectedPropGroup.UndoStack?.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnDeleteCommandExecuted()
	{
		SelectedPropGroup.ThrowWhenNull("SelectedPropGroup");
		CustomSlide previousSlide = SlideEditorVM.GetSlideAtOffset(base.Slides, base.OrderedSelectedSlides.First(), isForward: false) ?? base.Slides.Except(base.SelectedSlides).FirstOrDefault();
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		SelectedPropGroup.UndoStack?.BeginCommit(UndoActionTypes.RemoveTemplate.ToAction());
		StartIgnoringSelection();
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		SelectedPropGroup.RemoveProps(GetPropCueFromSlides(base.OrderedSelectedSlides).ToArray());
		StopIgnoringSelection();
		SelectSlide(previousSlide);
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(previousSlide);
			});
		});
		SelectedPropGroup.UndoStack?.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	protected override void OnSelectedSlideChanged(CustomSlide? oldValue, CustomSlide? newValue)
	{
		base.PropsInspectorVM.SelectedProp = GetPropCueFromSlides(newValue.ToEnumerable()).FirstOrDefault();
		OnPropertyChanged("Background");
	}

	protected override void OnDropSlidesCommand(DragDropCommandParameters<CustomSlide, PresentationBase> e)
	{
		SelectedPropGroup.ThrowWhenNull("SelectedPropGroup");
		CustomSlide[] slides = e.Items?.OrderBy(base.Slides.IndexOf).ToArray();
		int index = ((e.TargetItem == null) ? (-1) : base.Slides.IndexOf(e.TargetItem)) + ((!e.DroppedBefore) ? 1 : 0);
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		IPropCue[] array = SelectedPropGroup.Where((IPropCue m) => m.SlideAction != null && (slides?.Contains(m.SlideAction.Slide) ?? false)).OrderBy(((ImmutableObservableCollection<IPropCue>)SelectedPropGroup).IndexOf).ToArray();
		SelectedPropGroup.UndoStack?.BeginCommit(UndoActionTypes.MoveSlides.ToAction());
		StartIgnoringSelection();
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		if (e.Copy)
		{
			array = array.CloneItems().ToArray();
			SelectedPropGroup.PasteInto(array, index);
			slides = array.Select((IPropCue t) => (CustomSlide)t.SlideAction.Slide).ToArray();
		}
		else
		{
			SelectedPropGroup.MoveTo(array, index);
		}
		StopIgnoringSelection();
		SelectSlides(slides);
		SelectedPropGroup.UndoStack?.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(slides);
			});
		});
		SelectedPropGroup.UndoStack?.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	protected override void TriggerSelectedSlideCommandExecuted()
	{
		SelectedProp.ThrowWhenNull("SelectedProp");
		base.EditorService.TriggerProp(SelectedProp);
	}
}
