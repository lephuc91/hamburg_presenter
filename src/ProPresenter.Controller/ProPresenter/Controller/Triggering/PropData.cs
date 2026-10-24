using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Controller.Triggering;

public class PropData
{
	public Cue PropProto { get; }

	public CustomSlide? PropSlide { get; }

	public PropData(Cue propProto, CustomSlide? propSlide)
	{
		PropProto = propProto;
		PropSlide = propSlide;
	}
}
