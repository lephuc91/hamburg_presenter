using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.Common.SourceGenerator.Attributes;
using Pro.UI.Commands;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.UI.ViewModels.ProContent.Asset;
using ProPresenter.UI.ViewModels.ProContent.Collection;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Collection;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class ProContentCollectionVM : ObservableObject, IProContentCollectionVM, IDisposable
{
	private readonly IProContentCollection _proContentCollection;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public INotifyEnumerableChanged<IProContentAssetVM> Assets { get; }

	public LayoutType LayoutType => Convert(_proContentCollection.LayoutType);

	public string DisplayName => _proContentCollection.DisplayName;

	public string Description => _proContentCollection.Description;

	public IRelayCommand DownloadCommand { get; }

	public double ThumbnailAspectRatio => 1.7777777777777777;

	public ICollection<IProContentCollectionMoreMenuItemVM> MoreMenu { get; }

	public bool ShowMoreMenu => MoreMenu.Any((IProContentCollectionMoreMenuItemVM menuItem) => menuItem.Command.CanExecute(null));

	public ProContentCollectionVM(IProContentCollection collection, IProContentGroupVM group, IProContentProvider provider, IProContentDownloader downloader, IProContentVMsFactory factory)
	{
		_proContentCollection = collection;
		Assets = new PairedCollection<IProContentAsset, IProContentAssetVM>(collection, (IProContentAsset a) => factory.CreateAsset(a, group));
		int num = 1;
		List<IProContentCollectionMoreMenuItemVM> list = new List<IProContentCollectionMoreMenuItemVM>(num);
		CollectionsMarshal.SetCount(list, num);
		Span<IProContentCollectionMoreMenuItemVM> span = CollectionsMarshal.AsSpan(list);
		int index = 0;
		span[index] = new ProContentCollectionMoreMenuItemVM(new ParameterAugmentingCommand<Uri>(provider.BrowseMoreCommand, _proContentCollection.ExternalUrl), "MEDIA_BIN_OUTLINE_CONTEXT_MENU_BROWSE_MORE_title");
		MoreMenu = list;
		foreach (IProContentCollectionMoreMenuItemVM item in MoreMenu)
		{
			item.Command.CanExecuteChanged += OnShowMoreMenuValueUpdated;
		}
		DownloadCommand = new ParameterAugmentingCommand<IProContentCollection>(downloader.DownloadCollectionCommand, _proContentCollection);
	}

	private void OnShowMoreMenuValueUpdated(object? sender, EventArgs e)
	{
		OnPropertyChanged("ShowMoreMenu");
	}

	private static LayoutType Convert(ProContentCollectionLayoutType layoutType)
	{
		return layoutType switch
		{
			ProContentCollectionLayoutType.CarouselSmall => LayoutType.CarouselSmall, 
			ProContentCollectionLayoutType.Grid => LayoutType.Grid, 
			_ => LayoutType.CarouselLarge, 
		};
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		foreach (IProContentCollectionMoreMenuItemVM item in MoreMenu)
		{
			item.Command.CanExecuteChanged -= OnShowMoreMenuValueUpdated;
		}
	}
}
