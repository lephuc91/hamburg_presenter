using System.ComponentModel;

namespace Pro.Editor.Canvas;

public interface ITooltipDataSource : INotifyPropertyChanged
{
	string TooltipLabel { get; }
}
