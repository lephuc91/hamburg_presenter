using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Time;
using Pro.DO.Label;
using Pro.ssAPI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.DO.Arrangements;

public interface IArrangedCue
{
	Color BackgroundColor { get; }

	int BuildCount { get; }

	int BuildPosition { get; set; }

	bool CanRename { get; }

	TimeSlice Duration { get; }

	CueGroup Group { get; }

	GroupLabel? GroupLabel { get; }

	int Index { get; set; }

	bool IsEnabled { get; }

	bool IsGroupHead { get; }

	bool IsGroupTail { get; }

	bool IsValid { get; }

	Color LabelColor { get; }

	Brush LabelForeground { get; }

	string LabelName { get; }

	LiveVideoInput? LiveVideoInput { get; }

	string Name { get; set; }

	ScaleAlignment ScaleAlignment { get; }

	ScaleBehavior ScaleBehavior { get; }

	IEnumerable<IScrimSource> ScrimItems { get; }

	bool ShowGroupLabel { get; set; }

	bool ShowIndex { get; }

	SlideCue Source { get; }

	bool HasHotkey(Key key);
}
