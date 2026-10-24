using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IAppendixVM
{
	IRelayCommand TutorialsCommand { get; }

	IRelayCommand UserGroupCommand { get; }

	IRelayCommand KnowledgeBaseCommand { get; }

	IRelayCommand BlogCommand { get; }

	IRelayCommand InstagramCommand { get; }

	IRelayCommand FacebookCommand { get; }
}
