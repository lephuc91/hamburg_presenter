using System;
using System.ComponentModel;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Collection;

namespace ProPresenter.UI.ViewModels.ProContent.Group;

public interface IProContentGroupVM : INavigationItem, INotifyPropertyChanged, IDisposable
{
	INotifyEnumerableChanged<IProContentCollectionVM> Collection { get; }

	double ThumbnailAspectRatio { get; }

	int Index { get; }
}
