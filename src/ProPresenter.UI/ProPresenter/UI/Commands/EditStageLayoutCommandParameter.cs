using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.Commands;

public record EditStageLayoutCommandParameter(CustomSlide? Slide, ShowSource Source)
{
	public EditStageLayoutCommandParameter(ShowSource source)
		: this(null, source)
	{
	}
}
