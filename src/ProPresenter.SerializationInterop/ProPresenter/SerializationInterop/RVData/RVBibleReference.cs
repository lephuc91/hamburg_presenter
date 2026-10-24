using Pro.Serialization.Control;

namespace ProPresenter.SerializationInterop.RVData;

public class RVBibleReference
{
	[Trait]
	public string translationAbbreviation { get; set; }

	[Trait]
	public string translationName { get; set; }

	[Trait]
	public string bookName { get; set; }

	[Trait]
	public short bookIndex { get; set; }

	[Trait]
	public short chapterStart { get; set; }

	[Trait]
	public short chapterEnd { get; set; }

	[Trait]
	public short verseStart { get; set; }

	[Trait]
	public short verseEnd { get; set; }

	[Child]
	[Optional]
	public RVTransition selectedTransition { get; set; }
}
