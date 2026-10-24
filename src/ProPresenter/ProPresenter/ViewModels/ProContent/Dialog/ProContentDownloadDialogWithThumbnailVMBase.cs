using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Pro.Common.Animation;
using Pro.Common.Cache;
using ProPresenter.DO;
using ProPresenter.DO.Cache;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Format;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.ViewModels.ProContent.Dialog;

public class ProContentDownloadDialogWithThumbnailVMBase : ProContentDownloadDialogVMBase, IProContentDownloadDialogWithThumbnailVM, IProContentDownloadDialogVM
{
	private sealed class AsyncCachedItem<T> : IAsyncValue<T>
	{
		private readonly Func<Task<T>> _doLoadAsync;

		public AsyncCachedItem(Func<Task<T>> doLoadAsync)
		{
			_doLoadAsync = doLoadAsync;
		}

		public Task<T> LoadAsync()
		{
			return _doLoadAsync();
		}
	}

	private readonly IProContentDownloadableAsset _downloadableAsset;

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public IAsyncValue<BitmapSource?> Thumbnail { get; }

	public IAsyncValue<IReadOnlyList<IAnimationFrame>> Preview { get; }

	protected ProContentDownloadDialogWithThumbnailVMBase(IProPresenterResourceService resources, IApp app, IUriCacheService<NullableBitmapSource> thumbnailCacheService, IUriCacheService<IReadOnlyList<IAnimationFrame>> previewCacheService, IProContentDownloadableAsset downloadableAsset)
		: base(resources, app, (IReadOnlyCollection<IProContentFormat>?)(object)downloadableAsset.Formats)
	{
		ProContentDownloadDialogWithThumbnailVMBase proContentDownloadDialogWithThumbnailVMBase = this;
		_downloadableAsset = downloadableAsset;
		Preview = new AsyncCachedItem<IReadOnlyList<IAnimationFrame>>(() => LoadFromCacheAsync(proContentDownloadDialogWithThumbnailVMBase._downloadableAsset.PreviewUrl, previewCacheService, Array.Empty<IAnimationFrame>()));
		Thumbnail = new AsyncCachedItem<BitmapSource>(async () => await LoadFromCacheAsync(proContentDownloadDialogWithThumbnailVMBase._downloadableAsset.ThumbnailUrl, thumbnailCacheService, NullableBitmapSource.Default));
		base.NewPlaylistName = _downloadableAsset.DisplayName;
	}

	private static async Task<T> LoadFromCacheAsync<T>(Uri? url, IUriCacheService<T> cacheService, T defaultValue)
	{
		if ((object)url == null || !url.IsAbsoluteUri)
		{
			return defaultValue;
		}
		return await cacheService.GetAsync(url);
	}
}
