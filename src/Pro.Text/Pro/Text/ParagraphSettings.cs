using System;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class ParagraphSettings : NotifyPropertyChangedBase, IEquatable<ParagraphSettings>, ICloneable<ParagraphSettings>
{
	private const double MIN_BULLET_SCALAR = 0.01;

	private const double MAX_BULLET_SCALAR = 9.99;

	private ParagraphAlignment _alignment;

	private LineSpacingMode _spacingMode;

	private double _lineSpacing = 1.0;

	private double _additionalLineSpacing;

	private double _beforeParagraph;

	private double _afterParagraph;

	private double _leftIndent;

	private double _rightIndent;

	private double _firstLineIndent;

	private int _listIndex;

	private int _levelIndex;

	private Color? _bulletColor;

	private double _bulletScalar;

	private int? _hashCode;

	private UndoStack? _undoStack;

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			if (_undoStack != value)
			{
				_undoStack = value;
				TabStops.UndoStack = value;
			}
		}
	}

	[TextDocument(TextAttributeType.None)]
	public ParagraphAlignment Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			SetValue("Alignment", ref _alignment, value, delegate(ParagraphAlignment o, ParagraphAlignment n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ParagraphAlignment), this, "Alignment", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public LineSpacingMode SpacingMode
	{
		get
		{
			return _spacingMode;
		}
		set
		{
			SetValue("SpacingMode", ref _spacingMode, value, delegate(LineSpacingMode o, LineSpacingMode n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LineSpacing), this, "SpacingMode", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double LineSpacing
	{
		get
		{
			return _lineSpacing;
		}
		set
		{
			SetValue("LineSpacing", ref _lineSpacing, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LineSpacing), this, "LineSpacing", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double AdditionalLineSpacing
	{
		get
		{
			return _additionalLineSpacing;
		}
		set
		{
			SetValue("AdditionalLineSpacing", ref _additionalLineSpacing, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LineSpacing), this, "AdditionalLineSpacing", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double BeforeParagraph
	{
		get
		{
			return _beforeParagraph;
		}
		set
		{
			SetValue("BeforeParagraph", ref _beforeParagraph, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BeforeParagraph), this, "BeforeParagraph", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double AfterParagraph
	{
		get
		{
			return _afterParagraph;
		}
		set
		{
			SetValue("AfterParagraph", ref _afterParagraph, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.AfterParagraph), this, "AfterParagraph", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double LeftIndent
	{
		get
		{
			return _leftIndent;
		}
		set
		{
			SetValue("LeftIndent", ref _leftIndent, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LeftIndent), this, "LeftIndent", o, n);
				OnPropertyChanged("FirstLineIndent");
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double RightIndent
	{
		get
		{
			return _rightIndent;
		}
		set
		{
			SetValue("RightIndent", ref _rightIndent, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RightIndent), this, "RightIndent", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double FirstLineIndent
	{
		get
		{
			return _firstLineIndent;
		}
		set
		{
			SetValue("FirstLineIndent", ref _firstLineIndent, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.FirstLineIndent), this, "FirstLineIndent", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.Ignore)]
	public int ListIndex
	{
		get
		{
			return _listIndex;
		}
		set
		{
			SetValue("ListIndex", ref _listIndex, value, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListIndex), this, "ListIndex", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.Ignore)]
	public int LevelIndex
	{
		get
		{
			return _levelIndex;
		}
		set
		{
			SetValue("LevelIndex", ref _levelIndex, value, delegate(int o, int n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LevelIndex), this, "LevelIndex", o, n, null, null, autoFinalize: true);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public Color? BulletColor
	{
		get
		{
			return _bulletColor;
		}
		set
		{
			SetValue("BulletColor", ref _bulletColor, value, delegate(Color? o, Color? n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListBulletColor), this, "BulletColor", o, n);
			});
		}
	}

	[TextDocument(TextAttributeType.None)]
	public double BulletScalar
	{
		get
		{
			return _bulletScalar;
		}
		set
		{
			SetValue("BulletScalar", ref _bulletScalar, CoerceBulletScalerValue(value), delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ListBulletSize), this, "BulletScalar", o, n);
			});
		}
	}

	public bool IsPartOfList
	{
		get
		{
			if (ListIndex >= 0)
			{
				return LevelIndex >= 0;
			}
			return false;
		}
	}

	[TextDocument(TextAttributeType.TabStops)]
	public TabStopCollection TabStops { get; }

	public ParagraphSettings()
		: this(ParagraphAlignment.Center, LineSpacingMode.Multiple, 1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, new TabStopCollection(), -1, -1, 1.0, null)
	{
	}

	private ParagraphSettings(ParagraphSettings settings)
		: this(settings.Alignment, settings.SpacingMode, settings.LineSpacing, settings.AdditionalLineSpacing, settings.BeforeParagraph, settings.AfterParagraph, settings.LeftIndent, settings.RightIndent, settings.FirstLineIndent, settings.TabStops.Clone(), settings.ListIndex, settings.LevelIndex, settings.BulletScalar, settings.BulletColor)
	{
	}

	public ParagraphSettings(ParagraphAlignment alignment, LineSpacingMode spacingMode, double lineSpacing, double additionalLineSpacing, double beforeParagraph, double afterParagraph, double leftIndent, double rightIndent, double firstLineIndent)
		: this(alignment, spacingMode, lineSpacing, additionalLineSpacing, beforeParagraph, afterParagraph, leftIndent, rightIndent, firstLineIndent, new TabStopCollection(), -1, -1, 1.0, null)
	{
	}

	private ParagraphSettings(ParagraphAlignment alignment, LineSpacingMode spacingMode, double lineSpacing, double additionalLineSpacing, double beforeParagraph, double afterParagraph, double leftIndent, double rightIndent, double firstLineIndent, TabStopCollection tabStops, int listIndex, int levelIndex, double bulletScalar, Color? bulletColor)
	{
		Alignment = alignment;
		SpacingMode = spacingMode;
		LineSpacing = lineSpacing;
		AdditionalLineSpacing = additionalLineSpacing;
		BeforeParagraph = beforeParagraph;
		AfterParagraph = afterParagraph;
		LeftIndent = leftIndent;
		RightIndent = rightIndent;
		FirstLineIndent = firstLineIndent;
		TabStops = tabStops;
		ListIndex = listIndex;
		LevelIndex = levelIndex;
		BulletScalar = bulletScalar;
		BulletColor = bulletColor;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(_alignment, _spacingMode, _lineSpacing, _additionalLineSpacing, _beforeParagraph, _afterParagraph, _leftIndent, _rightIndent, _firstLineIndent, _listIndex, _levelIndex, _bulletScalar, _bulletColor, TabStops);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ParagraphSettings other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ParagraphSettings? other)
	{
		if ((object)other != null && _alignment == other._alignment && _spacingMode == other._spacingMode && _lineSpacing == other._lineSpacing && _additionalLineSpacing == other._additionalLineSpacing && _beforeParagraph == other._beforeParagraph && _afterParagraph == other._afterParagraph && _leftIndent == other._leftIndent && _rightIndent == other._rightIndent && _firstLineIndent == other._firstLineIndent && _listIndex == other._listIndex && _levelIndex == other._levelIndex && _bulletScalar == other._bulletScalar && _bulletColor == other._bulletColor)
		{
			return TabStops.ContentsMatchExactly(other.TabStops);
		}
		return false;
	}

	public ParagraphSettings Clone()
	{
		return new ParagraphSettings(this);
	}

	public static bool operator ==(ParagraphSettings? lhs, ParagraphSettings? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(ParagraphSettings? lhs, ParagraphSettings? rhs)
	{
		return !lhs.NullableEquals(rhs);
	}

	private double CoerceBulletScalerValue(double value)
	{
		return value.Clamp(0.01, 9.99);
	}
}
