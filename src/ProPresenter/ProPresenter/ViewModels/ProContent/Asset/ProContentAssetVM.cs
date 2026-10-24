using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Animation;
using Pro.Common.Cache;
using Pro.UI.Commands;
using ProPresenter.DO.Cache;
using ProPresenter.DO.PanelSourcing;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Asset;

public class ProContentAssetVM : ObservableObject, IProContentAssetVMInternal, IProContentAssetVM, INotifyPropertyChanged, IUniformViewSource
{
	private sealed class AsyncCachedItem<T>(Func<Task<T>> getter) : IAsyncValue<T>
	{
		public Task<T> LoadAsync()
		{
			return _003Cgetter_003EP();
		}
	}

	public IProContentAsset Asset { get; }

	public string DisplayName => Asset.DisplayName;

	public AssetType Type => Convert(Asset.Type);

	public IProContentGroupVM ContainingGroup { get; }

	public IAsyncRelayCommand DownloadCommand { get; }

	public IAsyncValue<BitmapSource?> Thumbnail { get; }

	public IAsyncValue<IReadOnlyList<IAnimationFrame>> Preview { get; }

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public int Index => 0;

	public bool IsNavigable => Asset.IsNavigable;

	public bool IsFree
	{
		get
		{
			IProContentDownloadableAsset obj = Asset as IProContentDownloadableAsset;
			if (obj == null)
			{
				return false;
			}
			return obj.SubscriptionType == SubscriptionType.Free;
		}
	}

	public ProContentAssetVM(IProContentAsset asset, IProContentGroupVM containingGroup, IProContentDownloader downloader, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService)
	{
		Asset = asset;
		ContainingGroup = containingGroup;
		DownloadCommand = new AsyncParameterAugmentingCommand<IProContentAsset>(downloader.DownloadAssetCommand, Asset);
		Preview = new AsyncCachedItem<IReadOnlyList<IAnimationFrame>>(() => LoadFromCacheAsync(asset.PreviewUrl, previewCacheService, Array.Empty<IAnimationFrame>()));
		Prefetch(asset.ThumbnailUrl, thumbnailCacheService);
		Thumbnail = new AsyncCachedItem<BitmapSource>(async () => await LoadFromCacheAsync(asset.ThumbnailUrl, thumbnailCacheService, NullableBitmapSource.Default));
	}

	private static async Task<T> LoadFromCacheAsync<T>(Uri? url, IUriCacheService<T> cacheService, T defaultValue)
	{
		if ((object)url == null || !url.IsAbsoluteUri)
		{
			return defaultValue;
		}
		return await cacheService.GetAsync(url);
	}

	private static void Prefetch<T>(Uri? url, IUriCacheService<T> cacheService)
	{
		if ((object)url != null)
		{
			cacheService.Prefetch(url);
		}
	}

	private static AssetType Convert(ProContentAssetType type)
	{
		return type switch
		{
			ProContentAssetType.Pack => AssetType.Pack, 
			ProContentAssetType.File => AssetType.File, 
			ProContentAssetType.Navigation => AssetType.Navigation, 
			_ => throw new InvalidOperationException($"Cannot convert {type} to {typeof(AssetType).FullName}"), 
		};
	}
}
