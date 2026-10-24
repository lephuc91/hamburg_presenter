using System.Windows.Input;

namespace ProPresenter.UI.ViewModels.Registration.Banners;

public interface IBannerVM
{
	string TextContent { get; }

	BannerStyle BannerStyle { get; }

	ICommand ClickCommand { get; }
}
