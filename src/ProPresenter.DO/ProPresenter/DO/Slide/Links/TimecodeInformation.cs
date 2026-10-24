using System.Windows.Media;
using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public class TimecodeInformation : ITimecodeInformation
{
	public TimeSlice? ElapsedTime { get; set; }

	public Color? StatusColor { get; set; }

	public double Fps { get; set; }
}
