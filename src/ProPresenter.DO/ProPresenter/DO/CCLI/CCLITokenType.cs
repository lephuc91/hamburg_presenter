using System.ComponentModel;

namespace ProPresenter.DO.CCLI;

public enum CCLITokenType
{
	[Description("Artist")]
	Artist,
	[Description("Author")]
	Author,
	[Description("Publisher")]
	Publisher,
	[Description("Title")]
	Title,
	[Description("Copyright Year")]
	CopyrightYear,
	[Description("License Number")]
	LicenseNumber,
	[Description("Song Number")]
	SongNumber
}
