using System;
using System.ComponentModel;
using Pro.UI.Components;

namespace ProPresenter.UI.ViewModels.Preview;

public interface IOutputScreenVM : INotifyPropertyChanged, IEquatable<IOutputScreenVM>
{
	Guid Id { get; }

	string Name { get; }

	BindableRoutedCommand? Command { get; }
}
