using System;
using System.ComponentModel;
using ProPresenter.DO.ProContent.Model.Group;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.ViewModels.ProContent.Group;

public interface IProContentGroupVMInternal : IProContentGroupVM, INavigationItem, INotifyPropertyChanged, IDisposable
{
	IProContentGroup Group { get; }
}
