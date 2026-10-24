using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Nullability;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Import;

public partial class EditImportFileWindow : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty DocumentOptionsProperty = DependencyProperty.Register("DocumentOptions", typeof(DocumentOptions), typeof(EditImportFileWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((EditImportFileWindow)(object)d).DocumentOptionsChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as DocumentOptions, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as DocumentOptions);
	}));

	private static readonly DependencyProperty DocumentCueProperty = DependencyProperty.Register("DocumentCue", typeof(DocumentCue), typeof(EditImportFileWindow));

	public static readonly DependencyProperty SelectedSlidesProperty = DependencyProperty.Register("SelectedSlides", typeof(ObservableCollection<ArrangedCue>), typeof(EditImportFileWindow));

	public static readonly DependencyProperty ReflowTextZoomLevelProperty = DependencyProperty.Register("ReflowTextZoomLevel", typeof(double), typeof(EditImportFileWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty ReflowRowCapacityProperty = DependencyProperty.Register("ReflowRowCapacity", typeof(int), typeof(EditImportFileWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	private static readonly DependencyProperty PresentationVMProperty = DependencyProperty.Register("PresentationVM", typeof(IPresentationVM), typeof(EditImportFileWindow));

	public DocumentOptions? DocumentOptions
	{
		get
		{
			return (DocumentOptions)((DependencyObject)this).GetValue(DocumentOptionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentOptionsProperty, (object)value);
		}
	}

	public bool ImportDocument { get; set; }

	private DocumentCue? DocumentCue
	{
		get
		{
			return (DocumentCue)((DependencyObject)this).GetValue(DocumentCueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentCueProperty, (object)value);
		}
	}

	public ObservableCollection<ArrangedCue>? SelectedSlides
	{
		get
		{
			return (ObservableCollection<ArrangedCue>)((DependencyObject)this).GetValue(SelectedSlidesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSlidesProperty, (object)value);
		}
	}

	public double ReflowTextZoomLevel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ReflowTextZoomLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReflowTextZoomLevelProperty, (object)value);
		}
	}

	public int ReflowRowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(ReflowRowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ReflowRowCapacityProperty, (object)value);
		}
	}

	private IPresentationVM? PresentationVM
	{
		get
		{
			return (IPresentationVM)((DependencyObject)this).GetValue(PresentationVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PresentationVMProperty, (object)value);
		}
	}

	private CustomPresentation? Presentation => DocumentOptions?.WorkingPresentation;

	private UndoStack? UndoStack => Presentation?.UndoStack;

	public ThemeCollection Themes { get; } = DataVault.Themes;

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(delegate(TemplateSlide template)
	{
		if (DocumentOptions != null)
		{
			DocumentOptions.Template = template;
		}
	});

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, CanExecute_AnySelection);

	public ICommand CutCommand => new RelayCommand(OnCutCommand, CanExecute_AnySelection);

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<SlideBase>());

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommand, CanExecute_AnySelection);

	public ICommand UndoCommand => new RelayCommand(delegate
	{
		UndoStack?.Undo();
	}, () => UndoStack != null && UndoStack.CanUndo);

	public ICommand RedoCommand => new RelayCommand(delegate
	{
		UndoStack?.Redo();
	}, () => UndoStack != null && UndoStack.CanRedo);

	public EditImportFileWindow(IPresentationVM presentationVM, IInputActions inputActions)
	{
		InitializeComponent();
		((DependencyObject)this).SetCurrentValue(PresentationVMProperty, (object)presentationVM);
		base.CommandBindings.Add(inputActions.CommonInputActions.Undo.BindCommand, UndoCommand);
		base.CommandBindings.Add(inputActions.CommonInputActions.Redo.BindCommand, RedoCommand);
	}

	private void DocumentOptionsChanged(DocumentOptions? oldOptions, DocumentOptions? newOptions)
	{
		if (oldOptions != null)
		{
			oldOptions.PropertyChanged -= DocumentOptions_PropertyChanged;
		}
		if (newOptions != null)
		{
			newOptions.PropertyChanged += DocumentOptions_PropertyChanged;
			((DependencyObject)this).SetCurrentValue(DocumentCueProperty, (object)new DocumentCue(newOptions.WorkingPresentation));
		}
		else
		{
			((DependencyObject)this).SetCurrentValue(DocumentCueProperty, (object)null);
		}
	}

	private void DocumentOptions_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "WorkingPresentation")
		{
			DocumentCue = new DocumentCue(DocumentOptions.WorkingPresentation);
		}
	}

	private void ImportButton_Click(object? sender, RoutedEventArgs e)
	{
		CloseWindow(result: true);
	}

	private void CancelButton_Click(object? sender, RoutedEventArgs e)
	{
		DocumentOptions?.InvalidateDocument();
		CloseWindow(result: false);
	}

	private void CloseWindow(bool result)
	{
		ImportDocument = result;
		Close();
	}

	private bool CanExecute_AnySelection()
	{
		return SelectedSlides?.Any() ?? false;
	}

	private void OnCopyCommand()
	{
		if (SelectedSlides != null)
		{
			ClipboardManagerHelper.CopyFromCollection(SelectedSlides.Select((ArrangedCue s) => s.Source.SlideAction?.Slide).NotNull().ToArray());
		}
	}

	private void OnCutCommand()
	{
		OnCopyCommand();
		OnDeleteCommand();
	}

	private void OnPasteCommand()
	{
		CustomPresentation customPresentation = DocumentOptions?.WorkingPresentation;
		if (customPresentation != null)
		{
			ArrangedCue arrangedCue = SelectedSlides?.LastOrDefault();
			SlideCue[] existingSlides = customPresentation.ArrangementGroups.SelectMany((CueGroup s) => s.Cues).ToArray();
			ClipboardManagerHelper.PasteIntoCollection<PresentationBase, SlidesCopyData>(customPresentation, existingSlides.IndexOf(arrangedCue?.Source));
			IEnumerable<ArrangedCue> enumerable = (customPresentation.ActiveArrangement ?? customPresentation.DefaultArrangement).ArrangedCues.Where((ArrangedCue s) => !existingSlides.Contains(s.Source));
			if (enumerable.Any())
			{
				SelectedSlides?.Clear();
				SelectedSlides?.AddRange(enumerable);
			}
		}
	}

	private void OnDeleteCommand()
	{
		SelectedSlides.ThrowWhenNull("SelectedSlides");
		IEnumerable<SlideCue> enumerable = SelectedSlides.Select((ArrangedCue s) => s.Source);
		DocumentOptions?.WorkingPresentation.RemoveCues(enumerable);
		SelectedSlides?.RemoveRange(enumerable);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
