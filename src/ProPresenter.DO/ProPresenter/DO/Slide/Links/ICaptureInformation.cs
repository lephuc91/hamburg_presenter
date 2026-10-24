using System.Windows.Media;
using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public interface ICaptureInformation
{
	TimeSlice? ElapsedTime { get; }

	string StatusText { get; }

	Color StatusColor { get; }
}
