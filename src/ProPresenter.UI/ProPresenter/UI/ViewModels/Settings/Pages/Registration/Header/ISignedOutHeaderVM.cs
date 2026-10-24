using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

public interface ISignedOutHeaderVM : IHeaderVM, INotifyPropertyChanged, IDisposable
{
	IRelayCommand SignInCommand { get; }

	IRelayCommand SignUpCommand { get; }
}
