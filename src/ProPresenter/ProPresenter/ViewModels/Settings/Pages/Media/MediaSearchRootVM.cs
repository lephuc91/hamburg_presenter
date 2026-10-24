using System.ComponentModel;
using Pro.Common.Components;
using Pro.DO.Storage;
using Pro.Localization.Services;
using ProPresenter.UI.ViewModels.Settings.Pages.Media;

namespace ProPresenter.ViewModels.Settings.Pages.Media;

public class MediaSearchRootVM : LinkedNotifyPropertyChangedBase, IMediaSearchRootVM, INotifyPropertyChanged
{
	private readonly ISearchRoot _searchRoot;

	public bool IsActive
	{
		get
		{
			return _searchRoot.IsActive;
		}
		set
		{
			_searchRoot.IsActive = value;
		}
	}

	public string Name { get; }

	public string Path => RelativePath.GetSearchRootPath(_searchRoot);

	public MediaSearchRootVM(ISearchRoot searchRoot, ILocalization localization)
	{
		_searchRoot = searchRoot;
		Name = localization.Get(_searchRoot.Type);
		LinkProperties("IsActive", "IsActive");
		_searchRoot.PropertyChanged += base.RaiseLinkedValues;
	}
}
