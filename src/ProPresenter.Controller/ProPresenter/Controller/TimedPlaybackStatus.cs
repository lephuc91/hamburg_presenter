using ProPresenterCore.ProCore.Interop;

namespace ProPresenter.Controller;

public class TimedPlaybackStatus
{
	public double Time { get; }

	public TimedPlaybackState State { get; }

	public double Framerate { get; }

	public TimedPlaybackStatus(double time, TimedPlaybackState state, double framerate)
	{
		Time = time;
		State = state;
		Framerate = framerate;
	}
}
