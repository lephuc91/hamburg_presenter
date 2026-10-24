using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Animation;
using Pro.Common.Cache;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ViewModels.ProContent.Asset;

public interface IProContentAssetVM : INotifyPropertyChanged, IUniformViewSource
{
	string DisplayName { get; }

	IProContentGroupVM ContainingGroup { get; }

	IAsyncValue<BitmapSource?> Thumbnail { get; }

	IAsyncValue<IReadOnlyList<IAnimationFrame>> Preview { get; }

	IAsyncRelayCommand DownloadCommand { get; }

	AssetType Type { get; }

	bool IsNavigable { get; }

	bool IsFree { get; }
}
