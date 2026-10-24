using ProPresenter.DO.Arrangements;

namespace ProPresenter.DO.Slide.Links;

public interface ISlideGroupInformation
{
	CueGroup? CurrentSlideGroup { get; }

	CueGroup? NextSlideGroup { get; }

	CueGroup? NextArrangementGroup { get; }
}
