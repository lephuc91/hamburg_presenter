using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.Editor;
using Pro.Text;
using Pro.Text.Fills;
using Pro.Text.Reversibility;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.DO;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor.Inspectors;
using ProPresenter.UI.ViewModels.Editor;

namespace ProPresenter.ViewModels.Editor;

public class TextInspectorVM : NotifyPropertyChangedBase, ITextInspectorVM, INotifyPropertyChanged
{
	private readonly ITextFillInspectorPrompt _prompt;

	private readonly ObservableCollection<ICanvasElement> _selectedElements;

	private readonly IMediaProvider _mediaProvider;

	private EditMode _editMode;

	private CustomSlide? _selectedSlide;

	private IEnumerable<ClosedBezierPath> SelectedElements => _selectedElements.OfType<ClosedBezierPath>();

	private ClosedBezierPath? FirstElement => SelectedElements.FirstOrDefault((ClosedBezierPath e) => e.IsEditModeActive) ?? SelectedElements.FirstOrDefault();

	public Pro.Text.Range[] SelectionRanges => FirstElement?.EditTextbox?.SelectionRanges ?? Array.Empty<Pro.Text.Range>();

	public int CaretIndex => (FirstElement?.EditTextbox?.CaretIndex).GetValueOrDefault();

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
				OnPropertyChanged("ShowTextStyleControls");
			}, (Predicate<EditMode>?)null, referenceComparison: false);
		}
	}

	public RunSettings ActiveRunSettings
	{
		get
		{
			if (_selectedElements.Count != 0 && EditMode != EditMode.Template)
			{
				return FirstElement?.EditTextbox?.ActiveRunSettings ?? FirstElement?.Text.Attributes.RunSettings ?? new RunSettings();
			}
			return FirstElement?.Text.Attributes.RunSettings ?? new RunSettings();
		}
	}

	public TextDocument? ActiveDocument => FirstElement?.Text;

	public LineFillMask? ActiveLineFillMask => FirstElement?.LineFillMask;

	public IEnumerable<ListPreset> AvailableListPresets { get; } = from p in Enum.GetValues<ListPreset>()
		where p != ListPreset.None
		select p;

	public bool ShowTextStyleControls => EditMode.IsAnyOf(EditMode.Presentation, EditMode.Prop, EditMode.Stage, EditMode.Template);

	public ICommand<TextFillType> ChangeTextFillTypeCommand => new RelayCommand<TextFillType>(OnChangeTextFillTypeCommand);

	public ICommand<DocumentSettingsCommandParameters> ApplyDocumentSettingsCommand => new RelayCommand<DocumentSettingsCommandParameters>(OnApplyDocumentSettingsCommand);

	public ICommand<ParagraphSettingsCommandParameters> ApplyParagraphSettingsCommand => new RelayCommand<ParagraphSettingsCommandParameters>(OnApplyParagraphSettingsCommand);

	public ICommand<RunSettingsCommandParameters> ApplyRunSettingsCommand => new RelayCommand<RunSettingsCommandParameters>(OnApplyRunSettingsCommand);

	public ICommand<LineFillMaskCommandParameters> ApplyLineFillMaskSettingsCommand => new RelayCommand<LineFillMaskCommandParameters>(OnApplyLineFillMaskSettingsCommand);

	public ICommand FocusTextBoxCommand => new RelayCommand(delegate
	{
		FirstElement?.EditTextbox?.Focus();
	});

	private UndoStack? UndoStack => FirstElement?.UndoStack;

	public CommandTargetType CommandTargetType { get; set; }

	public IScrollingTextInspectorVM ScrollingTextInspectorVM { get; }

	public IMediaProvider MediaProvider => _mediaProvider;

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

	public TextInspectorVM(ObservableCollection<ICanvasElement> selectedElements, IMediaProvider mediaProvider, ITextFillInspectorPrompt? prompt = null)
	{
		_selectedElements = selectedElements;
		_mediaProvider = mediaProvider;
		_prompt = prompt ?? new TextFillInspectorPrompt();
		_selectedElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			NotifyPropertyChanges();
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(TeardownElement);
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(SetupElement);
		};
		ScrollingTextInspectorVM = new ScrollingTextInspectorVM(selectedElements);
	}

	private void SetupElement(ClosedBezierPath element)
	{
		element.PropertyChanged += Element_PropertyChanged;
		element.LineFillMask.PropertyChanged += LineFillMask_PropertyChanged;
		element.Text.AttributesChanged += TextOnAttributesChanged;
	}

	private void TextOnAttributesChanged()
	{
		OnPropertyChanged("ActiveRunSettings");
	}

	private void TeardownElement(ClosedBezierPath element)
	{
		element.PropertyChanged -= Element_PropertyChanged;
		element.LineFillMask.PropertyChanged -= LineFillMask_PropertyChanged;
	}

	private void Element_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "IsEditModeActive"))
		{
			if (propertyName == "Text")
			{
				NotifyPropertyChanges();
			}
		}
		else if (sender is ClosedBezierPath path)
		{
			Element_IsEditModeActiveChanged(path);
		}
	}

	private void Element_IsEditModeActiveChanged(ClosedBezierPath path)
	{
		if (path.IsInlineEditActive)
		{
			path.EditTextbox.CaretPositionChanged += delegate
			{
				NotifyPropertyChanges();
			};
		}
		NotifyPropertyChanges();
	}

	private void LineFillMask_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		NotifyPropertyChanges();
	}

	private void NotifyPropertyChanges()
	{
		OnPropertyChanged("ActiveDocument");
		OnPropertyChanged("ActiveLineFillMask");
		OnPropertyChanged("SelectionRanges");
		OnPropertyChanged("CaretIndex");
		OnPropertyChanged("ActiveRunSettings");
	}

	private IEnumerable<ClosedBezierPath> GetActiveElements()
	{
		ClosedBezierPath firstElement = FirstElement;
		if (firstElement == null)
		{
			return Array.Empty<ClosedBezierPath>();
		}
		if (firstElement.IsEditModeActive)
		{
			return new ClosedBezierPath[1] { firstElement };
		}
		return SelectedElements;
	}

	public IEnumerable<TextDocument> GetActiveDocuments(out bool editModeActive)
	{
		ClosedBezierPath[] array = GetActiveElements().ToArray();
		editModeActive = array.Length == 1 && array[0].IsEditModeActive;
		if (editModeActive)
		{
			return array[0].Text.ToEnumerable();
		}
		return array.Select((ClosedBezierPath e) => e.Text);
	}

	private void OnChangeTextFillTypeCommand(TextFillType fillType)
	{
		SelectedSlide.ThrowWhenNull("SelectedSlide");
		bool removeReveal = false;
		bool removeScrolling = false;
		ClosedBezierPath[] activeElements = GetActiveElements().ToArray();
		if (activeElements.Any((ClosedBezierPath e) => e.RevealType != RevealType.None) && fillType.IsAnyOf(TextFillType.CutOut))
		{
			removeReveal = true;
			if (!_prompt.ConfirmRemoveTextReveal())
			{
				return;
			}
		}
		if (activeElements.Any((ClosedBezierPath e) => e.TextScroller.ShouldScrollText) && fillType.IsAnyOf(TextFillType.BackgroundInvert, TextFillType.BackgroundBlur, TextFillType.CutOut, TextFillType.Media))
		{
			removeScrolling = true;
			if (!_prompt.ConfirmRemoveTextScrolling())
			{
				return;
			}
		}
		TextFillBase newFill = null;
		Pro.Text.Reversibility.UndoActionTypes undoType = Pro.Text.Reversibility.UndoActionTypes.Text;
		switch (fillType)
		{
		default:
			return;
		case TextFillType.SolidColor:
			newFill = new SolidTextFill();
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextSolidFill;
			break;
		case TextFillType.Gradient:
			newFill = new GradientTextFill();
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextGradientFill;
			break;
		case TextFillType.CutOut:
			newFill = new CutOutTextFill();
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextCutoutFill;
			break;
		case TextFillType.Media:
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextMediaFill;
			MediaProvider?.GetMedia(SelectedSlide.ContainerId, delegate(MediaBase? m)
			{
				if (m is VisualMedia visualMedia)
				{
					visualMedia.Drawing.ScaleBehavior = ScaleBehavior.ScaleToFill;
					visualMedia.SupportsAudio = false;
					visualMedia.SupportsScaleAndBlur = false;
					newFill = new MediaTextFill(visualMedia);
					ApplyFill(removeReveal, removeScrolling, activeElements, newFill, undoType);
				}
			});
			return;
		case TextFillType.BackgroundInvert:
			newFill = new BackgroundInvertTextFill();
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextBackgroundInvertFill;
			break;
		case TextFillType.BackgroundBlur:
			newFill = new BackgroundBlurTextFill();
			undoType = Pro.Text.Reversibility.UndoActionTypes.TextBackgroundBlurFill;
			break;
		}
		ApplyFill(removeReveal, removeScrolling, activeElements, newFill, undoType);
	}

	private void ApplyFill(bool removeReveal, bool removeScrolling, ClosedBezierPath[] activeElements, TextFillBase newFill, Pro.Text.Reversibility.UndoActionTypes undoType)
	{
		if ((object)newFill == null)
		{
			return;
		}
		UndoStack?.BeginCommit(undoType.ToAction());
		if (removeReveal)
		{
			activeElements.ForEach(delegate(ClosedBezierPath e)
			{
				e.RevealType = RevealType.None;
			});
		}
		if (removeScrolling)
		{
			activeElements.ForEach(delegate(ClosedBezierPath e)
			{
				e.TextScroller.ShouldScrollText = false;
			});
		}
		if (newFill != null)
		{
			OnApplyRunSettingsCommand(new RunSettingsCommandParameters(delegate(RunSettings settings, RangeSelectionType type, TextDocument? _)
			{
				settings.Fill = newFill;
			}, undoType, autoFinalize: true));
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
		NotifyPropertyChanges();
	}

	private void OnApplyDocumentSettingsCommand(DocumentSettingsCommandParameters parameters)
	{
		UndoStack?.BeginCommit(parameters.UndoActionType.ToAction());
		bool editModeActive;
		foreach (TextDocument activeDocument in GetActiveDocuments(out editModeActive))
		{
			parameters.SettingsAction(activeDocument.Settings, RangeSelectionType.Document);
		}
		UndoStack?.EndCommit(null, null, parameters.AutoFinalize);
	}

	private void OnApplyParagraphSettingsCommand(ParagraphSettingsCommandParameters parameters)
	{
		UndoStack?.BeginCommit(parameters.UndoActionType.ToAction());
		bool editModeActive;
		foreach (TextDocument activeDocument in GetActiveDocuments(out editModeActive))
		{
			if (EditMode != EditMode.Template && editModeActive)
			{
				RangeSelectionType rangeSelectionType = SelectionRanges.GetRangeSelectionType(activeDocument);
				activeDocument.IterateParagraphs(SelectionRanges, delegate(Paragraph p)
				{
					parameters.SettingsAction(p.Settings, p.First().Settings, rangeSelectionType);
				});
			}
			else
			{
				activeDocument.IterateParagraphs(Pro.Text.Range.All, delegate(Paragraph p)
				{
					parameters.SettingsAction(p.Settings, p.First().Settings, RangeSelectionType.Document);
				});
			}
		}
		UndoStack?.EndCommit(null, null, parameters.AutoFinalize);
	}

	private void OnApplyRunSettingsCommand(RunSettingsCommandParameters parameters)
	{
		UndoStack?.BeginCommit(parameters.UndoActionType.ToAction());
		bool editModeActive;
		foreach (TextDocument document in GetActiveDocuments(out editModeActive))
		{
			if (EditMode != EditMode.Template && editModeActive)
			{
				if (SelectionRanges.ContainsSelection())
				{
					RangeSelectionType rangeSelectionType = SelectionRanges.GetRangeSelectionType(document);
					document.IterateRuns(SelectionRanges, splitRuns: true, delegate(RunBase r)
					{
						parameters.SettingsAction(r.Settings, rangeSelectionType, document);
					});
				}
				else
				{
					parameters.SettingsAction(ActiveRunSettings, RangeSelectionType.NextUp, document);
				}
			}
			else
			{
				document.IterateRuns(Pro.Text.Range.All, splitRuns: true, delegate(RunBase r)
				{
					parameters.SettingsAction(r.Settings, RangeSelectionType.Document, document);
				});
			}
		}
		UndoStack?.EndCommit(null, null, parameters.AutoFinalize);
	}

	private void OnApplyLineFillMaskSettingsCommand(LineFillMaskCommandParameters parameters)
	{
		UndoStack?.BeginCommit(parameters.UndoActionType.ToAction());
		SelectedElements.ForEach(delegate(ClosedBezierPath e)
		{
			parameters.SettingsAction(e.LineFillMask, RangeSelectionType.Document);
		});
		UndoStack?.EndCommit(null, null, parameters.AutoFinalize);
	}
}
