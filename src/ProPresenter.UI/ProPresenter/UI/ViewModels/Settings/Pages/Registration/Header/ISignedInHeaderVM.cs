using System;
using System.ComponentModel;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

public interface ISignedInHeaderVM : IHeaderVM, INotifyPropertyChanged, IDisposable
{
	string OrganizationName { get; }
}
