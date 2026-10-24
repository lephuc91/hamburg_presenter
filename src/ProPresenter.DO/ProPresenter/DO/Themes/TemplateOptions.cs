using System;

namespace ProPresenter.DO.Themes;

[Flags]
public enum TemplateOptions
{
	None = 0,
	RetainTemplateIDs = 1,
	RefreshAllSlideIDs = 2,
	MaintainOriginalSlideBuild = 4,
	RetainTemplateText = 8
}
