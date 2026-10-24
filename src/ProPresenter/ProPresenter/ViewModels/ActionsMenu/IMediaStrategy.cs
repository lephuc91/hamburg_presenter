namespace ProPresenter.ViewModels.ActionsMenu;

public interface IMediaStrategy
{
	bool CanConvertMediaToSlideElement { get; }

	void AddMediaAction(string mediaFile);

	void ConvertMediaToSlideElement();
}
