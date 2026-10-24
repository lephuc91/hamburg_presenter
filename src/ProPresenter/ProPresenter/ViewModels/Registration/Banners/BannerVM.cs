using System.Windows.Input;
using ProPresenter.UI.ViewModels.Registration.Banners;

namespace ProPresenter.ViewModels.Registration.Banners;

public record BannerVM(string TextContent, BannerStyle BannerStyle, ICommand ClickCommand) : IBannerVM;
