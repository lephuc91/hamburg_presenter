using ProPresenter.DO.Props;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.SlideEditor;

public class PropCueContainer : SlideContainerBase
{
	private readonly IPropCue _propCue;

	public override string Name
	{
		get
		{
			return _propCue.Name;
		}
		set
		{
			_propCue.Name = value;
		}
	}

	public PropCueContainer(IPropCue propCue)
		: base(propCue.SlideAction?.Slide as CustomSlide)
	{
		_propCue = propCue;
		LinkProperties("Name", "Name");
		_propCue.PropertyChanged += base.RaiseLinkedValues;
	}
}
