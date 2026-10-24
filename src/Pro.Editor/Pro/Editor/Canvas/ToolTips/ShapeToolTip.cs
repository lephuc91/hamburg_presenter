using System.ComponentModel;
using Pro.Common.Components;

namespace Pro.Editor.Canvas.ToolTips;

public class ShapeToolTip : NotifyPropertyChangedBase, ITooltipDataSource, INotifyPropertyChanged
{
	private string _toolTip = string.Empty;

	public string TooltipLabel
	{
		get
		{
			return _toolTip;
		}
		set
		{
			SetValue("TooltipLabel", ref _toolTip, value);
		}
	}
}
