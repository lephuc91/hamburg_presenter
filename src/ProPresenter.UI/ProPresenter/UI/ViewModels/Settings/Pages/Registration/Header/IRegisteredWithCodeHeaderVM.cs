using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Registration.Header;

public interface IRegisteredWithCodeHeaderVM : IHeaderVM, INotifyPropertyChanged, IDisposable
{
	IRelayCommand LearnMoreCommand { get; }

	IRelayCommand MigrateCommand { get; }
}
