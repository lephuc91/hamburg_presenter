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
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.UI.Components;
using Pro.UI.DialogService;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Masks;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class MaskEditorVM : SlideEditorVM, IMaskEditorVM, ISlideEditorVM, INotifyPropertyChanged
{
	public IMaskCollection Masks { get; }

	public ObservableCollection<SlideContainerBase> SlideContainers { get; } = new ObservableCollection<SlideContainerBase>();

	public override CommandTargetType CommandTargetType => CommandTargetType.MaskEditor;

	private SlideCue? SelectedMask => Masks.FirstOrDefault((SlideCue m) => base.SelectedSlide != null && m.SlideAction?.Slide == base.SelectedSlide);

	private SlideCue[] SelectedMasks => Masks.Where((SlideCue m) => m.SlideAction != null && base.OrderedSelectedSlides.Contains(m.SlideAction?.Slide)).ToArray();

	protected override Color PrimaryBackgroundColor => Colors.Transparent;

	public override ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, () => base.SelectedSlides.Any());

	public override ICommand<TemplateSlide> AddCommand => new RelayCommand<TemplateSlide>(OnAddCommand);

	public override ICommand CopyCommand => new RelayCommand(OnCopyCommand, () => base.SelectedSlides.Any());

	public override ICommand CutCommand => new RelayCommand(OnCutCommand, () => base.SelectedSlides.Any());

	public override ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, () => base.SelectedSlides.Any() && base.Slides.Count() > 1);

	public override ICommand PasteSlidesCommand => new RelayCommand(OnPasteCommand, CanPasteSlides);

	public override string SelectedItemName
	{
		get
		{
			return SelectedMask?.Name ?? string.Empty;
		}
		set
		{
			if (SelectedMask != null)
			{
				SelectedMask.Name = value;
				OnPropertyChanged("SelectedItemName");
			}
		}
	}

	public override bool UsePrimaryBackground
	{
		get
		{
			return true;
		}
		set
		{
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

	public MaskEditorVM(IEditorService service, IApp app, ITimerFactory timerFactory, IImport import, IProPresenterResourceService resourceService, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IFlagService flagService, IGeneral general, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime, IMaskCollection masks)
		: base(service, app, timerFactory, import, resourceService, processHelper, fileSystem, advanced, general, importProcessFactory, factoryProvider, transitionDescriptions, messageDialogService, flagService, currentTime)
	{
		Masks = masks;
		Masks.UndoStack.StartIgnoring();
		Masks.CollectionChanged += Masks_CollectionChanged;
		foreach (SlideCue mask in Masks)
		{
			if (mask.SlideAction?.Slide is CustomSlide item)
			{
				base.Slides.Add(item);
			}
			SlideContainers.Add(new SlideCueContainer(mask));
		}
		LinkProperties("Name", "SelectedItemName");
		Masks.UndoStack.StopIgnoring();
	}

	protected override void OnSelectedSlideChanged(CustomSlide? oldValue, CustomSlide? newValue)
	{
		if (oldValue != null)
		{
			SlideCue slideCue = Masks.FirstOrDefault((SlideCue m) => m.SlideAction?.Slide == oldValue);
			if (slideCue != null)
			{
				slideCue.PropertyChanged -= base.RaiseLinkedValues;
			}
		}
		if (newValue != null)
		{
			SlideCue slideCue2 = Masks.FirstOrDefault((SlideCue m) => m.SlideAction?.Slide == newValue);
			if (slideCue2 != null)
			{
				slideCue2.PropertyChanged += base.RaiseLinkedValues;
			}
		}
		OnPropertyChanged("SelectedItemName");
	}

	protected override void OnDropSlidesCommand(DragDropCommandParameters<CustomSlide, PresentationBase> e)
	{
		CustomSlide[] slides = e.Items?.OrderBy(base.Slides.IndexOf).ToArray();
		int index = ((e.TargetItem == null) ? (-1) : base.Slides.IndexOf(e.TargetItem)) + ((!e.DroppedBefore) ? 1 : 0);
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		SlideCue[] array = Masks.Where((SlideCue m) => m.SlideAction != null && (slides?.Contains(m.SlideAction.Slide) ?? false)).OrderBy(Masks.IndexOf).ToArray();
		Masks.UndoStack.BeginCommit(UndoActionTypes.MoveTemplates.ToAction());
		StartIgnoringSelection();
		Masks.UndoStack.Commit(delegate
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
			Masks.PasteInto(array, index);
			slides = array.Select((SlideCue t) => (CustomSlide)t.SlideAction.Slide).ToArray();
		}
		else
		{
			Masks.MoveTo(array, index);
		}
		StopIgnoringSelection();
		SelectSlides(slides);
		Masks.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(slides);
			});
		});
		Masks.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void Masks_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<SlideCue>().ForEach(delegate(SlideCue m)
		{
			SlideBase slideBase = m.SlideAction?.Slide;
			CustomSlide slide = slideBase as CustomSlide;
			if (slide != null)
			{
				base.Slides.Remove(slide);
				SlideContainers.RemoveIf((SlideContainerBase c) => c.Slide == slide);
			}
		});
		e.NewItems?.Cast<SlideCue>().ForEach(delegate(SlideCue m)
		{
			if (m.SlideAction?.Slide is CustomSlide slide2)
			{
				InsertSlide(slide2, e.NewStartingIndex);
				SlideContainers.Insert(e.NewStartingIndex, new SlideCueContainer(m));
			}
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
		CustomSlide lastSelectedSlide = base.OrderedSelectedSlides.LastOrDefault();
		int index = ((lastSelectedSlide == null) ? base.Slides.Count : (base.Slides.IndexOf(lastSelectedSlide) + 1));
		Masks.UndoStack.BeginCommit(UndoActionTypes.AddMask.ToAction());
		StartIgnoringSelection();
		Masks.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(lastSelectedSlide);
			});
		}, delegate
		{
		});
		CustomSlide newSlide = Masks.Insert(index, templateSlide).SlideAction?.Slide as CustomSlide;
		StopIgnoringSelection();
		SelectSlide(newSlide);
		Masks.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(newSlide);
			});
		});
		Masks.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnCopyCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(SelectedMasks);
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private bool CanPasteSlides()
	{
		return base.PasteStrategy.CanPasteSlides((SlideCue s) => (!(s.SlideAction?.Slide is CustomSlide customSlide)) ? Enumerable.Empty<SlideElementBase>() : customSlide.Elements);
	}

	private void OnPasteCommand()
	{
		int index = base.Slides.IndexOf(base.OrderedSelectedSlides.Last()) + 1;
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Masks.UndoStack.BeginCommit(UndoActionTypes.PasteSlide.ToAction());
		StartIgnoringSelection();
		Masks.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		CustomSlide[] pastedItems = (from c in base.PasteStrategy.PasteSlides<IMaskCollection, SlideCue>(Masks, index)
			select c.SlideAction?.Slide as CustomSlide).NotNull().ToArray();
		StopIgnoringSelection();
		SelectSlides(pastedItems);
		Masks.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(pastedItems);
			});
		});
		Masks.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	private void OnDeleteCommand()
	{
		CustomSlide previousSlide = SlideEditorVM.GetSlideAtOffset(base.Slides, base.OrderedSelectedSlides.First(), isForward: false) ?? base.Slides.Except(base.SelectedSlides).FirstOrDefault();
		CustomSlide[] originalSelectedSlides = base.SelectedSlides.ToArray();
		Masks.UndoStack.BeginCommit(UndoActionTypes.RemoveMask.ToAction());
		StartIgnoringSelection();
		Masks.UndoStack.Commit(delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlides(originalSelectedSlides);
			});
		}, delegate
		{
		});
		Masks.RemoveRange(SelectedMasks);
		StopIgnoringSelection();
		previousSlide = previousSlide ?? (Masks.FirstOrDefault()?.SlideAction?.Slide as CustomSlide);
		SelectSlide(previousSlide);
		Masks.UndoStack.Commit(delegate
		{
		}, delegate
		{
			AllowSelectionForBlock(delegate
			{
				SelectSlide(previousSlide);
			});
		});
		Masks.UndoStack.EndCommit(base.StartIgnoringSelection, base.StopIgnoringSelection, autoFinalize: true);
	}

	protected override CustomSlide? GetSlide(int slideIndex)
	{
		return SlideContainers?.ElementAtOrDefault(slideIndex)?.Slide;
	}
}
