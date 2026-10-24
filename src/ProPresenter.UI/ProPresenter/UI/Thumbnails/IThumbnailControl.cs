namespace ProPresenter.UI.Thumbnails;

public interface IThumbnailControl : IUniformViewControl
{
	bool IsActive { get; set; }

	bool HideBackgroundImage { get; set; }
}
