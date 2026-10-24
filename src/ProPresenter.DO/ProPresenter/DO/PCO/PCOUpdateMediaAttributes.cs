namespace ProPresenter.DO.PCO;

public class PCOUpdateMediaAttributes
{
	public enum MediaTypeValue
	{
		Audio,
		BackgroundAudio,
		BackgroundImage,
		BackgroundVideo,
		Countdown,
		Document,
		Drama,
		Image,
		Powerpoint,
		SongVideo,
		Video
	}

	public MediaTypeValue MediaType { get; }

	public string Title { get; }

	public string? CreatorName { get; }

	public string? Themes { get; }

	public PCOUpdateMediaAttributes(string title, MediaTypeValue mediaType, string? creatorName = null, string? themes = null)
	{
		Title = title;
		MediaType = mediaType;
		CreatorName = creatorName;
		Themes = themes;
	}
}
