using System;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVHeaderCue : RVCue, IPlaylistChild
{
	public PlaylistChildType ChildType => PlaylistChildType.Cue;

	[Trait]
	public string duration { get; set; }

	[Trait]
	public string endTime { get; set; }

	[Trait]
	public RVTimerType timerType { get; set; }

	[Trait]
	public RVCountDownToTimeFormat countDownToTimeFormat { get; set; }

	[Trait]
	public bool allowOverrun { get; set; }

	[Trait]
	public Color color { get; set; }

	[Trait]
	public Guid timerUUID { get; set; }
}
