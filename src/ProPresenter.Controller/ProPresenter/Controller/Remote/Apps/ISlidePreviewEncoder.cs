using ProPresenter.DO.Cues;

namespace ProPresenter.Controller.Remote.Apps;

public interface ISlidePreviewEncoder
{
	string Encode(SlideCue slide, int slideQuality);
}
