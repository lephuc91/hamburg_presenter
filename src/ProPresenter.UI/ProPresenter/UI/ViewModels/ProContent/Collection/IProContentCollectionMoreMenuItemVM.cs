using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.ProContent.Collection;

public interface IProContentCollectionMoreMenuItemVM
{
	IRelayCommand Command { get; }

	string TranslationKey { get; }
}
