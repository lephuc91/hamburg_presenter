using System;
using System.Collections.Generic;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVDisplaySlide
{
	[Trait]
	public Guid UUID { get; set; }

	[Trait]
	public Color backgroundColor { get; set; }

	[Trait]
	public Color highlightColor { get; set; }

	[Trait]
	public bool drawingBackgroundColor { get; set; }

	[Trait]
	public bool enabled { get; set; }

	[Trait]
	public string hotKey { get; set; }

	[Trait]
	public string label { get; set; }

	[Trait]
	public string chordChartPath { get; set; }

	[Trait]
	public string notes { get; set; }

	[Trait]
	[Optional]
	public uint slideNumber { get; set; }

	[Collection]
	[Optional]
	[KnownTypes(typeof(RVAudioCue), new Type[]
	{
		typeof(RVClearCue),
		typeof(RVLiveVideoCue),
		typeof(RVMaskCue),
		typeof(RVMediaCue),
		typeof(RVMessageCue),
		typeof(RVMultiScreenCue),
		typeof(RVPropCue),
		typeof(RVSlideTimerCue),
		typeof(RVStageDisplayCue),
		typeof(RVTimerCue)
	})]
	public List<RVCue> cues { get; set; }

	[Collection]
	[Optional]
	public List<RVGraphicsElement> graphicsElements { get; set; }

	[Child]
	[Optional]
	public RVTransition selectedTransition { get; set; }
}
