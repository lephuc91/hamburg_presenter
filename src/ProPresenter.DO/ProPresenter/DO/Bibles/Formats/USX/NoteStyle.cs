using System.ComponentModel;

namespace ProPresenter.DO.Bibles.Formats.USX;

public enum NoteStyle
{
	Unknown,
	[Description("f")]
	Footnote,
	[Description("fe")]
	Endnote,
	[Description("ef")]
	StudyNote,
	[Description("x")]
	CrossReference,
	[Description("ex")]
	StudyCrossReference
}
