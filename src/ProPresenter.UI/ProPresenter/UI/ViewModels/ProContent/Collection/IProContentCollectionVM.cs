using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.ProContent.Asset;

namespace ProPresenter.UI.ViewModels.ProContent.Collection;

public interface IProContentCollectionVM : IDisposable
{
	string DisplayName { get; }

	string Description { get; }

	LayoutType LayoutType { get; }

	INotifyEnumerableChanged<IProContentAssetVM> Assets { get; }

	IRelayCommand DownloadCommand { get; }

	ICollection<IProContentCollectionMoreMenuItemVM> MoreMenu { get; }

	bool ShowMoreMenu { get; }

	double ThumbnailAspectRatio { get; }
}
