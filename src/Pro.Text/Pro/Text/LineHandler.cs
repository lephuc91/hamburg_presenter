using System;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;

namespace Pro.Text;

internal class LineHandler
{
	public enum LineType
	{
		Strikethrough,
		Underline
	}

	public delegate void DrawLineDelegate(Rect<double> rect, Brush brush);

	public delegate Brush? BrushProviderDelegate(TextFillBase? fill, Rect<double> lineBounds, Rect<double> fillGroupBounds);

	private readonly LineType _lineType;

	private readonly DrawLineDelegate _drawLine;

	private readonly Brush? _overrideBrush;

	private readonly BrushProviderDelegate? _brushProvider;

	private readonly Predicate<Character> _enabledPredicate;

	private TextFillBase? _lineFill;

	private Character? _firstCharacter;

	private Character? _lastSoftCharacter;

	private Character? _lastHardCharacter;

	public LineHandler(LineType lineType, DrawLineDelegate drawLine, Brush? overrideBrush, BrushProviderDelegate brushProvider, Predicate<Character> enabledPredicate)
	{
		_lineType = lineType;
		_drawLine = drawLine;
		_overrideBrush = overrideBrush;
		_brushProvider = brushProvider;
		_enabledPredicate = enabledPredicate;
	}

	public void HandleCharacter(Line line, Character character)
	{
		TextFillBase lineFill = GetLineFill(character);
		bool flag = _lineType == LineType.Underline && character.GlyphBounds.Bottom > line.Baseline + GetOffset(character);
		bool flag2 = IsLineEnabled(character) && !flag;
		if (_firstCharacter != null)
		{
			if (flag2)
			{
				if (GetOffset(_firstCharacter) != GetOffset(character) || GetThickness(_firstCharacter) != GetThickness(character) || (_overrideBrush == null && !(_lineFill == lineFill)))
				{
					EndLine(line, isHard: true);
					StartLine(character, lineFill);
				}
				else
				{
					ContinueLine(character);
				}
			}
			else
			{
				EndLine(line, isHard: true, character, flag);
			}
		}
		else if (flag2)
		{
			StartLine(character, lineFill);
		}
	}

	public void HandleLineEnd(Line line)
	{
		if (_firstCharacter != null)
		{
			EndLine(line, isHard: false);
		}
	}

	private void StartLine(Character character, TextFillBase? lineFill)
	{
		_lineFill = lineFill;
		_firstCharacter = character;
		_lastSoftCharacter = character;
		_lastHardCharacter = character;
	}

	private void ContinueLine(Character character)
	{
		_ = _lastSoftCharacter;
		_lastSoftCharacter = character;
		if (!character.IsWhitespace)
		{
			_lastHardCharacter = character;
		}
	}

	private void EndLine(Line line, bool isHard, Character? finalCharacterEncountered = null, bool hasDescender = false)
	{
		Character firstCharacter = _firstCharacter;
		Character character = (isHard ? _lastSoftCharacter : _lastHardCharacter);
		_lastHardCharacter.ThrowWhenNull("_lastHardCharacter");
		_firstCharacter.ThrowWhenNull("_firstCharacter");
		character.ThrowWhenNull("lastCharacter");
		firstCharacter.ThrowWhenNull("firstCharacter");
		if (_lastHardCharacter.IsWhitespace)
		{
			return;
		}
		double y = line.Top + line.Baseline + GetOffset(_firstCharacter);
		Vector2<double> vector = new Vector2<double>(firstCharacter.Position.X, y);
		double thickness = GetThickness(firstCharacter);
		Vector2<double> vector2 = ((!(finalCharacterEncountered != null && hasDescender)) ? new Vector2<double>(character.Position.X + character.CharInfo.Advance.X, y) : new Vector2<double>(finalCharacterEncountered.Position.X - thickness * 0.85, y));
		Rect<double> rect = new Rect<double>(vector.X, vector.Y - thickness / 2.0, vector2.X - vector.X, thickness);
		object obj = _overrideBrush;
		if (obj == null)
		{
			obj = _brushProvider?.Invoke(_lineFill, rect, firstCharacter.FillGroupBounds);
			if (obj == null)
			{
				TextFillBase? lineFill = _lineFill;
				obj = (((object)lineFill != null && !lineFill.IsTransparent) ? new SolidColorBrush(_lineFill.PrimaryColor) : null);
			}
		}
		Brush brush = (Brush)obj;
		if (brush != null)
		{
			_drawLine?.Invoke(rect, brush);
		}
		_lineFill = null;
		_firstCharacter = null;
		_lastSoftCharacter = null;
		_lastHardCharacter = null;
	}

	private bool IsLineEnabled(Character character)
	{
		Predicate<Character> enabledPredicate = _enabledPredicate;
		if (enabledPredicate != null && !enabledPredicate(character))
		{
			return false;
		}
		return _lineType switch
		{
			LineType.Strikethrough => character.IsStrickenthrough, 
			LineType.Underline => character.IsUnderlined, 
			_ => throw new NotSupportedException(), 
		};
	}

	private double GetOffset(Character character)
	{
		return _lineType switch
		{
			LineType.Strikethrough => character.StrikethroughOffset, 
			LineType.Underline => character.UnderlineOffset, 
			_ => throw new NotSupportedException(), 
		};
	}

	private double GetThickness(Character character)
	{
		return _lineType switch
		{
			LineType.Strikethrough => character.StrikethroughThickness, 
			LineType.Underline => character.UnderlineThickness, 
			_ => throw new NotSupportedException(), 
		};
	}

	private TextFillBase? GetLineFill(Character character)
	{
		return _lineType switch
		{
			LineType.Strikethrough => character.LineFill, 
			LineType.Underline => character.UnderlineFill, 
			_ => throw new NotSupportedException(), 
		};
	}
}
