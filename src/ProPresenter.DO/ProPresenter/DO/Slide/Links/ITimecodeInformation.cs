using System.Windows.Media;
using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public interface ITimecodeInformation
{
	TimeSlice? ElapsedTime { get; }

	Color? StatusColor { get; }

	double Fps { get; }
}
