using ProPresenter.DO.Chords;

namespace ProPresenter.DO.Slide.Links;

public interface IKeyInformation
{
	Key? BaseKey { get; }

	Key? TargetKey { get; }
}
