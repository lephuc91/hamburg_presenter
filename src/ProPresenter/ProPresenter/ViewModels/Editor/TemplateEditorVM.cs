using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.FeatureFlag;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.Localization;
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
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class TemplateEditorVM : SlideEditorVM, ITemplateEditorVM, ISlideEditorVM, INotifyPropertyChanged
{
	private Theme? _theme;

	private TemplateSlide? _selectedTemplate;

	public override CommandTargetType CommandTargetType => CommandTargetType.TemplateEditor;

	public ThemeCollection Themes { get; }

	public Theme? Theme
	{
		get
		{
			return _theme;
		}
		set
		{
			SetValue<Theme>("Theme", ref _theme, value, delegate(Theme o, Theme n)
			{
				base.Slides.Clear();
				SlideContainers.Clear();
				if (o != null)
				{
					o.CollectionChanged -= Theme_CollectionChanged;
				}
				if (n != null)
				{
					n.CollectionChanged += Theme_CollectionChanged;
					foreach (TemplateSlide item in n)
					{
						base.Slides.Add(item.Slide);
						SlideContainers.Add(new TemplateSlideContainer(item));
					}
					SelectSlide(base.Slides.FirstOrDefault());
					this.StackChanged?.Invoke(n.UndoStack);
				}
				OnPropertyChanged("SelectedItemName");
			});
		}
	}

	public ObservableCollection<SlideContainerBase> SlideContainers { get; } = new ObservableCollection<SlideContainerBase>();

	public override string SelectedItemName
	{
		get
		{
			return Theme?.Name ?? string.Empty;
		}
		set
		{
			if (Theme != null)
			{
				Theme.Name = value;
				OnPropertyChanged("SelectedItemName");
			}
		}
	}

	protected override Color PrimaryBackgroundColor => base.SelectedSlide?.BackgroundColor ?? base.PrimaryBackgroundColor;

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
			return false;
		}
		set
		{
		}
	}

	protected override string? MediaRoot => base.EditMode switch
	{
		EditMode.Template => Theme?.GetAssetPath(), 
		EditMode.CCLITemplate => base.MediaRoot, 
		_ => throw new NotSupportedException(), 
	};

	public TemplateSlide? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			SetValue<TemplateSlide>("SelectedTemplate", ref _selectedTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				if (o != null)
				{
					o.VisualInvalidated -= Template_VisualInvalidated;
					o.MediaActionVisualInvalidated -= Template_MediaActionVisualInvalidated;
				}
				if (n != null)
				{
					n.VisualInvalidated += Template_VisualInvalidated;
					n.MediaActionVisualInvalidated += Template_MediaActionVisualInvalidated;
				}
				base.TemplateSlideInspectorVM.SelectedTemplate = n;
				Template_MediaActionVisualInvalidated();
			});
		}
	}

	private IEnumerable<TemplateSlide> SelectedTempletSlides
	{
		get
		{
			Theme.ThrowWhenNull("Theme");
			IEnumerable<CustomSlide> orderedSlides = base.OrderedSelectedSlides;
			return Theme.Where((TemplateSlide x) => orderedSlides.Contains(x.Slide));
		}
	}

	public override ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, () => Theme != null && base.SelectedSlides.Any());

	public override ICommand<TemplateSlide> AddCommand => new RelayCommand<TemplateSlide>(OnAddCommand, (TemplateSlide t) => Theme != null && base.EditMode != EditMode.CCLITemplate);

	public override ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, IsRemovable);

	public override ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => Theme != null && base.SelectedSlides.Any());

	public override ICommand CutCommand => new RelayCommand(OnCutCommand, () => Theme != null && base.SelectedSlides.Any());

	public override ICommand PasteSlidesCommand => new RelayCommand(OnPasteCommand, CanPasteSlides);

	public event Action<UndoStack>? StackChanged;

	private void Template_MediaActionVisualInvalidated()
	{
		LoadBackgroundImageAsync().ExecuteAsync();
	}

	public TemplateEditorVM(IEditorService service, IThemeRepo themeRepo, IApp app, ITimerFactory timerFactory, IImport import, IProPresenterResourceService resourceService, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IGeneral general, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, IFlagService flagService, ICurrentTime currentTime)
		: base(service, app, timerFactory, import, resourceService, processHelper, fileSystem, advanced, general, importProcessFactory, factoryProvider, transitionDescriptions, messageDialogService, flagService, currentTime)
	{
		Themes = themeRepo.Themes;
		LinkProperties("UseBackgroundColor", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "UsePrimaryBackground", "Background" }));
		LinkProperties("BackgroundColor", new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "PrimaryBackgroundColor", "Background" }));
	}

	protected override void OnDropSlidesCommand(DragDropCommandParameters<CustomSlide, PresentationBase> e)
	{
		Theme.ThrowWhenNull("Theme");
		CustomSlide[] slides = e.Items?.OrderBy(base.Slides.IndexOf).ToArray() ?? Array.Empty<CustomSlide>();
		int index = ((e.TargetItem == null) ? (-1) : base.Slides.IndexOf(e.TargetItem)) + ((!e.DroppedBefore) ? 1 : 0);
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		IEnumerable<TemplateSlide> templatesFromSlides = GetTemplatesFromSlides(slides);
		Theme.UndoStack.BeginCommit(UndoActionTypes.MoveTemplates.ToAction());
		StartIgnoringSelection();
		Theme.UndoStack.Commit(delegate
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
			templatesFromSlides = templatesFromSlides.CloneItems();
			Theme.PasteInto(templatesFromSlides, index);
			slides = templatesFromSlides.Select((TemplateSlide t) => t.Slide).ToArray();
		}
		else
		{
			Theme.MoveTo(templatesFromSlides, index);
		}
		StopIgnoringSelection();
		SelectSlides(slides);
		Theme.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(slides);
			});
		});
		Theme.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	protected override void OnSelectedSlideChanged(CustomSlide? oldValue, CustomSlide? newValue)
	{
		SelectedTemplate = GetTemplateFromSlide(newValue);
		if (oldValue != null)
		{
			oldValue.VisualInvalidated -= NotifyBackgroundChanged;
		}
		if (newValue != null)
		{
			newValue.VisualInvalidated += NotifyBackgroundChanged;
		}
		OnPropertyChanged("UsePrimaryBackground");
		OnPropertyChanged("Background");
		OnPropertyChanged("Slides");
		OnPropertyChanged("SelectedItemName");
		NotifyBackgroundChanged();
	}

	private void Template_VisualInvalidated(TemplateSlide template)
	{
		NotifyBackgroundChanged();
	}

	private void NotifyBackgroundChanged()
	{
		OnPropertyChanged("IncludeBackground");
		OnPropertyChanged("BackgroundImageScale");
		OnPropertyChanged("BackgroundImageAlignment");
	}

	protected override void OnDeleteElementsCommand(IEnumerable<SlideElementBase> elements)
	{
		if (base.EditMode == EditMode.CCLITemplate)
		{
			CustomSlide? selectedSlide = base.SelectedSlide;
			if (selectedSlide == null || !selectedSlide.Elements.Except(elements).OfType<ClosedBezierPath>().Any(delegate(ClosedBezierPath e)
			{
				ILinkedTextObject? linkedObject = e.TextLink.LinkedObject;
				return linkedObject != null && linkedObject.LinkedTextType == LinkedTextType.CCLITemplate;
			}))
			{
				base.MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("EDITOR_CCLI_INSPECTOR_DELETE_DENIED_ALERT_message") + "\n\n" + LocalizedStrings.Get("EDITOR_CCLI_INSPECTOR_DELETE_DENIED_ALERT_info"), DefaultButtons.OK, DefaultButtons.OK);
				return;
			}
		}
		base.OnDeleteElementsCommand(elements);
	}

	private void Theme_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		int startIndex = e.NewStartingIndex;
		e.OldItems?.Cast<TemplateSlide>().ForEach(delegate(TemplateSlide t)
		{
			base.Slides.Remove(t.Slide);
			SlideContainers.RemoveIf((SlideContainerBase c) => c.Slide == t.Slide);
		});
		e.NewItems?.Cast<TemplateSlide>().ForEach(delegate(TemplateSlide t)
		{
			int index = startIndex++;
			InsertSlide(t.Slide, index);
			SlideContainers.Insert(index, new TemplateSlideContainer(t));
		});
		OnPropertyChanged("Slides");
	}

	private void OnDuplicateCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnAddCommand(TemplateSlide templateSlide)
	{
		Theme.ThrowWhenNull("Theme");
		CustomSlide lastSelectedSlide = base.OrderedSelectedSlides.LastOrDefault();
		int index = ((lastSelectedSlide == null) ? base.Slides.Count : (base.Slides.IndexOf(lastSelectedSlide) + 1));
		Theme.UndoStack.BeginCommit(UndoActionTypes.AddTemplate.ToAction());
		StartIgnoringSelection();
		Theme.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(lastSelectedSlide);
			});
		}, delegate
		{
		});
		TemplateSlide newTemplate = templateSlide ?? new TemplateSlide(base.FactoryProvider, base.TransitionDescriptions, base.FlagService, addDefaultShape: true);
		Theme.Insert(index, newTemplate);
		StopIgnoringSelection();
		SelectSlide(newTemplate.Slide);
		Theme.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(newTemplate.Slide);
			});
		});
		Theme.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnCopyCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(GetTemplatesFromSlides(base.OrderedSelectedSlides));
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private bool CanPasteSlides()
	{
		return base.PasteStrategy.CanPasteSlides((TemplateSlide s) => s.Slide.Elements);
	}

	private void OnPasteCommand()
	{
		Theme.ThrowWhenNull("Theme");
		int index = base.Slides.IndexOf(base.OrderedSelectedSlides.Last()) + 1;
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Theme.UndoStack.BeginCommit(UndoActionTypes.PasteSlide.ToAction());
		StartIgnoringSelection();
		Theme.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		TemplateSlide[] source = base.PasteStrategy.PasteSlides<Theme, TemplateSlide>(Theme, index).ToArray();
		CustomSlide[] pastedSlides = source.Select((TemplateSlide c) => c.Slide).ToArray();
		ITrackedMedia[] mediaToAdd = source.Select((TemplateSlide x) => x.MediaAction?.Media).OfType<ITrackedMedia>().Concat(pastedSlides.SelectMany((CustomSlide x) => CustomSlide.GetTrackedMediaFromElements(x.Elements)))
			.ToArray();
		mediaToAdd.ForEach(delegate(ITrackedMedia x)
		{
			x.AddToMediaServiceAndApplyTransform(userInitiated: true);
		});
		StopIgnoringSelection();
		SelectSlides(pastedSlides);
		Theme.UndoStack.Commit(delegate
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
			AllowSelectionForBlock(delegate
			{
				SelectSlides(pastedSlides);
			});
		});
		Theme.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnDeleteCommand()
	{
		Theme.ThrowWhenNull("Theme");
		CustomSlide previousSlide = SlideEditorVM.GetSlideAtOffset(base.Slides, base.OrderedSelectedSlides.First(), isForward: false) ?? base.Slides.Except(base.SelectedSlides).FirstOrDefault();
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Theme.UndoStack.BeginCommit(UndoActionTypes.RemoveTemplate.ToAction());
		StartIgnoringSelection();
		Theme.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		ITrackedMedia[] mediaToRemove = base.OrderedSelectedSlides.SelectMany((CustomSlide x) => CustomSlide.GetTrackedMediaFromElements(x.Elements)).Concat(SelectedTempletSlides.Select((TemplateSlide x) => x.MediaAction?.Media).OfType<ITrackedMedia>()).ToArray();
		Theme.Remove(GetTemplatesFromSlides(base.OrderedSelectedSlides).ToArray());
		mediaToRemove.ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		StopIgnoringSelection();
		SelectSlide(previousSlide);
		Theme.UndoStack.Commit(delegate
		{
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
		}, delegate
		{
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
			AllowSelectionForBlock(delegate
			{
				SelectSlide(previousSlide);
			});
		});
		Theme.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private bool IsRemovable()
	{
		if (Theme != null && base.EditMode != EditMode.CCLITemplate && base.SelectedSlides.Any())
		{
			return base.Slides.Count() > 1;
		}
		return false;
	}

	private TemplateSlide? GetTemplateFromSlide(CustomSlide? slide)
	{
		if (slide != null)
		{
			return Theme?.FirstOrDefault((TemplateSlide t) => t.Slide == slide);
		}
		return null;
	}

	private IEnumerable<TemplateSlide> GetTemplatesFromSlides(IEnumerable<CustomSlide> slides)
	{
		return slides.Select(GetTemplateFromSlide).NotNull();
	}

	protected override CustomSlide? GetSlide(int slideIndex)
	{
		return SlideContainers.ElementAtOrDefault(slideIndex)?.Slide;
	}

	protected override IEnumerable<MediaAction> GetMediaActions()
	{
		return base.TemplateSlideInspectorVM.SelectedTemplate?.Actions.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>();
	}

	protected override ArrangedCue GetArrangedCueFromSelectedSlide()
	{
		base.SelectedSlide.ThrowWhenNull("SelectedSlide");
		SelectedTemplate.ThrowWhenNull("SelectedTemplate");
		SlideCue slideCue = base.SelectedSlide.ToCue(base.FactoryProvider, base.TransitionDescriptions);
		SelectedTemplate.Actions.ForEach(slideCue.Actions.Add);
		return new ArrangedCue(slideCue, new CueGroup(new CustomPresentation(base.App, base.TimerFactory, base.FactoryProvider, base.TransitionDescriptions, base.MessageDialogService, base.CurrentTime), new GroupLabel(string.Empty), base.FactoryProvider, base.TransitionDescriptions));
	}

	protected override bool ShouldSuppressGotoNext()
	{
		return false;
	}
}
