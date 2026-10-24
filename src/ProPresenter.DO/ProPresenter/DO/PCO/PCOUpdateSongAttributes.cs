namespace ProPresenter.DO.PCO;

public class PCOUpdateSongAttributes
{
	public string? Title { get; }

	public string? Admin { get; }

	public string? Author { get; }

	public string? Copyright { get; }

	public int? CCLINumber { get; }

	public bool Hidden { get; }

	public string? Themes { get; }

	public PCOUpdateSongAttributes(string title, string? admin = null, string? author = null, string? copyright = null, int? ccliNumber = null, bool hidden = false, string? themes = null)
	{
		Title = title;
		Admin = admin;
		Author = author;
		Copyright = copyright;
		CCLINumber = ccliNumber;
		Hidden = hidden;
		Themes = themes;
	}
}
