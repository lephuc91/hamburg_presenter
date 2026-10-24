using System.Windows.Media;
using Pro.Common.Time;

namespace ProPresenter.DO.Slide.Links;

public record CaptureInformation(TimeSlice? ElapsedTime, string StatusText, Color StatusColor) : ICaptureInformation;
