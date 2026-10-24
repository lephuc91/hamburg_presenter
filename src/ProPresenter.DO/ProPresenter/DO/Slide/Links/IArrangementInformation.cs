namespace ProPresenter.DO.Slide.Links;

public interface IArrangementInformation
{
	int CurrentSlideNumber { get; }

	int SlidesRemaining { get; }

	int TotalSlideCount { get; }
}
