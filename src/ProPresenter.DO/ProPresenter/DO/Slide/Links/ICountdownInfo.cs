namespace ProPresenter.DO.Slide.Links;

public interface ICountdownInfo
{
	CountdownData Presentation { get; }

	CountdownData Announcement { get; }

	CountdownData Audio { get; }
}
