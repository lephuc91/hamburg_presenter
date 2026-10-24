using System;

namespace ProPresenter.Controller.Triggering;

[Flags]
public enum StageDataUpdateSource
{
	None = 0,
	StagePresentationChanged = 1,
	StageScreenAssignmentChanged = 2,
	StageScreenArrangementsChanged = 4,
	Initialization = 8
}
