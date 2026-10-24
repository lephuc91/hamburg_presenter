using System;
using Pro.DO.Effects;
using Pro.UI.Converters;

namespace ProPresenter.UI.CueInspector;

public class CueInspectorDirectionConverter : DirectionToStringConverter
{
	protected override string KeyForValue(Direction direction)
	{
		switch (direction)
		{
		case Direction.TopLeft:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_TOP_LEFT_title";
		case Direction.Top:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_TOP_CENTER_title";
		case Direction.TopRight:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_TOP_RIGHT_title";
		case Direction.Left:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_MIDDLE_LEFT_title";
		case Direction.None:
		case Direction.Center:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_MIDDLE_CENTER_title";
		case Direction.Right:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_MIDDLE_RIGHT_title";
		case Direction.BottomLeft:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_BOTTOM_LEFT_title";
		case Direction.Bottom:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_BOTTOM_CENTER_title";
		case Direction.BottomRight:
			return "CUE_INSPECTOR_PROPERTIES_TAB_SCALE_ALIGNMENT_BOTTOM_RIGHT_title";
		default:
			throw new NotSupportedException();
		}
	}
}
