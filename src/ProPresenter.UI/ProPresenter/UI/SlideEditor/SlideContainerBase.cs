using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.SlideEditor;

public abstract class SlideContainerBase : LinkedNotifyPropertyChangedBase
{
	public abstract string Name { get; set; }

	public CustomSlide? Slide { get; }

	protected SlideContainerBase(CustomSlide? slide)
	{
		Slide = slide;
	}
}
