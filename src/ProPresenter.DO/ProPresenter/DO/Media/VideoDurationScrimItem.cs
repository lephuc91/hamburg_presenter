using Pro.Common.Time;

namespace ProPresenter.DO.Media;

public class VideoDurationScrimItem : IScrimSource
{
	public ScrimPosition Position => ScrimPosition.BottomLeft;

	public DisplayMode DisplayMode => DisplayMode.Label;

	public bool IsEditable => false;

	public ListViewType ListViewType => ListViewType.None;

	public TimeSlice Duration { get; }

	public VideoDurationScrimItem(TimeSlice duration)
	{
		Duration = duration;
	}
}
