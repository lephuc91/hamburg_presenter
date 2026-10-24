using System;
using System.CodeDom.Compiler;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.Text;
using Pro.UI.Commands;
using Pro.UI.Components;
using Pro.UI.Controls;
using Pro.UI.DependencyInjection;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ActionPalette;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.ReflowEditor;

public partial class ReflowEditor : UserControl, IComponentConnector
{
	private bool _ignoreSelection;

	private FormattedTextBox? _prevSelected;

	private readonly Lazy<ScrollBar?> _reflowScrollBar;

	private readonly Lazy<ScrollBar?> _thumbnailScrollBar;

	public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(ReflowEditor));

	public static readonly DependencyProperty PlaylistItemProperty = DependencyProperty.Register("PlaylistItem", typeof(ProPresenterCue), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnPlaylistItemPropertyChanged)));

	public static readonly DependencyProperty SelectedSlideProperty = DependencyProperty.Register("SelectedSlide", typeof(ArrangedCue), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectedSlidePropertyChanged)));

	public static readonly DependencyProperty SelectedSlidesProperty = DependencyProperty.Register("SelectedSlides", typeof(ObservableCollection<ArrangedCue>), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)new ObservableCollection<ArrangedCue>()));

	public static readonly DependencyProperty CustomSlideMenuVMProperty = DependencyProperty.Register("CustomSlideMenuVM", typeof(ICustomSlideMenuVM), typeof(ReflowEditor));

	public static readonly DependencyProperty TextZoomLevelProperty = DependencyProperty.Register("TextZoomLevel", typeof(double), typeof(ReflowEditor));

	public static readonly DependencyProperty RowCapacityProperty = DependencyProperty.Register("RowCapacity", typeof(int), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)4));

	public static readonly DependencyProperty AddCueCommandProperty = DependencyProperty.Register("AddActionCommand", typeof(ICommand), typeof(ReflowEditor));

	public static readonly DependencyProperty CopyCommandProperty = DependencyProperty.Register("CopyCommand", typeof(ICommand), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)s).CommandBindings.Add(CommonApplicationCommands.Copy, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand);
	}));

	public static readonly DependencyProperty CutCommandProperty = DependencyProperty.Register("CutCommand", typeof(ICommand), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)s).CommandBindings.Add(CommonApplicationCommands.CutCommand, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand);
	}));

	public static readonly DependencyProperty PasteCommandProperty = DependencyProperty.Register("PasteCommand", typeof(ICommand), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)s).CommandBindings.Add(CommonApplicationCommands.Paste, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand);
	}));

	public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand", typeof(ICommand), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)s).CommandBindings.Add(CommonApplicationCommands.Delete, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ICommand);
	}));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(ReflowEditor));

	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(ReflowEditor));

	public static readonly DependencyProperty DocumentCueProperty = DependencyProperty.Register("DocumentCue", typeof(IDocumentCue), typeof(ReflowEditor));

	public static readonly DependencyProperty AddMediaActionCommandProperty = DependencyProperty.Register("AddMediaActionCommand", typeof(ICommand<(IDocumentCue, AddMediaCueParameters)>), typeof(ReflowEditor));

	public static readonly DependencyProperty AddMediaPlaylistActionCommandProperty = DependencyProperty.Register("AddMediaPlaylistActionCommand", typeof(ICommand<(IDocumentCue, AddMediaPlaylistParameters)>), typeof(ReflowEditor));

	public static readonly DependencyProperty AddDroppedMediaActionCommandProperty = DependencyProperty.Register("AddDroppedMediaActionCommand", typeof(ICommand<(IDocumentCue, MediaActionCommandParameters)>), typeof(ReflowEditor));

	public static readonly DependencyProperty DropMediaFilesCommandProperty = DependencyProperty.Register("DropMediaFilesCommand", typeof(ICommand<(IDocumentCue, DropMediaFilesCommandParameters)>), typeof(ReflowEditor));

	public static readonly DependencyProperty AddDroppedActionCommandProperty = DependencyProperty.Register("AddDroppedActionCommand", typeof(ICommand<(IDocumentCue, ActionCommandParameters)>), typeof(ReflowEditor));

	public static readonly DependencyProperty ThemeContextGroupProperty = DependencyProperty.Register("ThemeContextGroup", typeof(ThemePickerGroup), typeof(ReflowEditor), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)ThemePickerGroup.Presentation));

	public static readonly DependencyProperty DropPropCommandProperty = DependencyProperty.Register("DropPropCommand", typeof(ICommand<DropPropCommandParameter>), typeof(ReflowEditor));

	public bool ShowCloseButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowCloseButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowCloseButtonProperty, (object)value);
		}
	}

	public ProPresenterCue PlaylistItem
	{
		get
		{
			return (ProPresenterCue)((DependencyObject)this).GetValue(PlaylistItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaylistItemProperty, (object)value);
		}
	}

	public ArrangedCue? SelectedSlide
	{
		get
		{
			return (ArrangedCue)((DependencyObject)this).GetValue(SelectedSlideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedSlideProperty, (object)value);
		}
	}

	public ObservableCollection<ArrangedCue> SelectedSlides
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

	public ICustomSlideMenuVM CustomSlideMenuVM
	{
		get
		{
			return (ICustomSlideMenuVM)((DependencyObject)this).GetValue(CustomSlideMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomSlideMenuVMProperty, (object)value);
		}
	}

	public TransitionParameters SelectedTransition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(SelectedTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTransitionProperty, (object)value);
		}
	}

	public double TextZoomLevel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(TextZoomLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TextZoomLevelProperty, (object)value);
		}
	}

	public int RowCapacity
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(RowCapacityProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowCapacityProperty, (object)value);
		}
	}

	public ICommand AddActionCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddCueCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddCueCommandProperty, (object)value);
		}
	}

	public ICommand CopyCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CopyCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CopyCommandProperty, (object)value);
		}
	}

	public ICommand CutCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CutCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CutCommandProperty, (object)value);
		}
	}

	public ICommand PasteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(PasteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PasteCommandProperty, (object)value);
		}
	}

	public ICommand DeleteCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(DeleteCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeleteCommandProperty, (object)value);
		}
	}

	public ICommand? GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public IDocumentCue? DocumentCue
	{
		get
		{
			return (IDocumentCue)((DependencyObject)this).GetValue(DocumentCueProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(DocumentCueProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, AddMediaCueParameters)> AddMediaActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, AddMediaCueParameters)>)((DependencyObject)this).GetValue(AddMediaActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddMediaActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, AddMediaPlaylistParameters)> AddMediaPlaylistActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, AddMediaPlaylistParameters)>)((DependencyObject)this).GetValue(AddMediaPlaylistActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddMediaPlaylistActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, DropMediaFilesCommandParameters)> DropMediaFilesCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, DropMediaFilesCommandParameters)>)((DependencyObject)this).GetValue(DropMediaFilesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropMediaFilesCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, MediaActionCommandParameters)> AddDroppedMediaActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, MediaActionCommandParameters)>)((DependencyObject)this).GetValue(AddDroppedMediaActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddDroppedMediaActionCommandProperty, (object)value);
		}
	}

	public ICommand<(IDocumentCue, ActionCommandParameters)> AddDroppedActionCommand
	{
		get
		{
			return (ICommand<(IDocumentCue, ActionCommandParameters)>)((DependencyObject)this).GetValue(AddDroppedActionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddDroppedActionCommandProperty, (object)value);
		}
	}

	public ThemePickerGroup ThemeContextGroup
	{
		get
		{
			return (ThemePickerGroup)((DependencyObject)this).GetValue(ThemeContextGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ThemeContextGroupProperty, (object)value);
		}
	}

	public ICommand<DropPropCommandParameter> DropPropCommand
	{
		get
		{
			return (ICommand<DropPropCommandParameter>)((DependencyObject)this).GetValue(DropPropCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DropPropCommandProperty, (object)value);
		}
	}

	private CustomPresentation? Presentation => (PlaylistItem as IDocumentCue)?.DocumentAction?.Presentation as CustomPresentation;

	private ScrollBar? ReflowScrollBar => _reflowScrollBar.Value;

	private ScrollBar? ThumbnailScrollBar => _thumbnailScrollBar.Value;

	public event Action? Close;

	private static void OnSelectedSlidePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)d).SelectedItemChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ArrangedCue);
	}

	private static void OnPlaylistItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ReflowEditor)(object)d).HookupSourcePropertyChange(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as ProPresenterCue);
	}

	public ReflowEditor()
	{
		IInputActions service = UIServiceProvider.GetService<IInputActions>();
		InitializeComponent();
		base.GotFocus += ReflowEditor_GotFocus;
		_reflowScrollBar = new Lazy<ScrollBar>(() => ((DependencyObject)(object)ReflowTextList)?.FindVisualChild<ScrollBar>());
		_thumbnailScrollBar = new Lazy<ScrollBar>(delegate
		{
			ScrollBar scrollBar = ((DependencyObject)(object)ThumbnailControl).FindVisualChild<ScrollBar>();
			if (scrollBar != null)
			{
				scrollBar.ValueChanged += ThumbnailScrollBar_ValueChanged;
			}
			return scrollBar;
		});
		this.AddTunnelingCommand(service.ProCommon.BreakTextToNewSlide.BindCommand, delegate
		{
			InsertSlide(breakToNewSlide: true);
		});
		this.AddTunnelingCommand(service.ProCommon.BreakTextToNextSlide.BindCommand, delegate
		{
			InsertSlide(breakToNewSlide: false);
		});
	}

	private void ReflowEditor_GotFocus(object? sender, RoutedEventArgs e)
	{
		GotFocusCommand?.Invoke();
	}

	private void ReflowEditorBtnClose_Click(object? sender, RoutedEventArgs e)
	{
		this.Close?.Invoke();
	}

	private void ReflowText_BackSpaceMerge()
	{
		if (Presentation == null || SelectedSlide?.Source == null)
		{
			return;
		}
		int characterIndex;
		SlideCue previousSlide;
		switch (Presentation.MergeSlidesDocument(SelectedSlide.Source, out characterIndex, out previousSlide, delegate
		{
			Pro.Text.Range? previousSelection = GetTextBox(SelectedSlide)?.FormattedTextBox?.SelectionRanges.FirstOrDefault();
			ReflowTextList.ItemContainerGenerator.StatusChanged += StatusChanged;
			void StatusChanged(object? sender, EventArgs args)
			{
				if (previousSelection.HasValue)
				{
					FormattedTextBox formattedTextBox = GetTextBox(SelectedSlide)?.FormattedTextBox;
					if (formattedTextBox != null)
					{
						int? num = formattedTextBox?.Document?.AllText.Length;
						Pro.Text.Range range = ((previousSelection.Value.End > num) ? new Pro.Text.Range(Math.Min(previousSelection.Value.Start, num.Value), Math.Min(previousSelection.Value.End, num.Value)) : previousSelection.Value);
						formattedTextBox.ChangeSelection(range, range.Start);
						formattedTextBox.Focus();
					}
				}
				ReflowTextList.ItemContainerGenerator.StatusChanged -= StatusChanged;
			}
		}))
		{
		case CustomPresentation.SlideMergeResult.PreviousSlideHasNoText:
		case CustomPresentation.SlideMergeResult.SlideNotFoundInPresentation:
			MessageDialogService.ShowAlert(LocalizedStrings.Get("REFLOW_EDITOR_MERGE_SLIDE_ALERT_message"));
			break;
		case CustomPresentation.SlideMergeResult.FirstSlideInGroup:
			MessageDialogService.ShowAlert(LocalizedStrings.Get("REFLOW_EDITOR_MERGE_GROUPS_ALERT_message"));
			break;
		case CustomPresentation.SlideMergeResult.Successful:
			OnSlideMerged(previousSlide, characterIndex);
			break;
		case CustomPresentation.SlideMergeResult.FirstSlide:
			break;
		}
	}

	private void OnSlideMerged(SlideCue? slide, int lastIndex)
	{
		UpdateLayout();
		ArrangedCue arrangedSlide = ReflowTextList.Items.OfType<ArrangedCue>().FirstOrDefault((ArrangedCue a) => a.Source == slide);
		_ignoreSelection = true;
		SelectThumbnail(arrangedSlide);
		SelectReflowText(arrangedSlide, lastIndex + 1);
		_ignoreSelection = false;
	}

	private void BtnInsertSlideBreak_Click(object? sender, RoutedEventArgs e)
	{
		InsertSlide(breakToNewSlide: true);
	}

	private void SelectReflowText(ArrangedCue? arrangedSlide, int index)
	{
		_prevSelected?.DeselectAll();
		_prevSelected = ((arrangedSlide == null) ? null : GetTextBox(arrangedSlide)?.FormattedTextBox);
		if (_prevSelected != null)
		{
			_prevSelected.ChangeSelection(index);
			_prevSelected.Focus();
		}
	}

	private void SelectThumbnail(ArrangedCue? arrangedSlide)
	{
		((DependencyObject)this).SetCurrentValue(SelectedSlideProperty, (object)arrangedSlide);
	}

	private void SelectedItemChanged(ArrangedCue? newSlide)
	{
		if (newSlide != null && Presentation != null)
		{
			Presentation.UndoStack.FinalizeNextAction();
			if (!_ignoreSelection)
			{
				SelectReflowText(newSlide, 0);
			}
		}
	}

	private void ReflowText_Select(ReflowText reflowText)
	{
		if (reflowText.FormattedTextBox != _prevSelected)
		{
			_prevSelected?.DeselectAll();
		}
		_prevSelected = reflowText.FormattedTextBox;
		SelectThumbnail(reflowText.DataContext as ArrangedCue);
	}

	private ReflowText? GetTextBox(ArrangedCue arrangedSlide)
	{
		return ReflowTextList.ItemContainerGenerator.ContainerFromItem(arrangedSlide).FindVisualChild<ReflowText>();
	}

	private void HookupSourcePropertyChange(ProPresenterCue? newCue)
	{
		if (newCue is IDocumentCue documentCue)
		{
			DocumentCue = documentCue;
		}
	}

	private void ReflowTextList_ScrollChanged(object? sender, ScrollChangedEventArgs e)
	{
		if (ThumbnailScrollBar != null && ReflowScrollBar != null && ReflowScrollBar.Maximum != 0.0)
		{
			ThumbnailScrollBar.Value = ThumbnailScrollBar.Maximum / ReflowScrollBar.Maximum * e.VerticalOffset;
		}
	}

	private void ThumbnailScrollBar_ValueChanged(object? sender, RoutedPropertyChangedEventArgs<double> e)
	{
		if (ThumbnailScrollBar != null && ReflowScrollBar != null && ThumbnailScrollBar.Maximum != 0.0)
		{
			ReflowScrollBar.Value = ReflowScrollBar.Maximum / ThumbnailScrollBar.Maximum * e.NewValue;
			((DependencyObject)(object)ReflowTextList).FindVisualChild<ScrollViewer>()?.ScrollToVerticalOffset(ReflowScrollBar.Value);
		}
	}

	private void ReflowText_CaretPositionChanged(Vector2<double> pos, FormattedTextBox.CaretLocation location)
	{
		if (DocumentCue?.DocumentAction?.ActiveArrangement != null && SelectedSlide != null)
		{
			bool flag = location == FormattedTextBox.CaretLocation.Bottom || location == FormattedTextBox.CaretLocation.End;
			IImmutableObservableCollection<ArrangedCue> arrangedCues = DocumentCue.DocumentAction.ActiveArrangement.ArrangedCues;
			int num = arrangedCues.IndexOf(SelectedSlide);
			if ((num != 0 || flag) && !(num + 1 == arrangedCues.Count && flag))
			{
				num = ((!flag) ? (num - 1) : (num + 1));
				ArrangedCue arrangedSlide = arrangedCues[num];
				SelectThumbnail(arrangedSlide);
				GetTextBox(arrangedSlide)?.HandleNewCaretPosition(pos, location);
			}
		}
	}

	private void InsertSlide(bool breakToNewSlide)
	{
		if (SelectedSlide != null && Presentation != null)
		{
			_ignoreSelection = true;
			SlideCue slide = Presentation.BreakSlideDocument(SelectedSlide.Source, (GetTextBox(SelectedSlide)?.FormattedTextBox?.CaretIndex).GetValueOrDefault(), null, breakToNewSlide);
			UpdateLayout();
			ArrangedCue arrangedSlide = ReflowTextList.Items.OfType<ArrangedCue>().FirstOrDefault((ArrangedCue a) => a.Source == slide);
			SelectThumbnail(arrangedSlide);
			SelectReflowText(arrangedSlide, 0);
			_ignoreSelection = false;
		}
	}

	private void ReflowTextList_LayoutUpdated(object? sender, EventArgs e)
	{
		foreach (TruncatedTextblock labelBlock in ((DependencyObject)(object)ReflowTextList).FindVisualChildren<TruncatedTextblock>())
		{
			ReflowText reflowText = ((DependencyObject)(object)ReflowTextList).FindVisualChildren<ReflowText>().FirstOrDefault((ReflowText s) => s.DataContext == labelBlock.DataContext);
			if (reflowText != null && reflowText.FindName("ReflowHeaderRow") is RowDefinition rowDefinition && reflowText.FindName("ReflowTextRow") is RowDefinition rowDefinition2)
			{
				labelBlock.Width = rowDefinition2.ActualHeight + rowDefinition.ActualHeight;
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
