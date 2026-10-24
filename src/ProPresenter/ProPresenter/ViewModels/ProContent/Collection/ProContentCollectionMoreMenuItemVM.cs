using CommunityToolkit.Mvvm.Input;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.ViewModels.ProContent.Collection;

public class ProContentCollectionMoreMenuItemVM : IProContentCollectionMoreMenuItemVM
{
	public IRelayCommand Command { get; }

	public string TranslationKey { get; }

	public ProContentCollectionMoreMenuItemVM(IRelayCommand command, string translationKey)
	{
		Command = command;
		TranslationKey = translationKey;
	}
}
