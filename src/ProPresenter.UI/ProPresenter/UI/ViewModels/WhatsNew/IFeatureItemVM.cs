using System;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.WhatsNew;

public interface IFeatureItemVM
{
	string Title { get; }

	string Description { get; }

	Uri? FeatureLinkUri { get; }

	string FeatureLinkText { get; }

	bool FeatureContainsLink { get; }

	bool ColorizeImage { get; }

	ImageSource? Icon { get; }

	IRelayCommand GotoLinkCommand { get; }
}
