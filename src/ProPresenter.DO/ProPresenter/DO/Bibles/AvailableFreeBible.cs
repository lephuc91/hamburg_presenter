using ProPresenter.DO.Registration.State.Bible;

namespace ProPresenter.DO.Bibles;

public class AvailableFreeBible : AvailableBibleBase
{
	public string Language { get; }

	public override bool IsActive => true;

	public AvailableFreeBible(Metadata bibleData)
		: base(bibleData.Id, bibleData.Name, bibleData.InternalAbbreviation, bibleData.DisplayAbbreviation)
	{
		Language = bibleData.Language;
	}
}
