using System.Collections.Generic;
using ProPresenter.DO;
using ProPresenter.DO.ProContent.Model.Collection;
using ProPresenter.DO.ProContent.Model.Format;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.ViewModels.ProContent.Dialog.Download;

public class ProContentDownloadCollectionDialogVM : ProContentDownloadDialogVMBase, IProContentDownloadCollectionDialogVM, IProContentDownloadDialogVM
{
	public string CollectionTitle { get; }

	public ProContentDownloadCollectionDialogVM(IProPresenterResourceService resources, IApp app, IProContentDownloadableCollection collection)
		: base(resources, app, (IReadOnlyCollection<IProContentFormat>?)(object)collection.Formats)
	{
		base.NewPlaylistName = collection.DisplayName;
		CollectionTitle = collection.DisplayName;
	}
}
