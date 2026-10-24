using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Text;
using Pro.Text.Reversibility;
using Pro.UI.Commands;
using Pro.UI.DependencyInjection;
using Pro.UI.Themes;
using Pro.UI.Utility;

namespace Pro.UI.Controls;

public partial class FormattedTextBox : FrameworkElement, IFormattedTextBox, IComponentConnector, IStyleConnector
{
	public enum CaretLocation
	{
		Body,
		Beginning,
		End,
		Top,
		Bottom
	}

	private readonly string TextDocumentFormatString = typeof(TextDocument).FullName;

	private static readonly Brush? TextMaskBrush = Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.SpecialTextFill);

	private readonly Func<Vector2<double>, Color> _backlightSampler;

	private Vector2<double> _startingCaretPosition;

	private ITextComposition? _textComposition;

	private ArrangedText? _arrangedText;

	private bool _insertMode;

	private double _caretZoomFactor = 1.0;

	private double _caretHeight;

	private Pro.Text.Range[] _storedSelectionRanges = Array.Empty<Pro.Text.Range>();

	private Vector2<double> _caretPosition = Vector2<double>.Zero;

	private bool _isMouseDown;

	private bool _isSelectionDragActive;

	private Vector2<double> _mouseDownPosition = Vector2<double>.Zero;

	private int _mouseDownIndex = -1;

	private bool _ignoreSelectionChanges;

	private int _compositionIndex;

	private readonly ISpellChecker? _spellChecker;

	private readonly ITextDocumentFactory _textDocumentFactory;

	private readonly List<Pro.Text.Range> _misspelledWords = new List<Pro.Text.Range>();

	private string[] _wordsSinceLastSpellCheck = Array.Empty<string>();

	private Pro.Text.Range _currentWord = Pro.Text.Range.Empty;

	public static readonly DependencyProperty TypefaceLibraryProperty = DependencyProperty.Register("TypefaceLibrary", typeof(TypefaceLibrary), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTypefaceLibraryPropertyChanged)));

	public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(TextDocument), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDocumentPropertyChanged)));

	public static readonly DependencyProperty SelectionRangesProperty = DependencyProperty.Register("SelectionRanges", typeof(Pro.Text.Range[]), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnSelectionRangesPropertyChanged), (CoerceValueCallback)((DependencyObject _, object e) => (e is Pro.Text.Range[]) ? e : Array.Empty<Pro.Text.Range>())));

	public static readonly DependencyProperty CaretIndexProperty = DependencyProperty.Register("CaretIndex", typeof(int), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCaretIndexPropertyChanged)));

	public static readonly DependencyProperty ActiveRunSettingsProperty = DependencyProperty.Register("ActiveRunSettings", typeof(RunSettings), typeof(FormattedTextBox));

	public static readonly DependencyProperty DefaultRunSettingsProperty = DependencyProperty.Register("DefaultRunSettings", typeof(RunSettings), typeof(FormattedTextBox));

	public static readonly DependencyProperty AutoSizeHeightProperty = DependencyProperty.Register("AutoSizeHeight", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty AutoSizeWidthProperty = DependencyProperty.Register("AutoSizeWidth", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty ZoomLevelProperty = DependencyProperty.Register("ZoomLevel", typeof(double), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0));

	public static readonly DependencyProperty BacklightProperty = DependencyProperty.Register("Backlight", typeof(Color), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)System.Windows.Media.Colors.White));

	public static readonly DependencyProperty FillBrushOverrideProperty = DependencyProperty.Register("FillBrushOverride", typeof(Brush), typeof(FormattedTextBox));

	public static readonly DependencyProperty StrokeBrushOverrideProperty = DependencyProperty.Register("StrokeBrushOverride", typeof(Brush), typeof(FormattedTextBox));

	public static readonly DependencyProperty UnderlineBrushOverrideProperty = DependencyProperty.Register("UnderlineBrushOverride", typeof(Brush), typeof(FormattedTextBox));

	public static readonly DependencyProperty StrikeBrushOverrideProperty = DependencyProperty.Register("StrikeBrushOverride", typeof(Brush), typeof(FormattedTextBox));

	public static readonly DependencyProperty RenderTextShadowProperty = DependencyProperty.Register("RenderTextShadow", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty CanTransformProperty = DependencyProperty.Register("CanTransform", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		if (s is FormattedTextBox { _arrangedText: not null } formattedTextBox && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is bool canTransform)
		{
			formattedTextBox._arrangedText.CanTransform = canTransform;
		}
	}));

	public static readonly DependencyProperty SpellCheckEnableProperty = DependencyProperty.Register("SpellCheckEnable", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs _)
	{
		((FormattedTextBox)(object)s).CheckSpelling();
	}));

	public static readonly DependencyProperty IgnoreMarginsProperty = DependencyProperty.Register("IgnoreMargins", typeof(bool), typeof(FormattedTextBox), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, (PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		if (s is FormattedTextBox { _arrangedText: not null } formattedTextBox2 && ((DependencyPropertyChangedEventArgs)(ref e)).NewValue is bool isMarginsIgnored)
		{
			formattedTextBox2._arrangedText.IsMarginsIgnored = isMarginsIgnored;
		}
	}));

	private static readonly DependencyProperty SpellErrorSuggestionsProperty = DependencyProperty.Register("SpellErrorSuggestions", typeof(IEnumerable<string>), typeof(FormattedTextBox));

	private static readonly DependencyProperty CreateDefaultTextBoxCommandProperty = DependencyProperty.Register("CreateDefaultTextBoxCommand", typeof(ICommand), typeof(FormattedTextBox));

	public TypefaceLibrary? TypefaceLibrary
	{
		get
		{
			return (TypefaceLibrary)((DependencyObject)this).GetValue(TypefaceLibraryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TypefaceLibraryProperty, (object)value);
		}
	}

	public TextDocument? Document
	{
		get
		{
			return (TextDocument)((DependencyObject)this).GetValue(DocumentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DocumentProperty, (object)value);
		}
	}

	public Pro.Text.Range[] SelectionRanges
	{
		get
		{
			return ((Pro.Text.Range[])((DependencyObject)this).GetValue(SelectionRangesProperty)) ?? Array.Empty<Pro.Text.Range>();
		}
		set
		{
			((DependencyObject)this).SetValue(SelectionRangesProperty, (object)value);
		}
	}

	public int CaretIndex
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(CaretIndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CaretIndexProperty, (object)value);
		}
	}

	public RunSettings? ActiveRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(ActiveRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveRunSettingsProperty, (object)value);
		}
	}

	public RunSettings? DefaultRunSettings
	{
		get
		{
			return (RunSettings)((DependencyObject)this).GetValue(DefaultRunSettingsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultRunSettingsProperty, (object)value);
		}
	}

	public bool IsSelectionActive => SelectionRanges.ContainsSelection();

	public bool AutoSizeHeight
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoSizeHeightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoSizeHeightProperty, (object)value);
		}
	}

	public bool AutoSizeWidth
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoSizeWidthProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoSizeWidthProperty, (object)value);
		}
	}

	public Vector2<double> CaretPosition => _caretPosition;

	public double ZoomLevel
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomLevelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomLevelProperty, (object)value);
		}
	}

	public Color Backlight
	{
		get
		{
			return (Color)((DependencyObject)this).GetValue(BacklightProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BacklightProperty, (object)value);
		}
	}

	public Brush FillBrushOverride
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(FillBrushOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillBrushOverrideProperty, (object)value);
		}
	}

	public Brush StrokeBrushOverride
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(StrokeBrushOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrokeBrushOverrideProperty, (object)value);
		}
	}

	public Brush UnderlineBrushOverride
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(UnderlineBrushOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnderlineBrushOverrideProperty, (object)value);
		}
	}

	public Brush StrikeBrushOverride
	{
		get
		{
			return (Brush)((DependencyObject)this).GetValue(StrikeBrushOverrideProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StrikeBrushOverrideProperty, (object)value);
		}
	}

	public bool RenderTextShadow
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(RenderTextShadowProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RenderTextShadowProperty, (object)value);
		}
	}

	public bool CanTransform
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanTransformProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanTransformProperty, (object)value);
		}
	}

	public bool SpellCheckEnable
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SpellCheckEnableProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpellCheckEnableProperty, (object)value);
		}
	}

	private IEnumerable<string> SpellErrorSuggestions
	{
		get
		{
			return (IEnumerable<string>)((DependencyObject)this).GetValue(SpellErrorSuggestionsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SpellErrorSuggestionsProperty, (object)value);
		}
	}

	public bool IgnoreMargins
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IgnoreMarginsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IgnoreMarginsProperty, (object)value);
		}
	}

	public ICommand CreateDefaultTextBoxCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CreateDefaultTextBoxCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CreateDefaultTextBoxCommandProperty, (object)value);
		}
	}

	public event Action<Vector2<double>, CaretLocation, double>? CaretPositionChanged;

	public event Action? TextChanged;

	public event Action? ExitRequested;

	private static void OnTypefaceLibraryPropertyChanged(DependencyObject c, DependencyPropertyChangedEventArgs e)
	{
		((FormattedTextBox)(object)c).TypefaceLibraryChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TypefaceLibrary);
	}

	private static void OnDocumentPropertyChanged(DependencyObject c, DependencyPropertyChangedEventArgs e)
	{
		((FormattedTextBox)(object)c).LoadTextDocument(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TextDocument, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TextDocument);
	}

	private static void OnSelectionRangesPropertyChanged(DependencyObject c, DependencyPropertyChangedEventArgs e)
	{
		((FormattedTextBox)(object)c).SelectionRangesChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as Pro.Text.Range[], ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as Pro.Text.Range[]);
	}

	private static void OnCaretIndexPropertyChanged(DependencyObject c, DependencyPropertyChangedEventArgs e)
	{
		((FormattedTextBox)(object)c).CaretIndexChanged((int)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (int)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public FormattedTextBox()
		: this(null)
	{
	}

	public FormattedTextBox(Func<Vector2<double>, Color>? backlightSampler, Vector2<double> startingCaretPosition = default(Vector2<double>))
	{
		_backlightSampler = backlightSampler ?? ((Func<Vector2<double>, Color>)((Vector2<double> _) => Backlight));
		_startingCaretPosition = startingCaretPosition;
		InitializeComponent();
		base.LostFocus += FormattedTextBox_LostFocus;
		base.GotFocus += FormattedTextBox_GotFocus;
		base.Loaded += FormattedTextBox_Loaded;
		base.Unloaded += FormattedTextBox_Unloaded;
		if (!UnitTestDetector.IsInUnitTest)
		{
			TypefaceLibrary = SharedTypefaceLibrary.Library;
		}
		base.CommandBindings.Add(CommonApplicationCommands.CutCommand, CutText, () => Document != null && IsSelectionActive);
		base.CommandBindings.Add(CommonApplicationCommands.Copy, CopyText, () => Document != null && IsSelectionActive);
		base.CommandBindings.Add(CommonApplicationCommands.Paste, PasteText, () => Clipboard.ContainsText(TextDataFormat.Rtf) || Clipboard.ContainsText(TextDataFormat.UnicodeText));
		base.CommandBindings.Add(CommonApplicationCommands.SelectAllCommand, SelectAll, () => Document != null);
		base.CommandBindings.Add(CommonApplicationCommands.PasteAndMatchStyle, PasteAndMatchStyle, () => Clipboard.ContainsText(TextDataFormat.Rtf) || Clipboard.ContainsText(TextDataFormat.UnicodeText));
		base.CommandBindings.Add(CommonApplicationCommands.Delete, delegate
		{
			HandleKey((Key)32);
		});
		_spellChecker = UIServiceProvider.GetService<ISpellChecker>();
		_textDocumentFactory = UIServiceProvider.GetService<ITextDocumentFactory>();
	}

	public void SelectAll()
	{
		int num = Document?.LastCharacterIndex ?? 0;
		ChangeSelection(new Pro.Text.Range(0, num), num);
	}

	public void DeselectAll()
	{
		ChangeSelection(0);
	}

	public void SetCaretBeginning()
	{
		if (!(Document == null))
		{
			ChangeSelection(0);
		}
	}

	public void SetCaretEnd()
	{
		if (!(Document == null))
		{
			ChangeSelection(Document.LastCharacterIndex);
		}
	}

	public void SetCaretFromTop(Vector2<double> position)
	{
		SetCaret(new Vector2<double>(position.X, 0.0));
	}

	public void SetCaretFromBottom(Vector2<double> position)
	{
		SetCaret(new Vector2<double>(position.X, base.ActualHeight));
	}

	public void SetCaret(Vector2<double> position)
	{
		int num = _arrangedText?.FindCharacterIndex(position) ?? (-1);
		if (num >= 0)
		{
			ChangeSelection(num);
		}
	}

	public void AdjustCaretWidth(double factor)
	{
		_caretZoomFactor = factor;
		CaretIndicator caretIndicator = this.GetCaretIndicator();
		if (caretIndicator != null)
		{
			caretIndicator.ZoomFactor = factor;
		}
	}

	private void TypefaceLibraryChanged(TypefaceLibrary? library)
	{
		if (library != null)
		{
			if (_arrangedText != null)
			{
				_arrangedText.ArrangeInvalidated -= ArrangedTextInvalidated;
				_arrangedText.Dispose();
			}
			_arrangedText = new ArrangedText(library)
			{
				Document = Document,
				ClipToMaxBounds = false,
				CanTransform = CanTransform,
				IsMarginsIgnored = IgnoreMargins
			};
			_arrangedText.ArrangeInvalidated += ArrangedTextInvalidated;
		}
	}

	private void SetupTextComposition(ITextComposition textComposition)
	{
		if (_textComposition != null)
		{
			throw new InvalidOperationException();
		}
		_textComposition = textComposition;
		_textComposition.SetFocus();
		_textComposition.Started += OnCompositionStarted;
		_textComposition.Updated += OnCompositionUpdated;
		_textComposition.Complete += OnCompositionComplete;
	}

	private void SetupTextComposition()
	{
		if (_textComposition == null)
		{
			Window window = ((DependencyObject)(object)this).FindVisualParent<Window>();
			if (window != null)
			{
				SetupTextComposition(new Pro.Text.TextComposition(GetCompositionPosition, new WindowInteropHelper(window).EnsureHandle()));
			}
		}
	}

	private void FormattedTextBox_Loaded(object? sender, RoutedEventArgs e)
	{
		if (_startingCaretPosition != default(Vector2<double>))
		{
			SetCaret(_startingCaretPosition);
			_startingCaretPosition = default(Vector2<double>);
		}
	}

	private void FormattedTextBox_Unloaded(object? sender, RoutedEventArgs e)
	{
		if (_arrangedText != null)
		{
			_arrangedText.ArrangeInvalidated -= ArrangedTextInvalidated;
		}
		TeardownTextComposition();
		base.LostFocus -= FormattedTextBox_LostFocus;
		base.GotFocus -= FormattedTextBox_GotFocus;
	}

	private void TeardownTextComposition()
	{
		if (_textComposition != null)
		{
			_textComposition.Started -= OnCompositionStarted;
			_textComposition.Updated -= OnCompositionUpdated;
			_textComposition.Complete -= OnCompositionComplete;
			_textComposition = null;
		}
	}

	private void ArrangedTextInvalidated()
	{
		InvalidateMeasure();
		InvalidateVisual();
	}

	private void FormattedTextBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		InputMethod.SetIsInputMethodEnabled((DependencyObject)(object)this, value: false);
		InputMethod.SetIsInputMethodSuspended((DependencyObject)(object)this, value: false);
		TeardownTextComposition();
		if (!IsSelectionActive)
		{
			this.ResetSelectionIndicator();
		}
	}

	private void FormattedTextBox_GotFocus(object? sender, RoutedEventArgs e)
	{
		if (InputMethod.GetIsInputMethodEnabled((DependencyObject)(object)this))
		{
			InputMethod.SetIsInputMethodEnabled((DependencyObject)(object)this, value: false);
		}
		if (InputMethod.GetIsInputMethodSuspended((DependencyObject)(object)this))
		{
			InputMethod.SetIsInputMethodSuspended((DependencyObject)(object)this, value: false);
		}
		InputMethod.SetIsInputMethodEnabled((DependencyObject)(object)this, value: true);
		InputMethod.SetIsInputMethodSuspended((DependencyObject)(object)this, value: true);
		SetupTextComposition();
		_textComposition?.SetFocus();
		UpdateCaret();
	}

	private void LoadTextDocument(TextDocument? oldDocument, TextDocument? newDocument)
	{
		if (oldDocument != null)
		{
			oldDocument.DocumentChanged -= TextDocument_DocumentChanged;
		}
		if (newDocument != null)
		{
			newDocument.DocumentChanged += TextDocument_DocumentChanged;
		}
		if (_arrangedText != null)
		{
			_arrangedText.Document = newDocument;
		}
		ChangeSelection(0);
		UpdateActiveRunSettings();
		CheckSpelling();
		_wordsSinceLastSpellCheck = GetWords(Document?.AllText ?? string.Empty);
	}

	private void TextDocument_DocumentChanged(TextDocument document)
	{
		UpdateActiveRunSettings();
	}

	private void UpdateActiveRunSettings()
	{
		if (!_ignoreSelectionChanges)
		{
			TextDocument? document = Document;
			ActiveRunSettings = ((((object)document == null || !document.HasText) && (object)DefaultRunSettings != null) ? DefaultRunSettings : Document?.GetActiveRunSettings(SelectionRanges.FirstIndex(), SelectionRanges)?.Clone());
		}
	}

	private void AppendSelection(Pro.Text.Range appendRange, int caretIndex, bool useStoredRanges = true)
	{
		Pro.Text.Range[] lhs = ((useStoredRanges && !_storedSelectionRanges.IsEmpty()) ? _storedSelectionRanges : SelectionRanges);
		ChangeSelection(lhs.Join(appendRange), caretIndex, !useStoredRanges);
	}

	public void ChangeSelection(int index, bool canSpellCheck = true)
	{
		ChangeSelection(new Pro.Text.Range(index), index, canSpellCheck);
	}

	public void ChangeSelection(Pro.Text.Range range, int caretIndex, bool canSpellCheck = true)
	{
		ChangeSelection(range.MakeArray(), caretIndex, reset: true, canSpellCheck);
	}

	private void ChangeSelection(Pro.Text.Range[] newSelectionRanges, int caretIndex, bool reset, bool canSpellCheck = true)
	{
		_ignoreSelectionChanges = true;
		SelectionRanges = newSelectionRanges.Compact();
		CaretIndex = caretIndex;
		_ignoreSelectionChanges = false;
		if (reset)
		{
			_storedSelectionRanges = SelectionRanges;
		}
		UpdateActiveRunSettings();
		UpdateCaret();
		if ((object)Document != null)
		{
			Pro.Text.Range range = Document.FindWord(caretIndex);
			if (canSpellCheck && _currentWord != range)
			{
				CheckSpelling();
			}
			_currentWord = range;
		}
	}

	private string[] GetWords(string text)
	{
		return text.Split(new char[3] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)base.MeasureOverride(availableSize);
		vector = new Vector2<double>((!double.IsNaN(base.Width)) ? base.Width : ((!double.IsInfinity(((Size)(ref availableSize)).Width)) ? ((Size)(ref availableSize)).Width : vector.X), (!double.IsNaN(base.Height)) ? base.Height : ((!double.IsInfinity(((Size)(ref availableSize)).Height)) ? ((Size)(ref availableSize)).Height : vector.Y));
		if (_arrangedText != null)
		{
			_arrangedText.MaxSize = new Vector2<double>(AutoSizeWidth ? double.PositiveInfinity : vector.X, AutoSizeHeight ? double.PositiveInfinity : vector.Y);
			return new Vector2<double>(AutoSizeWidth ? _arrangedText.ArrangedSize.X : vector.X, AutoSizeHeight ? _arrangedText.ArrangedSize.Y : vector.Y);
		}
		return vector;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight));
		if (_arrangedText != null)
		{
			drawingContext.DrawRectangle(System.Windows.Media.Brushes.Transparent, null, _arrangedText.RenderBounds);
			List<(Pro.Text.Range range, bool renderFill)> ranges = new List<(Pro.Text.Range, bool)>();
			bool hasNonShadowCastingRanges = false;
			if (RenderTextShadow)
			{
				_arrangedText.FindCharacterFillRanges(Pro.Text.Range.All, delegate(Pro.Text.Range subRange, bool _, TextFillBase fill)
				{
					bool flag = fill.TextFillType != TextFillType.CutOut;
					ranges.Add((subRange, flag));
					if (!flag)
					{
						hasNonShadowCastingRanges = true;
					}
				});
			}
			if (hasNonShadowCastingRanges)
			{
				foreach (var item in ranges)
				{
					_arrangedText.RenderText(drawingContext, new TextRenderParams(FillBrushOverride, StrokeBrushOverride, UnderlineBrushOverride, StrikeBrushOverride, renderShadow: true, item.renderFill, useStandardMaskBrush: false, null, translateOverrideMaskBrush: true, item.range));
				}
				_arrangedText.RenderText(drawingContext, new TextRenderParams(FillBrushOverride, StrokeBrushOverride, UnderlineBrushOverride, StrikeBrushOverride, renderShadow: false, renderFill: true, useStandardMaskBrush: false, TextMaskBrush, translateOverrideMaskBrush: true, null));
			}
			else
			{
				_arrangedText.RenderText(drawingContext, new TextRenderParams(FillBrushOverride, StrokeBrushOverride, UnderlineBrushOverride, StrikeBrushOverride, RenderTextShadow, renderFill: true, useStandardMaskBrush: false, TextMaskBrush, translateOverrideMaskBrush: true, null));
			}
		}
		UpdateCaret();
		UpdateWrongSpellingIndicators();
	}

	private void UpdateCaret(CaretLocation location = CaretLocation.Body)
	{
		_caretPosition = _arrangedText?.GetCaretPosition(CaretIndex, out _caretHeight) ?? Vector2<double>.Zero;
		this.CaretPositionChanged?.Invoke(_caretPosition, location, _caretHeight);
		this.ResetSelectionIndicator();
		ArrangedText? arrangedText = _arrangedText;
		if (arrangedText != null && arrangedText.IsComposing)
		{
			this.ShowTextSelectionIndicator(_arrangedText.GetCompositionRects());
		}
		else if (IsSelectionActive)
		{
			IEnumerable<Rect<double>> rects = _arrangedText?.GetSelectionRects(SelectionRanges) ?? Array.Empty<Rect<double>>();
			this.ShowTextSelectionIndicator(rects);
		}
		if (base.IsFocused)
		{
			this.ShowCaretIndicator(_caretZoomFactor, _caretHeight, _caretPosition, _backlightSampler(_caretPosition + new Vector2<double>(0.0, _caretHeight)).IsLuminous() ? System.Windows.Media.Colors.Black : System.Windows.Media.Colors.White);
		}
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Focus();
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool flag = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		bool flag2 = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4);
		int num = (e.ClickCount - 1) % 3 + 1;
		if (e.ChangedButton != 0)
		{
			return;
		}
		e.Handled = true;
		_isMouseDown = true;
		_mouseDownPosition = (Vector2<double>)e.GetPosition(this);
		_mouseDownIndex = _arrangedText?.FindCharacterIndex(_mouseDownPosition) ?? 0;
		CancelComposition();
		switch (num)
		{
		case 1:
			if (!flag)
			{
				if (flag2)
				{
					int num2 = SelectionRanges.FirstIndex();
					int num3 = SelectionRanges.LastIndex();
					int start = ((_mouseDownIndex >= (num2 + num3) / 2) ? num2 : num3);
					ChangeSelection(new Pro.Text.Range(start, _mouseDownIndex), _mouseDownIndex);
				}
				else
				{
					ChangeSelection(_mouseDownIndex);
				}
			}
			else if (e.ClickCount == 1)
			{
				_storedSelectionRanges = SelectionRanges;
			}
			break;
		case 2:
		{
			Pro.Text.Range range2 = Document?.FindWord(_mouseDownIndex) ?? Pro.Text.Range.Empty;
			if (flag)
			{
				AppendSelection(range2, range2.End);
			}
			else
			{
				ChangeSelection(range2, range2.End);
			}
			break;
		}
		case 3:
		{
			Pro.Text.Range range = new Pro.Text.Range(_arrangedText?.FindFirstIndexOfLine(_mouseDownIndex) ?? 0, _arrangedText?.FindLastIndexOfLine(_mouseDownIndex) ?? 0);
			if (flag)
			{
				AppendSelection(range, range.End);
			}
			else
			{
				ChangeSelection(range, range.End);
			}
			break;
		}
		}
		CaptureMouse();
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left)
		{
			e.Handled = true;
			_isMouseDown = false;
			_isSelectionDragActive = false;
			ReleaseMouseCapture();
		}
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		if (!_isSelectionDragActive && _isMouseDown && base.IsFocused)
		{
			_isSelectionDragActive = e.CanDrag(this, _mouseDownPosition);
		}
		if (_isSelectionDragActive)
		{
			e.Handled = true;
			int num = _arrangedText?.FindCharacterIndex((Vector2<double>)e.GetPosition(this)) ?? 0;
			AppendSelection(new Pro.Text.Range(_mouseDownIndex, num), num);
		}
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		e.Handled = HandleKey(e.Key);
	}

	private bool HandleKey(Key key)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Invalid comparison between Unknown and I4
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Invalid comparison between Unknown and I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected I4, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Invalid comparison between Unknown and I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected I4, but got Unknown
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Invalid comparison between Unknown and I4
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Invalid comparison between Unknown and I4
		if (Document == null)
		{
			return true;
		}
		bool result = false;
		bool flag = false;
		ModifierKeys modifiers = Keyboard.Modifiers;
		bool flag2 = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
		bool shiftPressed = ((Enum)modifiers).HasFlag((Enum)(object)(ModifierKeys)4);
		bool flag3 = SelectionRanges.ContainsSelection();
		int num = ((!flag3 || (flag3 && shiftPressed)) ? CaretIndex : SelectionRanges.FirstIndex());
		int num2 = ((!flag3 || (flag3 && shiftPressed)) ? CaretIndex : SelectionRanges.LastIndex());
		CaretLocation location = CaretLocation.Body;
		if ((int)key <= 26)
		{
			switch (key - 2)
			{
			default:
				switch (key - 13)
				{
				case 10:
				{
					int num3 = num;
					int num4 = ((!flag2) ? ((!flag3 || (flag3 && shiftPressed)) ? Math.Max(num3 - 1, 0) : num3) : Document.FindWordStart(num3));
					adjustSelection(num4, num3, num4, CaretLocation.Beginning);
					result = true;
					break;
				}
				case 12:
				{
					int num9 = num2;
					int num10 = ((!flag2) ? ((!flag3 || (flag3 && shiftPressed)) ? Math.Min(num9 + 1, Document.LastCharacterIndex) : num9) : Document.FindWordEnd(num9));
					adjustSelection(num9, num10, num10, CaretLocation.End);
					result = true;
					break;
				}
				case 11:
				{
					int num13 = num;
					int num14 = _arrangedText?.FindIndexOnPreviousLine(num13) ?? 0;
					adjustSelection(num14, num13, num14, CaretLocation.Top);
					result = true;
					break;
				}
				case 13:
				{
					int num11 = num2;
					int num12 = _arrangedText?.FindIndexOnNextLine(num11) ?? 0;
					adjustSelection(num11, num12, num12, CaretLocation.Bottom);
					result = true;
					break;
				}
				case 9:
				{
					int num5 = num;
					int num6 = _arrangedText?.FindFirstIndexOfLine(num5) ?? 0;
					adjustSelection(num6, num5, num6);
					result = true;
					break;
				}
				case 8:
				{
					int num7 = num2;
					int num8 = _arrangedText?.FindLastIndexOfLine(num7) ?? 0;
					adjustSelection(num7, num8, num8);
					result = true;
					break;
				}
				case 0:
					this.ExitRequested?.Invoke();
					return true;
				case 5:
					HandleTextInput(" ");
					CheckSpelling();
					return true;
				}
				break;
			case 1:
				if ((Document.IsPartOfList(num) || Document.IsPartOfList(num2)) && (flag3 || Document.IsParagraphStart(CaretIndex)))
				{
					Document.IndentList(SelectionRanges, !shiftPressed);
				}
				else if (!shiftPressed)
				{
					HandleInput(1, (int index) => Document.InsertTabs(index, 1, ActiveRunSettings));
				}
				else if (Document.GetText(new Pro.Text.Range(CaretIndex - 1, CaretIndex)) == "\t")
				{
					ChangeSelection(CaretIndex - 1);
					Document.RemoveCharacter(CaretIndex);
				}
				result = true;
				flag = true;
				break;
			case 0:
				if (flag3)
				{
					ClearSelection();
				}
				else if (Document.IsPartOfList(CaretIndex) && Document.IsParagraphStart(CaretIndex))
				{
					Document.RemoveList(CaretIndex);
				}
				else if (Document.IsParagraphStart(CaretIndex) && Document.IsParagraphLeftIndented(CaretIndex))
				{
					Document.ResetLeftIndenting(CaretIndex);
				}
				else if (flag2)
				{
					ChangeSelection(Document.RemoveCharacters(new Pro.Text.Range(Document.FindWordStart(num), num)));
				}
				else if (CaretIndex > 0)
				{
					ChangeSelection(CaretIndex - 1);
					Document.RemoveCharacter(CaretIndex);
				}
				result = true;
				flag = true;
				break;
			case 4:
				if (Document.IsParagraphEmpty(CaretIndex) && Document.IsPartOfList(CaretIndex))
				{
					Document.RemoveList(CaretIndex);
				}
				else
				{
					ClearSelection();
					ChangeSelection(Document.InsertParagraph(CaretIndex));
				}
				result = true;
				flag = true;
				break;
			case 2:
			case 3:
				break;
			}
		}
		else if ((int)key != 31)
		{
			if ((int)key == 32)
			{
				if (flag3)
				{
					ClearSelection();
				}
				else if (flag2)
				{
					ChangeSelection(Document.RemoveCharacters(new Pro.Text.Range(num2, Document.FindWordEnd(num2))));
				}
				else
				{
					Document.RemoveCharacter(CaretIndex);
				}
				result = true;
				flag = true;
			}
		}
		else
		{
			_insertMode = !_insertMode;
			result = true;
		}
		if (flag2)
		{
			if ((int)key != 142)
			{
				if ((int)key == 144)
				{
					int? level = ActiveRunSettings?.ScriptLevel;
					Document.IterateRuns(SelectionRanges, splitRuns: true, delegate(RunBase r)
					{
						r.Settings.ScriptLevel = (level ?? r.Settings.ScriptLevel) + 1;
					});
					result = true;
					flag = true;
				}
			}
			else
			{
				int? level2 = ActiveRunSettings?.ScriptLevel;
				Document.IterateRuns(SelectionRanges, splitRuns: true, delegate(RunBase r)
				{
					r.Settings.ScriptLevel = (level2 ?? r.Settings.ScriptLevel) - 1;
				});
				result = true;
				flag = true;
			}
		}
		UpdateCaret(location);
		if (flag)
		{
			this.TextChanged?.Invoke();
		}
		return result;
		void adjustSelection(int start, int end, int caretIndex, CaretLocation caretLocation = CaretLocation.Body)
		{
			if (shiftPressed)
			{
				AppendSelection(new Pro.Text.Range(start, end), caretIndex, useStoredRanges: false);
			}
			else
			{
				if (start == end)
				{
					location = caretLocation;
				}
				ChangeSelection(caretIndex);
			}
		}
	}

	private void ClearSelection()
	{
		if (IsSelectionActive && Document != null)
		{
			ChangeSelection(Document.RemoveCharacters(SelectionRanges));
		}
	}

	private void OnCompositionStarted()
	{
		_compositionIndex = CaretIndex;
	}

	private Vector2<double> GetCompositionPosition()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = _caretPosition + new Vector2<double>(0.0, _caretHeight);
		Window window = ((DependencyObject)(object)this).FindVisualParent<Window>();
		if (window != null)
		{
			vector = (Vector2<double>)TransformToAncestor(window).Transform(vector);
		}
		return vector;
	}

	private void OnCompositionUpdated(string text)
	{
		if (!string.IsNullOrEmpty(text))
		{
			ClearSelection();
			_arrangedText?.SetComposition(_compositionIndex, text);
		}
	}

	private void OnCompositionComplete(string? text)
	{
		_arrangedText?.ClearComposition();
		if (!text.NullableIsNullOrEmpty())
		{
			HandleTextInput(text);
		}
		_compositionIndex = CaretIndex;
	}

	private void CancelComposition()
	{
		_textComposition?.Cancel();
	}

	protected override void OnTextInput(TextCompositionEventArgs e)
	{
		HandleTextInput(e.Text);
	}

	public void SendTextInput(TextCompositionEventArgs e)
	{
		OnTextInput(e);
	}

	private void HandleTextInput(string text)
	{
		HandleInput(text.Length, (int index) => Document?.InsertTextAndParagraphs(index, text, ActiveRunSettings) ?? (-1));
	}

	private void HandleTextInput(TextDocument? document)
	{
		if ((object)document != null)
		{
			HandleInput(document.AllText.Length, (int index) => Document?.InsertDocument(index, document) ?? (-1));
		}
	}

	private void HandleInput(int characterCount, Func<int, int> insertText)
	{
		if (Document == null || characterCount <= 0)
		{
			return;
		}
		_ignoreSelectionChanges = true;
		Document.UndoStack?.BeginCommit(UndoActionTypes.Text.ToAction());
		ClearSelection();
		if (_insertMode)
		{
			for (int i = 0; i < characterCount; i++)
			{
				Document.RemoveCharacter(CaretIndex);
			}
		}
		ShiftMisspelledWords(characterCount);
		ChangeSelection(insertText(CaretIndex), canSpellCheck: false);
		Document?.UndoStack?.EndCommit();
		_ignoreSelectionChanges = false;
		UpdateActiveRunSettings();
		this.TextChanged?.Invoke();
	}

	private void CutText()
	{
		CopyText();
		ClearSelection();
	}

	private void CopyText()
	{
		TextDocument textDocument = Document?.Subset(SelectionRanges);
		DataObject dataObject = new DataObject();
		dataObject.SetText(textDocument?.ToRTF() ?? string.Empty, TextDataFormat.Rtf);
		dataObject.SetText(textDocument?.AllText ?? string.Empty, TextDataFormat.UnicodeText);
		dataObject.SetData(TextDocumentFormatString, textDocument?.ToByteArray() ?? Array.Empty<byte>());
		Clipboard.SetDataObject(dataObject);
	}

	private void PasteText()
	{
		if ((object)Document == null)
		{
			CreateDefaultTextBoxCommand.Invoke();
		}
		string rtfString;
		string text;
		if (TryGetCustomData(out byte[] byteArr))
		{
			TextDocument document = _textDocumentFactory.Create(byteArr, "");
			HandleTextInput(document);
		}
		else if (TryGetRtfData(out rtfString))
		{
			HandleTextInput(ParseRtfString(rtfString));
		}
		else if (TryGetUnicodeText(out text))
		{
			HandleTextInput(text);
		}
		else
		{
			HandleTextInput(string.Empty);
		}
	}

	private void PasteAndMatchStyle()
	{
		string rtfString;
		if (TryGetUnicodeText(out string text))
		{
			HandleTextInput(text);
		}
		else if (TryGetRtfData(out rtfString))
		{
			HandleTextInput(ParseRtfString(rtfString)?.AllText ?? string.Empty);
		}
		else
		{
			HandleTextInput(string.Empty);
		}
	}

	private static TextDocument? ParseRtfString(string rtfString)
	{
		if (string.IsNullOrEmpty(rtfString))
		{
			return null;
		}
		try
		{
			TextDocument textDocument = rtfString.ToTextDocument();
			textDocument.IterateParagraphs(Pro.Text.Range.All, delegate(Paragraph p)
			{
				p.Settings.TabStops.Clear();
				p.Settings.LeftIndent = 0.0;
				p.Settings.RightIndent = 0.0;
				p.Settings.FirstLineIndent = 0.0;
			});
			textDocument.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				FontInfo info = SharedTypefaceLibrary.Library.FindFont(r.Settings.Font).Info;
				r.Settings.Font = info;
			});
			return textDocument;
		}
		catch (Exception ex)
		{
			Log.Error("Failed to parse RTF document: {0}", ex);
			return null;
		}
	}

	private void SelectionRangesChanged(Pro.Text.Range[]? oldRanges, Pro.Text.Range[]? newRanges)
	{
		if (Document?.UndoStack?.IsRecording == true)
		{
			Document.UndoStack.Commit(UndoActionTypes.Text.ToAction(), this, "SelectionRanges", oldRanges, newRanges);
		}
		else
		{
			Document?.UndoStack?.FinalizeNextAction();
		}
		UpdateActiveRunSettings();
	}

	private void CaretIndexChanged(int oldIndex, int newIndex)
	{
		if (Document?.UndoStack?.IsRecording == true)
		{
			Document.UndoStack.Commit(UndoActionTypes.Text.ToAction(), this, "CaretIndex", oldIndex, newIndex);
		}
		else
		{
			Document?.UndoStack?.FinalizeNextAction();
		}
		UpdateActiveRunSettings();
	}

	private void CheckSpelling()
	{
		checkSpellingAsync().ExecuteAsync();
		async Task checkSpellingAsync()
		{
			if (_spellChecker != null && SpellCheckEnable && (object)Document != null && Document.HasText)
			{
				string[] currentWords = GetWords(Document.AllText);
				if (!currentWords.ContentsMatchExactly(_wordsSinceLastSpellCheck))
				{
					IEnumerable<Pro.Text.Range> collection = await _spellChecker.GetMisspelledWordsAsync(Document.AllText);
					_misspelledWords.Clear();
					_misspelledWords.AddRange(collection);
					UpdateWrongSpellingIndicators();
				}
				_wordsSinceLastSpellCheck = currentWords;
			}
		}
	}

	private void UpdateWrongSpellingIndicators()
	{
		IEnumerable<Rect<double>> wordRects = _misspelledWords.SelectMany((Pro.Text.Range i) => _arrangedText?.GetSelectionRects(i) ?? Enumerable.Empty<Rect<double>>());
		this.ResetSpellErrorIndicator();
		this.ShowSpellError(wordRects);
	}

	private void TextMenu_Opened(object? sender, RoutedEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if ((object)Document != null)
		{
			_mouseDownPosition = (Vector2<double>)Mouse.GetPosition(this);
			_mouseDownIndex = _arrangedText?.FindCharacterIndex(_mouseDownPosition) ?? 0;
			Pro.Text.Range range = _misspelledWords.FirstOrDefault((Pro.Text.Range i) => _mouseDownIndex.IsInRange(i.Start, i.End));
			string text = Document.GetText(range);
			((DependencyObject)this).SetCurrentValue(SpellErrorSuggestionsProperty, (object)(_spellChecker?.GetSuggestions(text) ?? Enumerable.Empty<string>()));
		}
	}

	private void TextMenu_Closed(object? sender, RoutedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(SpellErrorSuggestionsProperty, (object)null);
	}

	private void ReplaceText_Click(object? sender, RoutedEventArgs e)
	{
		if ((object)Document != null && sender is MenuItem { Header: string header })
		{
			Pro.Text.Range range = Document.FindWord(_mouseDownIndex);
			Document.RemoveCharacters(range);
			Document.InsertText(range.Start, header);
			this.TextChanged?.Invoke();
			CheckSpelling();
		}
	}

	private void ShiftMisspelledWords(int characterCount)
	{
		Pro.Text.Range range = _misspelledWords.FirstOrDefault((Pro.Text.Range r) => CaretIndex.IsInRange(r.Start, r.End));
		if (range != default(Pro.Text.Range))
		{
			_misspelledWords.Remove(range);
		}
		Pro.Text.Range[] array = _misspelledWords.Where((Pro.Text.Range r) => CaretIndex <= r.Start).ToArray();
		foreach (Pro.Text.Range range2 in array)
		{
			int index = _misspelledWords.IndexOf(range2);
			_misspelledWords[index] = range2.OffSet(characterCount);
		}
	}

	private bool TryGetCustomData([NotNullWhen(true)] out byte[]? byteArr)
	{
		byteArr = null;
		try
		{
			if (Clipboard.ContainsData(TextDocumentFormatString))
			{
				byteArr = Clipboard.GetDataObject()?.GetData(TextDocumentFormatString) as byte[];
				return byteArr != null;
			}
			return false;
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			Log.Error("Clipboard system locked or inaccessible during custom format parsing: {0}", ex.Message);
			return false;
		}
	}

	private bool TryGetRtfData([NotNullWhen(true)] out string? rtfString)
	{
		rtfString = null;
		try
		{
			if (Clipboard.ContainsText(TextDataFormat.Rtf))
			{
				rtfString = Clipboard.GetText(TextDataFormat.Rtf);
				return rtfString != null;
			}
			return false;
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			Log.Error("Clipboard system locked or inaccessible during RTF format parsing: {0}", ex.Message);
			return false;
		}
	}

	private bool TryGetUnicodeText([NotNullWhen(true)] out string? text)
	{
		text = null;
		try
		{
			if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
			{
				text = Clipboard.GetText(TextDataFormat.UnicodeText);
				return text != null;
			}
			return false;
		}
		catch (Exception ex) when (((ex is COMException || ex is ExternalException) ? 1 : 0) != 0)
		{
			Log.Error("Clipboard system locked or inaccessible during text format parsing: {0}", ex.Message);
			return false;
		}
	}
}
