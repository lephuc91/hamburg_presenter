using System;
using System.Collections.Generic;
using System.Windows.Media;
using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVPresentationDocument
{
	[Optional]
	[Trait]
	public Guid uuid { get; set; }

	[Trait]
	public int versionNumber { get; set; }

	[Trait]
	public RVPresentationType docType { get; set; }

	[Trait]
	public int width { get; set; }

	[Trait]
	public int height { get; set; }

	[Trait]
	public int usedCount { get; set; }

	[Trait]
	public Color backgroundColor { get; set; }

	[Trait]
	public bool drawingBackgroundColor { get; set; }

	[Trait]
	public bool CCLIDisplay { get; set; }

	[Trait]
	public DateTime? lastDateUsed { get; set; }

	[Trait]
	public Guid selectedArrangementID { get; set; }

	[Trait]
	public string category { get; set; }

	[Trait]
	public string resourcesDirectory { get; set; }

	[Trait]
	public string notes { get; set; }

	[Trait]
	public string chordChartPath { get; set; }

	[Optional]
	[Trait]
	public string powerPointFilePath { get; set; }

	[Optional]
	[Trait]
	public string CCLIAuthor { get; set; }

	[Optional]
	[Trait]
	public string CCLIArtistCredits { get; set; }

	[Optional]
	[Trait]
	public string CCLISongTitle { get; set; }

	[Optional]
	[Trait]
	public string CCLIPublisher { get; set; }

	[Optional]
	[Trait]
	public string CCLICopyrightYear { get; set; }

	[Optional]
	[Trait]
	public string CCLISongNumber { get; set; }

	[Optional]
	[Trait]
	public string os { get; set; }

	[Optional]
	[Trait]
	public string buildNumber { get; set; }

	[Optional]
	[Child]
	public RVBibleReference bibleReference { get; set; }

	[Optional]
	[Child]
	public RVTimeline timeline { get; set; }

	[Optional]
	[Collection]
	public List<RVSlideGrouping> groups { get; set; }

	[Optional]
	[Collection]
	public List<RVSongArrangement> arrangements { get; set; }

	[Optional]
	[Child]
	public RVTransition selectedTransition { get; set; }
}
