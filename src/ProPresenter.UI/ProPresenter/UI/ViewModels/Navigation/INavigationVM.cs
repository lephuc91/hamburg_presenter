using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Navigation;

public interface INavigationVM<T> where T : INavigationItem
{
	T ActiveItem { get; }

	IRelayCommand GoBackCommand { get; }

	IRelayCommand GoForwardCommand { get; }

	void UpdateActiveItem(T activeItem);

	void Navigate(T item);

	void RemoveItem(T item);
}
