using System;
using Pro.DO.Effects;
using Pro.UI.Converters;

namespace ProPresenter.UI.Transitions.Converters;

public class TransitionDirectionStringConverter : DirectionToStringConverter
{
	protected override string KeyForValue(Direction direction)
	{
		switch (direction)
		{
		case Direction.TopLeft:
			return "TRANSITIONS_DIRECTION_TOP_LEFT_title";
		case Direction.Top:
			return "TRANSITIONS_DIRECTION_TOP_CENTER_title";
		case Direction.TopRight:
			return "TRANSITIONS_DIRECTION_TOP_RIGHT_title";
		case Direction.Left:
			return "TRANSITIONS_DIRECTION_MIDDLE_LEFT_title";
		case Direction.None:
		case Direction.Center:
			return "TRANSITIONS_DIRECTION_MIDDLE_CENTER_title";
		case Direction.Right:
			return "TRANSITIONS_DIRECTION_MIDDLE_RIGHT_title";
		case Direction.BottomLeft:
			return "TRANSITIONS_DIRECTION_BOTTOM_LEFT_title";
		case Direction.Bottom:
			return "TRANSITIONS_DIRECTION_BOTTOM_CENTER_title";
		case Direction.BottomRight:
			return "TRANSITIONS_DIRECTION_BOTTOM_RIGHT_title";
		default:
			throw new NotSupportedException();
		}
	}
}
