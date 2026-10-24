using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Props;

namespace ProPresenter.Controller.Triggering;

public class PropCueInfo : CueInfo
{
	public IPropCue? OriginalProp { get; }

	public Slide? PropProtoSlide { get; }

	public PropCueInfo(CueLocation location, IPropCue? originalProp, Slide? propProtoSlide)
		: base(location)
	{
		OriginalProp = originalProp;
		PropProtoSlide = propProtoSlide;
	}
}
