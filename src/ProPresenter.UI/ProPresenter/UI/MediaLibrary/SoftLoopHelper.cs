using System.Collections.Generic;
using Pro.Common.Time;

namespace ProPresenter.UI.MediaLibrary;

public static class SoftLoopHelper
{
	public static readonly IReadOnlyList<TimeSlice> Durations = new global::_003C_003Ez__ReadOnlyArray<TimeSlice>(new TimeSlice[7]
	{
		TimeSlice.FromSeconds(0.125),
		TimeSlice.FromSeconds(0.25),
		TimeSlice.FromSeconds(0.5),
		TimeSlice.FromSeconds(0.75),
		TimeSlice.FromSeconds(1.0),
		TimeSlice.FromSeconds(1.5),
		TimeSlice.FromSeconds(2.0)
	});
}
