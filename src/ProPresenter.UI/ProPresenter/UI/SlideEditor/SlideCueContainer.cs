using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.SlideEditor;

public class SlideCueContainer : SlideContainerBase
{
	private readonly SlideCue _cue;

	public override string Name
	{
		get
		{
			return _cue.Name;
		}
		set
		{
			_cue.Name = value;
		}
	}

	public SlideCueContainer(SlideCue cue)
		: base(cue.SlideAction?.Slide as CustomSlide)
	{
		_cue = cue;
		LinkProperties("Name", "Name");
		_cue.PropertyChanged += base.RaiseLinkedValues;
	}
}
