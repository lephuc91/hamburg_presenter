using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Cues;

namespace ProPresenter.Controller;

public interface IPresentationHandlerOperationService
{
	IEnumerable<API_v1_Presentation.Types.SlideGroup.Types.Slide> Serialize(IEnumerable<SlideCue> cues);
}
