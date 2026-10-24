using System;

namespace ProPresenter.UI.CueInspector;

[Flags]
public enum InspectorOptions
{
	None = 1,
	SupportsTransition = 2,
	SwitchToMarkerTab = 4,
	SupportsAudioNextBehavior = 8,
	SupportsRetriggerBehavior = 0x10,
	Default = 0x1A
}
