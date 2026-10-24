using System;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class RunSettings : NotifyPropertyChangedBase, IEquatable<RunSettings>, ICloneable<RunSettings>
{
	public const int MinCharacterSize = 1;

	public const int MaxCharacterSize = 10000;

	private const int DefaultCharacterSize = 50;

	private const double DefaultCharacterSpacing = 0.0;

	private static readonly TextFillBase DefaultFill = new SolidTextFill(Colors.Black);

	public static readonly FontInfo DefaultFont = new FontInfo("Arial", "Regular", "ArialMT");

	private const double DefaultStrokeThickness = 0.0;

	private static readonly Color DefaultStrokeColor = Colors.White;

	private FontInfo _font;

	private FontInfo? _originalFont;

	private int _characterSize;

	private double _characterSpacing;

	private int _scriptLevel;

	private TextFillBase _fill;

	private Color? _highlightColor;

	private double _strokeThickness;

	private double _oldStrokeThickness;

	private Color _strokeColor;

	private bool _underline;

	private Color? _underlineColor;

	private bool _strikethrough;

	private CapitalizationType _capitalizationType;

	private bool _tabularNumbers;

	private string? _chordAnnotation;

	private Range[] _chordSuperscriptRanges = Array.Empty<Range>();

	private bool _preserveFillColor;

	private int? _hashCode;

	private bool _ligaturesEnabled = true;

	public UndoStack? UndoStack { get; set; }

	[TextDocument(TextAttributeType.Font)]
	public FontInfo Font
	{
		get
		{
			return _font;
		}
		set
		{
			SetValue("Font", ref _font, value, delegate(FontInfo o, FontInfo n)
			{
				if (!_originalFont.HasValue)
				{
					_originalFont = o;
				}
				_hashCode = null;
				UndoStack?.Commit(UndoActionTypes.Font.ToAction(), this, "Font", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.OriginalFont)]
	public FontInfo? OriginalFont
	{
		get
		{
			return _originalFont;
		}
		set
		{
			SetValue("OriginalFont", ref _originalFont, value);
		}
	}

	public bool IsFontMissing
	{
		get
		{
			if (_originalFont.HasValue)
			{
				return !_originalFont.Value.Equals(_font);
			}
			return false;
		}
	}

	[TextDocument(TextAttributeType.CharacterSize)]
	public int CharacterSize
	{
		get
		{
			return _characterSize;
		}
		set
		{
			SetValue("CharacterSize", ref _characterSize, Math.Min(Math.Max(value, 1), 10000), delegate(int o, int n)
			{
				UndoStack?.Commit(UndoActionTypes.CharacterSize.ToAction(), this, "CharacterSize", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double CharacterSpacing
	{
		get
		{
			return _characterSpacing;
		}
		set
		{
			SetValue("CharacterSpacing", ref _characterSpacing, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.CharacterSpacing.ToAction(), this, "CharacterSpacing", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.Ignore)]
	public bool LigaturesEnabled
	{
		get
		{
			return _ligaturesEnabled;
		}
		set
		{
			SetValue("LigaturesEnabled", ref _ligaturesEnabled, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.EnableLigatures.ToAction(), this, "LigaturesEnabled", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.Ignore)]
	public int ScriptLevel
	{
		get
		{
			return _scriptLevel;
		}
		set
		{
			SetValue("ScriptLevel", ref _scriptLevel, value, delegate(int o, int n)
			{
				UndoStack?.Commit(UndoActionTypes.ScriptLevel.ToAction(), this, "ScriptLevel", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.Fill)]
	public TextFillBase Fill
	{
		get
		{
			return _fill;
		}
		set
		{
			SetValue("Fill", ref _fill, value, delegate(TextFillBase o, TextFillBase n)
			{
				if (o != null)
				{
					o.FillChanged -= FillChanged;
				}
				n.FillChanged += FillChanged;
				UndoStack?.Commit(UndoActionTypes.TextFill.ToAction(), this, "Fill", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public Color? HighlightColor
	{
		get
		{
			return _highlightColor;
		}
		set
		{
			SetValue("HighlightColor", ref _highlightColor, value, delegate(Color? o, Color? n)
			{
				UndoStack?.Commit(UndoActionTypes.HighlightColor.ToAction(), this, "HighlightColor", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public bool IsStrokeVisible
	{
		get
		{
			return StrokeThickness >= 1.0;
		}
		set
		{
			if (value != IsStrokeVisible)
			{
				if (value)
				{
					SetStrokeThickness(Math.Max(_oldStrokeThickness, 1.0), autoFinalize: true);
					return;
				}
				_oldStrokeThickness = StrokeThickness;
				SetStrokeThickness(0.0, autoFinalize: true);
			}
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double StrokeThickness
	{
		get
		{
			return _strokeThickness;
		}
		set
		{
			SetStrokeThickness(value, autoFinalize: false);
		}
	}

	[TextDocument(TextAttributeType.StrokeColor)]
	public Color StrokeColor
	{
		get
		{
			return _strokeColor;
		}
		set
		{
			SetValue("StrokeColor", ref _strokeColor, value, delegate(Color o, Color n)
			{
				UndoStack?.Commit(UndoActionTypes.TextStrokeColor.ToAction(), this, "StrokeColor", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public bool Underline
	{
		get
		{
			return _underline;
		}
		set
		{
			SetValue("Underline", ref _underline, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.Underline.ToAction(), this, "Underline", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public Color? UnderlineColor
	{
		get
		{
			return _underlineColor;
		}
		set
		{
			SetValue("UnderlineColor", ref _underlineColor, value, delegate(Color? o, Color? n)
			{
				UndoStack?.Commit(UndoActionTypes.UnderlineColor.ToAction(), this, "UnderlineColor", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public bool Strikethrough
	{
		get
		{
			return _strikethrough;
		}
		set
		{
			SetValue("Strikethrough", ref _strikethrough, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.Strikethrough.ToAction(), this, "Strikethrough", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public CapitalizationType CapitalizationType
	{
		get
		{
			return _capitalizationType;
		}
		set
		{
			SetValue("CapitalizationType", ref _capitalizationType, value, delegate(CapitalizationType o, CapitalizationType n)
			{
				UndoStack?.Commit(UndoActionTypes.Capitalization.ToAction(), this, "CapitalizationType", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public bool TabularNumbers
	{
		get
		{
			return _tabularNumbers;
		}
		set
		{
			SetValue("TabularNumbers", ref _tabularNumbers, value);
		}
	}

	public string? ChordAnnotation
	{
		get
		{
			return _chordAnnotation;
		}
		set
		{
			SetValue("ChordAnnotation", ref _chordAnnotation, value);
		}
	}

	public Range[] ChordSuperscriptRanges
	{
		get
		{
			return _chordSuperscriptRanges;
		}
		set
		{
			SetValue("ChordSuperscriptRanges", ref _chordSuperscriptRanges, value);
		}
	}

	public bool PreserveFillColor
	{
		get
		{
			return _preserveFillColor;
		}
		set
		{
			SetValue("PreserveFillColor", ref _preserveFillColor, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.TextFill.ToAction(), this, "PreserveFillColor", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public RunSettings()
		: this(DefaultFont, 50, 0.0, DefaultFill.Clone(), 0.0, DefaultStrokeColor)
	{
	}

	public RunSettings(FontInfo font, int characterSize, double characterSpacing, TextFillBase fill, double strokeThickness, Color strokeColor)
	{
		_font = font;
		_originalFont = font;
		_characterSize = characterSize;
		_characterSpacing = characterSpacing;
		_fill = fill;
		_strokeThickness = strokeThickness;
		_strokeColor = strokeColor;
		_fill.FillChanged += FillChanged;
	}

	public void UpdateOriginalFont()
	{
		_originalFont = _font;
		_hashCode = null;
	}

	public void ReplaceFont(FontInfo replacementFont)
	{
		SetValue("Font", ref _font, replacementFont, delegate(FontInfo o, FontInfo n)
		{
			UndoStack?.Commit(UndoActionTypes.Font.ToAction(), this, "Font", o, n, null, null, autoFinalize: true);
		});
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add(_font);
			hashCode.Add(_characterSize);
			hashCode.Add(_characterSpacing);
			hashCode.Add(_scriptLevel);
			hashCode.Add(_ligaturesEnabled);
			hashCode.Add(_fill);
			hashCode.Add(_strokeThickness);
			hashCode.Add(_strokeColor);
			hashCode.Add(_underline);
			hashCode.Add(_underlineColor);
			hashCode.Add(_highlightColor);
			hashCode.Add(_strikethrough);
			hashCode.Add(_capitalizationType);
			hashCode.Add(_tabularNumbers);
			hashCode.Add(_chordAnnotation);
			hashCode.Add(_preserveFillColor);
			Range[] chordSuperscriptRanges = _chordSuperscriptRanges;
			foreach (Range value in chordSuperscriptRanges)
			{
				hashCode.Add(value);
			}
			_hashCode = hashCode.ToHashCode();
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is RunSettings other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(RunSettings? other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (_font == other._font && _characterSize == other._characterSize && _characterSpacing == other._characterSpacing && _scriptLevel == other._scriptLevel && _ligaturesEnabled == other._ligaturesEnabled && _fill == other._fill && _strokeThickness == other._strokeThickness && (_strokeThickness == 0.0 || _strokeColor == other._strokeColor) && _underline == other._underline && _underlineColor == other._underlineColor)
		{
			Color? highlightColor = _highlightColor;
			Color? highlightColor2 = other._highlightColor;
			if (highlightColor.HasValue == highlightColor2.HasValue && (!highlightColor.HasValue || highlightColor.GetValueOrDefault() == highlightColor2.GetValueOrDefault()) && _strikethrough == other._strikethrough && _capitalizationType == other._capitalizationType && _tabularNumbers == other._tabularNumbers && _chordAnnotation == other._chordAnnotation && _chordSuperscriptRanges.ContentsMatchExactly(other._chordSuperscriptRanges))
			{
				return _preserveFillColor == other._preserveFillColor;
			}
		}
		return false;
	}

	public RunSettings Clone()
	{
		return new RunSettings(_font, _characterSize, _characterSpacing, _fill.Clone(), _strokeThickness, _strokeColor)
		{
			_scriptLevel = _scriptLevel,
			_ligaturesEnabled = _ligaturesEnabled,
			_underline = _underline,
			_underlineColor = _underlineColor,
			_highlightColor = _highlightColor,
			_strikethrough = _strikethrough,
			_capitalizationType = _capitalizationType,
			_tabularNumbers = _tabularNumbers,
			_chordAnnotation = _chordAnnotation,
			_chordSuperscriptRanges = _chordSuperscriptRanges,
			_preserveFillColor = _preserveFillColor,
			_oldStrokeThickness = _oldStrokeThickness,
			_originalFont = _originalFont
		};
	}

	private void FillChanged(TextFillBase textFill)
	{
		OnPropertyChanged("Fill");
	}

	public static bool operator ==(RunSettings? lhs, RunSettings? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(RunSettings? lhs, RunSettings? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}

	private void SetStrokeThickness(double thickness, bool autoFinalize)
	{
		SetValue("StrokeThickness", ref _strokeThickness, thickness, delegate(double o, double n)
		{
			UndoStack?.Commit(UndoActionTypes.TextStrokeThickness.ToAction(), this, "StrokeThickness", o, n, null, null, autoFinalize);
		});
	}
}
