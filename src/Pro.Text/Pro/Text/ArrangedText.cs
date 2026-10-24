using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Pro.Common.Collections;
using Pro.Common.Effects;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.Text.Fills;
using Pro.Text.Runs;
using Pro.ssAPI;

namespace Pro.Text;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ArrangedText : IDisposable
{
	public delegate void LineIteratorDelegate(ParagraphAlignment alignment, Rect<double> bounds, bool hasNonWhitespaceCharacters);

	public delegate void FillRangeHandlerDelegate(Range range, bool isMask, TextFillBase fill);

	public delegate void ColorRangeHandlerDelegate(Range range, Color color);

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass138_0
	{
		public ArrangedText _003C_003E4__this;

		public List<Character> characters;

		public Vector2<double> layoutPosition;

		public RunSettings runSettings;

		public Vector2<double> annotationPosition;

		public int indexOffset;

		public double lineLeft;

		public double lineHeight;

		public bool documentHasAnnotation;

		public ParagraphSettings paragraphSettings;

		public bool isXInfinite;

		public Vector2<double> maxSize;

		public Vector2<double> startingPos;

		public int consumedCharacters;

		public int previousLineLastIndex;

		public int lastBreakIndex;

		public bool continueOnOverflow;

		public int lineLastIndex;

		public List<Line> lines;

		public List<int> wordBreaks;

		public bool hasBroken;

		public bool needsNewLine;

		public bool hasDelimited;

		public TextTransform textTransform;

		public bool isYInfinite;

		public Character tabChar;

		public List<Character> tabGroup;

		public Dictionary<int, int> levelCounter;

		public int characterCounter;

		public bool hasComposed;

		public Func<TextFillBase?> _003C_003E9__21;

		public Func<RunBase, (RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures)> _003C_003E9__23;

		public Func<int, (int indexOffset, RunSettings runSettings, int? scriptLevel)> _003C_003E9__43;

		public Func<int, RunSettings> _003C_003E9__44;

		public Func<TextFillBase?> _003C_003E9__45;

		internal TextFillBase? _003CDoArrange_003Eb__21()
		{
			return runSettings.Fill;
		}

		internal (RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) _003CDoArrange_003Eb__23(RunBase r)
		{
			bool isFallbackFont;
			return (run: r, fontData: (_003C_003E4__this._library.FindFont(r.Settings.Font.GetStyledFontVariant(), out isFallbackFont), isFallbackFont), textFeatures: GetTextFeatures(r.Settings));
		}

		internal (int indexOffset, RunSettings runSettings, int? scriptLevel) _003CDoArrange_003Eb__43(int i)
		{
			return (indexOffset: 0, runSettings: runSettings, scriptLevel: null);
		}

		internal RunSettings _003CDoArrange_003Eb__44(int i)
		{
			return runSettings;
		}

		internal TextFillBase? _003CDoArrange_003Eb__45()
		{
			return runSettings.Fill;
		}
	}

	private const double BaseFontSize = 24.0;

	private const double FillRatioLowerBound = 0.95;

	private const double FillRatioUpperBound = 1.0;

	private const double LowerTolerance = 1E-05;

	private const double UpperTolerance = 0.001;

	private const double LowerWeight = 0.55;

	private const double UpperWeight = 0.45;

	private const double LowerDecay = 0.25;

	private const double UpperDecay = 0.98;

	private const double LowerLimit = 10.0;

	private const double UpperLimit = 1000.0;

	private const int MaximumResizeAttempts = 20;

	private const double MiterLimit = 4.0;

	private const double MaxMaskBitmapSize = 16384.0;

	private static readonly Brush StandardMaskBrush = Brushes.White;

	public static readonly double MAXIMUM_STROKE_THICKNESS = 1000.0;

	private readonly TypefaceLibrary _library;

	private TextDocument? _document;

	private Vector2<double> _maxSize = new Vector2<double>(double.PositiveInfinity);

	private Rect<double>? _marginClipBounds;

	private bool _clipToMaxBounds = true;

	private bool _clipToMargins;

	private bool _renderAnnotations;

	private bool _arrangeValid;

	private Line[]? _lines;

	private Shadow? _shadow;

	private Vector2<double> _arrangedSize = Vector2<double>.Zero;

	private OverflowMode _overflowMode;

	private bool _didOverflow;

	private int _overflowCharacterIndex = -1;

	private int _overflowBreakIndex = -1;

	private double _baseScalar = 1.0;

	private double _textScalar = 1.0;

	private bool _isRenderPrepared;

	private Rect<double>? _renderBounds;

	private int _compositionIndex = -1;

	private string? _compositionString;

	private bool _canTransform = true;

	private bool _wordWrapped;

	private Brush[]? _maskBrushes;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool IsFrozen { get; private set; }

	public bool IsMarginsIgnored { get; set; }

	[MemberNotNullWhen(true, "_shadow")]
	public bool HasShadow
	{
		[MemberNotNullWhen(true, "_shadow")]
		get
		{
			EnsureArranged();
			return _shadow?.IsEnabled ?? false;
		}
	}

	public TextDocument? Document
	{
		get
		{
			return _document;
		}
		set
		{
			EnsureUnfrozen();
			if (_document != value)
			{
				if ((object)_document != null)
				{
					_document.DocumentChanged -= OnDocumentChanged;
				}
				_document = value;
				InvalidateArrange();
				if ((object)_document != null)
				{
					_document.DocumentChanged += OnDocumentChanged;
				}
			}
		}
	}

	public Vector2<double> MaxSize
	{
		get
		{
			return _maxSize;
		}
		set
		{
			EnsureUnfrozen();
			if (_maxSize != value)
			{
				_maxSize = value;
				InvalidateArrange();
			}
		}
	}

	public bool ClipToMaxBounds
	{
		get
		{
			return _clipToMaxBounds;
		}
		set
		{
			EnsureUnfrozen();
			if (_clipToMaxBounds != value)
			{
				_clipToMaxBounds = value;
				InvalidateArrange();
			}
		}
	}

	public bool ClipToMargins
	{
		get
		{
			return _clipToMargins;
		}
		set
		{
			EnsureUnfrozen();
			if (_clipToMargins != value)
			{
				_clipToMargins = value;
				InvalidateArrange();
			}
		}
	}

	public bool RenderAnnotations
	{
		get
		{
			return _renderAnnotations;
		}
		set
		{
			EnsureUnfrozen();
			if (_renderAnnotations != value)
			{
				_renderAnnotations = value;
				InvalidateArrange();
			}
		}
	}

	public Vector2<double> ArrangedSize
	{
		get
		{
			EnsureArranged();
			return _arrangedSize;
		}
	}

	public OverflowMode OverflowMode
	{
		get
		{
			return _overflowMode;
		}
		set
		{
			EnsureUnfrozen();
			if (_overflowMode != value)
			{
				_overflowMode = value;
				InvalidateArrange();
			}
		}
	}

	public bool StopOnOverflow => OverflowMode != OverflowMode.Continue;

	public bool DidOverflow
	{
		get
		{
			EnsureArranged();
			return _didOverflow;
		}
	}

	public int OverflowCharacterIndex
	{
		get
		{
			EnsureArranged();
			return _overflowCharacterIndex;
		}
	}

	public int OverflowBreakIndex
	{
		get
		{
			EnsureArranged();
			return _overflowBreakIndex;
		}
	}

	public int LineCount
	{
		get
		{
			EnsureArranged();
			return _lines.Length;
		}
	}

	public Rect<double> RenderBounds
	{
		get
		{
			EnsureArranged();
			if (!_renderBounds.HasValue)
			{
				_renderBounds = (from c in _lines.SelectMany((Line l) => l.Characters)
					select new Rect<double>(c.Position + c.GlyphBounds.Position, c.GlyphBounds.Size.Max(c.Advance - c.GlyphBounds.Position))).GetBoundingBox();
			}
			return _renderBounds.Value;
		}
	}

	public bool CanTransform
	{
		get
		{
			return _canTransform;
		}
		set
		{
			EnsureUnfrozen();
			if (_canTransform != value)
			{
				_canTransform = value;
				InvalidateArrange();
			}
		}
	}

	public bool IsComposing
	{
		get
		{
			if (_compositionIndex >= 0)
			{
				return !string.IsNullOrEmpty(_compositionString);
			}
			return false;
		}
	}

	public event Action? ArrangeInvalidated;

	public ArrangedText(TypefaceLibrary library)
	{
		_library = library;
	}

	public void Freeze()
	{
		if (!IsFrozen)
		{
			if ((object)_document != null)
			{
				_document.DocumentChanged -= OnDocumentChanged;
			}
			IsFrozen = true;
			EnsureArranged();
			EnsureRenderPrepared();
			_document = null;
			_shadow = _shadow?.Clone();
		}
	}

	private void EnsureUnfrozen()
	{
		if (IsFrozen)
		{
			throw new InvalidOperationException();
		}
	}

	public void RenderText(DrawingContext dc, TextRenderParams? renderOptions = null)
	{
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		if (renderOptions == null)
		{
			renderOptions = TextRenderParams.Default;
		}
		Range range = ((renderOptions.Range == Range.All) ? new Range(0, int.MaxValue) : renderOptions.Range);
		EnsureArranged();
		EnsureRenderPrepared();
		if (StopOnOverflow && _didOverflow)
		{
			throw new InvalidOperationException("Rendering overflowing text that hasn't been fully arranged is not supported");
		}
		DrawingContext drawingContext = dc;
		DrawingVisual drawingVisual = new DrawingVisual();
		if (HasShadow && renderOptions.RenderShadow)
		{
			drawingVisual.Effect = new DropShadowEffect
			{
				BlurRadius = _shadow.BlurRadius,
				Color = _shadow.Color,
				Opacity = _shadow.Opacity,
				Direction = _shadow.Angle.CartesianValue,
				ShadowDepth = _shadow.Offset,
				RenderingBias = RenderingBias.Quality
			};
			drawingContext = drawingVisual.RenderOpen();
		}
		bool flag = ClipToMaxBounds && (!double.IsInfinity(MaxSize.X) || !double.IsInfinity(MaxSize.Y));
		bool flag2 = ClipToMargins && _marginClipBounds.HasValue;
		bool num = flag || flag2;
		if (num)
		{
			Rect<double> rect = new Rect<double>(-2147483648.0, -2147483648.0, 4294967294.0, 4294967294.0);
			if (flag)
			{
				if (!double.IsInfinity(MaxSize.X))
				{
					rect.Left = Math.Max(rect.Left, 0.0);
					rect.Right = Math.Min(rect.Right, MaxSize.X);
				}
				if (!double.IsInfinity(MaxSize.Y))
				{
					rect.Top = Math.Max(rect.Top, 0.0);
					rect.Bottom = Math.Min(rect.Bottom, MaxSize.Y);
				}
			}
			if (flag2)
			{
				Rect<double> value = _marginClipBounds.Value;
				rect.Left = Math.Max(rect.Left, value.Left);
				rect.Top = Math.Max(rect.Top, value.Top);
				rect.Right = Math.Min(rect.Right, value.Right);
				rect.Bottom = Math.Min(rect.Bottom, value.Bottom);
			}
			drawingContext.PushClip(new RectangleGeometry(rect));
		}
		DoRender(drawingContext, range, renderOptions);
		if (num)
		{
			drawingContext.Pop();
		}
		if (HasShadow && renderOptions.RenderShadow)
		{
			drawingContext.Close();
			Rect val = Rect.Empty;
			try
			{
				val = drawingVisual.ContentBounds;
			}
			catch
			{
			}
			if (!((Rect)(ref val)).IsEmpty)
			{
				Vector2<double> vector = new Vector2<double>(_shadow.Offset, 0.0).Rotate(Vector2<double>.Zero, _shadow.Angle.InvertedCartesianValue);
				Rect<double> rect2 = ((Rect<double>)val).Pad(_shadow.BlurRadius);
				Rect<double> rect3 = new Rect<double>(rect2.Position + vector, rect2.Size);
				Rect<double> boundingBox = new Rect<double>[2] { rect2, rect3 }.GetBoundingBox();
				VisualBrush brush = new VisualBrush(drawingVisual)
				{
					Stretch = Stretch.None
				};
				dc.DrawRectangle(brush, null, boundingBox);
			}
		}
	}

	public void SetComposition(int index, string value)
	{
		EnsureUnfrozen();
		bool num = _compositionIndex != index || _compositionString != value;
		_compositionIndex = index;
		_compositionString = value;
		if (num)
		{
			InvalidateArrange();
		}
	}

	public void ClearComposition()
	{
		EnsureUnfrozen();
		bool isComposing = IsComposing;
		_compositionIndex = -1;
		_compositionString = null;
		if (isComposing)
		{
			InvalidateArrange();
		}
	}

	private void PrepareRender()
	{
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		if (_lines == null)
		{
			throw new InvalidOperationException();
		}
		_maskBrushes = null;
		DrawingVisual drawingVisual = new DrawingVisual
		{
			Effect = new InvertEffect
			{
				InvertRGB = false,
				InvertTransparency = true
			}
		};
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			Vector2<double>? currentScalar = null;
			Line[] lines = _lines;
			for (int i = 0; i < lines.Length; i++)
			{
				foreach (Character item in lines[i].Characters.Where((Character c) => c.Glyph != null))
				{
					PushCharacterScalar(drawingContext, ref currentScalar, item);
					drawingContext.PushTransform(GetCharacterTransform(item, currentScalar.Value));
					drawingContext.DrawGeometry(Brushes.White, item.IsStroked ? new Pen(Brushes.Transparent, item.StrokeThickness)
					{
						MiterLimit = 4.0
					} : null, item.Glyph.Geometry);
					drawingContext.Pop();
				}
			}
		}
		Rect contentBounds = drawingVisual.ContentBounds;
		Vector2<double> position = ((Vector2<double>)((Rect)(ref contentBounds)).TopLeft).Floor();
		contentBounds = drawingVisual.ContentBounds;
		Rect<double> rect = new Rect<double>(position, ((Vector2<double>)((Rect)(ref contentBounds)).Size).Ceiling());
		if (rect.Width <= 0.0 || rect.Height <= 0.0)
		{
			return;
		}
		try
		{
			List<Brush> list = new List<Brush>();
			for (double num = 0.0; num < rect.Width; num += 16384.0)
			{
				for (double num2 = 0.0; num2 < rect.Height; num2 += 16384.0)
				{
					Vector2<double> vector = rect.TopLeft + new Vector2<double>(num, num2);
					Vector2<double> size = new Vector2<double>(Math.Min(rect.Width - num, 16384.0), Math.Min(rect.Height - num2, 16384.0));
					drawingVisual.Offset = vector.Negate();
					using DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)size.X, (int)size.Y, 96.0, 96.0, PixelFormats.Pbgra32);
					disposableRenderTargetBitmap.Render(drawingVisual);
					disposableRenderTargetBitmap.Freeze();
					ImageBrush imageBrush = new ImageBrush((BitmapSource)disposableRenderTargetBitmap)
					{
						Viewport = new Rect<double>(vector, size),
						ViewportUnits = BrushMappingMode.Absolute,
						Stretch = Stretch.None
					};
					((Freezable)imageBrush).Freeze();
					list.Add(imageBrush);
				}
			}
			_maskBrushes = list.ToArray();
		}
		catch (Exception ex)
		{
			Log.Info("Failed to Create Mask Bitmap - error: {0}", ex.Message);
		}
	}

	private void DoRender(DrawingContext dc, Range range, TextRenderParams renderOptions)
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		if (_lines == null)
		{
			throw new InvalidOperationException();
		}
		Vector2<double>? currentScalar = null;
		if (!renderOptions.Flags.HasFlag(TextRenderOptions.UnderlineOnly) && !renderOptions.Flags.HasFlag(TextRenderOptions.MaskOnly))
		{
			if (renderOptions.RenderFill)
			{
				Line[] lines = _lines;
				foreach (Line line in lines)
				{
					foreach (Character[] item in line.Characters.Where((Character c) => shouldDrawCharacter(c, false)).ContiguousGroups(delegate(Character a, Character b)
					{
						Color? highlightColor = a.HighlightColor;
						Color? highlightColor2 = b.HighlightColor;
						if (highlightColor.HasValue != highlightColor2.HasValue)
						{
							return false;
						}
						return !highlightColor.HasValue || highlightColor.GetValueOrDefault() == highlightColor2.GetValueOrDefault();
					}))
					{
						Color? highlightColor3 = item[0].HighlightColor;
						if (highlightColor3.HasValue)
						{
							Rect<double> boundingBox = (from c in item
								where c.Glyph != null && !c.IsWhitespace
								select new Rect<double>(c.Position.X, line.Top, c.Advance.X, line.LineHeight)).GetBoundingBox();
							dc.DrawRectangle(new SolidColorBrush(highlightColor3.Value), null, boundingBox);
						}
					}
				}
			}
			if (renderOptions.RenderStroke)
			{
				Brush[] array = _maskBrushes ?? new Brush[1];
				foreach (Brush brush2 in array)
				{
					bool flag = brush2 != null;
					Rect<double> targetRect = ((Rect<double>?)(brush2 as TileBrush)?.Viewport) ?? Rect<double>.Empty;
					if (flag)
					{
						dc.PushOpacityMask(brush2);
					}
					Line[] lines = _lines;
					for (int j = 0; j < lines.Length; j++)
					{
						foreach (Character item2 in lines[j].Characters.Where((Character c) => shouldDrawCharacter(c, false) && c.Glyph != null && c.StrokeThickness != 0.0 && c.StrokeColor.A > 0))
						{
							double num = 4.0;
							if (flag)
							{
								Rect<double> glyphBounds = item2.GlyphBounds;
								glyphBounds.Position += item2.Position;
								glyphBounds = glyphBounds.Pad(item2.StrokeThickness / 2.0 * num);
								if (!glyphBounds.Intersects(targetRect))
								{
									continue;
								}
							}
							PushCharacterScalar(dc, ref currentScalar, item2);
							dc.PushTransform(GetCharacterTransform(item2, currentScalar.Value));
							dc.DrawGeometry(null, new Pen(renderOptions.OverrideStrokeBrush ?? new SolidColorBrush(item2.StrokeColor), item2.StrokeThickness)
							{
								MiterLimit = num
							}, item2.Glyph.Geometry);
							dc.Pop();
						}
					}
					if (flag)
					{
						ClearCharacterScalar(dc, ref currentScalar);
						dc.Pop();
					}
				}
			}
		}
		LineHandler lineHandler = ((!renderOptions.Flags.HasFlag(TextRenderOptions.UnderlineOnly) && renderOptions.RenderLines) ? new LineHandler(LineHandler.LineType.Strikethrough, DrawLine, renderOptions.OverrideStrikeBrush, getLineBrush, (Character c) => checkMaskState(c.LineFill?.IsMask)) : null);
		LineHandler lineHandler2 = ((!renderOptions.Flags.HasFlag(TextRenderOptions.NoUnderline) && renderOptions.RenderLines) ? new LineHandler(LineHandler.LineType.Underline, DrawLine, renderOptions.OverrideUnderlineBrush, getLineBrush, (Character c) => checkMaskState(c.UnderlineFill?.IsMask)) : null);
		if (lineHandler != null || lineHandler2 != null || (!renderOptions.Flags.HasFlag(TextRenderOptions.UnderlineOnly) && renderOptions.RenderFill))
		{
			Line[] lines = _lines;
			foreach (Line line2 in lines)
			{
				foreach (Character item3 in line2.Characters.Where((Character c) => shouldDrawCharacter(c, null)))
				{
					PushCharacterScalar(dc, ref currentScalar, item3);
					if (item3.Glyph != null)
					{
						if (renderOptions.OverrideFillBrush == null)
						{
							TextFillBase? fill2 = item3.Fill;
							if ((object)fill2 == null || fill2.IsTransparent)
							{
								goto IL_06b9;
							}
						}
						if (checkMaskState(item3.Fill?.IsMask) && !renderOptions.Flags.HasFlag(TextRenderOptions.UnderlineOnly) && renderOptions.RenderFill)
						{
							Brush brush3 = renderOptions.OverrideFillBrush ?? GetFillBrush(item3.Fill ?? new SolidTextFill(Colors.Black), item3.Position, item3.GlyphBounds, item3.FillGroupBounds, MaxSize, currentScalar ?? Vector2<double>.One, renderOptions, forLine: false);
							dc.PushTransform(GetCharacterTransform(item3, currentScalar ?? Vector2<double>.One));
							dc.DrawGeometry(brush3, null, item3.Glyph.Geometry);
							dc.Pop();
						}
					}
					goto IL_06b9;
					IL_06b9:
					lineHandler?.HandleCharacter(line2, item3);
					lineHandler2?.HandleCharacter(line2, item3);
				}
				lineHandler?.HandleLineEnd(line2);
				lineHandler2?.HandleLineEnd(line2);
			}
		}
		ClearCharacterScalar(dc, ref currentScalar);
		void DrawLine(Rect<double> rect, Brush brush)
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			Vector2<double> scalar = (currentScalar.HasValue ? currentScalar.Value.Invert() : Vector2<double>.One);
			Rect<double> rect2 = rect.Scale(scalar);
			dc.DrawRectangle(brush, null, rect2);
		}
		bool checkMaskState(bool? isMask)
		{
			if (renderOptions.Flags.HasFlag(TextRenderOptions.MaskOnly) && isMask == false)
			{
				return false;
			}
			if (renderOptions.Flags.HasFlag(TextRenderOptions.NoMask) && isMask == true)
			{
				return false;
			}
			return true;
		}
		Brush? getLineBrush(TextFillBase? fill, Rect<double> lineBounds, Rect<double> fillGroupBounds)
		{
			return GetFillBrush(fill, Vector2<double>.Zero, lineBounds, fillGroupBounds, MaxSize, currentScalar ?? Vector2<double>.One, renderOptions, forLine: true);
		}
		bool shouldDrawCharacter(Character character, bool? isMask = null)
		{
			if (character.Index < range.Start || character.Index >= range.End)
			{
				return false;
			}
			if (!checkMaskState(isMask))
			{
				return false;
			}
			return true;
		}
	}

	private static void PushCharacterScalar(DrawingContext dc, [NotNull] ref Vector2<double>? currentScalar, Character character)
	{
		if (currentScalar.HasValue)
		{
			Vector2<double> finalScalar = character.CharInfo.FinalScalar;
			Vector2<double>? vector = currentScalar;
			if (!(finalScalar != vector))
			{
				goto IL_0075;
			}
		}
		if (currentScalar.HasValue)
		{
			dc.Pop();
		}
		dc.PushTransform(new ScaleTransform(character.CharInfo.FinalScalar.X, character.CharInfo.FinalScalar.Y));
		goto IL_0075;
		IL_0075:
		currentScalar = character.CharInfo.FinalScalar;
	}

	private static void ClearCharacterScalar(DrawingContext dc, ref Vector2<double>? currentScalar)
	{
		if (currentScalar.HasValue)
		{
			dc.Pop();
			currentScalar = null;
		}
	}

	private static TranslateTransform GetCharacterTransform(Character character, Vector2<double> currentScalar)
	{
		Vector2<double> vector = character.Position.ComponentwiseQuotient(currentScalar);
		return new TranslateTransform(vector.X, vector.Y);
	}

	private static Brush? GetFillBrush(TextFillBase? fill, Vector2<double> renderPosition, Rect<double> renderBounds, Rect<double> fillGroupBounds, Vector2<double> maxSize, Vector2<double> currentScalar, TextRenderParams renderOptions, bool forLine)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		if ((object)fill == null)
		{
			return null;
		}
		if (fill.IsMask && renderOptions.UseStandardMaskBrush)
		{
			return StandardMaskBrush;
		}
		switch (fill.TextFillType)
		{
		case TextFillType.SolidColor:
			return new SolidColorBrush(((SolidTextFill)fill).Color);
		case TextFillType.Gradient:
		{
			GradientTextFill gradientTextFill = (GradientTextFill)fill;
			if (forLine)
			{
				return null;
			}
			Rect<double> rect2 = ((gradientTextFill.StretchToDocumentBounds && maxSize.X.IsReal() && maxSize.Y.IsReal()) ? new Rect<double>(maxSize) : fillGroupBounds).Rotate(0.0 - gradientTextFill.Angle.InvertedCartesianValue);
			Vector2<double> vector5 = rect2.LeftCenter.Rotate(rect2.Center, gradientTextFill.Angle.InvertedCartesianValue);
			Vector2<double> vector6 = rect2.RightCenter.Rotate(rect2.Center, gradientTextFill.Angle.InvertedCartesianValue);
			return new LinearGradientBrush(gradientTextFill.StartColor, gradientTextFill.EndColor, 0.0)
			{
				StartPoint = (vector5 - (renderPosition + renderBounds.Position)).ComponentwiseQuotient(renderBounds.Size),
				EndPoint = (vector6 - (renderPosition + renderBounds.Position)).ComponentwiseQuotient(renderBounds.Size)
			};
		}
		case TextFillType.Media:
		{
			MediaTextFill mediaTextFill = (MediaTextFill)fill;
			if (!mediaTextFill.IsValid || mediaTextFill.Media?.PreviewImage == null)
			{
				return StandardMaskBrush;
			}
			Rect<double> rect = ((maxSize.X.IsReal() && maxSize.Y.IsReal()) ? new Rect<double>(maxSize) : fillGroupBounds);
			Vector2<double> vector3 = rect.Position - renderPosition;
			Vector2<double> vector4 = currentScalar.Invert();
			TransformGroup transformGroup2 = new TransformGroup();
			transformGroup2.Children.Add(new TranslateTransform(vector3.X, vector3.Y));
			transformGroup2.Children.Add(new ScaleTransform(vector4.X, vector4.Y));
			ImageBrush imageBrush = new ImageBrush(renderOptions.UseFullSizeMedia ? mediaTextFill.Media.FullSizeImage : mediaTextFill.Media.PreviewImage);
			imageBrush.Transform = transformGroup2;
			imageBrush.Viewport = new Rect<double>(rect.Size);
			imageBrush.ViewportUnits = BrushMappingMode.Absolute;
			ImageBrush imageBrush2 = imageBrush;
			imageBrush2.Stretch = mediaTextFill.Media.ScaleBehavior switch
			{
				ScaleBehavior.ScaleToFit => Stretch.Uniform, 
				ScaleBehavior.ScaleAndBlur => Stretch.Uniform, 
				ScaleBehavior.ScaleToFill => Stretch.UniformToFill, 
				ScaleBehavior.StretchToFill => Stretch.Fill, 
				_ => Stretch.Fill, 
			};
			return imageBrush;
		}
		case TextFillType.CutOut:
		case TextFillType.BackgroundInvert:
		case TextFillType.BackgroundBlur:
		{
			if (renderOptions.OverrideMaskBrush == null)
			{
				if (fill.TextFillType != TextFillType.CutOut)
				{
					return StandardMaskBrush;
				}
				return Brushes.Transparent;
			}
			if (!renderOptions.TranslateOverrideMaskBrush)
			{
				return renderOptions.OverrideMaskBrush;
			}
			Brush brush = renderOptions.OverrideMaskBrush.Clone();
			Vector2<double> vector = currentScalar.Invert();
			Vector2<double> vector2 = fillGroupBounds.Position - renderPosition;
			TransformGroup transformGroup = new TransformGroup();
			if (brush.Transform != null)
			{
				transformGroup.Children.Add(brush.Transform);
			}
			transformGroup.Children.Add(new TranslateTransform(vector2.X, vector2.Y));
			transformGroup.Children.Add(new ScaleTransform(vector.X, vector.Y));
			brush.Transform = transformGroup;
			return brush;
		}
		default:
			return null;
		}
	}

	public Vector2<double> GetCaretPosition(int caretIndex, out double caretHeight)
	{
		EnsureArranged();
		Line[] lines = _lines;
		int num = 0;
		Vector2<double> result;
		while (true)
		{
			if (num < lines.Length)
			{
				Line line = lines[num];
				Character character = null;
				foreach (Character item in line.Characters.Where((Character c) => c.IsSelectable))
				{
					int index = item.Index;
					bool flag = item.EndOfParagraph && index + 1 == caretIndex;
					if (index == caretIndex || flag)
					{
						if (character == null || flag)
						{
							double lineHeight = item.LineHeight;
							result = item.CharInfo.ScriptScalar;
							caretHeight = lineHeight * result.Y;
							Vector2<double> vector = (flag ? item.Advance : Vector2<double>.Zero);
							result = item.Position + vector;
						}
						else
						{
							caretHeight = character.LineHeight * character.CharInfo.ScriptScalar.Y;
							result = character.Position + character.Advance;
						}
						goto end_IL_014b;
					}
					character = item;
				}
				if (line.IndexOffset == caretIndex)
				{
					caretHeight = line.LineHeight;
					return new Vector2<double>(line.Left, line.Top);
				}
				num++;
				continue;
			}
			caretHeight = 0.0;
			return Vector2<double>.Zero;
			continue;
			end_IL_014b:
			break;
		}
		return result;
	}

	public void IterateLines(LineIteratorDelegate iterator)
	{
		EnsureArranged();
		_lines.ForEach(delegate(Line l)
		{
			iterator(l.Alignment, new Rect<double>(l.Left, l.Top, l.Right - l.Left, l.LineHeight), l.Characters.Any((Character c) => !c.IsWhitespace));
		});
	}

	public IEnumerable<Rect<double>> GetCompositionRects()
	{
		if (!IsComposing)
		{
			return Array.Empty<Rect<double>>();
		}
		return GetSelectionRects(new Range(_compositionIndex, (_compositionIndex + _compositionString?.Length).GetValueOrDefault()), includeEndOfParagraph: false);
	}

	public IEnumerable<Rect<double>> GetSelectionRects(Range[] ranges)
	{
		return ranges?.SelectMany(GetSelectionRects) ?? Array.Empty<Rect<double>>();
	}

	public IEnumerable<Rect<double>> GetSelectionRects(Range range)
	{
		return GetSelectionRects(range, includeEndOfParagraph: true);
	}

	private List<Rect<double>> GetSelectionRects(Range range, bool includeEndOfParagraph)
	{
		Line line = null;
		List<Rect<double>> lineRects = new List<Rect<double>>();
		List<Rect<double>> rects = new List<Rect<double>>();
		Action action = delegate
		{
			if (lineRects.Count > 0)
			{
				rects.Add(lineRects.GetBoundingBox());
				lineRects.Clear();
			}
		};
		int i;
		for (i = range.Start; i < range.End; i++)
		{
			Line line2 = FindLine(i);
			if (line2 != null)
			{
				Character character = line2.Characters.FirstOrDefault((Character c) => c.IsSelectable && (c.Index == i || (includeEndOfParagraph && c.EndOfParagraph && c.Index + 1 == i)));
				if (line2 != line)
				{
					action();
				}
				if (character != null)
				{
					lineRects.Add(new Rect<double>(character.Position, new Vector2<double>(character.Advance.X, character.LineHeight * character.CharInfo.ScriptScalar.Y)));
				}
				line = line2;
			}
		}
		action();
		return rects;
	}

	public int FindCharacterIndex(Vector2<double> position)
	{
		EnsureArranged();
		Line line = null;
		if ((object)_document == null || _lines.Length == 0 || position.Y < _lines.Min((Line l) => l.Top))
		{
			return 0;
		}
		if (position.Y > _lines.Max((Line l) => l.Top + l.LineHeight))
		{
			return _document.LastCharacterIndex;
		}
		for (int i = 0; i < _lines.Length; i++)
		{
			Line line2 = _lines[i];
			double num = 0.0;
			double num2 = 0.0;
			if (i > 0)
			{
				num = GetLineSpace(_lines[i - 1], line2) / 2.0;
			}
			if (i + 1 < _lines.Length)
			{
				num2 = GetLineSpace(line2, _lines[i + 1]) / 2.0;
			}
			if (line2.Top - num <= position.Y && line2.Top + line2.LineHeight + num2 >= position.Y)
			{
				line = line2;
				break;
			}
		}
		if (line == null)
		{
			return 0;
		}
		for (int j = 0; j < line.Characters.Length; j++)
		{
			Character character = line.Characters[j];
			double num3 = 0.0;
			double num4 = 0.0;
			if (!character.IsSelectable)
			{
				continue;
			}
			if (j > 0)
			{
				num3 = GetCharacterSpace(line.Characters[j - 1], character) / 2.0;
			}
			if (j + 1 < line.Characters.Length)
			{
				num4 = GetCharacterSpace(character, line.Characters[j + 1]) / 2.0;
			}
			if (character.Position.X - num3 <= position.X && character.Position.X + character.Advance.X + num4 >= position.X)
			{
				int num5 = character.Index;
				if (position.X > character.Position.X + character.Advance.X / 2.0)
				{
					num5++;
				}
				return num5;
			}
		}
		if (!line.Characters.Any((Character c) => c.IsSelectable) || position.X < line.Characters.Where((Character c) => c.IsSelectable).Min((Character c) => c.Position.X))
		{
			return line.Characters.FirstOrDefault((Character c) => c.IsSelectable)?.Index ?? line.IndexOffset;
		}
		Character character2 = line.Characters.Last((Character c) => c.IsSelectable);
		int num6 = character2.Index;
		if (character2.EndOfParagraph)
		{
			num6++;
		}
		return num6;
	}

	public int FindFirstIndexOfLine(int characterIndex)
	{
		return FindLine(characterIndex)?.Characters.FirstOrDefault((Character c) => c.IsSelectable)?.Index ?? characterIndex;
	}

	public int FindLastIndexOfLine(int characterIndex)
	{
		Line? line = FindLine(characterIndex);
		return ((line == null) ? ((int?)null) : (line.Characters.LastOrDefault((Character c) => c.IsSelectable)?.Index + 1)) ?? characterIndex;
	}

	public int FindIndexOnPreviousLine(int characterIndex)
	{
		return FindIndexOnOtherLine(characterIndex, -1);
	}

	public int FindIndexOnNextLine(int characterIndex)
	{
		return FindIndexOnOtherLine(characterIndex, 1);
	}

	private int FindIndexOnOtherLine(int characterIndex, int lineIndexChange)
	{
		if (_lines == null)
		{
			throw new InvalidOperationException();
		}
		Line value = FindLine(characterIndex);
		int num = _lines.IndexOf(value) + lineIndexChange;
		if (num >= 0 && num < _lines.Length)
		{
			Line line = _lines[num];
			double caretHeight;
			return FindCharacterIndex(new Vector2<double>(GetCaretPosition(characterIndex, out caretHeight).X, line.Top + line.LineHeight / 2.0));
		}
		return characterIndex;
	}

	private Line? FindLine(int characterIndex)
	{
		EnsureArranged();
		return _lines.FirstOrDefault((Line l) => l.IndexOffset == characterIndex || l.Characters.Where((Character c) => c.IsSelectable).Any((Character c) => c.Index == characterIndex || (c.EndOfParagraph && c.Index + 1 == characterIndex)));
	}

	public int GetFirstIndexOfLine(int lineIndex)
	{
		EnsureArranged();
		return _lines[lineIndex].Characters.FirstOrDefault((Character c) => c.IsSelectable)?.Index ?? _lines[lineIndex].IndexOffset;
	}

	public int GetLastIndexOfLine(int lineIndex)
	{
		EnsureArranged();
		Character? character = _lines[lineIndex].Characters.LastOrDefault((Character c) => c.IsSelectable);
		if (character == null)
		{
			return _lines[lineIndex].IndexOffset;
		}
		return character.Index + 1;
	}

	public bool HasMaskRanges()
	{
		EnsureArranged();
		return _lines.SelectMany((Line l) => l.Characters).Any((Character c) => c.Glyph != null && (c.Fill?.IsMask ?? false));
	}

	public void FindCharacterFillRanges(Range range, FillRangeHandlerDelegate groupHandler)
	{
		FindFillRanges(range, groupHandler, (Character a, Character b) => a.Fill == b.Fill, (Character c) => c.Fill);
	}

	public void FindStrikethroughFillRanges(Range range, FillRangeHandlerDelegate groupHandler)
	{
		FindFillRanges(range, groupHandler, (Character a, Character b) => a.LineFill == b.LineFill && a.IsStrickenthrough == b.IsStrickenthrough, (Character c) => c.LineFill, (Character c) => c.IsStrickenthrough);
	}

	public void FindUnderlineFillRanges(Range range, FillRangeHandlerDelegate groupHandler)
	{
		FindFillRanges(range, groupHandler, (Character a, Character b) => a.UnderlineFill == b.UnderlineFill && a.IsUnderlined == b.IsUnderlined, (Character c) => c.UnderlineFill, (Character c) => c.IsUnderlined);
	}

	public void FindHighlightColorRanges(Range range, ColorRangeHandlerDelegate groupHandler)
	{
		FindColorRanges(range, groupHandler, delegate(Character a, Character b)
		{
			Color? highlightColor = a.HighlightColor;
			Color? highlightColor2 = b.HighlightColor;
			if (highlightColor.HasValue != highlightColor2.HasValue)
			{
				return false;
			}
			return !highlightColor.HasValue || highlightColor.GetValueOrDefault() == highlightColor2.GetValueOrDefault();
		}, (Character c) => c.HighlightColor);
	}

	public void FindStrokeColorRanges(Range range, ColorRangeHandlerDelegate groupHandler)
	{
		FindColorRanges(range, groupHandler, (Character a, Character b) => a.StrokeColor == b.StrokeColor && a.IsStroked == b.IsStroked, (Character c) => c.StrokeColor, (Character c) => c.IsStroked);
	}

	private void FindFillRanges(Range range, FillRangeHandlerDelegate groupHandler, Func<Character, Character, bool> comparer, Func<Character, TextFillBase?> fillSelector, Predicate<Character>? filter = null)
	{
		FindRanges<Character>(range, delegate(Range range, Character firstCharacter)
		{
			TextFillBase textFillBase = fillSelector(firstCharacter);
			if ((object)textFillBase == null)
			{
				throw new InvalidOperationException();
			}
			groupHandler(range, textFillBase.IsMask, textFillBase);
		}, comparer, (Character c) => (object)fillSelector(c) != null && (filter?.Invoke(c) ?? true));
	}

	private void FindColorRanges(Range range, ColorRangeHandlerDelegate groupHandler, Func<Character, Character, bool> comparer, Func<Character, Color?> colorSelector, Predicate<Character>? filter = null)
	{
		FindRanges<Character>(range, delegate(Range range, Character firstCharacter)
		{
			Color? color = colorSelector(firstCharacter);
			if (!color.HasValue)
			{
				throw new InvalidOperationException();
			}
			groupHandler(range, color.Value);
		}, comparer, (Character c) => colorSelector(c).HasValue && (filter?.Invoke(c) ?? true));
	}

	private void FindRanges<T>(Range range, Action<Range, Character> groupHandler, Func<Character, Character, bool> comparer, Predicate<Character>? filter = null)
	{
		EnsureArranged();
		if (range == Range.All)
		{
			range = new Range(0, int.MaxValue);
		}
		foreach (Character[] item in (from c in _lines.SelectMany((Line l) => l.Characters)
			where c.Glyph != null && c.Index >= range.Start && c.Index < range.End
			orderby c.Index
			select c).ContiguousGroups(comparer))
		{
			Character character = item[0];
			if (filter == null || filter(character))
			{
				int start = item.Min((Character c) => c.Index);
				int end = item.Max((Character c) => c.Index) + 1;
				groupHandler?.Invoke(new Range(start, end), character);
			}
		}
	}

	private void OnDocumentChanged(TextDocument document)
	{
		InvalidateArrange();
	}

	private void InvalidateArrange()
	{
		EnsureUnfrozen();
		_arrangeValid = false;
		InvalidateRender();
		this.ArrangeInvalidated?.Invoke();
	}

	private void InvalidateRender()
	{
		EnsureUnfrozen();
		_maskBrushes = null;
		_isRenderPrepared = false;
	}

	private static double GetLineSpace(Line topLine, Line bottomLine)
	{
		return Math.Max(bottomLine.Top - (topLine.Top + topLine.LineHeight), 0.0);
	}

	private static double GetCharacterSpace(Character leftCharacter, Character rightCharacter)
	{
		return Math.Max(rightCharacter.Position.X - (leftCharacter.Position.X + leftCharacter.Advance.X), 0.0);
	}

	private void EnsureRenderPrepared()
	{
		if (!_isRenderPrepared)
		{
			_isRenderPrepared = true;
			PrepareRender();
		}
	}

	public static double GetEmptyTextHeight(RunSettings runSettings)
	{
		return SharedTypefaceLibrary.Library.FindFont(runSettings.Font).GetLineHeight(runSettings.CharacterSize);
	}

	[MemberNotNull("_lines")]
	private void EnsureArranged()
	{
		if (_lines != null && _arrangeValid)
		{
			return;
		}
		ScaleMode scaleMode = _document?.Settings.ScaleMode ?? ScaleMode.None;
		bool flag = ((scaleMode == ScaleMode.Up || scaleMode == ScaleMode.UpOrDown) ? true : false);
		bool flag2 = flag;
		flag = (uint)(scaleMode - 3) <= 1u;
		bool flag3 = flag;
		double fillRatio = 1.0;
		bool overflow = false;
		Arrange(1.0, 1.0, continueOnOverflow: false, ref fillRatio, ref overflow);
		if ((object)_document != null && (!double.IsInfinity(_maxSize.Y) || _wordWrapped) && ((flag2 && !overflow) || (flag3 && overflow)))
		{
			int minFont = int.MaxValue;
			_document.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
			{
				minFont = Math.Min(r.Settings.CharacterSize, minFont);
			});
			Arrange(1.0, 24.0 / (double)minFont, continueOnOverflow: false, ref fillRatio, ref overflow);
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			bool flag4 = true;
			int num4 = 0;
			bool didOverflow = false;
			int overflowCharacterIndex = -1;
			int overflowBreakIndex = -1;
			while (_wordWrapped || !(1.0 / fillRatio).IsInRangeInclusive(0.95, 1.0))
			{
				if (num4++ == 20)
				{
					Arrange(num3, null, continueOnOverflow: true, ref fillRatio, ref overflow);
					break;
				}
				if (flag4)
				{
					if (overflow)
					{
						num2 = fillRatio;
					}
					else
					{
						num = Math.Max(1.0, Math.Pow(fillRatio, 0.25));
						num2 = Math.Pow(fillRatio, 0.98);
					}
					flag4 = false;
				}
				else if (overflow)
				{
					num2 = Math.Min(_textScalar, num2);
				}
				else
				{
					num = Math.Max(_textScalar, num);
				}
				if (!overflow)
				{
					num3 = Math.Max(num3, _textScalar);
					didOverflow = _didOverflow;
					overflowCharacterIndex = _overflowCharacterIndex;
					overflowBreakIndex = _overflowBreakIndex;
				}
				double num5 = (num2 - num).Abs();
				if ((!overflow || num5 <= 1E-05) && num5 <= 0.001)
				{
					_didOverflow = didOverflow;
					_overflowCharacterIndex = overflowCharacterIndex;
					_overflowBreakIndex = overflowBreakIndex;
					break;
				}
				Arrange(num * 0.55 + num2 * 0.45, null, continueOnOverflow: true, ref fillRatio, ref overflow);
			}
		}
		_shadow = _document?.Settings.Shadow;
	}

	[MemberNotNull("_lines")]
	protected void Arrange(double scalar, double? baseScalar, bool continueOnOverflow, ref double fillRatio, ref bool overflow)
	{
		if (_lines == null || _textScalar != scalar || !_arrangeValid || baseScalar.HasValue)
		{
			if (baseScalar.HasValue)
			{
				_baseScalar = baseScalar.Value;
			}
			_textScalar = scalar;
			DoArrange(continueOnOverflow);
			double num = (((object)_document != null) ? (_document.Settings.Margins.Top + _document.Settings.Margins.Bottom) : 0.0);
			fillRatio = (_maxSize.Y - num) / _arrangedSize.Y;
			overflow = fillRatio < 1.0 || _wordWrapped;
			_arrangeValid = true;
		}
	}

	[MemberNotNull("_lines")]
	private void DoArrange(bool continueOnOverflow)
	{
		_003C_003Ec__DisplayClass138_0 CS_0024_003C_003E8__locals238 = new _003C_003Ec__DisplayClass138_0();
		CS_0024_003C_003E8__locals238._003C_003E4__this = this;
		CS_0024_003C_003E8__locals238.continueOnOverflow = continueOnOverflow;
		if (_library == null)
		{
			_lines = Array.Empty<Line>();
			return;
		}
		_wordWrapped = false;
		_arrangedSize = Vector2<double>.Zero;
		_marginClipBounds = null;
		_didOverflow = false;
		_overflowCharacterIndex = -1;
		_overflowBreakIndex = -1;
		_renderBounds = null;
		CS_0024_003C_003E8__locals238.textTransform = ((_canTransform && (object)_document != null) ? _document.Settings.Transform : TextTransform.None);
		bool flag = !CS_0024_003C_003E8__locals238.textTransform.TransformsLineReturns();
		CS_0024_003C_003E8__locals238.hasDelimited = false;
		TextDocument document = _document;
		FallbackFontProvider fallbackFontProvider = _library.FallbackFontProvider;
		CS_0024_003C_003E8__locals238.needsNewLine = false;
		CS_0024_003C_003E8__locals238.lines = new List<Line>();
		CS_0024_003C_003E8__locals238.characters = new List<Character>();
		CS_0024_003C_003E8__locals238.wordBreaks = new List<int>();
		CS_0024_003C_003E8__locals238.hasBroken = false;
		CS_0024_003C_003E8__locals238.hasComposed = false;
		CS_0024_003C_003E8__locals238.characterCounter = 0;
		CS_0024_003C_003E8__locals238.consumedCharacters = 0;
		CS_0024_003C_003E8__locals238.indexOffset = 0;
		CS_0024_003C_003E8__locals238.maxSize = MaxSize;
		CS_0024_003C_003E8__locals238.isXInfinite = double.IsInfinity(CS_0024_003C_003E8__locals238.maxSize.X);
		CS_0024_003C_003E8__locals238.isYInfinite = double.IsInfinity(CS_0024_003C_003E8__locals238.maxSize.Y);
		CS_0024_003C_003E8__locals238.startingPos = Vector2<double>.Zero;
		CS_0024_003C_003E8__locals238.layoutPosition = Vector2<double>.Zero;
		CS_0024_003C_003E8__locals238.annotationPosition = Vector2<double>.Zero;
		CS_0024_003C_003E8__locals238.lineLeft = 0.0;
		CS_0024_003C_003E8__locals238.lineHeight = 0.0;
		CS_0024_003C_003E8__locals238.documentHasAnnotation = false;
		CS_0024_003C_003E8__locals238.lastBreakIndex = -1;
		CS_0024_003C_003E8__locals238.lineLastIndex = -1;
		CS_0024_003C_003E8__locals238.previousLineLastIndex = -1;
		CS_0024_003C_003E8__locals238.paragraphSettings = new ParagraphSettings();
		CS_0024_003C_003E8__locals238.runSettings = new RunSettings();
		int num = -1;
		int num2 = -1;
		CS_0024_003C_003E8__locals238.levelCounter = new Dictionary<int, int>();
		CS_0024_003C_003E8__locals238.tabGroup = new List<Character>();
		CS_0024_003C_003E8__locals238.tabChar = null;
		if ((object)document != null)
		{
			Margins margins = document.Settings.Margins;
			CS_0024_003C_003E8__locals238.startingPos = (IsMarginsIgnored ? new Vector2<double>(0.0, 0.0) : new Vector2<double>(margins.Left, margins.Top));
			CS_0024_003C_003E8__locals238.layoutPosition = CS_0024_003C_003E8__locals238.startingPos;
			CS_0024_003C_003E8__locals238.annotationPosition = CS_0024_003C_003E8__locals238.layoutPosition;
			CS_0024_003C_003E8__locals238.documentHasAnnotation = RenderAnnotations && document.Any((Paragraph p) => p.Any((RunBase r) => !string.IsNullOrWhiteSpace(r.Settings?.ChordAnnotation)));
			if (!CS_0024_003C_003E8__locals238.isXInfinite && !IsMarginsIgnored)
			{
				CS_0024_003C_003E8__locals238.maxSize.X -= margins.Left + margins.Right;
			}
			if (!CS_0024_003C_003E8__locals238.isYInfinite && !IsMarginsIgnored)
			{
				CS_0024_003C_003E8__locals238.maxSize.Y -= margins.Top + margins.Bottom;
			}
			if (!CS_0024_003C_003E8__locals238.isXInfinite && !CS_0024_003C_003E8__locals238.isYInfinite)
			{
				_marginClipBounds = new Rect<double>(CS_0024_003C_003E8__locals238.startingPos, CS_0024_003C_003E8__locals238.maxSize);
			}
			foreach (Paragraph item5 in document.Where((Paragraph p) => p.Any()))
			{
				Paragraph paragraph = item5;
				_003C_003Ec__DisplayClass138_0 _003C_003Ec__DisplayClass138_ = CS_0024_003C_003E8__locals238;
				if (!continueArrange())
				{
					break;
				}
				if (_003C_003Ec__DisplayClass138_.lines.Count > 0)
				{
					_003C_003Ec__DisplayClass138_.layoutPosition.Y += Math.Max(_003C_003Ec__DisplayClass138_.paragraphSettings.AfterParagraph, paragraph.Settings.BeforeParagraph);
				}
				_003C_003Ec__DisplayClass138_.paragraphSettings = paragraph.Settings;
				double num3 = _003C_003Ec__DisplayClass138_.paragraphSettings.LeftIndent + _003C_003Ec__DisplayClass138_.paragraphSettings.FirstLineIndent;
				_003C_003Ec__DisplayClass138_.layoutPosition.X += num3;
				_003C_003Ec__DisplayClass138_.lineLeft += num3;
				string shapedText = string.Empty;
				List<ShapedCharacter> shapedCharacters2 = new List<ShapedCharacter>();
				List<RunSettings> settingsLookup = new List<RunSettings>();
				List<ShapedCharacter[]?> annotationsLookup2 = new List<ShapedCharacter[]>();
				bool flag2 = true;
				RunSettings settings = paragraph.First().Settings;
				_003C_003Ec__DisplayClass138_.lineHeight = _library.FindFont(settings.Font.GetStyledFontVariant()).GetLineHeight(scaleCharacterSize(settings.CharacterSize));
				bool isFallbackFont;
				foreach ((RunBase, (Font, bool), TextFeature)[] item6 in paragraph.Select((RunBase r) => ((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures))(run: r, fontData: (_003C_003Ec__DisplayClass138_._003C_003E4__this._library.FindFont(r.Settings.Font.GetStyledFontVariant(), out isFallbackFont), isFallbackFont), textFeatures: GetTextFeatures(r.Settings))).ContiguousGroups(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) a, (RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) b) => a.run.RunType == b.run.RunType && a.textFeatures == b.textFeatures && (a.fontData.font == b.fontData.font || string.IsNullOrWhiteSpace(b.run.PlainText))))
				{
					if (!continueArrange())
					{
						break;
					}
					(Font, bool) tuple = (item6.Any(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => !string.IsNullOrWhiteSpace(r.run.PlainText)) ? item6.FirstOrDefault(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => !string.IsNullOrWhiteSpace(r.run.PlainText)).fontData : item6[0].Item2);
					RunType runType = item6[0].Item1.RunType;
					TextFeature item = item6[0].Item3;
					var (font, _) = tuple;
					if (runType == RunType.Text && tuple.Item2)
					{
						string text = string.Join(string.Empty, item6.Select(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => r.run.PlainText));
						Font font2 = _library.FallbackFontProvider.FindFallbackFont(text);
						if ((object)font2 != null)
						{
							font = font2;
						}
					}
					if (flag2)
					{
						if (_003C_003Ec__DisplayClass138_.paragraphSettings.IsPartOfList && _003C_003Ec__DisplayClass138_.paragraphSettings.ListIndex < document.ListSettingsCollection.Count)
						{
							if (num != _003C_003Ec__DisplayClass138_.paragraphSettings.ListIndex)
							{
								_003C_003Ec__DisplayClass138_.levelCounter.Clear();
							}
							ListSettings listSettings = document.ListSettingsCollection[_003C_003Ec__DisplayClass138_.paragraphSettings.ListIndex];
							int levelIndex2 = _003C_003Ec__DisplayClass138_.paragraphSettings.LevelIndex;
							LevelSettings levelSettings = listSettings.Levels.GetLevelSettings(levelIndex2);
							for (int j = num2; j < levelIndex2; j++)
							{
								_003C_003Ec__DisplayClass138_.levelCounter[j + 1] = listSettings.Levels.GetLevelSettings(j + 1).StartNumber;
							}
							string[] array = (from i in Enumerable.Range(0, levelIndex2 + 1)
								select NumberingProvider.GetNumberString(getLevelCount(i), levelSettings.NumberingScheme)).ToArray();
							Font font3 = font;
							string numberingFormat = levelSettings.NumberingFormat;
							object[] args = array;
							using (ShapedTextRun shapedTextRun2 = new ShapedTextRun(font3, fallbackFontProvider, string.Format(numberingFormat, args) + ((levelSettings.Follow == FollowType.Space) ? " " : string.Empty), GetTextFeatures(null)))
							{
								RunSettings runGroupSettings = item6[0].Item1.Settings;
								ShapedCharacter[] shapedCharacters3 = getShapedCharacters(shapedTextRun2, (int i) => ((int indexOffset, RunSettings runSettings, int? scriptLevel))(indexOffset: 0, runSettings: runGroupSettings, scriptLevel: null), _003C_003Ec__DisplayClass138_.paragraphSettings.BulletScalar).ToArray();
								TextFillBase bulletFill = ((_003C_003Ec__DisplayClass138_.paragraphSettings.BulletColor.HasValue && _003C_003Ec__DisplayClass138_.paragraphSettings.BulletColor.Value.A != 0) ? new SolidTextFill(_003C_003Ec__DisplayClass138_.paragraphSettings.BulletColor.Value) : runGroupSettings.Fill);
								addText(shapedTextRun2.Text, shapedCharacters3, doesConsume: false, (int i) => runGroupSettings, () => bulletFill, 0);
							}
							if (levelSettings.Follow == FollowType.Tab)
							{
								addTabs(1, doesConsume: false, allowDefault: false, 0);
							}
							_003C_003Ec__DisplayClass138_.levelCounter[levelIndex2] = getLevelCount(levelIndex2) + 1;
							num = _003C_003Ec__DisplayClass138_.paragraphSettings.ListIndex;
							num2 = levelIndex2;
							_003C_003Ec__DisplayClass138_.lineLeft = _003C_003Ec__DisplayClass138_.layoutPosition.X;
						}
						else
						{
							_003C_003Ec__DisplayClass138_.levelCounter.Clear();
							num = -1;
							num2 = -1;
						}
					}
					switch (runType)
					{
					case RunType.Text:
					{
						int lookupOffset = settingsLookup.Count;
						int runLength2 = item6.CountMany(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => r.run.Length);
						string text2 = string.Empty;
						bool flag3 = shouldCompose(runLength2);
						int num5 = (flag3 ? (_compositionIndex - _003C_003Ec__DisplayClass138_.characterCounter) : (-1));
						foreach (TextRun item7 in item6.Select(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => (TextRun)r.run))
						{
							TextRun textRun = item7;
							string text3 = textRun.Settings.CapitalizationType.CapitalizeText(textRun.Text);
							for (int k = 0; k < text3.Length; k++)
							{
								settingsLookup.Add(textRun.Settings);
							}
							text2 += text3;
							if (RenderAnnotations)
							{
								if (!string.IsNullOrWhiteSpace(textRun.Settings.ChordAnnotation))
								{
									Font font4 = font;
									if (tuple.Item2)
									{
										Font font5 = _library.FallbackFontProvider.FindFallbackFont(textRun.Settings.ChordAnnotation);
										if ((object)font5 != null)
										{
											font4 = font5;
										}
									}
									using ShapedTextRun shapedTextRun4 = new ShapedTextRun(font4, fallbackFontProvider, textRun.Settings.ChordAnnotation?.Trim() + "\u00a0", TextFeature.None);
									annotationsLookup2.Add(getShapedCharacters(shapedTextRun4, (int i) => ((int indexOffset, RunSettings runSettings, int? scriptLevel))(indexOffset: 0, runSettings: textRun.Settings, scriptLevel: getScriptLevel(i)), 1.0).ToArray());
								}
								else
								{
									annotationsLookup2.Add(null);
								}
								for (int m = 1; m < textRun.Length; m++)
								{
									annotationsLookup2.Add(null);
								}
							}
							if (flag3 && !_003C_003Ec__DisplayClass138_.hasComposed && text2.Length >= num5)
							{
								string text4 = textRun.Settings.CapitalizationType.CapitalizeText(_compositionString);
								for (int n = 0; n < text4.Length; n++)
								{
									settingsLookup.Add(textRun.Settings);
								}
								text2 = text2.Insert(num5, text4);
								_003C_003Ec__DisplayClass138_.hasComposed = true;
							}
							int getScriptLevel(int i)
							{
								return textRun.Settings.ChordSuperscriptRanges.Any((Range r) => r.Contains(i)) ? 1 : 0;
							}
						}
						shapedText += text2;
						using (ShapedTextRun shapedTextRun5 = new ShapedTextRun(font, fallbackFontProvider, text2, item))
						{
							shapedCharacters2.AddRange(getShapedCharacters(shapedTextRun5, (int i) => ((int indexOffset, RunSettings runSettings, int? scriptLevel))(indexOffset: lookupOffset, runSettings: settingsLookup[i + lookupOffset], scriptLevel: null), 1.0).ToArray());
						}
						break;
					}
					case RunType.Tab:
					{
						addShapedText();
						alignTabGroup();
						int num4 = item6.CountMany(((RunBase run, (Font font, bool isFallbackFont) fontData, TextFeature textFeatures) r) => ((TabRun)r.run).TabCount);
						addTabs(num4, doesConsume: true, allowDefault: true, paragraph.TextLength);
						consumeCharacters(num4);
						if (!shouldCompose(num4))
						{
							break;
						}
						RunSettings compositionRunSettings = item6.Last().Item1.Settings;
						using (ShapedTextRun shapedTextRun3 = new ShapedTextRun(font, fallbackFontProvider, compositionRunSettings.CapitalizationType.CapitalizeText(_compositionString), item))
						{
							ShapedCharacter[] shapedCharacters4 = getShapedCharacters(shapedTextRun3, (int i) => ((int indexOffset, RunSettings runSettings, int? scriptLevel))(indexOffset: 0, runSettings: compositionRunSettings, scriptLevel: null), 1.0).ToArray();
							addText(shapedTextRun3.Text, shapedCharacters4, doesConsume: true, (int i) => compositionRunSettings, () => compositionRunSettings.Fill, paragraph.TextLength);
						}
						consumeCharacters(_compositionString?.Length ?? 0);
						_003C_003Ec__DisplayClass138_.hasComposed = true;
						break;
					}
					}
					flag2 = false;
				}
				addShapedText();
				alignTabGroup();
				consumeCharacters(1);
				if (!flag && (object)paragraph != document.Last())
				{
					if (!_003C_003Ec__DisplayClass138_.hasDelimited)
					{
						string text5 = ((_003C_003Ec__DisplayClass138_.textTransform == TextTransform.ReplaceLineReturns) ? document.Settings.TransformDelimiter : " ");
						bool isFallbackFont2;
						Font font6 = _library.FindFont(_003C_003Ec__DisplayClass138_.runSettings.Font, out isFallbackFont2);
						if (!string.IsNullOrWhiteSpace(text5) && isFallbackFont2)
						{
							Font font7 = _library.FallbackFontProvider.FindFallbackFont(text5);
							if ((object)font7 != null)
							{
								font6 = font7;
							}
						}
						using ShapedTextRun shapedTextRun6 = new ShapedTextRun(font6, fallbackFontProvider, text5, TextFeature.None);
						addText(shapedTextRun6.Text, getShapedCharacters(shapedTextRun6, (int i) => ((int indexOffset, RunSettings runSettings, int? scriptLevel))(indexOffset: 0, runSettings: _003C_003Ec__DisplayClass138_.runSettings, scriptLevel: null), 1.0).ToArray(), doesConsume: false, (int i) => _003C_003Ec__DisplayClass138_.runSettings, () => _003C_003Ec__DisplayClass138_.runSettings.Fill, paragraph.TextLength);
					}
					_003C_003Ec__DisplayClass138_.hasDelimited = true;
				}
				else
				{
					startNewLine(0.0, endOfParagraph: true);
				}
				void addShapedText()
				{
					if (!string.IsNullOrEmpty(shapedText))
					{
						addText(shapedText, shapedCharacters2.ToArray(), doesConsume: true, (int i) => settingsLookup[i], () => _003C_003Ec__DisplayClass138_.runSettings.Fill, paragraph.TextLength, delegate(int i)
						{
							if (_003C_003Ec__DisplayClass138_._003C_003E4__this.RenderAnnotations)
							{
								ShapedCharacter[] array3 = annotationsLookup2[i];
								if (array3 != null)
								{
									_003C_003Ec__DisplayClass138_.layoutPosition.X = Math.Max(_003C_003Ec__DisplayClass138_.layoutPosition.X, _003C_003Ec__DisplayClass138_.annotationPosition.X);
									_003C_003Ec__DisplayClass138_.annotationPosition = _003C_003Ec__DisplayClass138_.layoutPosition;
									ShapedCharacter[] array4 = array3;
									foreach (ShapedCharacter shapedCharacter in array4)
									{
										Character character6 = new Character(shapedCharacter, isSelectable: false, _003C_003Ec__DisplayClass138_.indexOffset + _003C_003Ec__DisplayClass138_.consumedCharacters, isWhitespace: false, 0, _003C_003Ec__DisplayClass138_.annotationPosition, _003C_003Ec__DisplayClass138_._003C_003E4__this._document.Settings.ChordPro.Color.HasValue ? new SolidTextFill(_003C_003Ec__DisplayClass138_._003C_003E4__this._document.Settings.ChordPro.Color.Value) : _003C_003Ec__DisplayClass138_.runSettings.Fill, _003C_003Ec__DisplayClass138_.runSettings.StrokeColor, _003C_003Ec__DisplayClass138_.runSettings.UnderlineColor, _003C_003Ec__DisplayClass138_.runSettings.HighlightColor, _003C_003Ec__DisplayClass138_.runSettings.StrokeThickness, _003C_003Ec__DisplayClass138_.runSettings.Strikethrough, _003C_003Ec__DisplayClass138_.runSettings.Underline, shapedCharacter.LineHeight, isAnnotation: true, endOfParagraph: false);
										character6.Position += shapedCharacter.Offset + character6.BaselineOffset;
										_003C_003Ec__DisplayClass138_.characters.Add(character6);
										_003C_003Ec__DisplayClass138_.annotationPosition += shapedCharacter.Advance;
									}
								}
							}
						}, annotationsLookup2);
						consumeCharacters(shapedText.Length);
						shapedText = string.Empty;
						shapedCharacters2.Clear();
						settingsLookup.Clear();
						annotationsLookup2.Clear();
					}
				}
			}
			if (!CS_0024_003C_003E8__locals238.isYInfinite && continueArrange())
			{
				AlignDocument(CS_0024_003C_003E8__locals238.lines, CS_0024_003C_003E8__locals238.maxSize.Y + CS_0024_003C_003E8__locals238.startingPos.Y - _arrangedSize.Y, document.Settings.Alignment, document.Settings.Transform);
			}
			_arrangedSize -= (IsMarginsIgnored ? new Vector2<double>(0.0, 0.0) : new Vector2<double>(margins.Left, margins.Top));
		}
		foreach (Character[] item8 in (from c in CS_0024_003C_003E8__locals238.lines.SelectMany((Line l) => l.Characters)
			where c.Glyph != null && c.IsSelectable
			orderby c.Index
			select c).ContiguousGroups((Character a, Character b) => a.Fill == b.Fill))
		{
			Rect<double> boundingBox = item8.Select(delegate(Character c)
			{
				Rect<double> glyphBounds = c.GlyphBounds;
				glyphBounds.Position += c.Position;
				return glyphBounds;
			}).GetBoundingBox();
			Character[] array2 = item8;
			for (int num6 = 0; num6 < array2.Length; num6++)
			{
				array2[num6].FillGroupBounds = boundingBox;
			}
		}
		_lines = CS_0024_003C_003E8__locals238.lines.ToArray();
		void addTabs(int tabCount, bool doesConsume, bool allowDefault, int paragraphLength)
		{
			for (int num24 = 0; num24 < tabCount; num24++)
			{
				TabStopType type = TabStopType.Left;
				double num25 = CS_0024_003C_003E8__locals238.paragraphSettings.TabStops.FindNextStopPosition(CS_0024_003C_003E8__locals238.layoutPosition.X, out type, allowDefault);
				double num26 = num25 - CS_0024_003C_003E8__locals238.layoutPosition.X;
				if (type != 0)
				{
					num25 = CS_0024_003C_003E8__locals238.layoutPosition.X;
				}
				double x3 = num25 - CS_0024_003C_003E8__locals238.layoutPosition.X;
				Character character5 = (CS_0024_003C_003E8__locals238.tabChar = new Character(new ShapedCharacter(0u, (uint)num24, 0, isRTL: false, -1, new Vector2<double>(x3, 0.0), Vector2<double>.Zero, 0.0, null, 1.0, Vector2<double>.One), doesConsume, CS_0024_003C_003E8__locals238.indexOffset + CS_0024_003C_003E8__locals238.consumedCharacters, isWhitespace: true, 0, CS_0024_003C_003E8__locals238.layoutPosition, null, Colors.Transparent, null, null, 0.0, isStrickenthrough: false, isUnderlined: false, CS_0024_003C_003E8__locals238.lineHeight, isAnnotation: false, doesConsume && num24 + CS_0024_003C_003E8__locals238.consumedCharacters == paragraphLength - 1)
				{
					IsTab = true,
					TabStopType = type,
					TabAdvance = num26
				});
				CS_0024_003C_003E8__locals238.characters.Add(character5);
				CS_0024_003C_003E8__locals238.layoutPosition.X += num26;
				CS_0024_003C_003E8__locals238.lastBreakIndex = character5.Index;
			}
			if (CS_0024_003C_003E8__locals238.tabChar != null && CS_0024_003C_003E8__locals238.tabChar.TabStopType != 0)
			{
				CS_0024_003C_003E8__locals238.layoutPosition.X -= CS_0024_003C_003E8__locals238.tabChar.TabAdvance;
			}
		}
		void addText(string originalText, ShapedCharacter[] shapedCharacters, bool doesConsume, Func<int, RunSettings> settingsProvider, Func<TextFillBase?> fillProvider, int paragraphLength, Action<int>? handleAnnotation = null, List<ShapedCharacter[]?>? annotationsLookup = null)
		{
			CS_0024_003C_003E8__locals238.hasDelimited = false;
			foreach ((int, ShapedCharacter)[] item9 in shapedCharacters.ContiguousGroups((ShapedCharacter a, ShapedCharacter b) => a.BIDILevel == b.BIDILevel, delegate(int i, ShapedCharacter c)
			{
				(int, ShapedCharacter) result = default((int, ShapedCharacter));
				result.Item1 = i;
				result.Item2 = c;
				return ((int index, ShapedCharacter character))result;
			}))
			{
				(int index, ShapedCharacter character)[] bidiGroup = item9;
				bool isRTL = bidiGroup[0].character.IsRTL;
				int incrementDirection = ((!isRTL) ? 1 : (-1));
				int num7 = ((!CS_0024_003C_003E8__locals238.isXInfinite && isRTL) ? (bidiGroup.Length - 1) : 0);
				int num8 = ((CS_0024_003C_003E8__locals238.isXInfinite || isRTL) ? bidiGroup.Length : 0);
				bool flag4 = true;
				do
				{
					int num9 = 0;
					int num10 = -1;
					int num11 = 0;
					if (!CS_0024_003C_003E8__locals238.isXInfinite)
					{
						double num12 = CS_0024_003C_003E8__locals238.maxSize.X + CS_0024_003C_003E8__locals238.startingPos.X - (CS_0024_003C_003E8__locals238.layoutPosition.X + CS_0024_003C_003E8__locals238.paragraphSettings.RightIndent);
						for (int num13 = num7; isRTL ? (num13 >= 0) : (num13 < bidiGroup.Length); num13 += incrementDirection)
						{
							ShapedCharacter item2 = bidiGroup[num13].character;
							Vector2<double> advance = item2.Advance;
							bool flag5 = isCharacterWhitespace(item2.Index);
							bool flag6 = flag5 && StringExtensions.NonBreakingSpaces.Contains(originalText[item2.Index]);
							if (flag4 && (annotationsLookup?.ElementAtOrDefault(bidiGroup[num13].index) != null || !flag5 || flag6))
							{
								double num14 = getWordWidth(num13);
								if (num12 - num14 <= 0.0)
								{
									CS_0024_003C_003E8__locals238.needsNewLine = true;
									flag5 = false;
								}
								flag4 = false;
							}
							num12 -= advance.X;
							if (((num12 <= 0.0) | CS_0024_003C_003E8__locals238.needsNewLine) && !flag5)
							{
								CS_0024_003C_003E8__locals238.needsNewLine = true;
								if (num10 >= 0)
								{
									num9 = num11;
									if (isRTL)
									{
										num7 = num10;
									}
									else
									{
										num8 = num10 + 1;
									}
								}
								else
								{
									CS_0024_003C_003E8__locals238._003C_003E4__this._wordWrapped = true;
								}
								break;
							}
							num12 -= settingsProvider(item2.Index).CharacterSpacing * item2.ScriptScalar.X;
							if (isRTL)
							{
								num7 = num13;
							}
							else
							{
								num8 = num13 + 1;
							}
							if (CS_0024_003C_003E8__locals238.textTransform == TextTransform.SingleCharacterPerLine)
							{
								CS_0024_003C_003E8__locals238.needsNewLine = true;
								break;
							}
							if ((flag5 && !flag6) || StringExtensions.AdditionalCharactersAllowingBreak.Contains(originalText[item2.Index]))
							{
								flag4 = true;
								num9++;
								num10 = num13;
								num11 = num9;
							}
							else
							{
								if (num10 >= 0 && CS_0024_003C_003E8__locals238.textTransform == TextTransform.SingleWordPerLine)
								{
									CS_0024_003C_003E8__locals238.needsNewLine = true;
									num9 = num11;
									if (isRTL)
									{
										num7 = num10;
									}
									else
									{
										num8 = num10 + 1;
									}
									break;
								}
								num9 = 0;
							}
						}
					}
					for (int num15 = num7; num15 < num8; num15++)
					{
						ShapedCharacter item3 = bidiGroup[num15].character;
						CS_0024_003C_003E8__locals238.runSettings = settingsProvider(item3.Index);
						CS_0024_003C_003E8__locals238.lineHeight = item3.LineHeight;
						bool flag7 = CS_0024_003C_003E8__locals238.needsNewLine && (isRTL ? (num15 - num7) : (num8 - num15 - 1)) < num9;
						bool isDecimal = originalText[item3.Index] == '.';
						Vector2<double> advance2 = item3.Advance;
						bool flag8 = isCharacterWhitespace(item3.Index);
						bool flag9 = flag8 && StringExtensions.NonBreakingSpaces.Contains(originalText[item3.Index]);
						handleAnnotation?.Invoke(bidiGroup[num15].index);
						if (flag8 && !flag9 && !flag7 && !CS_0024_003C_003E8__locals238.hasBroken)
						{
							CS_0024_003C_003E8__locals238.hasBroken = true;
							CS_0024_003C_003E8__locals238.wordBreaks.Add(CS_0024_003C_003E8__locals238.characters.Count);
						}
						else if (!flag8 || flag9)
						{
							CS_0024_003C_003E8__locals238.hasBroken = false;
						}
						Character character = new Character(item3, doesConsume, CS_0024_003C_003E8__locals238.indexOffset + CS_0024_003C_003E8__locals238.consumedCharacters, flag8, CS_0024_003C_003E8__locals238.runSettings.ScriptLevel, CS_0024_003C_003E8__locals238.layoutPosition, fillProvider(), CS_0024_003C_003E8__locals238.runSettings.StrokeColor, CS_0024_003C_003E8__locals238.runSettings.UnderlineColor, CS_0024_003C_003E8__locals238.runSettings.HighlightColor, CS_0024_003C_003E8__locals238.runSettings.StrokeThickness, CS_0024_003C_003E8__locals238.runSettings.Strikethrough, CS_0024_003C_003E8__locals238.runSettings.Underline, CS_0024_003C_003E8__locals238.lineHeight, isAnnotation: false, doesConsume && bidiGroup[num15].index + CS_0024_003C_003E8__locals238.consumedCharacters == paragraphLength - 1)
						{
							IsDecimal = isDecimal
						};
						if (!CS_0024_003C_003E8__locals238.isYInfinite && !CS_0024_003C_003E8__locals238._003C_003E4__this._didOverflow && CS_0024_003C_003E8__locals238._003C_003E4__this.StopOnOverflow && CS_0024_003C_003E8__locals238.layoutPosition.Y + CS_0024_003C_003E8__locals238.lineHeight > CS_0024_003C_003E8__locals238.maxSize.Y)
						{
							CS_0024_003C_003E8__locals238._003C_003E4__this._didOverflow = true;
							CS_0024_003C_003E8__locals238._003C_003E4__this._overflowCharacterIndex = character.Index;
							CS_0024_003C_003E8__locals238._003C_003E4__this._overflowBreakIndex = ((CS_0024_003C_003E8__locals238._003C_003E4__this._overflowMode == OverflowMode.StopWithSingleLinePadding) ? CS_0024_003C_003E8__locals238.previousLineLastIndex : CS_0024_003C_003E8__locals238.lastBreakIndex);
							if (!CS_0024_003C_003E8__locals238.continueOnOverflow)
							{
								return;
							}
						}
						else if (flag9)
						{
							CS_0024_003C_003E8__locals238.lastBreakIndex = character.Index;
						}
						if (character.CharInfo.ScriptScalar != Vector2<double>.One && character.Baseline.HasValue)
						{
							character.Position += new Vector2<double>(0.0, character.Baseline.Value * (1.0 - character.CharInfo.ScriptScalar.Y));
						}
						character.Position += item3.Offset + character.BaselineOffset;
						CS_0024_003C_003E8__locals238.characters.Add(character);
						if (CS_0024_003C_003E8__locals238.tabChar != null)
						{
							CS_0024_003C_003E8__locals238.tabGroup.Add(character);
						}
						advance2.X += CS_0024_003C_003E8__locals238.runSettings.CharacterSpacing * item3.ScriptScalar.X;
						if (!flag7)
						{
							CS_0024_003C_003E8__locals238.layoutPosition += advance2;
						}
					}
					if (isRTL)
					{
						num8 = num7--;
					}
					else
					{
						num7 = num8++;
					}
					if (CS_0024_003C_003E8__locals238.needsNewLine)
					{
						if (CS_0024_003C_003E8__locals238.characters.Count > 0)
						{
							startNewLine(CS_0024_003C_003E8__locals238.paragraphSettings.LeftIndent);
						}
						CS_0024_003C_003E8__locals238.needsNewLine = false;
					}
				}
				while (isRTL ? (num7 >= 0) : (num7 < bidiGroup.Length));
				double getWordWidth(int index)
				{
					int num16 = index;
					for (int num17 = index; isRTL ? (num17 >= 0) : (num17 < bidiGroup.Length); num17 += incrementDirection)
					{
						bool num18 = isCharacterWhitespace(bidiGroup[num17].character.Index);
						bool flag10 = num18 && StringExtensions.NonBreakingSpaces.Contains(originalText[bidiGroup[num17].character.Index]);
						if (num18 && !flag10 && annotationsLookup?.ElementAtOrDefault(bidiGroup[num17].index) == null)
						{
							break;
						}
						num16 = num17;
					}
					double num19 = 0.0;
					for (int num20 = Math.Min(index, num16); num20 <= Math.Max(index, num16); num20++)
					{
						ShapedCharacter item4 = bidiGroup[num20].character;
						double num21 = item4.Advance.X;
						if (num20 < num16)
						{
							num21 += settingsProvider(item4.Index).CharacterSpacing * item4.ScriptScalar.X;
						}
						double val = (annotationsLookup?.ElementAtOrDefault(bidiGroup[num20].index))?.Sum((ShapedCharacter ch) => ch.Advance.X) ?? 0.0;
						num19 += Math.Max(num21, val);
					}
					return num19;
				}
			}
			bool isCharacterWhitespace(int index)
			{
				if (!char.IsWhiteSpace(originalText[index]))
				{
					return originalText[index] == '\u200b';
				}
				return true;
			}
		}
		void alignTabGroup()
		{
			if (CS_0024_003C_003E8__locals238.tabChar != null && CS_0024_003C_003E8__locals238.tabChar.TabStopType != 0 && CS_0024_003C_003E8__locals238.tabGroup.Count > 0)
			{
				double charactersWidth = GetCharactersWidth(CS_0024_003C_003E8__locals238.tabGroup, CS_0024_003C_003E8__locals238.runSettings.CharacterSpacing);
				double num22 = charactersWidth;
				switch (CS_0024_003C_003E8__locals238.tabChar.TabStopType)
				{
				case TabStopType.Center:
					num22 /= 2.0;
					break;
				case TabStopType.Decimal:
				{
					Character character3 = CS_0024_003C_003E8__locals238.tabGroup.FirstOrDefault((Character c) => c.IsDecimal);
					if (character3 != null)
					{
						int count2 = CS_0024_003C_003E8__locals238.tabGroup.IndexOf(character3);
						num22 = GetCharactersWidth(CS_0024_003C_003E8__locals238.tabGroup.Take(count2), CS_0024_003C_003E8__locals238.runSettings.CharacterSpacing);
						num22 += character3.Advance.X / 2.0;
					}
					break;
				}
				}
				double num23 = CS_0024_003C_003E8__locals238.tabChar.TabAdvance - num22;
				Vector2<double> vector = new Vector2<double>(num23, 0.0);
				if (!CS_0024_003C_003E8__locals238.isXInfinite)
				{
					List<Character> list3 = CS_0024_003C_003E8__locals238.tabGroup;
					double x2 = list3[list3.Count - 1].Position.X;
					List<Character> list4 = CS_0024_003C_003E8__locals238.tabGroup;
					if (x2 + list4[list4.Count - 1].Advance.X + vector.X + CS_0024_003C_003E8__locals238.paragraphSettings.RightIndent > CS_0024_003C_003E8__locals238.maxSize.X + CS_0024_003C_003E8__locals238.startingPos.X)
					{
						num23 = CS_0024_003C_003E8__locals238.maxSize.X + CS_0024_003C_003E8__locals238.startingPos.X - CS_0024_003C_003E8__locals238.tabGroup[0].Position.X - charactersWidth;
						vector = new Vector2<double>(num23, 0.0);
					}
				}
				if (num23 >= 0.0)
				{
					foreach (Character item10 in CS_0024_003C_003E8__locals238.tabGroup)
					{
						item10.Position += vector;
					}
					CS_0024_003C_003E8__locals238.tabChar.AdditionalAdvance = vector;
				}
				List<Character> list5 = CS_0024_003C_003E8__locals238.tabGroup;
				Character character4 = list5[list5.Count - 1];
				CS_0024_003C_003E8__locals238.layoutPosition = character4.Position + character4.Advance;
			}
			CS_0024_003C_003E8__locals238.tabChar = null;
			CS_0024_003C_003E8__locals238.tabGroup.Clear();
		}
		void consumeCharacters(int count)
		{
			CS_0024_003C_003E8__locals238.consumedCharacters += count;
			CS_0024_003C_003E8__locals238.characterCounter += count;
		}
		bool continueArrange()
		{
			return (!CS_0024_003C_003E8__locals238._003C_003E4__this.StopOnOverflow || !CS_0024_003C_003E8__locals238._003C_003E4__this._didOverflow) | CS_0024_003C_003E8__locals238.continueOnOverflow;
		}
		int getLevelCount(int levelIndex)
		{
			if (!CS_0024_003C_003E8__locals238.levelCounter.TryGetValue(levelIndex, out var value))
			{
				return 1;
			}
			return value;
		}
		[IteratorStateMachine(typeof(_003C_003Ec__DisplayClass138_0._003C_003CDoArrange_003Eg__getShapedCharacters_007C1_003Ed))]
		IEnumerable<ShapedCharacter> getShapedCharacters(ShapedTextRun shapedTextRun, Func<int, (int indexOffset, RunSettings runSettings, int? scriptLevel)> settingsProvider, double characterSizeScalar)
		{
			//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
			return new _003C_003Ec__DisplayClass138_0._003C_003CDoArrange_003Eg__getShapedCharacters_007C1_003Ed(-2)
			{
				_003C_003E4__this = CS_0024_003C_003E8__locals238,
				_003C_003E3__shapedTextRun = shapedTextRun,
				_003C_003E3__settingsProvider = settingsProvider,
				_003C_003E3__characterSizeScalar = characterSizeScalar
			};
		}
		double scaleCharacterSize(double s)
		{
			return (s * CS_0024_003C_003E8__locals238._003C_003E4__this._textScalar * CS_0024_003C_003E8__locals238._003C_003E4__this._baseScalar).Clamp(10.0, 1000.0);
		}
		bool shouldCompose(int runLength)
		{
			if (CS_0024_003C_003E8__locals238._003C_003E4__this.IsComposing && !CS_0024_003C_003E8__locals238.hasComposed && CS_0024_003C_003E8__locals238.characterCounter <= CS_0024_003C_003E8__locals238._003C_003E4__this._compositionIndex)
			{
				return CS_0024_003C_003E8__locals238._003C_003E4__this._compositionIndex <= runLength + CS_0024_003C_003E8__locals238.characterCounter;
			}
			return false;
		}
		void startNewLine(double indent, bool endOfParagraph = false)
		{
			alignTabGroup();
			if (CS_0024_003C_003E8__locals238.characters.Count > 0)
			{
				ref Vector2<double> reference = ref CS_0024_003C_003E8__locals238.layoutPosition;
				double x = reference.X;
				double characterSpacing = CS_0024_003C_003E8__locals238.runSettings.CharacterSpacing;
				List<Character> list = CS_0024_003C_003E8__locals238.characters;
				reference.X = x - characterSpacing * list[list.Count - 1].CharInfo.ScriptScalar.X;
			}
			CS_0024_003C_003E8__locals238.layoutPosition.X = Math.Max(CS_0024_003C_003E8__locals238.layoutPosition.X, CS_0024_003C_003E8__locals238.annotationPosition.X);
			Line line = new Line(CS_0024_003C_003E8__locals238.characters, CS_0024_003C_003E8__locals238.indexOffset, CS_0024_003C_003E8__locals238.lineLeft, CS_0024_003C_003E8__locals238.layoutPosition.X, CS_0024_003C_003E8__locals238.layoutPosition.Y, CS_0024_003C_003E8__locals238.lineHeight, CS_0024_003C_003E8__locals238.documentHasAnnotation, CS_0024_003C_003E8__locals238.paragraphSettings.Alignment);
			double remainingWidth = ((!CS_0024_003C_003E8__locals238.isXInfinite) ? (CS_0024_003C_003E8__locals238.maxSize.X + CS_0024_003C_003E8__locals238.startingPos.X - (CS_0024_003C_003E8__locals238.layoutPosition.X + CS_0024_003C_003E8__locals238.paragraphSettings.RightIndent)) : 0.0);
			CS_0024_003C_003E8__locals238._003C_003E4__this.SetArrangedSize(new Vector2<double>(Math.Max(CS_0024_003C_003E8__locals238._003C_003E4__this._arrangedSize.X, CS_0024_003C_003E8__locals238.layoutPosition.X), Math.Max(CS_0024_003C_003E8__locals238._003C_003E4__this._arrangedSize.Y, CS_0024_003C_003E8__locals238.layoutPosition.Y + line.LineHeight + line.NonAnnotatedOffset)));
			CS_0024_003C_003E8__locals238.indexOffset += CS_0024_003C_003E8__locals238.consumedCharacters;
			CS_0024_003C_003E8__locals238.consumedCharacters = 0;
			CS_0024_003C_003E8__locals238.layoutPosition.Y += GetLineHeight(line.LineHeight, CS_0024_003C_003E8__locals238.documentHasAnnotation, CS_0024_003C_003E8__locals238.paragraphSettings);
			CS_0024_003C_003E8__locals238.layoutPosition.X = CS_0024_003C_003E8__locals238.startingPos.X + indent;
			CS_0024_003C_003E8__locals238.annotationPosition = CS_0024_003C_003E8__locals238.layoutPosition;
			CS_0024_003C_003E8__locals238.lineLeft = indent;
			if (CS_0024_003C_003E8__locals238.characters.Count == 0 && !CS_0024_003C_003E8__locals238._003C_003E4__this._didOverflow && CS_0024_003C_003E8__locals238._003C_003E4__this.StopOnOverflow && CS_0024_003C_003E8__locals238.layoutPosition.Y > CS_0024_003C_003E8__locals238.maxSize.Y)
			{
				CS_0024_003C_003E8__locals238._003C_003E4__this._didOverflow = true;
				CS_0024_003C_003E8__locals238._003C_003E4__this._overflowCharacterIndex = line.IndexOffset;
				CS_0024_003C_003E8__locals238._003C_003E4__this._overflowBreakIndex = ((CS_0024_003C_003E8__locals238._003C_003E4__this._overflowMode == OverflowMode.StopWithSingleLinePadding) ? CS_0024_003C_003E8__locals238.previousLineLastIndex : CS_0024_003C_003E8__locals238.lastBreakIndex);
				if (!CS_0024_003C_003E8__locals238.continueOnOverflow)
				{
					return;
				}
			}
			CS_0024_003C_003E8__locals238.previousLineLastIndex = CS_0024_003C_003E8__locals238.lineLastIndex;
			Character? character2 = CS_0024_003C_003E8__locals238.characters.LastOrDefault();
			CS_0024_003C_003E8__locals238.lineLastIndex = ((character2 != null) ? (character2.Index + 1) : line.IndexOffset);
			CS_0024_003C_003E8__locals238.lastBreakIndex = CS_0024_003C_003E8__locals238.lineLastIndex;
			CS_0024_003C_003E8__locals238.lines.Add(line);
			if (CS_0024_003C_003E8__locals238.wordBreaks.Count > 0)
			{
				List<int> list2 = CS_0024_003C_003E8__locals238.wordBreaks;
				if (list2[list2.Count - 1] == CS_0024_003C_003E8__locals238.characters.Count - 1)
				{
					CS_0024_003C_003E8__locals238.wordBreaks.RemoveAt(CS_0024_003C_003E8__locals238.wordBreaks.Count - 1);
				}
			}
			AlignLine(line, remainingWidth, !endOfParagraph, CS_0024_003C_003E8__locals238.paragraphSettings.Alignment, CS_0024_003C_003E8__locals238.wordBreaks);
			CS_0024_003C_003E8__locals238.characters.Clear();
			CS_0024_003C_003E8__locals238.wordBreaks.Clear();
			CS_0024_003C_003E8__locals238.hasBroken = false;
			CS_0024_003C_003E8__locals238.needsNewLine = false;
		}
	}

	private static TextFeature GetTextFeatures(RunSettings? settings)
	{
		TextFeature textFeature = TextFeature.None;
		if ((object)settings != null && settings.CapitalizationType == CapitalizationType.SmallCaps)
		{
			textFeature |= TextFeature.SmallCaps;
		}
		textFeature = (((object)settings == null || !settings.TabularNumbers) ? (textFeature | TextFeature.Kerning) : (textFeature | TextFeature.TabularNumbers));
		if (((object)settings != null && !settings.LigaturesEnabled) || Math.Abs(settings?.CharacterSpacing ?? 0.0) > 0.005)
		{
			textFeature |= TextFeature.NoLigatures;
		}
		return textFeature;
	}

	private static double GetCharactersWidth(IEnumerable<Character> characters, double characterSpacing)
	{
		double num = 0.0;
		foreach (Character character in characters)
		{
			ShapedCharacter charInfo = character.CharInfo;
			num += charInfo.Advance.X + characterSpacing;
		}
		if (num != 0.0)
		{
			num -= characterSpacing;
		}
		return num;
	}

	private static double GetLineHeight(double lineHeight, bool hasAnnotation, ParagraphSettings settings)
	{
		switch (settings.SpacingMode)
		{
		case LineSpacingMode.Absolute:
			lineHeight = settings.LineSpacing;
			break;
		case LineSpacingMode.Relative:
			lineHeight = Math.Max(lineHeight, settings.LineSpacing);
			break;
		case LineSpacingMode.Multiple:
			lineHeight *= settings.LineSpacing + (hasAnnotation ? 1.25 : 0.0);
			break;
		}
		return lineHeight + settings.AdditionalLineSpacing;
	}

	private static void AlignLine(Line line, double remainingWidth, bool didParagraphWrap, ParagraphAlignment alignment, List<int> wordBreaks)
	{
		if (alignment == ParagraphAlignment.Left || remainingWidth == 0.0)
		{
			return;
		}
		switch (alignment)
		{
		case ParagraphAlignment.Justified:
		{
			if (!didParagraphWrap || wordBreaks.Count == 0)
			{
				return;
			}
			line.Right += remainingWidth;
			remainingWidth /= (double)wordBreaks.Count;
			double num = 0.0;
			for (int i = wordBreaks.Min(); i < line.Characters.Length; i++)
			{
				line.Characters[i].Position += new Vector2<double>(num, 0.0);
				if (wordBreaks.Remove(i))
				{
					num += remainingWidth;
					line.Characters[i].AdditionalAdvance = new Vector2<double>(remainingWidth, 0.0);
				}
			}
			return;
		}
		case ParagraphAlignment.Center:
			remainingWidth /= 2.0;
			break;
		}
		line.Left += remainingWidth;
		line.Right += remainingWidth;
		Vector2<double> vector = new Vector2<double>(remainingWidth, 0.0);
		Character[] characters = line.Characters;
		for (int j = 0; j < characters.Length; j++)
		{
			characters[j].Position += vector;
		}
	}

	private static void AlignDocument(IEnumerable<Line> lines, double remainingHeight, DocumentAlignment alignment, TextTransform textTransform)
	{
		if (alignment != 0 && remainingHeight != 0.0 && !checkTransform())
		{
			if (alignment == DocumentAlignment.Middle)
			{
				remainingHeight /= 2.0;
			}
			lines.ForEach(delegate(Line l)
			{
				l.OffsetLineTop(remainingHeight);
			});
		}
		bool checkTransform()
		{
			if (textTransform.IsAnyOf(TextTransform.SingleCharacterPerLine, TextTransform.SingleWordPerLine))
			{
				return remainingHeight < 0.0;
			}
			return false;
		}
	}

	protected void SetArrangedSize(Vector2<double> arrangedSize)
	{
		_arrangedSize = arrangedSize;
	}

	public static double CalculateHeight(TypefaceLibrary library, TextDocument document, Vector2<double> maxSize)
	{
		ArrangedText obj = new ArrangedText(library)
		{
			Document = document,
			MaxSize = maxSize
		};
		double y = obj.ArrangedSize.Y;
		obj.Document = null;
		return y;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		Document = null;
	}
}
