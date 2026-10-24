namespace ProPresenter.UI.ViewModels.Editor.Links;

public interface IVideoCountdownLinkVM : ITimerTextLinkVM
{
	IIgnoreLoopVM IgnoreLoopVM { get; }

	ICountdownSourceVM CountdownSourceVM { get; }
}
